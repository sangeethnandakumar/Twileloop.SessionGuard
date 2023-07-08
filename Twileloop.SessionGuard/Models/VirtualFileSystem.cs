using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Twileloop.SessionGuard.Models
{
    public class VirtualFileSystem
    {
        private string zipFilePath;
        private List<VirtualFile> files;
        private List<VirtualDirectory> directories;
        private VirtualDirectory fileSystemTree;

        public VirtualFileSystem()
        {
            files = new List<VirtualFile>();
            directories = new List<VirtualDirectory>();
            fileSystemTree = new VirtualDirectory
            {
                Name = "/",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Files = new List<VirtualFile>(),
                Directories = new List<VirtualDirectory>(),
                ParentDirectory = null
            };
            directories.Add(fileSystemTree);
        }

        public void Initialize(string zipFilePath)
        {
            this.zipFilePath = zipFilePath;
            files.Clear();

            try
            {
                using (var archive = ZipFile.Open(zipFilePath, ZipArchiveMode.Create))
                {
                    // Empty zip file created or overwritten
                }
            }
            catch (IOException ex)
            {
                throw new Exception("An error occurred while initializing the virtual file system. Please make sure the zip file is not locked or in use.", ex);
            }
        }

        public void Mount(string zipFilePath)
        {
            this.zipFilePath = zipFilePath;
            files.Clear();
            directories.Clear();
            fileSystemTree = new VirtualDirectory
            {
                Name = "/",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Files = new List<VirtualFile>(),
                Directories = new List<VirtualDirectory>(),
                ParentDirectory = null
            };
            directories.Add(fileSystemTree);

            try
            {
                if (File.Exists(zipFilePath))
                {
                    using (var archive = ZipFile.OpenRead(zipFilePath))
                    {
                        foreach (var entry in archive.Entries)
                        {
                            if (!entry.FullName.EndsWith("/"))
                            {
                                using (var stream = entry.Open())
                                {
                                    var fileContent = new byte[entry.Length];
                                    stream.Read(fileContent, 0, fileContent.Length);

                                    var file = new VirtualFile
                                    {
                                        Name = entry.FullName,
                                        Created = entry.LastWriteTime.DateTime,
                                        Modified = entry.LastWriteTime.DateTime,
                                        Size = entry.Length,
                                        Content = fileContent,
                                        ParentDirectory = null
                                    };

                                    files.Add(file);
                                    AddFileToTree(file);
                                }
                            }
                            else
                            {
                                var directory = new VirtualDirectory
                                {
                                    Name = entry.FullName,
                                    Created = entry.LastWriteTime.DateTime,
                                    Modified = entry.LastWriteTime.DateTime,
                                    Files = new List<VirtualFile>(),
                                    Directories = new List<VirtualDirectory>(),
                                    ParentDirectory = null
                                };

                                directories.Add(directory);
                                AddDirectoryToTree(directory);
                            }
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                throw new Exception("An error occurred while mounting the virtual file system. Please make sure the zip file is not locked or in use.", ex);
            }
        }

        public void WriteFile(string fileName, byte[] content)
        {
            var file = new VirtualFile
            {
                Name = fileName,
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Size = content.Length,
                Content = content,
                ParentDirectory = null
            };

            files.Add(file);
            AddFileToTree(file);
            SaveToZip();
        }

        public byte[] Read(string fileName)
        {
            var file = files.Find(f => f.Name.Equals(fileName, StringComparison.OrdinalIgnoreCase));
            return file?.Content;
        }

        public void Rename(string fileName, string newFileName)
        {
            var file = files.Find(f => f.Name.Equals(fileName, StringComparison.OrdinalIgnoreCase));
            if (file != null)
            {
                file.Name = newFileName;
                file.Modified = DateTime.Now;
                SaveToZip();
            }
        }

        public void Delete(string fileName)
        {
            var file = files.Find(f => f.Name.Equals(fileName, StringComparison.OrdinalIgnoreCase));
            if (file != null)
            {
                files.Remove(file);
                RemoveFileFromTree(file);
                SaveToZip();
            }
        }

        public void Copy(string sourceFileName, string destinationFileName)
        {
            var sourceFile = files.Find(f => f.Name.Equals(sourceFileName, StringComparison.OrdinalIgnoreCase));
            if (sourceFile != null)
            {
                var destinationFile = new VirtualFile
                {
                    Name = destinationFileName,
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    Size = sourceFile.Size,
                    Content = (byte[])sourceFile.Content.Clone(),
                    ParentDirectory = null
                };

                files.Add(destinationFile);
                AddFileToTree(destinationFile);
                SaveToZip();
            }
        }

        public void Move(string sourceFileName, string destinationFileName)
        {
            var sourceFile = files.Find(f => f.Name.Equals(sourceFileName, StringComparison.OrdinalIgnoreCase));
            if (sourceFile != null)
            {
                var destinationFile = files.Find(f => f.Name.Equals(destinationFileName, StringComparison.OrdinalIgnoreCase));

                if (destinationFile != null)
                {
                    throw new Exception("A file with the same name already exists in the destination.");
                }

                files.Remove(sourceFile);
                sourceFile.Name = destinationFileName;
                sourceFile.Modified = DateTime.Now;
                files.Add(sourceFile);

                UpdateFileInTree(sourceFile);

                SaveToZip();
            }
        }

        public bool IsFileExists(string fileName)
        {
            return files.Exists(f => f.Name.Equals(fileName, StringComparison.OrdinalIgnoreCase));
        }

        public List<VirtualFile> GetAllFiles()
        {
            return files;
        }

        public VirtualFile GetMeta(string fileName)
        {
            return files.Find(f => f.Name.Equals(fileName, StringComparison.OrdinalIgnoreCase));
        }

            public void CreateDirectory(string directoryPath)
        {
            var dir = Path.GetDirectoryName(directoryPath);
            var directory = new VirtualDirectory
            {
                Name = directoryPath.TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar,
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Files = new List<VirtualFile>(),
                Directories = new List<VirtualDirectory>(),
                ParentDirectory = null
            };

            directories.Add(directory);
            AddDirectoryToTree(directory);
            SaveToZip();
        }

        public void RenameDirectory(string directoryPath, string newDirectoryName)
        {
            var directory = directories.Find(d => d.Name.Equals(directoryPath, StringComparison.OrdinalIgnoreCase));
            if (directory != null)
            {
                var newDirectoryPath = directoryPath.Substring(0, directoryPath.LastIndexOf('/') + 1) + newDirectoryName.TrimEnd('/') + "/";

                var existingDirectory = directories.Find(d => d.Name.Equals(newDirectoryPath, StringComparison.OrdinalIgnoreCase));
                if (existingDirectory != null)
                {
                    throw new Exception("A directory with the same name already exists in the destination.");
                }

                directories.Remove(directory);
                directory.Name = newDirectoryPath;
                directory.Modified = DateTime.Now;
                directories.Add(directory);

                UpdateDirectoryInTree(directory);

                SaveToZip();
            }
        }

        public void DeleteDirectory(string directoryPath)
        {
            var directory = directories.Find(d => d.Name.Equals(directoryPath, StringComparison.OrdinalIgnoreCase));
            if (directory != null)
            {
                directories.Remove(directory);
                RemoveDirectoryFromTree(directory);
                SaveToZip();
            }
        }

        public void MoveDirectory(string sourceDirectoryPath, string destinationDirectoryPath)
        {
            var sourceDirectory = directories.Find(d => d.Name.Equals(sourceDirectoryPath, StringComparison.OrdinalIgnoreCase));
            if (sourceDirectory != null)
            {
                var destinationDirectory = directories.Find(d => d.Name.Equals(destinationDirectoryPath, StringComparison.OrdinalIgnoreCase));

                if (destinationDirectory != null)
                {
                    throw new Exception("A directory with the same name already exists in the destination.");
                }

                directories.Remove(sourceDirectory);
                sourceDirectory.Name = destinationDirectoryPath.TrimEnd('/') + "/";
                sourceDirectory.Modified = DateTime.Now;
                directories.Add(sourceDirectory);

                UpdateDirectoryInTree(sourceDirectory);

                SaveToZip();
            }
        }

        public void CopyDirectory(string sourceDirectoryPath, string destinationDirectoryPath)
        {
            var sourceDirectory = directories.Find(d => d.Name.Equals(sourceDirectoryPath.TrimEnd('/') + "/", StringComparison.OrdinalIgnoreCase));
            if (sourceDirectory != null)
            {
                var destinationDirectory = directories.Find(d => d.Name.Equals(destinationDirectoryPath, StringComparison.OrdinalIgnoreCase));

                if (destinationDirectory != null)
                {
                    throw new Exception("A directory with the same name already exists in the destination.");
                }

                destinationDirectory = new VirtualDirectory
                {
                    Name = destinationDirectoryPath.TrimEnd('/') + "/",
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    Files = new List<VirtualFile>(),
                    Directories = new List<VirtualDirectory>(),
                    ParentDirectory = null
                };

                directories.Add(destinationDirectory);
                AddDirectoryToTree(destinationDirectory);

                CopyFilesToDirectory(sourceDirectory, destinationDirectory, destinationDirectoryPath);
                CopySubDirectories(sourceDirectory, destinationDirectory, destinationDirectoryPath);

                SaveToZip();
            }
        }

        private void CopyFilesToDirectory(VirtualDirectory sourceDirectory, VirtualDirectory destinationDirectory, string destinationDirectoryPath)
        {
            foreach (var file in sourceDirectory.Files)
            {
                var newFile = new VirtualFile
                {
                    Name = destinationDirectoryPath.TrimEnd('/') + "/" + Path.GetFileName(file.Name),
                    Created = file.Created,
                    Modified = file.Modified,
                    Size = file.Size,
                    Content = (byte[])file.Content.Clone(),
                    ParentDirectory = destinationDirectory
                };

                files.Add(newFile);
                destinationDirectory.Files.Add(newFile);
            }
        }

        private void CopySubDirectories(VirtualDirectory sourceDirectory, VirtualDirectory destinationDirectory, string destinationDirectoryPath)
        {
            foreach (var subDirectory in sourceDirectory.Directories)
            {
                var subDirectoryPath = destinationDirectoryPath.TrimEnd('/') + "/" + Path.GetFileName(subDirectory.Name.TrimEnd('/'));

                var newSubDirectory = new VirtualDirectory
                {
                    Name = subDirectoryPath + "/",
                    Created = subDirectory.Created,
                    Modified = subDirectory.Modified,
                    Files = new List<VirtualFile>(),
                    Directories = new List<VirtualDirectory>(),
                    ParentDirectory = destinationDirectory
                };

                directories.Add(newSubDirectory);
                destinationDirectory.Directories.Add(newSubDirectory);

                CopyFilesToDirectory(subDirectory, newSubDirectory, subDirectoryPath);
                CopySubDirectories(subDirectory, newSubDirectory, subDirectoryPath);
            }
        }

        public VirtualDirectory GetDirectoryMeta(string directoryPath)
        {
            return directories.Find(d => d.Name.Equals(directoryPath, StringComparison.OrdinalIgnoreCase));
        }

        public List<VirtualFile> GetFilesFromDirectory(string directoryPath)
        {
            var directory = directories.Find(d => d.Name.Equals(directoryPath, StringComparison.OrdinalIgnoreCase));
            return directory?.Files;
        }

        private void AddFileToTree(VirtualFile file)
        {
            var directoryPath = Path.GetDirectoryName(file.Name);
            var directory = FindOrCreateDirectory(directoryPath);
            directory.Files.Add(file);
            file.ParentDirectory = directory;
        }

        private void RemoveFileFromTree(VirtualFile file)
        {
            file.ParentDirectory.Files.Remove(file);
            file.ParentDirectory = null;
        }

        private void UpdateFileInTree(VirtualFile file)
        {
            var directoryPath = Path.GetDirectoryName(file.Name);
            var newParentDirectory = FindOrCreateDirectory(directoryPath);

            if (newParentDirectory != file.ParentDirectory)
            {
                file.ParentDirectory.Files.Remove(file);
                newParentDirectory.Files.Add(file);
                file.ParentDirectory = newParentDirectory;
            }
        }

        private VirtualDirectory FindOrCreateDirectory(string directoryPath)
        {
            var parts = directoryPath.Split('/', StringSplitOptions.RemoveEmptyEntries);
            var currentDirectory = fileSystemTree;

            foreach (var part in parts)
            {
                var childDirectory = currentDirectory.Directories.Find(d => d.Name.Equals(part + "/", StringComparison.OrdinalIgnoreCase));

                if (childDirectory == null)
                {
                    childDirectory = new VirtualDirectory
                    {
                        Name = currentDirectory.Name + part + "/",
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                        Files = new List<VirtualFile>(),
                        Directories = new List<VirtualDirectory>(),
                        ParentDirectory = currentDirectory
                    };

                    currentDirectory.Directories.Add(childDirectory);
                }

                currentDirectory = childDirectory;
            }

            return currentDirectory;
        }

        private void AddDirectoryToTree(VirtualDirectory directory)
        {
            var parentDirectoryPath = Path.GetDirectoryName(directory.Name);
            var parentDirectory = FindOrCreateDirectory(parentDirectoryPath);
            parentDirectory.Directories.Add(directory);
            directory.ParentDirectory = parentDirectory;
        }

        private void RemoveDirectoryFromTree(VirtualDirectory directory)
        {
            directory.ParentDirectory.Directories.Remove(directory);
            directory.ParentDirectory = null;
        }

        private void UpdateDirectoryInTree(VirtualDirectory directory)
        {
            var parentDirectoryPath = Path.GetDirectoryName(directory.Name);
            var newParentDirectory = FindOrCreateDirectory(parentDirectoryPath);

            if (newParentDirectory != directory.ParentDirectory)
            {
                directory.ParentDirectory.Directories.Remove(directory);
                newParentDirectory.Directories.Add(directory);
                directory.ParentDirectory = newParentDirectory;
            }
        }

        private void SaveToZip()
        {
            try
            {
                if (File.Exists(zipFilePath))
                {
                    File.Delete(zipFilePath);
                }

                using (var archive = ZipFile.Open(zipFilePath, ZipArchiveMode.Update))
                {
                    foreach (var file in files)
                    {
                        var entry = archive.CreateEntry(file.Name);
                        using (var stream = entry.Open())
                        {
                            stream.Write(file.Content, 0, file.Content.Length);
                        }
                        entry.LastWriteTime = new DateTimeOffset(file.Modified);
                    }

                    foreach (var directory in directories)
                    {
                        var entry = archive.CreateEntry(directory.Name);
                        entry.LastWriteTime = new DateTimeOffset(directory.Modified);
                    }
                }
            }
            catch (IOException ex)
            {
                throw new Exception("An error occurred while saving the virtual file system to the zip file. Please make sure the zip file is not locked or in use.", ex);
            }
        }

    }
}
