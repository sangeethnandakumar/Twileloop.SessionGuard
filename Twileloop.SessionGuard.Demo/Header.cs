using Twileloop.SessionGuard.Abstractions;
using Twileloop.SessionGuard.State;

namespace Twileloop.SessionGuard.Demo
{
    public partial class Header : StatefullUserControl
    {
        private readonly State<string> heading;
        private readonly State<string> subheading;

        public Header(string componentName) : base()
        {
            InitializeComponent();
            ComponentName = componentName;
            heading = UseState("heading", "Heading");
            subheading = UseState("subheading", "Sub-Heading");
        }

        public override void Render()
        {
            base.Render();

            Heading.Text = heading.Get<string>();
            Subheading.Text = subheading.Get<string>();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Header_Load(object sender, EventArgs e)
        {

        }
    }
}
