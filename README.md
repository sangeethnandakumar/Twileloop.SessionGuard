<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/sangeethnandakumar/Twileloop.UOW">
    <img src="https://iili.io/HPIj6ss.png" alt="Logo" width="80" height="80">
  </a>

  <h1 align="center"> Twileloop.SessionGuard</h1>
  <h4 align="center"> Single Source Of Truth | Reactive UI | Persistance Files </h4>
</div>

## About
SesionGuard is a state management framework and works similarly to React.
Although SessionGuard is primarily targeting WinForms desktop apps, It can be used anywhere on any project.

SessionGuard has 2 primary features
- State Management
- Persistence Management

### STATE MANAGEMENT
You can create a model representing your application state and give it to SessionGuard.
SessionGuard's job is to manage it. It stores it as a singleton and allows you to read and write your state from anywhere in your app.
This brings the concept of `SINGLE SOURCE OF TRUTH` to your app. Ensuring at all times, your app refers to a single point for knowing its current state

This is followed by React.Js however it can automatically update your UI the moment you change your state.
However, unlike React, SessionGuard cannot auto-update your WinForms UI (Or whatever UI) because of .NET data binding limitations.

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

> Choose the installation that suites your need

| Driver | To Use | Install Package   
| :---: | :---:   | :---:
| <img src="https://iili.io/HPIj6ss.png" alt="Logo" height="30"> | SessionGuard | `dotnet add package Twileloop.SessionGuard` 

## 1. Register all databases (ASP.NET dependency injection)
```csharp
//LiteDB
builder.Services.AddUnitOfWork((uow) => {
    uow.Connections = new List<LiteDBConnection>
    {
        new LiteDBConnection("DatabaseA", "Filename=DatabaseA.db; Mode=Shared; Password=****;"),
        new LiteDBConnection("DatabaseB", "Filename=DatabaseB.db; Mode=Shared; Password=****;")
    };
});

//MongoDB
builder.Services.AddUnitOfWork((uow) => {
    uow.Connections = new List<MongoDBConnection>
    {
        new MongoDBConnection("DatabaseA", "mongodb+srv://Uername:****@Cluster"),
        new MongoDBConnection("DatabaseB", "mongodb+srv://Uername:****@Cluster")
    };
});
```

## 2. For Non Dependency Injection Setup (Like Console apps)
```csharp
//LiteDB
var context = LiteDB.Support.Extensions.BuildDbContext(option =>
    {
        option.Connections = new List<LiteDBConnection>
        {
            new LiteDBConnection("DatabaseA", "Filename=DatabaseA.db; Mode=Shared; Password=****;"),
            new LiteDBConnection("DatabaseB", "Filename=DatabaseB.db; Mode=Shared; Password=****;")
        };
    });
var uow = new LiteDB.Core.UnitOfWork(context);

//MongoDB
var context = MongoDB.Support.Extensions.BuildDbContext(option =>
    {
        option.Connections = new List<MongoDBConnection>
        {
            new MongoDBConnection("DatabaseA", "mongodb+srv://Username:****@Cluster"),
            new MongoDBConnection("DatabaseB", "mongodb+srv://Username:****@Cluster")
        };
    });
var uow = new MongoDB.Core.UnitOfWork(context);
```

## 3. Inject and Use as required
```csharp
    [ApiController]
    public class HomeController : ControllerBase 
    {
        private readonly UnitOfWork uow;

        public HomeController(UnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpGet]
        public IActionResult Get() 
        {            
            try
            {
                // Step 1: Point to a database
                uow.UseDatabase("<DB_NAME>");

                //Step 2: Get a repository for your model 'Dogs'
                var dogRepo = uow.GetRepository<Dogs>();

                //Step 3: Do some fetch
                allDogs = dogRepo.GetAll().ToList();

                //Step 4: Or any CRUD operations you like
                uow.BeginTransaction();
                dogRepo.Add(new Dog());
                uow.Commit();

                return Ok(allDogs);
            }
            catch(Exception)
            {
                uow.Rollback();
            }            
        }

    }
```
