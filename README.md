# Odidont Setup
Welcome GDPR warriors! This is a .NET MAUI Blazor Hybrid app. This setup (hopefully) helps with the "it doesn't work on my computer" problems.

## Getting Stared
1. Clone the repo (of course)
2. Open the .sln
3. Get yourself the prerequisites.
4. Get yourself the prerequisites for your current OS.
5. Optional: Get yourself the prerequisites for other OSes if you are feeling fancy.

## Prerequisites
1. **.NET 10 SDK**: [Download here](https://dotnet.microsoft.com/en-us/download/dotnet/10.0).
2. **An IDE**: I used Rider ([Download here](https://www.jetbrains.com/help/rider/Installation\_guide.html)) so the rest of the setup might assume that.
3. **Maui Workload**: Open terminal -> `dotnet workload install maui`

## Android Project Profile Prerequisites
The fun thing about Maui is that we can make app boetifuul for Android and other OS's too. If you are into that, the following steps are needed too:
1. **JDK 21**: [Download here](https://www.oracle.com/java/technologies/downloads/#java21).
2. If you are on a non-Android device:
    1. **Android Studio**: [Download here](https://developer.android.com/studio). We only use it for the SDK and the emulation, don't worry.
    2. **Setup SDK Manager**:
        1. Open Android Studio -> "More Actions" -> "SDK Manager".
        2. Under "SDK Platforms", check "Android 16.0 (API Level 36.0)".
        3. *(Note: I accidentally did 36.1 and everything went boom, so make sure it is **36.0**)*.
        4. If you use Rider, you can click the gear icon in top right corner -> Android SDK Manager -> apply correct location. Now you don't even have to think about Android Studio, whoop whoop.
    3. **Emulator**:
        1. Open Android Studio -> "More Actions" -> "Virtual Device Manager".
        2. Create a device using API 36.0.
        3. Check if it starts.

## Windows Project Profile Prerequisites
A requirement for running the Windows version of the project is (I think) to have a Windows device...
Also, depending on the situation You might need to enable Developer Mode in Windows Settings (Settings -> System -> For developers) to run Unpackaged WinUI 3 apps.

## iOS / macOS Project Profile Prerequisites
1. **Have an Ugly Apple Machine**: Ew.
2. Uh yea, I don't have one so I hope this is not too difficult... Uh... Send me a DM if .net starts to mentally attack you... It does that sometimes.

## Rider Specific Random Tips
### Unable to Launch Device / No device icon left of run config icons
1. Click the settings / gear icon in the top right corner -> "Android SDK Manager".
2. Ensure the location of the SDK matched the path used by Android Studio (usually `Local/Android/Sdk`).

### Build'n'Run
In general, this is a dotnet application so we dont run, we Build'n'Run. 
IDK if the run configurations are also pushed to the repo but in case they are not, there is a handy trick to make sure you do not forget to build:
1. Click the "Run Configuration" dropdown -> "Edit Configurations".
2. Under "Before Launch", click the "+" and add "Build Project (Odidont)" to the list.
3. *Tip: Do this for all the run profiles you use (Windows + iOS + macOS + Android)*
If you are anything like me, you are likely to forget building and start to wonder why your recent changes have not changed anything... So, I just like to have Rider do it for me xD.
But I am sure other IDE's something similar to this too.

## Troubleshooting
I will add more here when I think of it.
1. **"Project not loaded"**: Make sure you ran `dotnet workload install maui`.
2. **"Failed to Launch Device" / Emulator not showing up**: Make sure you correctly coupled Android Studio's device manager. It may also be helpful to open the actual device manager and start the device manually first.
3. **Errors or changes that are not updating**: Sometimes you keep getting the same error, sometimes CSS doesnt update. Either way, "Clean" -> "Build" may be all you need.
4. **I added a cool new button but it is not showing up**: "Build" xD.
