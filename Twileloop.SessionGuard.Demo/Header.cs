using Twileloop.SessionGuard.State;

namespace Twileloop.SessionGuard.Demo
{
    public partial class Header : UserControl
    {
        private readonly Session<AppState> session = Session<AppState>.Instance;
        private readonly AtomicState<string> heading;
        private readonly AtomicState<string> subHeading;

        public Header()
        {
            InitializeComponent();
            heading = session.UseState(this, "heading", "Child Default", Render);
            subHeading = session.UseState(this, "subheading", "Child Default", Render);
            Render();
        }

        public void Render()
        {
            Heading.Text = heading.Value;
            Subheading.Text = subHeading.Value;
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
