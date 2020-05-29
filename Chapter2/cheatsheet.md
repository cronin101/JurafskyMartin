# .NET Cheatsheet

## Creating a solution

```bash
dotnet new sln -o Chapter2
```

## Creating a csproj

```bash
dotnet new classlib -o Chapter2
dotnet sln add .\Chapter2\Chapter2.csproj
```

## Creating and running test class

```bash
dotnet new xunit -o Chapter2.Tests
dotnet add .\Chapter2.Tests\Chapter2.Tests.csproj reference .\Chapter2\Chapter2.csproj
dotnet test
```

## Creating a console-app class

```bash
dotnet new console
dotnet run
```
