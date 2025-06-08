
using FileManager;

namespace TotalComanderTests
{
    [TestClass]
    public class FilesTests
    {
        public static string _directory;
        public static FileItem _fileManager;
        public static string GetFullPath(string name) => Path.Combine(_directory, name);
        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _directory = Path.Combine(Directory.GetCurrentDirectory(), "Temp");

            if (!Directory.Exists(_directory))
            {
                Directory.CreateDirectory(_directory);
            }

            _fileManager = new FileItem(_directory);
        }

        [DataTestMethod]
        [DataRow("test.txt")]
        public void FileManager_CreateFileWithValidName_FileCreated(string newFileName)
        {
            _fileManager.Create(newFileName);

            var result = File.Exists(GetFullPath(newFileName));
            Assert.IsTrue(result);
        }

        [DataTestMethod]
        [DataRow("")]
        public void FileManager_CreateFileWithInvalidName_FileNotCreated(string newFileName)
        {
            _fileManager.Create(newFileName);

            var result = File.Exists(GetFullPath(newFileName));
            Assert.IsFalse(result);
        }

        [DataTestMethod]
        [DataRow("test.txt")]
        public void FileManager_CreateFileWithDuplicatedName_FileNotCreated(string newFileName)
        {
            _fileManager.Create(newFileName);
            _fileManager.Create(newFileName);

            var result = Directory.GetFiles(_directory).Length == 1;

            Assert.IsTrue(result);
        }

        [DataTestMethod]
        [DataRow("test.txt")]
        public void FileManager_DeleteFileWithValidName_FileDeleted(string fileName)
        {
            using (File.Create(GetFullPath(fileName)))
            {
                _fileManager.Delete(GetFullPath(fileName));
            }

            Assert.IsFalse(File.Exists(GetFullPath(fileName)));
        }

        [DataTestMethod]
        [DataRow("test.txt")]
        public void FileManager_DeleteFileWithInvalidName_FileNotDeleted(string fileName)
        {
            using (File.Create(GetFullPath(fileName)))
            {
                _fileManager.Delete(GetFullPath(Path.GetFileNameWithoutExtension(fileName)));
            }
            
            Assert.IsTrue(File.Exists(GetFullPath(fileName)));
        }

        [DataTestMethod]
        [DataRow("test.txt", "test1.txt")]
        public void FileManager_RenameFileWithValidName_FileRenamed(string fileToRename, string newName)
        {
            using(File.Create(GetFullPath(fileToRename)))

            _fileManager.Rename(fileToRename, newName);

            Assert.IsFalse(File.Exists(GetFullPath(fileToRename)));
            Assert.IsTrue(File.Exists(GetFullPath(newName)));
        }

        [DataTestMethod]
        [DataRow("test.txt", "")]
        public void FileManager_RenameFileWithInvalidName_FileNotRenamed(string fileToRename, string newName)
        {
            using (File.Create(GetFullPath(fileToRename)))

            _fileManager.Rename(fileToRename, newName);

            Assert.IsTrue(File.Exists(GetFullPath(fileToRename)));
        }

        [DataTestMethod]
        [DataRow("", "test.txt")]
        public void FileManager_RenameInvalidFileWithValidName_FileNotRenamed(string fileToRename, string newName)
        {
            _fileManager.Rename(fileToRename, newName);

            Assert.IsFalse(File.Exists(GetFullPath(fileToRename)));
            Assert.IsFalse(File.Exists(GetFullPath(newName)));
        }

        [DataTestMethod]
        [DataRow("test.txt")]
        public void FileManager_MoveFileWithValidNameToExistingDirectory_FileMoved(string fileName)
        {
            using (File.Create(GetFullPath(fileName)))
            {

            }

            var dest = Directory.CreateDirectory(GetFullPath("subDir")).FullName;

            _fileManager.MoveFile(fileName, dest);

            Assert.IsFalse(File.Exists(GetFullPath(fileName)));
            Assert.IsTrue(File.Exists(Path.Combine(dest, fileName)));
        }

        [DataTestMethod]
        [DataRow("")]
        public void FileManager_MoveFileWithInvalidNameToValidDirectory_FileNotMoved(string fileName)
        {
            var dest = Directory.CreateDirectory(GetFullPath("subDir")).FullName;

            _fileManager.MoveFile(fileName, dest);

            Assert.IsFalse(File.Exists(GetFullPath(fileName)));
            Assert.IsFalse(File.Exists(Path.Combine(dest, fileName)));
        }

        [DataTestMethod]
        [DataRow("test.txt")]
        public void FileManager_MoveFileWithValidNameToInvalidDirectory_FileNotMoved(string fileName)
        {
            using (File.Create(GetFullPath(fileName)))
            {

            }

            var dest = Directory.CreateDirectory(GetFullPath("subDir")).FullName;
            Directory.Delete(dest);

            _fileManager.MoveFile(fileName, dest);

            Assert.IsTrue(File.Exists(GetFullPath(fileName)));
            Assert.IsFalse(File.Exists(Path.Combine(dest, fileName)));
        }

        [DataTestMethod]
        [DataRow("test.txt")]
        public void FileManager_ReadFileWithValidName_ContentDisplayedInConsole(string fileName)
        {
            var content = "Hello World!!!";
            File.WriteAllText(GetFullPath(fileName), content);
            using var writer = new StringWriter();
            Console.SetOut(writer);

            _fileManager.ReadFile(fileName);

            var output = writer.ToString().ReplaceLineEndings("");

            Assert.IsTrue(output == content);
        }

        [DataTestMethod]
        [DataRow("")]
        public void FileManager_ReadFileWithInvalidValidName_ContentNotDisplayedInConsole(string fileName)
        {
            var content = "Hello World!!!";
            using var writer = new StringWriter();
            Console.SetOut(writer);

            _fileManager.ReadFile(fileName);

            var output = writer.ToString().ReplaceLineEndings("");

            Assert.IsFalse(output == content);
        }

        [TestMethod]
        public void FileManagerDisplayAllUnits_UnitsExists_DisplayAllInConsole()
        {
            var fileName = "test.txt";
            File.WriteAllText(GetFullPath(fileName), null);

            var dirName = "TestDirectory";
            Directory.CreateDirectory(GetFullPath(dirName));

            using var writer = new StringWriter();
            Console.SetOut(writer);

            _fileManager.DisplayAllUnits();
            var output = writer.ToString();

            Assert.IsTrue(output.Contains(fileName));
            Assert.IsTrue(output.Contains(dirName));
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            if(Directory.Exists(_directory))
                Directory.Delete(_directory, true);

            if(!Directory.Exists(_directory))
                Directory.CreateDirectory(_directory);
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            if (Directory.Exists(_directory))
            {
                Directory.Delete(_directory,true);
            }
        }
    }
}