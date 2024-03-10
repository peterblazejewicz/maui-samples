# maui-samples
Samples built with .NET Multi-platform App UI (.NET MAUI).

## Configuration Sample (MVVM)

"How-To" for configuration support for:
- `appsettings.json` pattern support
- environment variables
- commandline arguments
- `IConfiguration` (through DI)
- `IOptions` pattern (through DI)

Options pattern binds values from:
- settings
- commandline
- environment

Command line and environment support are behind compiler flags, only for `MACCATALYST` and `WINDOWS`, as that's make sense.

## MessagingCenter (MVVM)

Rewritten `MessagingCenter` to use `WeakReferenceMessanger` introduced in .NET7.
Example shows how to subscribe/unsubscribe using `ObservableRecipient` features.

Original project:

https://github.com/jsuarezruiz/dotnet-maui-samples/tree/main/UsingMessagingCenter

## TodoRealm (MVVM)

Using Realm DB (MongoDB for devices) in Maui:
- MVVM pattern
- Realm non-synced (local) database
- CRUD operations

What is `MongoDB Atlas Device SDK`?  
https://www.mongodb.com/blog/post/realm-now-part-atlas-platform  
https://www.mongodb.com/docs/realm/sdk/dotnet/quick-start/

Original sample using Sqlite: https://github.com/dotnet/maui-samples/tree/main/8.0/Data/TodoSQLite


## Author

@peterblazejewicz
