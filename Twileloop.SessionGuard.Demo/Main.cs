using Twileloop.SessionGuard.State;

namespace Twileloop.SessionGuard.Demo
{
    public partial class Main : Form
    {
        private readonly Session<AppState> session = Session<AppState>.Instance;
        private readonly AtomicState<string> heading;
        private readonly AtomicState<string> subHeading;

        public Main()
        {
            InitializeComponent();

            heading = session.UseState(this, "heading", "Parent Default", Render);
            subHeading = session.UseState(this, "subheading", "Parent Default", Render);

            session.RegisterChildComponents(this, typeof(Header), heading, subHeading);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Render();
        }

        public void Render()
        {
            label1.Text = heading.Value;
            label2.Text = subHeading.Value;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            session.SetState(this, heading, richTextBox1.Text);
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            session.SetState(this, subHeading, richTextBox2.Text);
        }
    }
}