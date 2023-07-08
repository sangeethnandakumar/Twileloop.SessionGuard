using Twileloop.SessionGuard.Models;
using Twileloop.SessionGuard.Persistance;

namespace Twileloop.SessionGuard.Demo
{
    public partial class Main : Form
    {
        private readonly IPersistance<AMRFile> persistance;

        public Main(IPersistance<AMRFile> persistance)
        {
            InitializeComponent();
            this.persistance = persistance;
        }

        private void Write_Click(object sender, EventArgs e)
        {
            var amr = new AMRFile
            {
                Id = 1,
                FullName = Text.Text,
                List = new List<string>
                {
                    "India",
                    "China",
                    "America"
                }
            };
            persistance.WriteFileAsync(amr, "sample.amr").Wait();
        }

        private void Read_Click(object sender, EventArgs e)
        {
            var amr = persistance.ReadFileAsync("sample.amr").Result;
            Text.Text = amr.FullName;
        }

        private void Vfs_Click(object sender, EventArgs e)
        {
            //Initialize a VFS
            var vfs = new VirtualFileSystem();
            vfs.Initialize("start.zip");

            //Mount VFS
            vfs.Mount("start.zip");

            //Create 2 directories
            vfs.CreateDirectory("Small");
            vfs.CreateDirectory("Big");

            //Create a subdirectory
            vfs.CreateDirectory(@"Small\Images");

            //Write a file from FS to VFS
            var imageBytes = File.ReadAllBytes(@"C:\Users\Sangeeth Nandakumar\OneDrive\Pictures\Main.png");
            vfs.WriteFile(@"Small\Images\Main.png", imageBytes);

            //Move this file to a different directory
            vfs.Move(@"Small\Images\Main.png", @"Big\Images\Main.png");

            //Copy the folder as Big2
            vfs.CopyDirectory("Big", "Big2");

            //Move the Big2 directory into old folder
            vfs.MoveDirectory("Big2", @"Small\Images");
        }
    }
}