using Twileloop.SessionGuard.State;

namespace Twileloop.SessionGuard.Demo
{
    public partial class Header : UserControl
    {
        private readonly Session<AppState> session = Session<AppState>.Instance;
        private readonly AtomicState<string> heading;

        public Header()
        {
            InitializeComponent();
            heading = session.UseState(this, "heading", "Child Default", Render);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }

        public void Render()
        {
            Heading.Text = heading.Value;
            Subheading.Text = DateTime.Now.ToShortTimeString();
        }
    }
}
