## Hello, `wasmbrowser`

This project was created from the `dotnet new wasmbrowser` template. It is a simple example of running .NET code in the browser without Blazor.

## Environment

.NET 8

```sh
dotnet workload install wasi-experimental
```

## Building & Running

You know the drill.

```sh
dotnet build
```

```sh
dotnet run
```

## Publishing

```sh
dotnet publish ./Hello.WasmBrowserApp.csproj -r browser-wasm -c Release
```
Published files are in `bin/Release/net8.0/publish/wwwroot`

## References

While this does not use WASI, you can read more about developments at [Extending WebAssembly to the Cloud with .NET](https://devblogs.microsoft.com/dotnet/extending-web-assembly-to-the-cloud/).

Enjoy the bouncing lines.

![](screenshot.png)
