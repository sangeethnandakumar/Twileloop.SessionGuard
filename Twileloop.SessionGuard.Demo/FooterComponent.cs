using Twileloop.SessionGuard.Abstractions;
using Twileloop.SessionGuard.State;

namespace Twileloop.SessionGuard.Demo
{
    public partial class FooterComponent : StatefullUserControl
    {
        private readonly State<string> query;

        public FooterComponent()
        {
            InitializeComponent();

            ComponentName = "Footer";
            query = UseState("query", "");
        }

        public override void Render()
        {
            base.Render();
            var text = query.Get<string>();
            label1.Text = $"{text.Length} Characters | {text.Split(" ").Length} Words | {text.Split("\n").Length} Lines";
        }

        private void FooterComponent_Load(object sender, EventArgs e)
        {

        }
    }
}
