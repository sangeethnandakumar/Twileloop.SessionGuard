﻿<!-- PROJECT LOGO -->
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

![example](https://github.com/sangeethnandakumar/Twileloop.SessionGuard/assets/24974154/553ef507-5565-4c3d-977d-a2191b918f30)

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

## Usage And Documentation
https://packages.twileloop.com/twileloop.sessionguard
