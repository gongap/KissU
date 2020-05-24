cd ../
rmdir /S /Q Migrations
dotnet ef migrations add InitialCreate -c IdentityMigrationsDbContext -o Migrations
dotnet ef migrations script -c IdentityMigrationsDbContext -o Migrations/InitialCreate.sql
cmd
