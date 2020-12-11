cd ../
rmdir /S /Q Migrations
dotnet ef migrations add InitialCreate -c MigrationsDbContext -o Migrations
dotnet ef migrations script -c MigrationsDbContext -o Migrations/InitialCreate.sql
cmd
