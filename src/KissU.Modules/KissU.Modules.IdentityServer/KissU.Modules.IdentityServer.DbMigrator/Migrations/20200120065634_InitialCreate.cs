using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KissU.Modules.IdentityServer.DbMigrator.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                "ids");

            migrationBuilder.CreateTable(
                "ApiResources",
                schema: "ids",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Enabled = table.Column<bool>(),
                    Name = table.Column<string>(maxLength: 200),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_ApiResources", x => x.Id); });

            migrationBuilder.CreateTable(
                "Clients",
                schema: "ids",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200),
                    ClientName = table.Column<string>(maxLength: 200, nullable: true),
                    Enabled = table.Column<bool>(),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    ProtocolType = table.Column<string>(maxLength: 200),
                    UserCodeType = table.Column<string>(maxLength: 100, nullable: true),
                    RequireClientSecret = table.Column<bool>(),
                    RequirePkce = table.Column<bool>(),
                    AllowPlainTextPkce = table.Column<bool>(),
                    AllowOfflineAccess = table.Column<bool>(),
                    AllowAccessTokensViaBrowser = table.Column<bool>(),
                    FrontChannelLogoutUri = table.Column<string>(maxLength: 2000, nullable: true),
                    FrontChannelLogoutSessionRequired = table.Column<bool>(),
                    BackChannelLogoutUri = table.Column<string>(maxLength: 2000, nullable: true),
                    BackChannelLogoutSessionRequired = table.Column<bool>(),
                    EnableLocalLogin = table.Column<bool>(),
                    IdentityTokenLifetime = table.Column<int>(),
                    AccessTokenLifetime = table.Column<int>(),
                    AuthorizationCodeLifetime = table.Column<int>(),
                    AbsoluteRefreshTokenLifetime = table.Column<int>(),
                    SlidingRefreshTokenLifetime = table.Column<int>(),
                    RefreshTokenUsage = table.Column<int>(),
                    RefreshTokenExpiration = table.Column<int>(),
                    UpdateAccessTokenClaimsOnRefresh = table.Column<bool>(),
                    AccessTokenType = table.Column<int>(),
                    IncludeJwtId = table.Column<bool>(),
                    AlwaysSendClientClaims = table.Column<bool>(),
                    AlwaysIncludeUserClaimsInIdToken = table.Column<bool>(),
                    ClientClaimsPrefix = table.Column<string>(maxLength: 200, nullable: true),
                    PairWiseSubjectSalt = table.Column<string>(maxLength: 200, nullable: true),
                    RequireConsent = table.Column<bool>(),
                    AllowRememberConsent = table.Column<bool>(),
                    ConsentLifetime = table.Column<int>(nullable: true),
                    ClientUri = table.Column<string>(maxLength: 2000, nullable: true),
                    LogoUri = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Clients", x => x.Id); });

            migrationBuilder.CreateTable(
                "DeviceFlowCodes",
                schema: "ids",
                columns: table => new
                {
                    UserCode = table.Column<string>(maxLength: 200),
                    Id = table.Column<int>(),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    DeviceCode = table.Column<string>(maxLength: 200),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200),
                    CreationTime = table.Column<DateTime>(),
                    Expiration = table.Column<DateTime>(),
                    Data = table.Column<string>(maxLength: 50000)
                },
                constraints: table => { table.PrimaryKey("PK_DeviceFlowCodes", x => x.UserCode); });

            migrationBuilder.CreateTable(
                "IdentityResources",
                schema: "ids",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Required = table.Column<bool>(),
                    Emphasize = table.Column<bool>(),
                    ShowInDiscoveryDocument = table.Column<bool>(),
                    Enabled = table.Column<bool>(),
                    Name = table.Column<string>(maxLength: 200),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_IdentityResources", x => x.Id); });

            migrationBuilder.CreateTable(
                "PersistedGrants",
                schema: "ids",
                columns: table => new
                {
                    Key = table.Column<string>(maxLength: 200),
                    Id = table.Column<int>(),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Type = table.Column<string>(maxLength: 50),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200),
                    Data = table.Column<string>(maxLength: 50000),
                    CreationTime = table.Column<DateTime>(),
                    Expiration = table.Column<DateTime>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_PersistedGrants", x => x.Key); });

            migrationBuilder.CreateTable(
                "ApiClaims",
                schema: "ids",
                columns: table => new
                {
                    ApiResourceId = table.Column<int>(),
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiClaims", x => new {x.ApiResourceId, x.Id});
                    table.ForeignKey(
                        "FK_ApiClaims_ApiResources_ApiResourceId",
                        x => x.ApiResourceId,
                        principalSchema: "ids",
                        principalTable: "ApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ApiProperties",
                schema: "ids",
                columns: table => new
                {
                    ApiResourceId = table.Column<int>(),
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(maxLength: 250),
                    Value = table.Column<string>(maxLength: 2000)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiProperties", x => new {x.ApiResourceId, x.Id});
                    table.ForeignKey(
                        "FK_ApiProperties_ApiResources_ApiResourceId",
                        x => x.ApiResourceId,
                        principalSchema: "ids",
                        principalTable: "ApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ApiScopes",
                schema: "ids",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiResourceId = table.Column<int>(),
                    Name = table.Column<string>(maxLength: 200),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Required = table.Column<bool>(),
                    Emphasize = table.Column<bool>(),
                    ShowInDiscoveryDocument = table.Column<bool>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiScopes", x => x.Id);
                    table.ForeignKey(
                        "FK_ApiScopes_ApiResources_ApiResourceId",
                        x => x.ApiResourceId,
                        principalSchema: "ids",
                        principalTable: "ApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ApiSecrets",
                schema: "ids",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiResourceId = table.Column<int>(),
                    Type = table.Column<string>(maxLength: 250),
                    Value = table.Column<string>(maxLength: 4000),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Expiration = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiSecrets", x => x.Id);
                    table.ForeignKey(
                        "FK_ApiSecrets_ApiResources_ApiResourceId",
                        x => x.ApiResourceId,
                        principalSchema: "ids",
                        principalTable: "ApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClientClaims",
                schema: "ids",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(),
                    Type = table.Column<string>(maxLength: 250),
                    Value = table.Column<string>(maxLength: 250)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_ClientClaims_Clients_ClientId",
                        x => x.ClientId,
                        principalSchema: "ids",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClientCorsOrigins",
                schema: "ids",
                columns: table => new
                {
                    ClientId = table.Column<int>(),
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origin = table.Column<string>(maxLength: 150)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCorsOrigins", x => new {x.ClientId, x.Id});
                    table.ForeignKey(
                        "FK_ClientCorsOrigins_Clients_ClientId",
                        x => x.ClientId,
                        principalSchema: "ids",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClientGrantTypes",
                schema: "ids",
                columns: table => new
                {
                    ClientId = table.Column<int>(),
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrantType = table.Column<string>(maxLength: 250)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientGrantTypes", x => new {x.ClientId, x.Id});
                    table.ForeignKey(
                        "FK_ClientGrantTypes_Clients_ClientId",
                        x => x.ClientId,
                        principalSchema: "ids",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClientIdPRestrictions",
                schema: "ids",
                columns: table => new
                {
                    ClientId = table.Column<int>(),
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Provider = table.Column<string>(maxLength: 200)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientIdPRestrictions", x => new {x.ClientId, x.Id});
                    table.ForeignKey(
                        "FK_ClientIdPRestrictions_Clients_ClientId",
                        x => x.ClientId,
                        principalSchema: "ids",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClientPostLogoutRedirectUris",
                schema: "ids",
                columns: table => new
                {
                    ClientId = table.Column<int>(),
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostLogoutRedirectUri = table.Column<string>(maxLength: 2000)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPostLogoutRedirectUris", x => new {x.ClientId, x.Id});
                    table.ForeignKey(
                        "FK_ClientPostLogoutRedirectUris_Clients_ClientId",
                        x => x.ClientId,
                        principalSchema: "ids",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClientPropertys",
                schema: "ids",
                columns: table => new
                {
                    ClientId = table.Column<int>(),
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(maxLength: 250),
                    Value = table.Column<string>(maxLength: 2000)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPropertys", x => new {x.ClientId, x.Id});
                    table.ForeignKey(
                        "FK_ClientPropertys_Clients_ClientId",
                        x => x.ClientId,
                        principalSchema: "ids",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClientRedirectUris",
                schema: "ids",
                columns: table => new
                {
                    ClientId = table.Column<int>(),
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RedirectUri = table.Column<string>(maxLength: 2000)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientRedirectUris", x => new {x.ClientId, x.Id});
                    table.ForeignKey(
                        "FK_ClientRedirectUris_Clients_ClientId",
                        x => x.ClientId,
                        principalSchema: "ids",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClientScopes",
                schema: "ids",
                columns: table => new
                {
                    ClientId = table.Column<int>(),
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scope = table.Column<string>(maxLength: 200)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientScopes", x => new {x.ClientId, x.Id});
                    table.ForeignKey(
                        "FK_ClientScopes_Clients_ClientId",
                        x => x.ClientId,
                        principalSchema: "ids",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClientSecrets",
                schema: "ids",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(),
                    Type = table.Column<string>(maxLength: 250),
                    Value = table.Column<string>(maxLength: 4000),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    Expiration = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientSecrets", x => x.Id);
                    table.ForeignKey(
                        "FK_ClientSecrets_Clients_ClientId",
                        x => x.ClientId,
                        principalSchema: "ids",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityClaims",
                schema: "ids",
                columns: table => new
                {
                    IdentityResourceId = table.Column<int>(),
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 200)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityClaims", x => new {x.IdentityResourceId, x.Id});
                    table.ForeignKey(
                        "FK_IdentityClaims_IdentityResources_IdentityResourceId",
                        x => x.IdentityResourceId,
                        principalSchema: "ids",
                        principalTable: "IdentityResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityProperties",
                schema: "ids",
                columns: table => new
                {
                    IdentityResourceId = table.Column<int>(),
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(maxLength: 250),
                    Value = table.Column<string>(maxLength: 2000)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityProperties", x => new {x.IdentityResourceId, x.Id});
                    table.ForeignKey(
                        "FK_IdentityProperties_IdentityResources_IdentityResourceId",
                        x => x.IdentityResourceId,
                        principalSchema: "ids",
                        principalTable: "IdentityResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ApiScopeClaims",
                schema: "ids",
                columns: table => new
                {
                    ApiScopeId = table.Column<int>(),
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 200)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiScopeClaims", x => new {x.ApiScopeId, x.Id});
                    table.ForeignKey(
                        "FK_ApiScopeClaims_ApiScopes_ApiScopeId",
                        x => x.ApiScopeId,
                        principalSchema: "ids",
                        principalTable: "ApiScopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_ApiResources_Name",
                schema: "ids",
                table: "ApiResources",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_ApiScopes_ApiResourceId",
                schema: "ids",
                table: "ApiScopes",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                "IX_ApiScopes_Name",
                schema: "ids",
                table: "ApiScopes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_ApiSecrets_ApiResourceId",
                schema: "ids",
                table: "ApiSecrets",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                "IX_ClientClaims_ClientId",
                schema: "ids",
                table: "ClientClaims",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                "IX_Clients_ClientId",
                schema: "ids",
                table: "Clients",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_ClientSecrets_ClientId",
                schema: "ids",
                table: "ClientSecrets",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                "IX_DeviceFlowCodes_DeviceCode",
                schema: "ids",
                table: "DeviceFlowCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_DeviceFlowCodes_Expiration",
                schema: "ids",
                table: "DeviceFlowCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                "IX_IdentityResources_Name",
                schema: "ids",
                table: "IdentityResources",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_PersistedGrants_Expiration",
                schema: "ids",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                "IX_PersistedGrants_SubjectId_ClientId_Type",
                schema: "ids",
                table: "PersistedGrants",
                columns: new[] {"SubjectId", "ClientId", "Type"});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "ApiClaims",
                "ids");

            migrationBuilder.DropTable(
                "ApiProperties",
                "ids");

            migrationBuilder.DropTable(
                "ApiScopeClaims",
                "ids");

            migrationBuilder.DropTable(
                "ApiSecrets",
                "ids");

            migrationBuilder.DropTable(
                "ClientClaims",
                "ids");

            migrationBuilder.DropTable(
                "ClientCorsOrigins",
                "ids");

            migrationBuilder.DropTable(
                "ClientGrantTypes",
                "ids");

            migrationBuilder.DropTable(
                "ClientIdPRestrictions",
                "ids");

            migrationBuilder.DropTable(
                "ClientPostLogoutRedirectUris",
                "ids");

            migrationBuilder.DropTable(
                "ClientPropertys",
                "ids");

            migrationBuilder.DropTable(
                "ClientRedirectUris",
                "ids");

            migrationBuilder.DropTable(
                "ClientScopes",
                "ids");

            migrationBuilder.DropTable(
                "ClientSecrets",
                "ids");

            migrationBuilder.DropTable(
                "DeviceFlowCodes",
                "ids");

            migrationBuilder.DropTable(
                "IdentityClaims",
                "ids");

            migrationBuilder.DropTable(
                "IdentityProperties",
                "ids");

            migrationBuilder.DropTable(
                "PersistedGrants",
                "ids");

            migrationBuilder.DropTable(
                "ApiScopes",
                "ids");

            migrationBuilder.DropTable(
                "Clients",
                "ids");

            migrationBuilder.DropTable(
                "IdentityResources",
                "ids");

            migrationBuilder.DropTable(
                "ApiResources",
                "ids");
        }
    }
}