using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;
using System.Collections.Generic;

namespace DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "AccountChartTypes",
                schema: "public",
                columns: table => new
                {
                    AccountChartTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountChartTypeUId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateUserName = table.Column<string>(type: "text", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifyUserName = table.Column<string>(type: "text", nullable: true),
                    ModifyDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountChartTypes", x => x.AccountChartTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AuditTrails",
                schema: "public",
                columns: table => new
                {
                    AuditId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuditType = table.Column<string>(type: "text", nullable: true),
                    EntitypeID = table.Column<int>(type: "integer", nullable: false),
                    RecId = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    Source = table.Column<string>(type: "text", nullable: true),
                    Process = table.Column<string>(type: "text", nullable: true),
                    ComputerID = table.Column<string>(type: "text", nullable: true),
                    Data = table.Column<string>(type: "text", nullable: true),
                    AuditDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditTrails", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "BranchMerchantNumbers",
                schema: "public",
                columns: table => new
                {
                    BranchMerchantNumberId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MerchantPhoneNumber = table.Column<string>(type: "text", nullable: true),
                    NetworkProviderName = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    BranchCode = table.Column<string>(type: "text", nullable: true),
                    OrganizationUId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateUserName = table.Column<string>(type: "text", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifyUserName = table.Column<string>(type: "text", nullable: true),
                    ModifyDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchMerchantNumbers", x => x.BranchMerchantNumberId);
                });

            migrationBuilder.CreateTable(
                name: "CashIns",
                schema: "public",
                columns: table => new
                {
                    CashInId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CashInUId = table.Column<Guid>(type: "uuid", nullable: false),
                    EntitypeID = table.Column<int>(type: "integer", nullable: false),
                    TransactionType = table.Column<string>(type: "text", nullable: true),
                    CustomerName = table.Column<string>(type: "text", nullable: true),
                    CustomerPhoneNumber = table.Column<string>(type: "text", nullable: true),
                    DepositorName = table.Column<string>(type: "text", nullable: true),
                    DepositPhoneNumber = table.Column<string>(type: "text", nullable: true),
                    DepositAmount = table.Column<double>(type: "double precision", nullable: false),
                    IsSendingChargePaidBySender = table.Column<bool>(type: "boolean", nullable: false),
                    SendingCost = table.Column<double>(type: "double precision", nullable: false),
                    TransactionDate = table.Column<string>(type: "text", nullable: true),
                    lastStatus = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    History = table.Column<string>(type: "text", nullable: true),
                    DepositPhoneNumberNetworkName = table.Column<string>(type: "text", nullable: true),
                    BranchMerchantNumberNetworkName = table.Column<string>(type: "text", nullable: true),
                    BranchMerchantNumber = table.Column<string>(type: "text", nullable: true),
                    BranchCode = table.Column<string>(type: "text", nullable: true),
                    CreateUserName = table.Column<string>(type: "text", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifyUserName = table.Column<string>(type: "text", nullable: true),
                    ModifyDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastProcessName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashIns", x => x.CashInId);
                });

            migrationBuilder.CreateTable(
                name: "CashOuts",
                schema: "public",
                columns: table => new
                {
                    CashOutId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CashOutUId = table.Column<Guid>(type: "uuid", nullable: false),
                    EntitypeID = table.Column<int>(type: "integer", nullable: false),
                    TransactionType = table.Column<string>(type: "text", nullable: true),
                    CustomerName = table.Column<string>(type: "text", nullable: true),
                    CustomerPhoneNumber = table.Column<string>(type: "text", nullable: true),
                    WithdrawerName = table.Column<string>(type: "text", nullable: true),
                    WithdrawerPhoneNumber = table.Column<string>(type: "text", nullable: true),
                    WithdrawerIDType = table.Column<string>(type: "text", nullable: true),
                    WithdrawerIDNo = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    ChargeRate = table.Column<string>(type: "text", nullable: true),
                    ChargeAmount = table.Column<double>(type: "double precision", nullable: false),
                    TransactionDate = table.Column<string>(type: "text", nullable: true),
                    PrevStatus = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    History = table.Column<string>(type: "text", nullable: true),
                    WithdrawerNetworkName = table.Column<string>(type: "text", nullable: true),
                    BranchMerchantNumberNetworkName = table.Column<string>(type: "text", nullable: true),
                    BranchMerchantNumber = table.Column<string>(type: "text", nullable: true),
                    BranchCode = table.Column<string>(type: "text", nullable: true),
                    CreateUserName = table.Column<string>(type: "text", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifyUserName = table.Column<string>(type: "text", nullable: true),
                    ModifyDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastProcessName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashOuts", x => x.CashOutId);
                });

            migrationBuilder.CreateTable(
                name: "ChartOfAccounts",
                schema: "public",
                columns: table => new
                {
                    ChartOfAccountId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChartOfAccountUId = table.Column<Guid>(type: "uuid", nullable: false),
                    AccountNumber = table.Column<string>(type: "text", nullable: true),
                    AccountType = table.Column<string>(type: "text", nullable: true),
                    BranchCode = table.Column<string>(type: "text", nullable: true),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false),
                    CreateUserName = table.Column<string>(type: "text", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifyUserName = table.Column<string>(type: "text", nullable: true),
                    ModifyDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartOfAccounts", x => x.ChartOfAccountId);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "public",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    RegionId = table.Column<int>(type: "integer", nullable: false),
                    CreateUserName = table.Column<string>(type: "text", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifyUserName = table.Column<string>(type: "text", nullable: true),
                    ModifyDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "public",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreateUserName = table.Column<string>(type: "text", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifyUserName = table.Column<string>(type: "text", nullable: true),
                    ModifyDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "EntityTypes",
                schema: "public",
                columns: table => new
                {
                    EntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Table = table.Column<string>(type: "text", nullable: true),
                    CreateUserName = table.Column<string>(type: "text", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifyUserName = table.Column<string>(type: "text", nullable: true),
                    ModifyDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityTypes", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                schema: "public",
                columns: table => new
                {
                    FeatureId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EntitypeID = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreateUserName = table.Column<string>(type: "text", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifyUserName = table.Column<string>(type: "text", nullable: true),
                    ModifyDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.FeatureId);
                });

            migrationBuilder.CreateTable(
                name: "Ledgers",
                schema: "public",
                columns: table => new
                {
                    LedgerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountNumber = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<string>(type: "text", nullable: true),
                    EntryType = table.Column<char>(type: "character(1)", nullable: false),
                    TransactionType = table.Column<string>(type: "text", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Narration = table.Column<string>(type: "text", nullable: true),
                    CreateUserName = table.Column<string>(type: "text", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifyUserName = table.Column<string>(type: "text", nullable: true),
                    ModifyDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ledgers", x => x.LedgerId);
                });

            migrationBuilder.CreateTable(
                name: "OrganisationBranchs",
                schema: "public",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BranchUId = table.Column<Guid>(type: "uuid", nullable: false),
                    BranchCode = table.Column<string>(type: "text", nullable: true),
                    OrganizationUId = table.Column<Guid>(type: "uuid", nullable: false),
                    BranchName = table.Column<string>(type: "text", nullable: true),
                    BranchHeadUserName = table.Column<string>(type: "text", nullable: true),
                    BranchAddress = table.Column<string>(type: "text", nullable: true),
                    BranchDateOfEstablishment = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    BranchMerchantNumber = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<Guid>(type: "uuid", nullable: false),
                    Region = table.Column<Guid>(type: "uuid", nullable: false),
                    City = table.Column<string>(type: "text", nullable: true),
                    CreateUserName = table.Column<string>(type: "text", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifyUserName = table.Column<string>(type: "text", nullable: true),
                    ModifyDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationBranchs", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "Organisations",
                schema: "public",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganizationUId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    VATId = table.Column<string>(type: "text", nullable: true),
                    BusinessRegistrationId = table.Column<string>(type: "text", nullable: true),
                    BusinessRegistrationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Owners = table.Column<List<string>>(type: "text[]", nullable: true),
                    CEOs = table.Column<string>(type: "text", nullable: true),
                    CountryOfOrigin = table.Column<int>(type: "integer", nullable: false),
                    CreateUserName = table.Column<string>(type: "text", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifyUserName = table.Column<string>(type: "text", nullable: true),
                    ModifyDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisations", x => x.OrganizationId);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                schema: "public",
                columns: table => new
                {
                    PermissionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FeatureId = table.Column<int>(type: "integer", nullable: false),
                    Read = table.Column<int>(type: "integer", nullable: false),
                    Modify = table.Column<int>(type: "integer", nullable: false),
                    Add = table.Column<int>(type: "integer", nullable: false),
                    Delete = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    EntitypeID = table.Column<int>(type: "integer", nullable: false),
                    CreateUserName = table.Column<string>(type: "text", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifyUserName = table.Column<string>(type: "text", nullable: true),
                    ModifyDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.PermissionId);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                schema: "public",
                columns: table => new
                {
                    RegionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    CreateUserName = table.Column<string>(type: "text", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifyUserName = table.Column<string>(type: "text", nullable: true),
                    ModifyDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "public",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreateUserName = table.Column<string>(type: "text", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifyUserName = table.Column<string>(type: "text", nullable: true),
                    ModifyDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Towns",
                schema: "public",
                columns: table => new
                {
                    TownId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    CreateUserName = table.Column<string>(type: "text", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifyUserName = table.Column<string>(type: "text", nullable: true),
                    ModifyDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.TownId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "public",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    UserFullName = table.Column<string>(type: "text", nullable: true),
                    UserPassword = table.Column<string>(type: "text", nullable: true),
                    PasswordExpiryDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserRoleID = table.Column<int>(type: "integer", nullable: false),
                    BranchCode = table.Column<string>(type: "text", nullable: true),
                    MailingAddress = table.Column<string>(type: "text", nullable: true),
                    GhanaPostCode = table.Column<string>(type: "text", nullable: true),
                    MobileNumber = table.Column<string>(type: "text", nullable: true),
                    CreateUserName = table.Column<string>(type: "text", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifyUserName = table.Column<string>(type: "text", nullable: true),
                    ModifyDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountChartTypes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AuditTrails",
                schema: "public");

            migrationBuilder.DropTable(
                name: "BranchMerchantNumbers",
                schema: "public");

            migrationBuilder.DropTable(
                name: "CashIns",
                schema: "public");

            migrationBuilder.DropTable(
                name: "CashOuts",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ChartOfAccounts",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "public");

            migrationBuilder.DropTable(
                name: "EntityTypes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Features",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Ledgers",
                schema: "public");

            migrationBuilder.DropTable(
                name: "OrganisationBranchs",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Organisations",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Permissions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Regions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Towns",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "public");
        }
    }
}