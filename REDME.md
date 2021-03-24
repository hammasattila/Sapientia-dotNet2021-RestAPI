# .Net REST Web API

## Creating the project

This project uses **.NET 5**. This can be downloaded [here](https://dotnet.microsoft.com/download).

```PowerShell
dotnet new webapi -n TyreStore      # Creates a n example Web API project.
dotnet dev-certs https --trust      # With this, the web browsers will accept the invalid development certificates.
dotnet new gitignore                # Creates a gitignor file.
```

## Runinng the project

In Visual Studio Code you just need to press **F5** and the development server wil be launhed, you can see about the API in the **Swagger UI** at: a [Secured addres (https)](https://localhost:5001/swagger/) and an [Insecured addres (http)](http://localhost:5000/swagger/).

## Client

A client written in React.js for this API is avalabile [here](https://github.com/hammasattila/Sapientia-2021-dotNet-RestAPIClient).
