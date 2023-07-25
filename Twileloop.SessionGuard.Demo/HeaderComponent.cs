using Twileloop.SessionGuard.Abstractions;
using Twileloop.SessionGuard.State;

namespace Twileloop.SessionGuard.Demo
{
    public partial class HeaderComponent : StatefullUserControl
    {
        private readonly State<int> progress;
        public HeaderComponent()
        {
            InitializeComponent();

            ComponentName = "Header";
            progress = UseState(nameof(progress), 0);
        }

        private void HeaderComponent_Load(object sender, EventArgs e)
        {

        }

        public override void Render()
        {
            base.Render();
            progressBar1.Value = progress.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var val = progress.Value;
            progress.Value = val + 10;
            if (val > 50)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var val = progress.Value;
            progress.Value = val - 10;
        }
    }
}
