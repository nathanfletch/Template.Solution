# API


#### An api 

#### _By Nathan Fletcher_

## Technologies Used

* C#
* ASP.NET Core
* Restful Routing Conventions
* Entity Framework Core 
* Swagger

## Setup
<details>
<summary>Setup & Installation Instructions</summary>

#### Installations (if necessary)
* Install C# and .NET using the [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-5.0.100-macos-x64-installer)
* Install [MySql Community Server](https://dev.mysql.com/downloads/file/?id=484914)

#### Setup
* Clone this repository to your local machine
* Navigate to the Template.Solution folder and create a file named "appsettings.json" 
* Add the following code to the file:
  ```
  {
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=template;uid=root;pwd=[YOUR-PASSWORD-HERE];"
    }
  }
  ```
* Navigate to the Template folder and run the following commands:
* `dotnet restore` to install the necessary dependencies
* `dotnet build` to compile the project.
* `dotnet tool install --global dotnet-ef`
* `dotnet ef migrations add Initial`
* `dotnet ef database update`
* `dotnet run` to start the server.


</details>



## API Documentation

## Swagger
Check out Swagger's auto-generated documentation at `http://localhost:5000/swagger`

## CORS
CORS is enabled only for these specific ports: `5000`, `5001`, `8080`, `8081`.
This is to allow a front end app running on 8080 to call this api.

## Endpoints

Base URL: `http://localhost:5000`

## HTTP Request Structure

```
GET /api/placeholders
GET /api/placeholders/load
POST /api/placeholders
GET /api/placeholders/{id}
PUT /api/placeholders/{id}
DELETE /api/placeholders/{id}
```

## Known Issues
* There are no known bugs at this time.
* Please contact me if you find any bugs or have suggestions. 

## Future Plans
* Add more query parameters and endpoints.

## License

_[MIT](https://opensource.org/licenses/MIT)_  

Copyright (c) 2021 Nathan Fletcher 

## Contact Information

_Nathan Fletcher @ github.com/nathanfletch_  