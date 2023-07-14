<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/sangeethnandakumar/Twileloop.SessionGuard">
    <img src="https://iili.io/HsA31eI.png" alt="Logo" width="80" height="80">
  </a>

  <h1 align="center"> Twileloop.SessionGuard</h1>
  <h4 align="center"> Reactive UI | State Persistance </h4>
</div>

## About
SesionGuard is a state management framework and works similarly to React.
Although SessionGuard is primarily targeting WinForms desktop apps, It can be used anywhere on any project.

SessionGuard has 2 primary features
- State Management
- Persistence Management

### DEMO

<img src="https://iili.io/HsAuvFS.gif" alt="Working of Twileloop.SessionGurd NuGet package">

### STATE MANAGEMENT
You can create a model representing your application state and give it to SessionGuard.
SessionGuard's job is to manage it. It stores it as a singleton and allows you to read and write your state from anywhere in your app.
This brings the concept of `SINGLE SOURCE OF TRUTH` to your app. Ensuring at all times, your app refers to a single point for knowing its current state

This reactive approach is the foundation for React.Js apps, however, React can automatically update your UI the moment you change your state using a VirtualDOM.

But unlike React, SessionGuard cannot auto-update your WinForms UI (Or whatever UI) because of .NET data binding limitations.

So instead, It gives you an application-wide callback to one or more events, you define. You can utilize this callback to update your UI to match your state.

Like React, SessionGuard has `GetState()` and `SetState()` hooks. Every time you call `SetState(x => ...)` from anywhere in your app, SessionGuard updates the state and gives you a trigger callback to your events.
You can immediately update the UI to match the changed state ensuring UI and state are in sync.

### PERSISTENCE MANAGEMENT
Let's say you have your state in your custom model `MyState`. SessionGuard allows you to write your state into a file (with an extension you prefer) into the disk.

You can simply pass your model and a file path. SessionGuard takes care of serializing your model into XML. Then it compresses using Deflate algorithm and saves to disk.
This allows you to store your sessions or state in the most optimal way.

BCL XML serializers have limitations when using ICollections. But SessionGuard avoids these issues by utilizing `YAXLib1` to perform XML handling and error suppressions.

## License
> Twileloop.SessionGuard - is licensed under the MIT License. See the LICENSE file for more details.

#### This library is absolutely free. If it gives you a smile, A small coffee would be a great way to support my work. Thank you for considering it!
[!["Buy Me A Coffee"](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/sangeethnanda)

## Install Package
```powershell
dotnet add package Twileloop.SessionGuard
```

### STATE MANAGEMENT

## 1. Complete Setup
Here `MyData` is your custom model representing your application's state

```csharp
public partial class Main : Form
{
    //Step 1: Define Your State
    private readonly State<MyData> state = State<MyData>.Instance;

    public Main(IPersistance<MyData> persistance)
    {
        //Step 4: Register one or more events on the constructor
        State<MyData>.Instance.OnStateUpdated += OnStateUpdated;

        //Step 2: Load a default state, when the first constructor invokes. This is the first entry of data into your state.
        //You need to do this only one time in your app, preferably in an entry class
        state.LoadState(new MyData 
        {
            Id = 1,
            FullName = "Sangeeth Nandakumar",
            Counter = 0
        });
    }

    //Step 3: Define a custom event that will trigger every time the state changes
    //Here make sure UI corresponds to your custom state
    //You'll get an updated state instance in event args 'e'
    private void OnStateUpdated(object sender, StateUpdateEventArgs<MyData> e)
    {
        //Update UI according to your state
        Counter.Text = e.State.Counter.ToString();
        Text.Text = $"Sangeeth scored {e.State.Counter} points";
        Tab.SelectedIndex = e.State.Counter;
        Prev.Enabled = e.State.Counter == 0 ? false : true;
        Next.Enabled = e.State.Counter == 4 ? false : true;
    }

    //Step 5: Now simply update the state as you go
    //This triggers all registered events you made on your constructor after updating the state
    private void Plus_Click(object sender, EventArgs e)
    {
        //Do some tasks...
        state.SetState(x => x.Counter++);
    }

}
```

## Updating UI from a Different Thread / Background Thread

Call `state.SetState(x=>...)` like this, When you update UI from a cross thread like `Task.Run(()=>...)` or `Parallel.Invoke(()=>...)` or `Thread.Start()` etc...
```csharp
    //Specific use-case when updating from a background thread
    private void Minus_Click(object sender, EventArgs e)
    {
        //Let's say you're doing a background task in a different thread
        Task.Run(()=>
        {
            //Do background tasks here...
        
            //At some point you need to update UI by calling SetState(x=>...). But this is not our UI/Main thread
            //Since UI components can only be updated from UI/Main thread, Call SetState(x=>...) only from the main thread by making use of a delegate from any WinForm UI component instance

            //So, Call like this
            MainForm.Invoke(()=>
            {
                state.SetState(x => x.Counter--);
            });
        }
    }
```

### PERSISTENCE MANAGEMENT

## 2. Complete Setup
Let's say `MyData` is the custom model you want to write and read from the file.
`MyData` could be your state like above or it can be anything you want to store in a file.

```csharp
public partial class Main : Form
{
    //Step 1: Inject IPersistance with your model 'MyData'
    private readonly IPersistance<MyData> persistance;
    public Main(IPersistance<MyData> persistance)
    {
        this.persistance = persistance;
    }

    //Step 2: Write your model by simply calling `WriteFileAsync`
    //This will serialize your MyData into XML then compresses it using 'Deflate' algorithm before storing it as a binary file
    //Here we used '*.dat' as an extension, You can use any you prefer
    private void Write_Click(object sender, EventArgs e)
    {
        persistance.WriteFileAsync(new MyData {}, "mydata.dat").Wait();
    }

    //Step 3: Read back your model from your '*.dat' file
    //This will decompress the file using 'Deflate' algorithm and then deserializes XML back to your 'MyData' class
    private void Read_Click(object sender, EventArgs e)
    {
        var myData = persistance.ReadFileAsync("mydata.dat").Result;
    }
}
```
