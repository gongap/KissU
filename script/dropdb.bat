cd ../

cd src/KissU.Modules/KissU.Modules.IdentityServer/KissU.Modules.IdentityServer.DbMigrator
dotnet ef database drop -c DesignTimeDbContext

cd ../../../../

cd src/KissU.Modules/KissU.Modules.GreatWall/KissU.Modules.GreatWall.DbMigrator
dotnet ef database drop -c DesignTimeDbContext

cd ../../../../

cmd