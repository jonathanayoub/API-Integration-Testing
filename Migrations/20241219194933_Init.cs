using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiIntegrationTesting.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Person");

            migrationBuilder.EnsureSchema(
                name: "Production");

            migrationBuilder.EnsureSchema(
                name: "Sales");

            migrationBuilder.EnsureSchema(
                name: "HumanResources");

            migrationBuilder.EnsureSchema(
                name: "Purchasing");

            migrationBuilder.EnsureSchema(
                name: "Shield");

            migrationBuilder.CreateTable(
                name: "AddressType",
                schema: "Person",
                columns: table => new
                {
                    AddressTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressType", x => x.AddressTypeId);
                });

            migrationBuilder.CreateTable(
                name: "BusinessEntity",
                schema: "Person",
                columns: table => new
                {
                    BusinessEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessEntity", x => x.BusinessEntityId);
                });

            migrationBuilder.CreateTable(
                name: "ContactType",
                schema: "Person",
                columns: table => new
                {
                    ContactTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactType", x => x.ContactTypeId);
                });

            migrationBuilder.CreateTable(
                name: "CountryRegion",
                schema: "Person",
                columns: table => new
                {
                    CountryRegionCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryRegion", x => x.CountryRegionCode);
                });

            migrationBuilder.CreateTable(
                name: "CreditCard",
                schema: "Sales",
                columns: table => new
                {
                    CreditCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpMonth = table.Column<byte>(type: "tinyint", nullable: false),
                    ExpYear = table.Column<short>(type: "smallint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCard", x => x.CreditCardId);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                schema: "Sales",
                columns: table => new
                {
                    CurrencyCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.CurrencyCode);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "HumanResources",
                columns: table => new
                {
                    DepartmentId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Illustration",
                schema: "Production",
                columns: table => new
                {
                    IllustrationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Illustration", x => x.IllustrationId);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "Production",
                columns: table => new
                {
                    LocationId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Availability = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "PersonType",
                schema: "Person",
                columns: table => new
                {
                    PersonTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonTypeGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonTypeCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PersonTypeName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PersonTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonType", x => x.PersonTypeId);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumberType",
                schema: "Person",
                columns: table => new
                {
                    PhoneNumberTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumberType", x => x.PhoneNumberTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                schema: "Production",
                columns: table => new
                {
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.ProductCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ProductDescription",
                schema: "Production",
                columns: table => new
                {
                    ProductDescriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDescription", x => x.ProductDescriptionId);
                });

            migrationBuilder.CreateTable(
                name: "ProductModel",
                schema: "Production",
                columns: table => new
                {
                    ProductModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatalogDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModel", x => x.ProductModelId);
                });

            migrationBuilder.CreateTable(
                name: "ProductPhoto",
                schema: "Production",
                columns: table => new
                {
                    ProductPhotoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThumbNailPhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ThumbnailPhotoFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LargePhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    LargePhotoFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPhoto", x => x.ProductPhotoId);
                });

            migrationBuilder.CreateTable(
                name: "SalesReason",
                schema: "Sales",
                columns: table => new
                {
                    SalesReasonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReason", x => x.SalesReasonId);
                });

            migrationBuilder.CreateTable(
                name: "ScrapReason",
                schema: "Production",
                columns: table => new
                {
                    ScrapReasonId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrapReason", x => x.ScrapReasonId);
                });

            migrationBuilder.CreateTable(
                name: "SecurityFunction",
                schema: "Shield",
                columns: table => new
                {
                    FunctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FunctionGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FunctionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FunctionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityFunction", x => x.FunctionId);
                });

            migrationBuilder.CreateTable(
                name: "SecurityGroup",
                schema: "Shield",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityGroup", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "SecurityRole",
                schema: "Shield",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityRole", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                schema: "HumanResources",
                columns: table => new
                {
                    ShiftId = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.ShiftId);
                });

            migrationBuilder.CreateTable(
                name: "ShipMethod",
                schema: "Purchasing",
                columns: table => new
                {
                    ShipMethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipBase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShipRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipMethod", x => x.ShipMethodId);
                });

            migrationBuilder.CreateTable(
                name: "SpecialOffer",
                schema: "Sales",
                columns: table => new
                {
                    SpecialOfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountPct = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MinQty = table.Column<int>(type: "int", nullable: false),
                    MaxQty = table.Column<int>(type: "int", nullable: true),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialOffer", x => x.SpecialOfferId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionHistoryArchive",
                schema: "Production",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ReferenceOrderId = table.Column<int>(type: "int", nullable: false),
                    ReferenceOrderLineId = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ActualCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistoryArchive", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "UnitMeasure",
                schema: "Production",
                columns: table => new
                {
                    UnitMeasureCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitMeasure", x => x.UnitMeasureCode);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                schema: "Purchasing",
                columns: table => new
                {
                    BusinessEntityId = table.Column<int>(type: "int", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditRating = table.Column<byte>(type: "tinyint", nullable: false),
                    PreferredVendorStatus = table.Column<bool>(type: "bit", nullable: false),
                    ActiveFlag = table.Column<bool>(type: "bit", nullable: false),
                    PurchasingWebServiceUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.BusinessEntityId);
                    table.ForeignKey(
                        name: "FK_Vendor_BusinessEntity_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalSchema: "Person",
                        principalTable: "BusinessEntity",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesTerritory",
                schema: "Sales",
                columns: table => new
                {
                    TerritoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryRegionCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesYtd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalesLastYear = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostYtd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostLastYear = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTerritory", x => x.TerritoryId);
                    table.ForeignKey(
                        name: "FK_SalesTerritory_CountryRegion_CountryRegionCode",
                        column: x => x.CountryRegionCode,
                        principalSchema: "Person",
                        principalTable: "CountryRegion",
                        principalColumn: "CountryRegionCode");
                });

            migrationBuilder.CreateTable(
                name: "CountryRegionCurrency",
                schema: "Sales",
                columns: table => new
                {
                    CountryRegionCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrencyCode1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryRegionCurrency", x => new { x.CountryRegionCode, x.CurrencyCode });
                    table.ForeignKey(
                        name: "FK_CountryRegionCurrency_CountryRegion_CountryRegionCode",
                        column: x => x.CountryRegionCode,
                        principalSchema: "Person",
                        principalTable: "CountryRegion",
                        principalColumn: "CountryRegionCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryRegionCurrency_Currency_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalSchema: "Sales",
                        principalTable: "Currency",
                        principalColumn: "CurrencyCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryRegionCurrency_Currency_CurrencyCode1",
                        column: x => x.CurrencyCode1,
                        principalSchema: "Sales",
                        principalTable: "Currency",
                        principalColumn: "CurrencyCode");
                });

            migrationBuilder.CreateTable(
                name: "CurrencyRate",
                schema: "Sales",
                columns: table => new
                {
                    CurrencyRateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyRateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromCurrencyCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ToCurrencyCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AverageRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EndOfDayRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CurrencyCode1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyRate", x => x.CurrencyRateId);
                    table.ForeignKey(
                        name: "FK_CurrencyRate_Currency_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalSchema: "Sales",
                        principalTable: "Currency",
                        principalColumn: "CurrencyCode");
                    table.ForeignKey(
                        name: "FK_CurrencyRate_Currency_CurrencyCode1",
                        column: x => x.CurrencyCode1,
                        principalSchema: "Sales",
                        principalTable: "Currency",
                        principalColumn: "CurrencyCode");
                    table.ForeignKey(
                        name: "FK_CurrencyRate_Currency_FromCurrencyCode",
                        column: x => x.FromCurrencyCode,
                        principalSchema: "Sales",
                        principalTable: "Currency",
                        principalColumn: "CurrencyCode");
                    table.ForeignKey(
                        name: "FK_CurrencyRate_Currency_ToCurrencyCode",
                        column: x => x.ToCurrencyCode,
                        principalSchema: "Sales",
                        principalTable: "Currency",
                        principalColumn: "CurrencyCode");
                });

            migrationBuilder.CreateTable(
                name: "ProductSubcategory",
                schema: "Production",
                columns: table => new
                {
                    ProductSubcategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSubcategory", x => x.ProductSubcategoryId);
                    table.ForeignKey(
                        name: "FK_ProductSubcategory_ProductCategory_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalSchema: "Production",
                        principalTable: "ProductCategory",
                        principalColumn: "ProductCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductModelIllustration",
                schema: "Production",
                columns: table => new
                {
                    ProductModelId = table.Column<int>(type: "int", nullable: false),
                    IllustrationId = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IllustrationId1 = table.Column<int>(type: "int", nullable: true),
                    ProductModelId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModelIllustration", x => new { x.ProductModelId, x.IllustrationId });
                    table.ForeignKey(
                        name: "FK_ProductModelIllustration_Illustration_IllustrationId",
                        column: x => x.IllustrationId,
                        principalSchema: "Production",
                        principalTable: "Illustration",
                        principalColumn: "IllustrationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductModelIllustration_Illustration_IllustrationId1",
                        column: x => x.IllustrationId1,
                        principalSchema: "Production",
                        principalTable: "Illustration",
                        principalColumn: "IllustrationId");
                    table.ForeignKey(
                        name: "FK_ProductModelIllustration_ProductModel_ProductModelId",
                        column: x => x.ProductModelId,
                        principalSchema: "Production",
                        principalTable: "ProductModel",
                        principalColumn: "ProductModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductModelIllustration_ProductModel_ProductModelId1",
                        column: x => x.ProductModelId1,
                        principalSchema: "Production",
                        principalTable: "ProductModel",
                        principalColumn: "ProductModelId");
                });

            migrationBuilder.CreateTable(
                name: "ProductModelProductDescriptionCulture",
                schema: "Production",
                columns: table => new
                {
                    ProductModelId = table.Column<int>(type: "int", nullable: false),
                    ProductDescriptionId = table.Column<int>(type: "int", nullable: false),
                    CultureId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductDescriptionId1 = table.Column<int>(type: "int", nullable: true),
                    ProductModelId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModelProductDescriptionCulture", x => new { x.ProductModelId, x.ProductDescriptionId, x.CultureId });
                    table.ForeignKey(
                        name: "FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionId",
                        column: x => x.ProductDescriptionId,
                        principalSchema: "Production",
                        principalTable: "ProductDescription",
                        principalColumn: "ProductDescriptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionId1",
                        column: x => x.ProductDescriptionId1,
                        principalSchema: "Production",
                        principalTable: "ProductDescription",
                        principalColumn: "ProductDescriptionId");
                    table.ForeignKey(
                        name: "FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelId",
                        column: x => x.ProductModelId,
                        principalSchema: "Production",
                        principalTable: "ProductModel",
                        principalColumn: "ProductModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelId1",
                        column: x => x.ProductModelId1,
                        principalSchema: "Production",
                        principalTable: "ProductModel",
                        principalColumn: "ProductModelId");
                });

            migrationBuilder.CreateTable(
                name: "SecurityGroupSecurityFunction",
                schema: "Shield",
                columns: table => new
                {
                    SecurityGroupSecurityFunctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecurityGroupSecurityFunctionGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    FunctionId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityGroupSecurityFunction", x => x.SecurityGroupSecurityFunctionId);
                    table.ForeignKey(
                        name: "FK_SecurityGroupSecurityFunction_SecurityFunction_FunctionId",
                        column: x => x.FunctionId,
                        principalSchema: "Shield",
                        principalTable: "SecurityFunction",
                        principalColumn: "FunctionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SecurityGroupSecurityFunction_SecurityGroup_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "Shield",
                        principalTable: "SecurityGroup",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecurityGroupSecurityRole",
                schema: "Shield",
                columns: table => new
                {
                    SecurityGroupSecurityRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecurityGroupSecurityRoleGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityGroupSecurityRole", x => x.SecurityGroupSecurityRoleId);
                    table.ForeignKey(
                        name: "FK_SecurityGroupSecurityRole_SecurityGroup_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "Shield",
                        principalTable: "SecurityGroup",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SecurityGroupSecurityRole_SecurityRole_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Shield",
                        principalTable: "SecurityRole",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StateProvince",
                schema: "Person",
                columns: table => new
                {
                    StateProvinceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateProvinceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryRegionCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsOnlyStateProvinceFlag = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerritoryId = table.Column<int>(type: "int", nullable: false),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateProvince", x => x.StateProvinceId);
                    table.ForeignKey(
                        name: "FK_StateProvince_CountryRegion_CountryRegionCode",
                        column: x => x.CountryRegionCode,
                        principalSchema: "Person",
                        principalTable: "CountryRegion",
                        principalColumn: "CountryRegionCode");
                    table.ForeignKey(
                        name: "FK_StateProvince_SalesTerritory_TerritoryId",
                        column: x => x.TerritoryId,
                        principalSchema: "Sales",
                        principalTable: "SalesTerritory",
                        principalColumn: "TerritoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Production",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MakeFlag = table.Column<bool>(type: "bit", nullable: false),
                    FinishedGoodsFlag = table.Column<bool>(type: "bit", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SafetyStockLevel = table.Column<short>(type: "smallint", nullable: false),
                    ReorderPoint = table.Column<short>(type: "smallint", nullable: false),
                    StandardCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ListPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeUnitMeasureCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    WeightUnitMeasureCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DaysToManufacture = table.Column<int>(type: "int", nullable: false),
                    ProductLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Style = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductSubcategoryId = table.Column<int>(type: "int", nullable: true),
                    ProductModelId = table.Column<int>(type: "int", nullable: true),
                    SellStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SellEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiscontinuedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_ProductModel_ProductModelId",
                        column: x => x.ProductModelId,
                        principalSchema: "Production",
                        principalTable: "ProductModel",
                        principalColumn: "ProductModelId");
                    table.ForeignKey(
                        name: "FK_Product_ProductSubcategory_ProductSubcategoryId",
                        column: x => x.ProductSubcategoryId,
                        principalSchema: "Production",
                        principalTable: "ProductSubcategory",
                        principalColumn: "ProductSubcategoryId");
                    table.ForeignKey(
                        name: "FK_Product_UnitMeasure_SizeUnitMeasureCode",
                        column: x => x.SizeUnitMeasureCode,
                        principalSchema: "Production",
                        principalTable: "UnitMeasure",
                        principalColumn: "UnitMeasureCode");
                    table.ForeignKey(
                        name: "FK_Product_UnitMeasure_WeightUnitMeasureCode",
                        column: x => x.WeightUnitMeasureCode,
                        principalSchema: "Production",
                        principalTable: "UnitMeasure",
                        principalColumn: "UnitMeasureCode");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "Person",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateProvinceId = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_StateProvince_StateProvinceId",
                        column: x => x.StateProvinceId,
                        principalSchema: "Person",
                        principalTable: "StateProvince",
                        principalColumn: "StateProvinceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesTaxRate",
                schema: "Sales",
                columns: table => new
                {
                    SalesTaxRateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateProvinceId = table.Column<int>(type: "int", nullable: false),
                    TaxType = table.Column<byte>(type: "tinyint", nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StateProvinceEntityStateProvinceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTaxRate", x => x.SalesTaxRateId);
                    table.ForeignKey(
                        name: "FK_SalesTaxRate_StateProvince_StateProvinceEntityStateProvinceId",
                        column: x => x.StateProvinceEntityStateProvinceId,
                        principalSchema: "Person",
                        principalTable: "StateProvince",
                        principalColumn: "StateProvinceId");
                    table.ForeignKey(
                        name: "FK_SalesTaxRate_StateProvince_StateProvinceId",
                        column: x => x.StateProvinceId,
                        principalSchema: "Person",
                        principalTable: "StateProvince",
                        principalColumn: "StateProvinceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillOfMaterials",
                schema: "Production",
                columns: table => new
                {
                    BillOfMaterialsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductAssemblyId = table.Column<int>(type: "int", nullable: true),
                    ComponentId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnitMeasureCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Bomlevel = table.Column<short>(type: "smallint", nullable: false),
                    PerAssemblyQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillOfMaterials", x => x.BillOfMaterialsId);
                    table.ForeignKey(
                        name: "FK_BillOfMaterials_Product_ComponentId",
                        column: x => x.ComponentId,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillOfMaterials_Product_ProductAssemblyId",
                        column: x => x.ProductAssemblyId,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_BillOfMaterials_UnitMeasure_UnitMeasureCode",
                        column: x => x.UnitMeasureCode,
                        principalSchema: "Production",
                        principalTable: "UnitMeasure",
                        principalColumn: "UnitMeasureCode");
                });

            migrationBuilder.CreateTable(
                name: "ProductCostHistory",
                schema: "Production",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StandardCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCostHistory", x => new { x.ProductId, x.StartDate });
                    table.ForeignKey(
                        name: "FK_ProductCostHistory_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInventory",
                schema: "Production",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<short>(type: "smallint", nullable: false),
                    Shelf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bin = table.Column<byte>(type: "tinyint", nullable: false),
                    Quantity = table.Column<short>(type: "smallint", nullable: false),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInventory", x => new { x.ProductId, x.LocationId });
                    table.ForeignKey(
                        name: "FK_ProductInventory_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Production",
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInventory_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductListPriceHistory",
                schema: "Production",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ListPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductListPriceHistory", x => new { x.ProductId, x.StartDate });
                    table.ForeignKey(
                        name: "FK_ProductListPriceHistory_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductPhoto",
                schema: "Production",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductPhotoId = table.Column<int>(type: "int", nullable: false),
                    Primary = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductPhoto", x => new { x.ProductId, x.ProductPhotoId });
                    table.ForeignKey(
                        name: "FK_ProductProductPhoto_ProductPhoto_ProductPhotoId",
                        column: x => x.ProductPhotoId,
                        principalSchema: "Production",
                        principalTable: "ProductPhoto",
                        principalColumn: "ProductPhotoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductPhoto_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductReview",
                schema: "Production",
                columns: table => new
                {
                    ProductReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ReviewerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReview", x => x.ProductReviewId);
                    table.ForeignKey(
                        name: "FK_ProductReview_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductVendor",
                schema: "Purchasing",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    BusinessEntityId = table.Column<int>(type: "int", nullable: false),
                    AverageLeadTime = table.Column<int>(type: "int", nullable: false),
                    StandardPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastReceiptCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LastReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MinOrderQty = table.Column<int>(type: "int", nullable: false),
                    MaxOrderQty = table.Column<int>(type: "int", nullable: false),
                    OnOrderQty = table.Column<int>(type: "int", nullable: true),
                    UnitMeasureCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVendor", x => new { x.ProductId, x.BusinessEntityId });
                    table.ForeignKey(
                        name: "FK_ProductVendor_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVendor_UnitMeasure_UnitMeasureCode",
                        column: x => x.UnitMeasureCode,
                        principalSchema: "Production",
                        principalTable: "UnitMeasure",
                        principalColumn: "UnitMeasureCode");
                    table.ForeignKey(
                        name: "FK_ProductVendor_Vendor_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalSchema: "Purchasing",
                        principalTable: "Vendor",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItem",
                schema: "Sales",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingCartId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItem", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialOfferProduct",
                schema: "Sales",
                columns: table => new
                {
                    SpecialOfferId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialOfferProduct", x => new { x.SpecialOfferId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_SpecialOfferProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialOfferProduct_SpecialOffer_SpecialOfferId",
                        column: x => x.SpecialOfferId,
                        principalSchema: "Sales",
                        principalTable: "SpecialOffer",
                        principalColumn: "SpecialOfferId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionHistory",
                schema: "Production",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ReferenceOrderId = table.Column<int>(type: "int", nullable: false),
                    ReferenceOrderLineId = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ActualCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistory", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_TransactionHistory_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrder",
                schema: "Production",
                columns: table => new
                {
                    WorkOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderQty = table.Column<int>(type: "int", nullable: false),
                    StockedQty = table.Column<int>(type: "int", nullable: false),
                    ScrappedQty = table.Column<short>(type: "smallint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScrapReasonId = table.Column<short>(type: "smallint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrder", x => x.WorkOrderId);
                    table.ForeignKey(
                        name: "FK_WorkOrder_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkOrder_ScrapReason_ScrapReasonId",
                        column: x => x.ScrapReasonId,
                        principalSchema: "Production",
                        principalTable: "ScrapReason",
                        principalColumn: "ScrapReasonId");
                });

            migrationBuilder.CreateTable(
                name: "BusinessEntityAddress",
                schema: "Person",
                columns: table => new
                {
                    BusinessEntityId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    AddressTypeId = table.Column<int>(type: "int", nullable: false),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessEntityAddress", x => new { x.BusinessEntityId, x.AddressId, x.AddressTypeId });
                    table.ForeignKey(
                        name: "FK_BusinessEntityAddress_AddressType_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalSchema: "Person",
                        principalTable: "AddressType",
                        principalColumn: "AddressTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessEntityAddress_Address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "Person",
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessEntityAddress_BusinessEntity_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalSchema: "Person",
                        principalTable: "BusinessEntity",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderRouting",
                schema: "Production",
                columns: table => new
                {
                    WorkOrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OperationSequence = table.Column<short>(type: "smallint", nullable: false),
                    LocationId = table.Column<short>(type: "smallint", nullable: false),
                    ScheduledStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduledEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualResourceHrs = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PlannedCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ActualCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderRouting", x => new { x.WorkOrderId, x.ProductId, x.OperationSequence });
                    table.ForeignKey(
                        name: "FK_WorkOrderRouting_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Production",
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkOrderRouting_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkOrderRouting_WorkOrder_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalSchema: "Production",
                        principalTable: "WorkOrder",
                        principalColumn: "WorkOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessEntityContact",
                schema: "Person",
                columns: table => new
                {
                    BusinessEntityId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    ContactTypeId = table.Column<int>(type: "int", nullable: false),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessEntityContact", x => new { x.BusinessEntityId, x.PersonId, x.ContactTypeId });
                    table.ForeignKey(
                        name: "FK_BusinessEntityContact_BusinessEntity_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalSchema: "Person",
                        principalTable: "BusinessEntity",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessEntityContact_ContactType_ContactTypeId",
                        column: x => x.ContactTypeId,
                        principalSchema: "Person",
                        principalTable: "ContactType",
                        principalColumn: "ContactTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "Sales",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    StoreId = table.Column<int>(type: "int", nullable: true),
                    TerritoryId = table.Column<int>(type: "int", nullable: true),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customer_SalesTerritory_TerritoryId",
                        column: x => x.TerritoryId,
                        principalSchema: "Sales",
                        principalTable: "SalesTerritory",
                        principalColumn: "TerritoryId");
                });

            migrationBuilder.CreateTable(
                name: "EmailAddress",
                schema: "Person",
                columns: table => new
                {
                    EmailAddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessEntityId = table.Column<int>(type: "int", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddress", x => x.EmailAddressId);
                });

            migrationBuilder.CreateTable(
                name: "UserAccount",
                schema: "Shield",
                columns: table => new
                {
                    BusinessEntityId = table.Column<int>(type: "int", nullable: false),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryEmailAddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => x.BusinessEntityId);
                    table.ForeignKey(
                        name: "FK_UserAccount_BusinessEntity_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalSchema: "Person",
                        principalTable: "BusinessEntity",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAccount_EmailAddress_PrimaryEmailAddressId",
                        column: x => x.PrimaryEmailAddressId,
                        principalSchema: "Person",
                        principalTable: "EmailAddress",
                        principalColumn: "EmailAddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "Person",
                columns: table => new
                {
                    BusinessEntityId = table.Column<int>(type: "int", nullable: false),
                    PersonTypeId = table.Column<int>(type: "int", nullable: false),
                    NameStyle = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suffix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailPromotion = table.Column<int>(type: "int", nullable: false),
                    AdditionalContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Demographics = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.BusinessEntityId);
                    table.ForeignKey(
                        name: "FK_Person_BusinessEntity_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalSchema: "Person",
                        principalTable: "BusinessEntity",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Person_PersonType_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalSchema: "Person",
                        principalTable: "PersonType",
                        principalColumn: "PersonTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Person_UserAccount_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalSchema: "Shield",
                        principalTable: "UserAccount",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecurityGroupUserAccount",
                schema: "Shield",
                columns: table => new
                {
                    SecurityGroupUserAccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecurityGroupUserAccountGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    BusinessEntityId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityGroupUserAccount", x => x.SecurityGroupUserAccountId);
                    table.ForeignKey(
                        name: "FK_SecurityGroupUserAccount_BusinessEntity_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalSchema: "Person",
                        principalTable: "BusinessEntity",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SecurityGroupUserAccount_SecurityGroup_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "Shield",
                        principalTable: "SecurityGroup",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SecurityGroupUserAccount_UserAccount_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalSchema: "Shield",
                        principalTable: "UserAccount",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRefreshToken",
                schema: "Shield",
                columns: table => new
                {
                    UserRefreshTokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRefreshTokenGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessEntityId = table.Column<int>(type: "int", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiresOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsExpired = table.Column<bool>(type: "bit", nullable: false, computedColumnSql: "IsExpired"),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    RevokedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRefreshToken", x => x.UserRefreshTokenId);
                    table.ForeignKey(
                        name: "FK_UserRefreshToken_BusinessEntity_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalSchema: "Person",
                        principalTable: "BusinessEntity",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRefreshToken_UserAccount_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalSchema: "Shield",
                        principalTable: "UserAccount",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "HumanResources",
                columns: table => new
                {
                    BusinessEntityId = table.Column<int>(type: "int", nullable: false),
                    NationalIdnumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationLevel = table.Column<short>(type: "smallint", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalariedFlag = table.Column<bool>(type: "bit", nullable: false),
                    VacationHours = table.Column<short>(type: "smallint", nullable: false),
                    SickLeaveHours = table.Column<short>(type: "smallint", nullable: false),
                    CurrentFlag = table.Column<bool>(type: "bit", nullable: false),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.BusinessEntityId);
                    table.ForeignKey(
                        name: "FK_Employee_Person_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalSchema: "Person",
                        principalTable: "Person",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonCreditCard",
                schema: "Sales",
                columns: table => new
                {
                    BusinessEntityId = table.Column<int>(type: "int", nullable: false),
                    CreditCardId = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonCreditCard", x => new { x.BusinessEntityId, x.CreditCardId });
                    table.ForeignKey(
                        name: "FK_PersonCreditCard_CreditCard_CreditCardId",
                        column: x => x.CreditCardId,
                        principalSchema: "Sales",
                        principalTable: "CreditCard",
                        principalColumn: "CreditCardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonCreditCard_Person_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalSchema: "Person",
                        principalTable: "Person",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonPhone",
                schema: "Person",
                columns: table => new
                {
                    BusinessEntityId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumberTypeId = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPhone", x => new { x.BusinessEntityId, x.PhoneNumber, x.PhoneNumberTypeId });
                    table.ForeignKey(
                        name: "FK_PersonPhone_Person_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalSchema: "Person",
                        principalTable: "Person",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonPhone_PhoneNumberType_PhoneNumberTypeId",
                        column: x => x.PhoneNumberTypeId,
                        principalSchema: "Person",
                        principalTable: "PhoneNumberType",
                        principalColumn: "PhoneNumberTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDepartmentHistory",
                schema: "HumanResources",
                columns: table => new
                {
                    BusinessEntityId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<short>(type: "smallint", nullable: false),
                    ShiftId = table.Column<byte>(type: "tinyint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDepartmentHistory", x => new { x.BusinessEntityId, x.DepartmentId, x.ShiftId, x.StartDate });
                    table.ForeignKey(
                        name: "FK_EmployeeDepartmentHistory_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "HumanResources",
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDepartmentHistory_Employee_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDepartmentHistory_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalSchema: "HumanResources",
                        principalTable: "Shift",
                        principalColumn: "ShiftId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePayHistory",
                schema: "HumanResources",
                columns: table => new
                {
                    BusinessEntityId = table.Column<int>(type: "int", nullable: false),
                    RateChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayFrequency = table.Column<byte>(type: "tinyint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePayHistory", x => new { x.BusinessEntityId, x.RateChangeDate });
                    table.ForeignKey(
                        name: "FK_EmployeePayHistory_Employee_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobCandidate",
                schema: "HumanResources",
                columns: table => new
                {
                    JobCandidateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessEntityId = table.Column<int>(type: "int", nullable: true),
                    Resume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCandidate", x => x.JobCandidateId);
                    table.ForeignKey(
                        name: "FK_JobCandidate_Employee_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "BusinessEntityId");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderHeader",
                schema: "Purchasing",
                columns: table => new
                {
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RevisionNumber = table.Column<byte>(type: "tinyint", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    ShipMethodId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShipDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Freight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderHeader", x => x.PurchaseOrderId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderHeader_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderHeader_ShipMethod_ShipMethodId",
                        column: x => x.ShipMethodId,
                        principalSchema: "Purchasing",
                        principalTable: "ShipMethod",
                        principalColumn: "ShipMethodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderHeader_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalSchema: "Purchasing",
                        principalTable: "Vendor",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesPerson",
                schema: "Sales",
                columns: table => new
                {
                    BusinessEntityId = table.Column<int>(type: "int", nullable: false),
                    TerritoryId = table.Column<int>(type: "int", nullable: true),
                    SalesQuota = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Bonus = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CommissionPct = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalesYtd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalesLastYear = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPerson", x => x.BusinessEntityId);
                    table.ForeignKey(
                        name: "FK_SalesPerson_Employee_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesPerson_SalesTerritory_TerritoryId",
                        column: x => x.TerritoryId,
                        principalSchema: "Sales",
                        principalTable: "SalesTerritory",
                        principalColumn: "TerritoryId");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderDetail",
                schema: "Purchasing",
                columns: table => new
                {
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: false),
                    PurchaseOrderDetailId = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderQty = table.Column<short>(type: "smallint", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LineTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReceivedQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RejectedQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockedQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderDetail", x => new { x.PurchaseOrderId, x.PurchaseOrderDetailId });
                    table.ForeignKey(
                        name: "FK_PurchaseOrderDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalSchema: "Purchasing",
                        principalTable: "PurchaseOrderHeader",
                        principalColumn: "PurchaseOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderHeader",
                schema: "Sales",
                columns: table => new
                {
                    SalesOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RevisionNumber = table.Column<byte>(type: "tinyint", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShipDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    OnlineOrderFlag = table.Column<bool>(type: "bit", nullable: false),
                    SalesOrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseOrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SalesPersonId = table.Column<int>(type: "int", nullable: true),
                    TerritoryId = table.Column<int>(type: "int", nullable: true),
                    BillToAddressId = table.Column<int>(type: "int", nullable: false),
                    ShipToAddressId = table.Column<int>(type: "int", nullable: false),
                    ShipMethodId = table.Column<int>(type: "int", nullable: false),
                    CreditCardId = table.Column<int>(type: "int", nullable: true),
                    CreditCardApprovalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyRateId = table.Column<int>(type: "int", nullable: true),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Freight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderHeader", x => x.SalesOrderId);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_Address_BillToAddressId",
                        column: x => x.BillToAddressId,
                        principalSchema: "Person",
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_Address_ShipToAddressId",
                        column: x => x.ShipToAddressId,
                        principalSchema: "Person",
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_CreditCard_CreditCardId",
                        column: x => x.CreditCardId,
                        principalSchema: "Sales",
                        principalTable: "CreditCard",
                        principalColumn: "CreditCardId");
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_CurrencyRate_CurrencyRateId",
                        column: x => x.CurrencyRateId,
                        principalSchema: "Sales",
                        principalTable: "CurrencyRate",
                        principalColumn: "CurrencyRateId");
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Sales",
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_SalesPerson_SalesPersonId",
                        column: x => x.SalesPersonId,
                        principalSchema: "Sales",
                        principalTable: "SalesPerson",
                        principalColumn: "BusinessEntityId");
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_SalesTerritory_TerritoryId",
                        column: x => x.TerritoryId,
                        principalSchema: "Sales",
                        principalTable: "SalesTerritory",
                        principalColumn: "TerritoryId");
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_ShipMethod_ShipMethodId",
                        column: x => x.ShipMethodId,
                        principalSchema: "Purchasing",
                        principalTable: "ShipMethod",
                        principalColumn: "ShipMethodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesPersonQuotaHistory",
                schema: "Sales",
                columns: table => new
                {
                    BusinessEntityId = table.Column<int>(type: "int", nullable: false),
                    QuotaDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalesQuota = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalesPersonBusinessEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPersonQuotaHistory", x => new { x.BusinessEntityId, x.QuotaDate });
                    table.ForeignKey(
                        name: "FK_SalesPersonQuotaHistory_SalesPerson_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalSchema: "Sales",
                        principalTable: "SalesPerson",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesPersonQuotaHistory_SalesPerson_SalesPersonBusinessEntityId",
                        column: x => x.SalesPersonBusinessEntityId,
                        principalSchema: "Sales",
                        principalTable: "SalesPerson",
                        principalColumn: "BusinessEntityId");
                });

            migrationBuilder.CreateTable(
                name: "SalesTerritoryHistory",
                schema: "Sales",
                columns: table => new
                {
                    BusinessEntityId = table.Column<int>(type: "int", nullable: false),
                    TerritoryId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalesPersonBusinessEntityId = table.Column<int>(type: "int", nullable: true),
                    SalesTerritoryEntityTerritoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTerritoryHistory", x => new { x.BusinessEntityId, x.TerritoryId, x.StartDate });
                    table.ForeignKey(
                        name: "FK_SalesTerritoryHistory_SalesPerson_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalSchema: "Sales",
                        principalTable: "SalesPerson",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesTerritoryHistory_SalesPerson_SalesPersonBusinessEntityId",
                        column: x => x.SalesPersonBusinessEntityId,
                        principalSchema: "Sales",
                        principalTable: "SalesPerson",
                        principalColumn: "BusinessEntityId");
                    table.ForeignKey(
                        name: "FK_SalesTerritoryHistory_SalesTerritory_SalesTerritoryEntityTerritoryId",
                        column: x => x.SalesTerritoryEntityTerritoryId,
                        principalSchema: "Sales",
                        principalTable: "SalesTerritory",
                        principalColumn: "TerritoryId");
                    table.ForeignKey(
                        name: "FK_SalesTerritoryHistory_SalesTerritory_TerritoryId",
                        column: x => x.TerritoryId,
                        principalSchema: "Sales",
                        principalTable: "SalesTerritory",
                        principalColumn: "TerritoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                schema: "Sales",
                columns: table => new
                {
                    BusinessEntityId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesPersonId = table.Column<int>(type: "int", nullable: true),
                    Demographics = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.BusinessEntityId);
                    table.ForeignKey(
                        name: "FK_Store_BusinessEntity_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalSchema: "Person",
                        principalTable: "BusinessEntity",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Store_SalesPerson_SalesPersonId",
                        column: x => x.SalesPersonId,
                        principalSchema: "Sales",
                        principalTable: "SalesPerson",
                        principalColumn: "BusinessEntityId");
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderDetail",
                schema: "Sales",
                columns: table => new
                {
                    SalesOrderId = table.Column<int>(type: "int", nullable: false),
                    SalesOrderDetailId = table.Column<int>(type: "int", nullable: false),
                    CarrierTrackingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderQty = table.Column<short>(type: "smallint", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SpecialOfferId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPriceDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LineTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderDetail", x => new { x.SalesOrderId, x.SalesOrderDetailId });
                    table.ForeignKey(
                        name: "FK_SalesOrderDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderDetail_SalesOrderHeader_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalSchema: "Sales",
                        principalTable: "SalesOrderHeader",
                        principalColumn: "SalesOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferId_ProductId",
                        columns: x => new { x.SpecialOfferId, x.ProductId },
                        principalSchema: "Sales",
                        principalTable: "SpecialOfferProduct",
                        principalColumns: new[] { "SpecialOfferId", "ProductId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderHeaderSalesReason",
                schema: "Sales",
                columns: table => new
                {
                    SalesOrderId = table.Column<int>(type: "int", nullable: false),
                    SalesReasonId = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalesReasonId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderHeaderSalesReason", x => new { x.SalesOrderId, x.SalesReasonId });
                    table.ForeignKey(
                        name: "FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalSchema: "Sales",
                        principalTable: "SalesOrderHeader",
                        principalColumn: "SalesOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonId",
                        column: x => x.SalesReasonId,
                        principalSchema: "Sales",
                        principalTable: "SalesReason",
                        principalColumn: "SalesReasonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonId1",
                        column: x => x.SalesReasonId1,
                        principalSchema: "Sales",
                        principalTable: "SalesReason",
                        principalColumn: "SalesReasonId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_StateProvinceId",
                schema: "Person",
                table: "Address",
                column: "StateProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_BillOfMaterials_ComponentId",
                schema: "Production",
                table: "BillOfMaterials",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_BillOfMaterials_ProductAssemblyId",
                schema: "Production",
                table: "BillOfMaterials",
                column: "ProductAssemblyId");

            migrationBuilder.CreateIndex(
                name: "IX_BillOfMaterials_UnitMeasureCode",
                schema: "Production",
                table: "BillOfMaterials",
                column: "UnitMeasureCode");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEntityAddress_AddressId",
                schema: "Person",
                table: "BusinessEntityAddress",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEntityAddress_AddressTypeId",
                schema: "Person",
                table: "BusinessEntityAddress",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEntityContact_ContactTypeId",
                schema: "Person",
                table: "BusinessEntityContact",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEntityContact_PersonId",
                schema: "Person",
                table: "BusinessEntityContact",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryRegionCurrency_CurrencyCode",
                schema: "Sales",
                table: "CountryRegionCurrency",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_CountryRegionCurrency_CurrencyCode1",
                schema: "Sales",
                table: "CountryRegionCurrency",
                column: "CurrencyCode1");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyRate_CurrencyCode",
                schema: "Sales",
                table: "CurrencyRate",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyRate_CurrencyCode1",
                schema: "Sales",
                table: "CurrencyRate",
                column: "CurrencyCode1");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyRate_FromCurrencyCode",
                schema: "Sales",
                table: "CurrencyRate",
                column: "FromCurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyRate_ToCurrencyCode",
                schema: "Sales",
                table: "CurrencyRate",
                column: "ToCurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PersonId",
                schema: "Sales",
                table: "Customer",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_StoreId",
                schema: "Sales",
                table: "Customer",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_TerritoryId",
                schema: "Sales",
                table: "Customer",
                column: "TerritoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddress_BusinessEntityId",
                schema: "Person",
                table: "EmailAddress",
                column: "BusinessEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartmentHistory_DepartmentId",
                schema: "HumanResources",
                table: "EmployeeDepartmentHistory",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartmentHistory_ShiftId",
                schema: "HumanResources",
                table: "EmployeeDepartmentHistory",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCandidate_BusinessEntityId",
                schema: "HumanResources",
                table: "JobCandidate",
                column: "BusinessEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PersonTypeId",
                schema: "Person",
                table: "Person",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonCreditCard_CreditCardId",
                schema: "Sales",
                table: "PersonCreditCard",
                column: "CreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPhone_PhoneNumberTypeId",
                schema: "Person",
                table: "PersonPhone",
                column: "PhoneNumberTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductModelId",
                schema: "Production",
                table: "Product",
                column: "ProductModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductSubcategoryId",
                schema: "Production",
                table: "Product",
                column: "ProductSubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SizeUnitMeasureCode",
                schema: "Production",
                table: "Product",
                column: "SizeUnitMeasureCode");

            migrationBuilder.CreateIndex(
                name: "IX_Product_WeightUnitMeasureCode",
                schema: "Production",
                table: "Product",
                column: "WeightUnitMeasureCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventory_LocationId",
                schema: "Production",
                table: "ProductInventory",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModelIllustration_IllustrationId",
                schema: "Production",
                table: "ProductModelIllustration",
                column: "IllustrationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModelIllustration_IllustrationId1",
                schema: "Production",
                table: "ProductModelIllustration",
                column: "IllustrationId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModelIllustration_ProductModelId1",
                schema: "Production",
                table: "ProductModelIllustration",
                column: "ProductModelId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModelProductDescriptionCulture_ProductDescriptionId",
                schema: "Production",
                table: "ProductModelProductDescriptionCulture",
                column: "ProductDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModelProductDescriptionCulture_ProductDescriptionId1",
                schema: "Production",
                table: "ProductModelProductDescriptionCulture",
                column: "ProductDescriptionId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModelProductDescriptionCulture_ProductModelId1",
                schema: "Production",
                table: "ProductModelProductDescriptionCulture",
                column: "ProductModelId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductPhoto_ProductPhotoId",
                schema: "Production",
                table: "ProductProductPhoto",
                column: "ProductPhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_ProductId",
                schema: "Production",
                table: "ProductReview",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSubcategory_ProductCategoryId",
                schema: "Production",
                table: "ProductSubcategory",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVendor_BusinessEntityId",
                schema: "Purchasing",
                table: "ProductVendor",
                column: "BusinessEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVendor_UnitMeasureCode",
                schema: "Purchasing",
                table: "ProductVendor",
                column: "UnitMeasureCode");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderDetail_ProductId",
                schema: "Purchasing",
                table: "PurchaseOrderDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderHeader_EmployeeId",
                schema: "Purchasing",
                table: "PurchaseOrderHeader",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderHeader_ShipMethodId",
                schema: "Purchasing",
                table: "PurchaseOrderHeader",
                column: "ShipMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderHeader_VendorId",
                schema: "Purchasing",
                table: "PurchaseOrderHeader",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderDetail_ProductId",
                schema: "Sales",
                table: "SalesOrderDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderDetail_SpecialOfferId_ProductId",
                schema: "Sales",
                table: "SalesOrderDetail",
                columns: new[] { "SpecialOfferId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_BillToAddressId",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "BillToAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_CreditCardId",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "CreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_CurrencyRateId",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "CurrencyRateId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_CustomerId",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_SalesPersonId",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "SalesPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_ShipMethodId",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "ShipMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_ShipToAddressId",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "ShipToAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_TerritoryId",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "TerritoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeaderSalesReason_SalesReasonId",
                schema: "Sales",
                table: "SalesOrderHeaderSalesReason",
                column: "SalesReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeaderSalesReason_SalesReasonId1",
                schema: "Sales",
                table: "SalesOrderHeaderSalesReason",
                column: "SalesReasonId1");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPerson_TerritoryId",
                schema: "Sales",
                table: "SalesPerson",
                column: "TerritoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPersonQuotaHistory_SalesPersonBusinessEntityId",
                schema: "Sales",
                table: "SalesPersonQuotaHistory",
                column: "SalesPersonBusinessEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTaxRate_StateProvinceEntityStateProvinceId",
                schema: "Sales",
                table: "SalesTaxRate",
                column: "StateProvinceEntityStateProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTaxRate_StateProvinceId",
                schema: "Sales",
                table: "SalesTaxRate",
                column: "StateProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTerritory_CountryRegionCode",
                schema: "Sales",
                table: "SalesTerritory",
                column: "CountryRegionCode");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTerritoryHistory_SalesPersonBusinessEntityId",
                schema: "Sales",
                table: "SalesTerritoryHistory",
                column: "SalesPersonBusinessEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTerritoryHistory_SalesTerritoryEntityTerritoryId",
                schema: "Sales",
                table: "SalesTerritoryHistory",
                column: "SalesTerritoryEntityTerritoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTerritoryHistory_TerritoryId",
                schema: "Sales",
                table: "SalesTerritoryHistory",
                column: "TerritoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityGroupSecurityFunction_FunctionId",
                schema: "Shield",
                table: "SecurityGroupSecurityFunction",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityGroupSecurityFunction_GroupId",
                schema: "Shield",
                table: "SecurityGroupSecurityFunction",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityGroupSecurityRole_GroupId",
                schema: "Shield",
                table: "SecurityGroupSecurityRole",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityGroupSecurityRole_RoleId",
                schema: "Shield",
                table: "SecurityGroupSecurityRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityGroupUserAccount_BusinessEntityId",
                schema: "Shield",
                table: "SecurityGroupUserAccount",
                column: "BusinessEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityGroupUserAccount_GroupId",
                schema: "Shield",
                table: "SecurityGroupUserAccount",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ProductId",
                schema: "Sales",
                table: "ShoppingCartItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialOfferProduct_ProductId",
                schema: "Sales",
                table: "SpecialOfferProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StateProvince_CountryRegionCode",
                schema: "Person",
                table: "StateProvince",
                column: "CountryRegionCode");

            migrationBuilder.CreateIndex(
                name: "IX_StateProvince_TerritoryId",
                schema: "Person",
                table: "StateProvince",
                column: "TerritoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_SalesPersonId",
                schema: "Sales",
                table: "Store",
                column: "SalesPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_ProductId",
                schema: "Production",
                table: "TransactionHistory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_PrimaryEmailAddressId",
                schema: "Shield",
                table: "UserAccount",
                column: "PrimaryEmailAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshToken_BusinessEntityId",
                schema: "Shield",
                table: "UserRefreshToken",
                column: "BusinessEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrder_ProductId",
                schema: "Production",
                table: "WorkOrder",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrder_ScrapReasonId",
                schema: "Production",
                table: "WorkOrder",
                column: "ScrapReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderRouting_LocationId",
                schema: "Production",
                table: "WorkOrderRouting",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderRouting_ProductId",
                schema: "Production",
                table: "WorkOrderRouting",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessEntityContact_Person_PersonId",
                schema: "Person",
                table: "BusinessEntityContact",
                column: "PersonId",
                principalSchema: "Person",
                principalTable: "Person",
                principalColumn: "BusinessEntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Person_PersonId",
                schema: "Sales",
                table: "Customer",
                column: "PersonId",
                principalSchema: "Person",
                principalTable: "Person",
                principalColumn: "BusinessEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Store_StoreId",
                schema: "Sales",
                table: "Customer",
                column: "StoreId",
                principalSchema: "Sales",
                principalTable: "Store",
                principalColumn: "BusinessEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailAddress_Person_BusinessEntityId",
                schema: "Person",
                table: "EmailAddress",
                column: "BusinessEntityId",
                principalSchema: "Person",
                principalTable: "Person",
                principalColumn: "BusinessEntityId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_BusinessEntity_BusinessEntityId",
                schema: "Person",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_BusinessEntity_BusinessEntityId",
                schema: "Shield",
                table: "UserAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailAddress_Person_BusinessEntityId",
                schema: "Person",
                table: "EmailAddress");

            migrationBuilder.DropTable(
                name: "BillOfMaterials",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "BusinessEntityAddress",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "BusinessEntityContact",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "CountryRegionCurrency",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "EmployeeDepartmentHistory",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "EmployeePayHistory",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "JobCandidate",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "PersonCreditCard",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "PersonPhone",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "ProductCostHistory",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductInventory",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductListPriceHistory",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductModelIllustration",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductModelProductDescriptionCulture",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductProductPhoto",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductReview",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductVendor",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "PurchaseOrderDetail",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "SalesOrderDetail",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesOrderHeaderSalesReason",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesPersonQuotaHistory",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesTaxRate",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesTerritoryHistory",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SecurityGroupSecurityFunction",
                schema: "Shield");

            migrationBuilder.DropTable(
                name: "SecurityGroupSecurityRole",
                schema: "Shield");

            migrationBuilder.DropTable(
                name: "SecurityGroupUserAccount",
                schema: "Shield");

            migrationBuilder.DropTable(
                name: "ShoppingCartItem",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "TransactionHistory",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "TransactionHistoryArchive",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "UserRefreshToken",
                schema: "Shield");

            migrationBuilder.DropTable(
                name: "WorkOrderRouting",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "AddressType",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "ContactType",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "Shift",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "PhoneNumberType",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "Illustration",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductDescription",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductPhoto",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "PurchaseOrderHeader",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "SpecialOfferProduct",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesOrderHeader",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesReason",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SecurityFunction",
                schema: "Shield");

            migrationBuilder.DropTable(
                name: "SecurityRole",
                schema: "Shield");

            migrationBuilder.DropTable(
                name: "SecurityGroup",
                schema: "Shield");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "WorkOrder",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "Vendor",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "SpecialOffer",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "CreditCard",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "CurrencyRate",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "ShipMethod",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ScrapReason",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "StateProvince",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "Currency",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Store",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "ProductModel",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductSubcategory",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "UnitMeasure",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "SalesPerson",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "SalesTerritory",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "CountryRegion",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "BusinessEntity",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "PersonType",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "UserAccount",
                schema: "Shield");

            migrationBuilder.DropTable(
                name: "EmailAddress",
                schema: "Person");
        }
    }
}
