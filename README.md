# Prime Logger
This library is a conversion for Prime projects.

## Library Dependencies
The following are all external libraries this solution uses.
* [System.Data.Common]

## Nuget Packages using ASP.Net Core Libraries
The following links provide additional information on the techniques used to create a Nuget package using ASP.Net Core libraries.
* [Publish a package - Nuget](https://docs.nuget.org/ndocs/create-packages/publish-a-package)
* [Create .NET Standard Packages with Visual Studio 2017](https://docs.nuget.org/ndocs/guides/create-net-standard-packages-vs2017)
* [dotnet pack command line reference](https://docs.microsoft.com/en-us/dotnet/articles/core/tools/dotnet-pack)

### What was used
dotnet build -c release
dotnet pack --output  nupkgs -v n --include-symbols --include-source
nuget push nupkgs\Prime.Conversion.*.nupkg -source "\\ap05.bc.local\c$\Websites\BayTech Consulting\Nuget\Packages"

## Versioning
Do not forget to increment, in the Prime.Conversion.csproj file the version of the library manually not to crush the previous version in the Nuget repository.

# How to use this library
Follow the steps below to use this Nuget package in your ASP.Net Core web or console project:
* Download and install the Prime Logger package from [Baytech Consulting Nuget Package Repository](http://nuget.baytechconsulting.com/)
* Under _Logging_ in your appsettings.json file include the following settings:
> Prime : { ApiKey: [ex.: sdfw345swef34wtfw35trwtrf], ServerUrl: [ex.: http:\\exceptions.local], StorageType: [Server|Local|InMemory], StoragePath: [Physical local path ex.: .\\logs] }
> * **ApiKey** - The Exceptionless project key where your loggings will be logged.
> * **ServerUrl** - The Exceptionless server URL where your exceptionless project resides.
> * **Enabled** - True or false (on/off) boolean value that tells the library to log or not.
> * **StorageType** - The type of storage used. [Server, Local, InMemory]
> > * **Server** - Logs are logged on the server using the provided server url.
> > * **Local** - Logs are logged locally in an appointed location provided by the StoragePath
> > * **InMemory** - Logs are logged in memory and discarted when the application resets or closes. 
> * **StoragePath**: The local storage path where you want the logs to be logged when the UseLocalStorage property is set to true.
* In the Configure section of the **Startup.cs** file, add the following to the ILoggerFactory object.
> *loggerFactory.AddPrimeLogger(Configuration.GetSection("Logging"));*

Happy coding!