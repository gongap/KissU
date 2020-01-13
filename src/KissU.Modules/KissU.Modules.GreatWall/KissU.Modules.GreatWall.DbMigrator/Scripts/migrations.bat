cd ../
rmdir /S /Q Migrations
dotnet ef migrations add InitialCreate -c DesignTimeDbContext -o Migrations
dotnet ef migrations script -c DesignTimeDbContext -o Migrations/InitialCreate.sql
cmd
