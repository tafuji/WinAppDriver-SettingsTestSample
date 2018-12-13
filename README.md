# Sample UI automation testing of Windows 10 settings app with Windows Applicatin Driver

Sample test codes of Windows 10 settings app with Windows Application Driver

## Introduction

To test UWP app, you can find the Applicatin Id of UWP app by running the application, going to taks manager and clicking on properties of the application.
For example, the Application Id of Calculator app is as shown below.

![Calculator](https://github.com/tafuji/WinAppDriver-SettingsTestSample/raw/master/Screenshots/01-Calculator.png)

However, you cannot get the Application Id of settings app of Windows 10 from properties.

![Settingsapp](https://github.com/tafuji/WinAppDriver-SettingsTestSample/raw/master/Screenshots/02-SettingsApp.png)

I found the Appliction Id form the error messaege, which are described on the [question](https://answers.microsoft.com/en-us/windows/forum/windows_10-start/pc-settings-wont-open-since-new-windows-10-upgrade/f9d764da-1fd3-4c84-a1ff-6fec9b378a89) in Microsoft Comunity.

```text
Windows.ImmersiveControlPanel_cw5n1h2txyewy!microsoft.windows.immersivecontrolpanel
```

## How to launch settings app with Windows Application Driver

Here is a sample code to launch settings app with Windows Applicatin Driver. As normal UWP apps, the Appliaction Id should be passed to the argument of  ```SetCapability``` method of ```DesiredCapabilities``` class.

```csharp
DesiredCapabilities appCapabilities = new DesiredCapabilities();

// set application id of settings app.
appCapabilities.SetCapability("app", @"Windows.ImmersiveControlPanel_cw5n1h2txyewy!microsoft.windows.immersivecontrolpanel");
session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
Assert.IsNotNull(session);

// Set implicit timeout to 1.5 seconds to make element search to retry every 500 ms for at most three times
session.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1.5));

```

## Sample test codes

The ```ChangeBackGroundTest``` test method of ```ScenarioPersonarization``` class is a example which change the background of PC from photo to solid color. Here is the gif animation, where changing background ui test is executed.

![demo](https://github.com/tafuji/WinAppDriver-SettingsTestSample/raw/master/Screenshots/03-demo.gif)
