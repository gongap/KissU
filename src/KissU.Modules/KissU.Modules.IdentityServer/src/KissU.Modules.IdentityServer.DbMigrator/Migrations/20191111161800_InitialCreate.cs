﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KissU.Modules.IdentityServer.DbMigrator.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ids");

            migrationBuilder.CreateTable(
                name: "ApiResources",
                schema: "ids",
                columns: table => new
                {
                    ApiResourceId = table.Column<Guid>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    ClaimTypes = table.Column<string>(maxLength: 2000, nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiResources", x => x.ApiResourceId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "ids",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    ClientCode = table.Column<string>(maxLength: 60, nullable: false),
                    ClientName = table.Column<string>(maxLength: 200, nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    ProtocolType = table.Column<string>(maxLength: 200, nullable: false),
                    RequireClientSecret = table.Column<bool>(nullable: false),
                    ClientAllowedGrantTypes = table.Column<string>(nullable: true),
                    RequirePkce = table.Column<bool>(nullable: false),
                    AllowPlainTextPkce = table.Column<bool>(nullable: false),
                    ClientRedirectUris = table.Column<string>(maxLength: 2000, nullable: true),
                    ClientAllowedScopes = table.Column<string>(maxLength: 2000, nullable: true),
                    AllowOfflineAccess = table.Column<bool>(nullable: false),
                    AllowAccessTokensViaBrowser = table.Column<bool>(nullable: false),
                    ClientProperties = table.Column<string>(nullable: true),
                    ClientPostLogoutRedirectUris = table.Column<string>(maxLength: 2000, nullable: true),
                    FrontChannelLogoutUri = table.Column<string>(maxLength: 2000, nullable: true),
                    FrontChannelLogoutSessionRequired = table.Column<bool>(nullable: false),
                    BackChannelLogoutUri = table.Column<string>(maxLength: 2000, nullable: true),
                    BackChannelLogoutSessionRequired = table.Column<bool>(nullable: false),
                    EnableLocalLogin = table.Column<bool>(nullable: false),
                    ClientIdentityProviderRestrictions = table.Column<string>(maxLength: 2000, nullable: true),
                    IdentityTokenLifetime = table.Column<int>(nullable: false),
                    AccessTokenLifetime = table.Column<int>(nullable: false),
                    AuthorizationCodeLifetime = table.Column<int>(nullable: false),
                    AbsoluteRefreshTokenLifetime = table.Column<int>(nullable: false),
                    SlidingRefreshTokenLifetime = table.Column<int>(nullable: false),
                    RefreshTokenUsage = table.Column<int>(nullable: false),
                    RefreshTokenExpiration = table.Column<int>(nullable: false),
                    UpdateAccessTokenClaimsOnRefresh = table.Column<bool>(nullable: false),
                    AccessTokenType = table.Column<int>(nullable: false),
                    IncludeJwtId = table.Column<bool>(nullable: false),
                    ClientAllowedCorsOrigins = table.Column<string>(maxLength: 2000, nullable: true),
                    AlwaysSendClientClaims = table.Column<bool>(nullable: false),
                    AlwaysIncludeUserClaimsInIdToken = table.Column<bool>(nullable: false),
                    ClientClaimsPrefix = table.Column<string>(maxLength: 200, nullable: true),
                    PairWiseSubjectSalt = table.Column<string>(maxLength: 200, nullable: true),
                    RequireConsent = table.Column<bool>(nullable: false),
                    AllowRememberConsent = table.Column<bool>(nullable: false),
                    ConsentLifetime = table.Column<int>(nullable: true),
                    ClientUri = table.Column<string>(maxLength: 2000, nullable: true),
                    LogoUri = table.Column<string>(maxLength: 2000, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "EventLogs",
                schema: "ids",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    EventId = table.Column<int>(nullable: false),
                    ProcessId = table.Column<int>(nullable: false),
                    ActivityId = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    EventType = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Provider = table.Column<string>(nullable: true),
                    ProviderUserId = table.Column<string>(nullable: true),
                    SubjectId = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    ClientId = table.Column<string>(nullable: true),
                    ClientName = table.Column<string>(nullable: true),
                    TokenType = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    RedirectUri = table.Column<string>(nullable: true),
                    Endpoint = table.Column<string>(nullable: true),
                    Scopes = table.Column<string>(nullable: true),
                    GrantType = table.Column<string>(nullable: true),
                    AuthenticationMethod = table.Column<string>(nullable: true),
                    ApiName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ConsentRemembered = table.Column<bool>(nullable: false),
                    Error = table.Column<string>(nullable: true),
                    ErrorDescription = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    LocalIpAddress = table.Column<string>(nullable: true),
                    RemoteIpAddress = table.Column<string>(nullable: true),
                    Host = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Browser = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityResources",
                schema: "ids",
                columns: table => new
                {
                    IdentityResourceId = table.Column<Guid>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Required = table.Column<bool>(nullable: false),
                    Emphasize = table.Column<bool>(nullable: false),
                    ShowInDiscoveryDocument = table.Column<bool>(nullable: false),
                    ClaimTypes = table.Column<string>(maxLength: 2000, nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityResources", x => x.IdentityResourceId);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                schema: "ids",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Key = table.Column<string>(maxLength: 200, nullable: true),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    Type = table.Column<string>(maxLength: 50, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: true),
                    Data = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApiResourceScopes",
                schema: "ids",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ApiResourceId = table.Column<Guid>(nullable: true),
                    ClaimTypes = table.Column<string>(maxLength: 2000, nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Required = table.Column<bool>(nullable: false),
                    Emphasize = table.Column<bool>(nullable: false),
                    ShowInDiscoveryDocument = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiResourceScopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiResourceScopes_ApiResources_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalSchema: "ids",
                        principalTable: "ApiResources",
                        principalColumn: "ApiResourceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApiResourceSecrets",
                schema: "ids",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ApiResourceId = table.Column<Guid>(nullable: true),
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 2000, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Expiration = table.Column<DateTime>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiResourceSecrets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiResourceSecrets_ApiResources_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalSchema: "ids",
                        principalTable: "ApiResources",
                        principalColumn: "ApiResourceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientClaims",
                schema: "ids",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 2000, nullable: false),
                    ClientId = table.Column<Guid>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientClaims_Clients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "ids",
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientSecrets",
                schema: "ids",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: true),
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 2000, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Expiration = table.Column<DateTime>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientSecrets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientSecrets_Clients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "ids",
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceScopes_ApiResourceId",
                schema: "ids",
                table: "ApiResourceScopes",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceSecrets_ApiResourceId",
                schema: "ids",
                table: "ApiResourceSecrets",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientClaims_ClientId",
                schema: "ids",
                table: "ClientClaims",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientSecrets_ClientId",
                schema: "ids",
                table: "ClientSecrets",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiResourceScopes",
                schema: "ids");

            migrationBuilder.DropTable(
                name: "ApiResourceSecrets",
                schema: "ids");

            migrationBuilder.DropTable(
                name: "ClientClaims",
                schema: "ids");

            migrationBuilder.DropTable(
                name: "ClientSecrets",
                schema: "ids");

            migrationBuilder.DropTable(
                name: "EventLogs",
                schema: "ids");

            migrationBuilder.DropTable(
                name: "IdentityResources",
                schema: "ids");

            migrationBuilder.DropTable(
                name: "PersistedGrants",
                schema: "ids");

            migrationBuilder.DropTable(
                name: "ApiResources",
                schema: "ids");

            migrationBuilder.DropTable(
                name: "Clients",
                schema: "ids");
        }
    }
}