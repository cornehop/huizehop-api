# huizehop-api

## Running the API
To start the application, simply run the `dotnet run` command in the `\HuizeHop.Api` folder.

## Database
The API uses a SQLite database, code first with migrations.
If you haven't used the dotnet EF CLI tool before, install it by running this command in Powershell: `dotnet tool install --global dotnet-ef`.
After that you can create or update the database using the `dotnet ef database update` command.
For development purposes the database is stored in a `huizehop.db` file in your default local data folder.
When you run the application your database location will be shown in the console.

## Testing
The code contains unittests located in the `HuizeHop.Api.Tests` project. To run them use the `dotnet test` command.