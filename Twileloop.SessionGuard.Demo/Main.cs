using Twileloop.SessionGuard.Models;
using Twileloop.SessionGuard.Persistance;
using Twileloop.SessionGuard.State;

namespace Twileloop.SessionGuard.Demo
{
    public partial class Main : Form
    {
        private readonly IPersistance<MyData> persistance;

        private readonly State<MyData> state = State<MyData>.Instance;

        public Main(IPersistance<MyData> persistance)
        {
            InitializeComponent();
            state.LoadState(new MyData 
            {
                Id = 1,
                FullName = "Sangeeth",
                Counter = 0
            });
            this.persistance = persistance;
            State<MyData>.Instance.OnStateUpdated += OnStateUpdated;
        }

        private void Write_Click(object sender, EventArgs e)
        {
            persistance.WriteFileAsync(state.GetState(), "sample.amr").Wait();
        }

        private void Read_Click(object sender, EventArgs e)
        {
            //Read data from file
            var amr = persistance.ReadFileAsync("sample.amr").Result;

            //Load into state
            state.LoadState(amr.Data);
            var data = state.GetState();

            Text.Text = $"Sangeeth scored {data.Counter} points";
        }

        //Event Handler
        private void OnStateUpdated(object sender, StateUpdateEventArgs<MyData> e)
        {
            Counter.Text = e.State.Counter.ToString();
            Text.Text = $"Sangeeth scored {e.State.Counter} points";
            Tab.SelectedIndex = e.State.Counter;
            Prev.Enabled = e.State.Counter == 0 ? false : true;
            Next.Enabled = e.State.Counter == 4 ? false : true;
        }

        private void Plus_Click(object sender, EventArgs e)
        {
            state.SetState(x => x.Counter++);
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            state.SetState(x => x.Counter--);
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (state.GetState().Counter < 4)
            {
                state.SetState(x => x.Counter++);
            }
        }

        private void Prev_Click(object sender, EventArgs e)
        {
            if (state.GetState().Counter > 0)
            {
                state.SetState(x => x.Counter--);
            }
        }
    }
}