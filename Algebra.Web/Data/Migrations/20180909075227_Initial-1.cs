using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Algebra.Web.Data.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IpAddress = table.Column<string>(maxLength: 20, nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Type = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IpAddress = table.Column<string>(maxLength: 20, nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Individual = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    Couple = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    Dependent = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    GSTRate = table.Column<string>(maxLength: 50, nullable: false),
                    GSTAmount = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IpAddress = table.Column<string>(maxLength: 20, nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Digits = table.Column<string>(maxLength: 20, nullable: true),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<short>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    MembershipEndDate = table.Column<DateTime>(nullable: false),
                    MembershipStartDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CardId = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    ImagePath = table.Column<string>(maxLength: 100, nullable: true),
                    IpAddress = table.Column<string>(maxLength: 20, nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    AccountId = table.Column<string>(maxLength: 50, nullable: false),
                    ReferredBy = table.Column<short>(nullable: false),
                    MembershipType = table.Column<short>(nullable: false),
                    Title = table.Column<short>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 200, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 200, nullable: true),
                    LastName = table.Column<string>(maxLength: 200, nullable: false),
                    ProfessionalTitle = table.Column<string>(maxLength: 100, nullable: true),
                    Designation = table.Column<string>(maxLength: 100, nullable: true),
                    Organization = table.Column<string>(maxLength: 200, nullable: true),
                    TelephoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    PresentAddress = table.Column<string>(maxLength: 500, nullable: true),
                    PresentCity = table.Column<string>(maxLength: 100, nullable: true),
                    PresentState = table.Column<string>(maxLength: 100, nullable: true),
                    PresentPin = table.Column<string>(maxLength: 10, nullable: true),
                    PermanentAddress = table.Column<string>(maxLength: 500, nullable: true),
                    PermanentCity = table.Column<string>(maxLength: 100, nullable: true),
                    PermanentState = table.Column<string>(maxLength: 100, nullable: true),
                    PermanentPin = table.Column<string>(maxLength: 10, nullable: true),
                    PrimaryMobileNumber = table.Column<string>(maxLength: 50, nullable: false),
                    SecondaryMobileNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Location = table.Column<string>(maxLength: 50, nullable: true),
                    LocationId = table.Column<short>(nullable: false),
                    FormPath = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    MaritalStatus = table.Column<short>(nullable: false),
                    Occupation = table.Column<short>(nullable: false),
                    SponcerId = table.Column<int>(nullable: false),
                    Addressed = table.Column<string>(maxLength: 100, nullable: true),
                    MemberDOB = table.Column<DateTime>(nullable: false),
                    AnnualIncome = table.Column<decimal>(type: "decimal(10,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IpAddress = table.Column<string>(maxLength: 20, nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Text = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Referrer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IpAddress = table.Column<string>(maxLength: 20, nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referrer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    AccessFailedCount = table.Column<int>(nullable: false),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Notes = table.Column<string>(maxLength: 400, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Flags = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dependent",
                columns: table => new
                {
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<short>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    MembershipEndDate = table.Column<DateTime>(nullable: false),
                    MembershipStartDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CardId = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    ImagePath = table.Column<string>(maxLength: 100, nullable: true),
                    IpAddress = table.Column<string>(maxLength: 20, nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    MemberId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 200, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 200, nullable: true),
                    LastName = table.Column<string>(maxLength: 200, nullable: false),
                    MobileNumber = table.Column<string>(maxLength: 50, nullable: true),
                    DependentDOB = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dependent_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IpAddress = table.Column<string>(maxLength: 20, nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    MemberId = table.Column<int>(nullable: false),
                    MembershipFee = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    GST = table.Column<string>(maxLength: 50, nullable: true),
                    TaxAmount = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    PaymentMode = table.Column<short>(nullable: false),
                    PayeeName = table.Column<string>(maxLength: 500, nullable: true),
                    TransactionId = table.Column<string>(maxLength: 50, nullable: true),
                    IsDiscountApplicable = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    MembershipFeeId = table.Column<short>(nullable: false),
                    BankName = table.Column<string>(maxLength: 100, nullable: true),
                    PaymentRecievedBy = table.Column<string>(maxLength: 100, nullable: true),
                    PaymentStatus = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spouse",
                columns: table => new
                {
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<short>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    MembershipEndDate = table.Column<DateTime>(nullable: false),
                    MembershipStartDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CardId = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    ImagePath = table.Column<string>(maxLength: 100, nullable: true),
                    IpAddress = table.Column<string>(maxLength: 20, nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    MemberId = table.Column<int>(nullable: false),
                    Title = table.Column<short>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    PrimaryMobileNumber = table.Column<string>(maxLength: 50, nullable: false),
                    SecondaryMobileNumber = table.Column<string>(maxLength: 50, nullable: true),
                    TelephoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    ProfessionalTitle = table.Column<string>(maxLength: 50, nullable: true),
                    Designation = table.Column<string>(maxLength: 100, nullable: true),
                    Organization = table.Column<string>(maxLength: 100, nullable: true),
                    PresentAddress = table.Column<string>(maxLength: 200, nullable: true),
                    PresentCity = table.Column<string>(maxLength: 100, nullable: true),
                    PresentState = table.Column<string>(maxLength: 100, nullable: true),
                    PresentPin = table.Column<string>(maxLength: 10, nullable: true),
                    PermanentAddress = table.Column<string>(maxLength: 500, nullable: true),
                    PermanentCity = table.Column<string>(maxLength: 100, nullable: true),
                    PermanentState = table.Column<string>(maxLength: 100, nullable: true),
                    PermanentPin = table.Column<string>(maxLength: 10, nullable: true),
                    MaritalStatus = table.Column<short>(nullable: false),
                    Occupation = table.Column<short>(nullable: false),
                    SponcerId = table.Column<int>(nullable: false),
                    Addressed = table.Column<string>(maxLength: 100, nullable: true),
                    SpouseDOB = table.Column<DateTime>(nullable: false),
                    AnnualIncome = table.Column<decimal>(type: "decimal(10,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spouse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spouse_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<string>(maxLength: 50, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Value = table.Column<string>(maxLength: 50, nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Token_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cheque",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IpAddress = table.Column<string>(maxLength: 20, nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    PaymentId = table.Column<int>(nullable: false),
                    Number = table.Column<string>(maxLength: 50, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    BankName = table.Column<string>(maxLength: 100, nullable: true),
                    DrawnOn = table.Column<string>(maxLength: 100, nullable: true),
                    ChequeStatus = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cheque_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Cheque_PaymentId",
                table: "Cheque",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependent_MemberId",
                table: "Dependent",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_MemberId",
                table: "Payment",
                column: "MemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spouse_MemberId",
                table: "Spouse",
                column: "MemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Token_UserId",
                table: "Token",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Cheque");

            migrationBuilder.DropTable(
                name: "Dependent");

            migrationBuilder.DropTable(
                name: "Fee");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Mode");

            migrationBuilder.DropTable(
                name: "Referrer");

            migrationBuilder.DropTable(
                name: "Spouse");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Member");
        }
    }
}
