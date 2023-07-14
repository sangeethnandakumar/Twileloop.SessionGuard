using Twileloop.SessionGuard.Models;
using Twileloop.SessionGuard.Persistance;
using Twileloop.SessionGuard.State;

namespace Twileloop.SessionGuard.Demo
{
    public partial class Main : Form
    {
        private readonly IPersistance<MyData> persistance;

        //Step 1: Initialize session
        private readonly Session<MyData> session = Session<MyData>.Instance;

        public Main(IPersistance<MyData> persistance)
        {
            InitializeComponent();

            //Step 2: Register a UI renderer event when state changes
            session.OnStateUpdated += OnStateUpdated;
            //Step 3: Load initial state
            session.LoadState(new MyData
            {
                Id = 1,
                FullName = "Sangeeth",
                Counter = 0
            });

            this.persistance = persistance;
        }

        //Step 4: Write the UI render event
        private void OnStateUpdated(object sender, StateUpdateEventArgs<MyData> e)
        {
            //Bind UI components for autoupdate
            e.Session.Bind(nameof(e.State.Counter), () => Counter.Text = e.State.Counter.ToString());
            e.Session.Bind(nameof(e.State.Counter), () => Text.Text = $"Sangeeth scored {e.State.Counter} points");
            e.Session.Bind(nameof(e.State.Counter), () => Tab.SelectedIndex = e.State.Counter);
            e.Session.Bind(nameof(e.State.Counter), () => Prev.Enabled = e.State.Counter == 0 ? false : true);
            e.Session.Bind(nameof(e.State.Counter), () => Next.Enabled = e.State.Counter == 0 ? false : true);
        }

        private void Write_Click(object sender, EventArgs e)
        {
            persistance.WriteFileAsync(session.State, "sample.amr").Wait();
        }

        private void Read_Click(object sender, EventArgs e)
        {
            //Read data from file
            var amr = persistance.ReadFileAsync("sample.amr").Result;

            //Load into state
            session.LoadState(amr.Data);
            var data = session.State;

            Text.Text = $"Sangeeth scored {data.Counter} points";
        }

        private void Plus_Click(object sender, EventArgs e)
        {
            session.SetState(x => x.Counter++);
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            session.SetState(x => x.Counter--);
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (session.State.Counter < 4)
            {
                session.SetState(x => x.Counter++);
            }
        }

        private void Prev_Click(object sender, EventArgs e)
        {
            if (session.State.Counter > 0)
            {
                session.SetState(x => x.Counter--);
            }
        }
    }
}