﻿// <auto-generated />
using System;
using System.Collections.Generic;
using DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataAccess.Migrations
{
    [DbContext(typeof(mTellerDBContext))]
    [Migration("20210613153129_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DataAccess.AuditTrails", b =>
                {
                    b.Property<int>("AuditId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("AuditDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("AuditType")
                        .HasColumnType("text");

                    b.Property<string>("ComputerID")
                        .HasColumnType("text");

                    b.Property<string>("Data")
                        .HasColumnType("text");

                    b.Property<int>("EntitypeID")
                        .HasColumnType("integer");

                    b.Property<string>("Process")
                        .HasColumnType("text");

                    b.Property<int>("RecId")
                        .HasColumnType("integer");

                    b.Property<string>("Source")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("AuditId");

                    b.ToTable("AuditTrails");
                });

            modelBuilder.Entity("DataAccess.BranchMerchantNumber", b =>
                {
                    b.Property<int>("BranchMerchantNumberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("BranchCode")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreateUserName")
                        .HasColumnType("text");

                    b.Property<string>("MerchantPhoneNumber")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserName")
                        .HasColumnType("text");

                    b.Property<string>("NetworkProviderName")
                        .HasColumnType("text");

                    b.Property<Guid>("OrganizationUId")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("BranchMerchantNumberId");

                    b.ToTable("BranchMerchantNumbers");
                });

            modelBuilder.Entity("DataAccess.CashIn", b =>
                {
                    b.Property<int>("CashInId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("BranchCode")
                        .HasColumnType("text");

                    b.Property<string>("BranchMerchantNumber")
                        .HasColumnType("text");

                    b.Property<string>("BranchMerchantNumberNetworkName")
                        .HasColumnType("text");

                    b.Property<Guid>("CashInUId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreateUserName")
                        .HasColumnType("text");

                    b.Property<string>("CustomerName")
                        .HasColumnType("text");

                    b.Property<string>("CustomerPhoneNumber")
                        .HasColumnType("text");

                    b.Property<double>("DepositAmount")
                        .HasColumnType("double precision");

                    b.Property<string>("DepositPhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("DepositPhoneNumberNetworkName")
                        .HasColumnType("text");

                    b.Property<string>("DepositorName")
                        .HasColumnType("text");

                    b.Property<int>("EntitypeID")
                        .HasColumnType("integer");

                    b.Property<string>("History")
                        .HasColumnType("text");

                    b.Property<bool>("IsSendingChargePaidBySender")
                        .HasColumnType("boolean");

                    b.Property<string>("LastProcessName")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserName")
                        .HasColumnType("text");

                    b.Property<double>("SendingCost")
                        .HasColumnType("double precision");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<string>("TransactionDate")
                        .HasColumnType("text");

                    b.Property<string>("TransactionType")
                        .HasColumnType("text");

                    b.Property<string>("lastStatus")
                        .HasColumnType("text");

                    b.HasKey("CashInId");

                    b.ToTable("CashIns");
                });

            modelBuilder.Entity("DataAccess.CashOut", b =>
                {
                    b.Property<int>("CashOutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<string>("BranchCode")
                        .HasColumnType("text");

                    b.Property<string>("BranchMerchantNumber")
                        .HasColumnType("text");

                    b.Property<string>("BranchMerchantNumberNetworkName")
                        .HasColumnType("text");

                    b.Property<Guid>("CashOutUId")
                        .HasColumnType("uuid");

                    b.Property<double>("ChargeAmount")
                        .HasColumnType("double precision");

                    b.Property<string>("ChargeRate")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreateUserName")
                        .HasColumnType("text");

                    b.Property<string>("CustomerName")
                        .HasColumnType("text");

                    b.Property<string>("CustomerPhoneNumber")
                        .HasColumnType("text");

                    b.Property<int>("EntitypeID")
                        .HasColumnType("integer");

                    b.Property<string>("History")
                        .HasColumnType("text");

                    b.Property<string>("LastProcessName")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserName")
                        .HasColumnType("text");

                    b.Property<string>("PrevStatus")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<string>("TransactionDate")
                        .HasColumnType("text");

                    b.Property<string>("TransactionType")
                        .HasColumnType("text");

                    b.Property<string>("WithdrawerIDNo")
                        .HasColumnType("text");

                    b.Property<string>("WithdrawerIDType")
                        .HasColumnType("text");

                    b.Property<string>("WithdrawerName")
                        .HasColumnType("text");

                    b.Property<string>("WithdrawerNetworkName")
                        .HasColumnType("text");

                    b.Property<string>("WithdrawerPhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("CashOutId");

                    b.ToTable("CashOuts");
                });

            modelBuilder.Entity("DataAccess.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreateUserName")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("RegionId")
                        .HasColumnType("integer");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("DataAccess.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreateUserName")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("DataAccess.Ledger", b =>
                {
                    b.Property<int>("LedgerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AccountNumber")
                        .HasColumnType("text");

                    b.Property<string>("Amount")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreateUserName")
                        .HasColumnType("text");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<char>("EntryType")
                        .HasColumnType("character(1)");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserName")
                        .HasColumnType("text");

                    b.Property<string>("Narration")
                        .HasColumnType("text");

                    b.Property<string>("TransactionType")
                        .HasColumnType("text");

                    b.HasKey("LedgerId");

                    b.ToTable("Ledgers");
                });

            modelBuilder.Entity("DataAccess.Models.AccountChartType", b =>
                {
                    b.Property<int>("AccountChartTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<Guid>("AccountChartTypeUId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreateUserName")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserName")
                        .HasColumnType("text");

                    b.HasKey("AccountChartTypeId");

                    b.ToTable("AccountChartTypes");
                });

            modelBuilder.Entity("DataAccess.Models.ChartOfAccount", b =>
                {
                    b.Property<int>("ChartOfAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AccountNumber")
                        .HasColumnType("text");

                    b.Property<string>("AccountType")
                        .HasColumnType("text");

                    b.Property<decimal>("Balance")
                        .HasColumnType("numeric");

                    b.Property<string>("BranchCode")
                        .HasColumnType("text");

                    b.Property<Guid>("ChartOfAccountUId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreateUserName")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserName")
                        .HasColumnType("text");

                    b.HasKey("ChartOfAccountId");

                    b.ToTable("ChartOfAccounts");
                });

            modelBuilder.Entity("DataAccess.Models.EntityType", b =>
                {
                    b.Property<int>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreateUserName")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Table")
                        .HasColumnType("text");

                    b.HasKey("EntityId");

                    b.ToTable("EntityTypes");
                });

            modelBuilder.Entity("DataAccess.Models.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreateUserName")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("DataAccess.Organisation", b =>
                {
                    b.Property<int>("OrganizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("BusinessRegistrationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("BusinessRegistrationId")
                        .HasColumnType("text");

                    b.Property<string>("CEOs")
                        .HasColumnType("text");

                    b.Property<int>("CountryOfOrigin")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreateUserName")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("OrganizationUId")
                        .HasColumnType("uuid");

                    b.Property<List<string>>("Owners")
                        .HasColumnType("text[]");

                    b.Property<string>("VATId")
                        .HasColumnType("text");

                    b.HasKey("OrganizationId");

                    b.ToTable("Organisations");
                });

            modelBuilder.Entity("DataAccess.OrganisationBranch", b =>
                {
                    b.Property<int>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("BranchAddress")
                        .HasColumnType("text");

                    b.Property<string>("BranchCode")
                        .HasColumnType("text");

                    b.Property<DateTime>("BranchDateOfEstablishment")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("BranchHeadUserName")
                        .HasColumnType("text");

                    b.Property<string>("BranchMerchantNumber")
                        .HasColumnType("text");

                    b.Property<string>("BranchName")
                        .HasColumnType("text");

                    b.Property<Guid>("BranchUId")
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<Guid>("Country")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreateUserName")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserName")
                        .HasColumnType("text");

                    b.Property<Guid>("OrganizationUId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("Region")
                        .HasColumnType("uuid");

                    b.HasKey("BranchId");

                    b.ToTable("OrganisationBranchs");
                });

            modelBuilder.Entity("DataAccess.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Add")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreateUserName")
                        .HasColumnType("text");

                    b.Property<int>("Delete")
                        .HasColumnType("integer");

                    b.Property<int>("EntitypeID")
                        .HasColumnType("integer");

                    b.Property<int>("FeatureId")
                        .HasColumnType("integer");

                    b.Property<int>("Modify")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserName")
                        .HasColumnType("text");

                    b.Property<int>("Read")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("PermissionId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("DataAccess.Region", b =>
                {
                    b.Property<int>("RegionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreateUserName")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("RegionId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("DataAccess.Town", b =>
                {
                    b.Property<int>("TownId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreateUserName")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("TownId");

                    b.ToTable("Towns");
                });

            modelBuilder.Entity("Feature", b =>
                {
                    b.Property<int>("FeatureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreateUserName")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("EntitypeID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("FeatureId");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("BranchCode")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreateUserName")
                        .HasColumnType("text");

                    b.Property<string>("GhanaPostCode")
                        .HasColumnType("text");

                    b.Property<string>("MailingAddress")
                        .HasColumnType("text");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserName")
                        .HasColumnType("text");

                    b.Property<DateTime>("PasswordExpiryDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UserFullName")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.Property<string>("UserPassword")
                        .HasColumnType("text");

                    b.Property<int>("UserRoleID")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
