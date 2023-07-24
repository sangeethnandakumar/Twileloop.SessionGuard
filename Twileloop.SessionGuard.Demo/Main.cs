using System.Windows.Forms;
using Twileloop.SessionGuard.Abstractions;
using Twileloop.SessionGuard.State;

namespace Twileloop.SessionGuard.Demo
{
    public partial class Main : StatefullForm
    {
        private readonly State<string> query;

        public Main() : base()
        {
            InitializeComponent();

            //Step 1: Register main component
            ComponentName = "Main";
            //Step 2: Register atomic states
            query = UseState("query", "SELECT * FROM");
            //Step 3: Register child components
            UseChild("Footer", query);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Render();
        }

        public override void Render()
        {
            base.Render();
            QueryWindow.Text = query.Value;
            QueryWindow.SelectionStart = QueryWindow.Text.Length;
            QueryWindow.SelectionLength = 0;
            QueryWindow.ScrollToCaret();
        }

        private void QueryWindow_TextChanged(object sender, EventArgs e)
        {
            query.Value =  QueryWindow.Text;
        }
    }
}