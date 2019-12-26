cd ../

cd src/KissU.Modules/KissU.Modules.IdentityServer/KissU.Modules.IdentityServer.DbMigrator
rmdir /S /Q Migrations

dotnet ef migrations add InitialCreate -c DesignTimeDbContext -o Migrations
dotnet ef migrations script -c DesignTimeDbContext -o Migrations/InitialCreate.sql

cd ../../../../

cd src/KissU.Modules/KissU.Modules.GreatWall/KissU.Modules.GreatWall.DbMigrator
rmdir /S /Q Migrations

dotnet ef migrations add InitialCreate -c DesignTimeDbContext -o Migrations
dotnet ef migrations script -c DesignTimeDbContext -o Migrations/InitialCreate.sql

cd ../../../../

cd src/KissU.Modules/KissU.Modules.Theme/KissU.Modules.Theme.DbMigrator
rmdir /S /Q Migrations

dotnet ef migrations add InitialCreate -c DesignTimeDbContext -o Migrations
dotnet ef migrations script -c DesignTimeDbContext -o Migrations/InitialCreate.sql

cd ../../../../

cmd
