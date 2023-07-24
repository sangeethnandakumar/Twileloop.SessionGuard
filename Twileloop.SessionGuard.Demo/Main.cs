using Twileloop.SessionGuard.Abstractions;
using Twileloop.SessionGuard.State;

namespace Twileloop.SessionGuard.Demo
{
    public partial class Main : StatefullForm
    {
        private readonly State<string> heading;
        private readonly State<string> subHeading;

        public Main() : base()
        {
            InitializeComponent();

            //Step 1: Register main component
            ComponentName = "Main";

            //Step 2: Register atomic states
            heading = UseState("heading", "XML Processor");
            subHeading = UseState("subheading", "Procesess XML in seconds");

            //Step 3: Register child components
            UseChild("Header1", heading, subHeading);
            UseChild("Header2", heading, subHeading);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Render();
        }

        public override void Render()
        {
            base.Render();
            label1.Text = heading.Get<string>();
            label2.Text = subHeading.Get<string>();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            heading.Set(richTextBox1.Text);
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            subHeading.Set(richTextBox2.Text);
        }
    }
}