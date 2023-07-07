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
                FullName = "Sangeeth Nandakumar",
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
        }
    }
}