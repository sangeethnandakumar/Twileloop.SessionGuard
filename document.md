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

This reactive approach is the foundation for React.Js apps.
`Twileloop.SessionGuard` also tries to implement a reactive UI framework approach using a singleton application wide `State`.

Like React, SessionGuard has a `SetState()` hook which will tell it you need to update something in your state.
Every time you call `SetState(x => ...)`, SessionGuard checks for differences from previous state and update only the required UI components.

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

## Quick Overview Of Working
Here's how `Twileloop.SessionGuard` works in a nutshell

1. You define a model state for your app
1. Your UI should map to this state model. For that you use `session.Bind()` like below
1. There you tell, This should happen in UI when this state model's property updated
1. That's it
1. Now whenever you need to update your state, Just call `session.SetState(x=>...)` like below
1. Now `Twileloop.SessionGuard` understood you want to update your state
1. It does a comparison with previous state and new state
1. If it finds 2 fields in your state is updated, It invokes the bindings associated with those state fields
1. Thus your UI updates in sync with your state
1. You update state, UI auto updates
1. Now play with state only. Your app is already responsive ..!

## Step 0
Define a model that represent's your app's state. Let's say your state model is `MyData`
```csharp
public class MyData
{
    public int? Id { get; set; }
    public string? FullName { get; set; }
    public List<string>? List { get; set; }
    public int Counter { get; set; } = 0;
}
```

### Step 1
A session controls your state.
Define a readonly private variable to declare a session

```csharp
//Step 1: Initialize session
private readonly Session<MyData> session = Session<MyData>.Instance;
```

### Step 2
Since your app is going to be fully driven by state, You need an initial state when the app launches for first time. It can be some default values in your state model.
Also, We need to tell `Twileloop.SessionGuard` which event to update, When it detects a state update. This event can be called `UI Renderer Event` since that is where we write logic to update our UI

REnough. Let's register our UI renderer event & load initial state

```csharp
public Main()
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
}
```

### Step 3
Write your UI renderer event and bind fields.
Bind will register to `Twileloop.SessionGuard`, When this property changes on state, Do this (Which will be your desired UI update)

If you need to do a UI update on any subset of properties changed, Simply pass it as array

```csharp
//Step 4: Write the UI render event
private void OnStateUpdated(object sender, StateUpdateEventArgs<MyData> e)
{
    //Bind UI components for autoupdate
    e.Session.Bind(nameof(e.State.Counter), () => Counter.Text = e.State.Counter.ToString());
    e.Session.Bind(nameof(e.State.Counter), () => Tab.SelectedIndex = e.State.Counter);
    e.Session.Bind(nameof(e.State.Counter), () => Prev.Enabled = e.State.Counter == 0 ? false : true);
    e.Session.Bind(nameof(e.State.Counter), () => Next.Enabled = e.State.Counter == 0 ? false : true);

    //When you want to update Text field whenever any of these state values change
    e.Session.Bind(new string[] {
            nameof(e.State.Id),
            nameof(e.State.Counter),
            nameof(e.State.FullName)
        },
        () => Text.Text = $"Sangeeth scored {e.State.Counter} points"
    );
}
```

### Step 4
UI Renderer Event done. Let's goto last step

Now how you can we update state of our app and notify `Twileloop.SessionGuard`.
It's simple.

Whenever you need to change your state. Simply call `session.SetState(x=>...)`

```csharp
//Just call session.SetState(x => ...)
private void Plus_Click(object sender, EventArgs e)
{
    session.SetState(x => x.Counter++);
}

//And tell what to update
private void Minus_Click(object sender, EventArgs e)
{
    session.SetState(x => x.Counter = x.Counter - 1);
}
```

## Limitations

> **Warning**
> These are known limitations

Although quick, A WinForms UI can't update as fast as state changes. Doing very fast state updates can flicker rendering or block the UI thread bringing a very bad user experience.
This is a limitation on WinForms. Using `Twileloop.SessionGuard` invokes the UI refresh codebase the moment you call `state.SetState(x=>...)` triggering a re-rendering.
It works fine in all normal cases. However, if you try to call `state.SetState(x=>...)` on fast actions like Textbox text changes as the user presses key by key. The WinForm may not be able to keep up with the rendering speed. Directly update the state in those scenarios using `state.GetState().MyState.Text = TextBox.Text;`. This allows the state to update but won't refresh the UI.

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
