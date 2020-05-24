cd ../
rmdir /S /Q Migrations
dotnet ef migrations add InitialCreate -c QuickStartMigrationsDbContext -o Migrations
dotnet ef migrations script -c QuickStartMigrationsDbContext -o Migrations/InitialCreate.sql
cmd
