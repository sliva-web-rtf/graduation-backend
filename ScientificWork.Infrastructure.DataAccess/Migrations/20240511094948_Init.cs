using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ScientificWork.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", unicode: false, maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", unicode: false, maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataProtectionKeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FriendlyName = table.Column<string>(type: "text", unicode: false, nullable: true),
                    Xml = table.Column<string>(type: "text", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataProtectionKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScientificAreas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScientificInterests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", unicode: false, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificInterests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    Patronymic = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    LastLogin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastTokenResetAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RemovedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Contacts = table.Column<string>(type: "text", unicode: false, nullable: true),
                    About = table.Column<string>(type: "text", unicode: false, nullable: true),
                    IsRegistrationComplete = table.Column<bool>(type: "boolean", nullable: false),
                    UserStatus = table.Column<int>(type: "integer", nullable: false),
                    AvatarImagePath = table.Column<string>(type: "text", unicode: false, nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", unicode: false, maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", unicode: false, maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", unicode: false, maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", unicode: false, maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", unicode: false, nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", unicode: false, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", unicode: false, nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", unicode: false, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", unicode: false, nullable: true),
                    ClaimValue = table.Column<string>(type: "text", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScientificAreaSubsections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ScientificAreaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificAreaSubsections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScientificAreaSubsections_ScientificAreas_ScientificAreaId",
                        column: x => x.ScientificAreaId,
                        principalTable: "ScientificAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", unicode: false, nullable: true),
                    ClaimValue = table.Column<string>(type: "text", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", unicode: false, nullable: false),
                    ProviderKey = table.Column<string>(type: "text", unicode: false, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", unicode: false, nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", unicode: false, nullable: false),
                    Name = table.Column<string>(type: "text", unicode: false, nullable: false),
                    Value = table.Column<string>(type: "text", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Message = table.Column<string>(type: "text", unicode: false, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Address = table.Column<string>(type: "text", unicode: false, nullable: true),
                    Degree = table.Column<string>(type: "text", unicode: false, nullable: true),
                    Post = table.Column<string>(type: "text", unicode: false, nullable: true),
                    Limit = table.Column<int>(type: "integer", nullable: false),
                    Fullness = table.Column<int>(type: "integer", nullable: false),
                    WorkExperienceYears = table.Column<int>(type: "integer", nullable: false),
                    ScopusUri = table.Column<string>(type: "text", unicode: false, nullable: true),
                    RISCUri = table.Column<string>(type: "text", unicode: false, nullable: true),
                    URPUri = table.Column<string>(type: "text", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professors_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Degree = table.Column<string>(type: "text", unicode: false, nullable: true),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    PublicationsCount = table.Column<int>(type: "integer", nullable: false),
                    HIndex = table.Column<int>(type: "integer", nullable: false),
                    SearchStatus_Status = table.Column<int>(type: "integer", nullable: true),
                    SearchStatus_CommandSearching = table.Column<bool>(type: "boolean", nullable: true),
                    SearchStatus_ProfessorSearching = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemAdmins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemAdmins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemAdmins_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", unicode: false, nullable: false),
                    Token = table.Column<string>(type: "text", unicode: false, nullable: false),
                    IssuedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.Description });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorScientificAreaSubsection",
                columns: table => new
                {
                    ProfessorsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScientificAreaSubsectionsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorScientificAreaSubsection", x => new { x.ProfessorsId, x.ScientificAreaSubsectionsId });
                    table.ForeignKey(
                        name: "FK_ProfessorScientificAreaSubsection_Professors_ProfessorsId",
                        column: x => x.ProfessorsId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfessorScientificAreaSubsection_ScientificAreaSubsections~",
                        column: x => x.ScientificAreaSubsectionsId,
                        principalTable: "ScientificAreaSubsections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorScientificInterest",
                columns: table => new
                {
                    ProfessorsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScientificInterestsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorScientificInterest", x => new { x.ProfessorsId, x.ScientificInterestsId });
                    table.ForeignKey(
                        name: "FK_ProfessorScientificInterest_Professors_ProfessorsId",
                        column: x => x.ProfessorsId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfessorScientificInterest_ScientificInterests_ScientificI~",
                        column: x => x.ScientificInterestsId,
                        principalTable: "ScientificInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScientificWorks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", unicode: false, nullable: false),
                    Description = table.Column<string>(type: "text", unicode: false, nullable: false),
                    Limit = table.Column<int>(type: "integer", nullable: false),
                    Result = table.Column<string>(type: "text", unicode: false, nullable: false),
                    Fullness = table.Column<int>(type: "integer", nullable: false),
                    WorkStatus = table.Column<int>(type: "integer", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProfessorId = table.Column<Guid>(type: "uuid", nullable: true),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScientificWorks_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProfessorFavoriteStudent",
                columns: table => new
                {
                    ProfessorId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorFavoriteStudent", x => new { x.ProfessorId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_ProfessorFavoriteStudent_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfessorFavoriteStudent_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScientificAreaSubsectionStudent",
                columns: table => new
                {
                    ScientificAreaSubsectionsId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificAreaSubsectionStudent", x => new { x.ScientificAreaSubsectionsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_ScientificAreaSubsectionStudent_ScientificAreaSubsections_S~",
                        column: x => x.ScientificAreaSubsectionsId,
                        principalTable: "ScientificAreaSubsections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScientificAreaSubsectionStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScientificInterestStudent",
                columns: table => new
                {
                    ScientificInterestsId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificInterestStudent", x => new { x.ScientificInterestsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_ScientificInterestStudent_ScientificInterests_ScientificInt~",
                        column: x => x.ScientificInterestsId,
                        principalTable: "ScientificInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScientificInterestStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentFavoriteProfessor",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfessorId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFavoriteProfessor", x => new { x.StudentId, x.ProfessorId });
                    table.ForeignKey(
                        name: "FK_StudentFavoriteProfessor_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentFavoriteProfessor_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentFavoriteStudent",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    FavoriteStudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFavoriteStudent", x => new { x.StudentId, x.FavoriteStudentId });
                    table.ForeignKey(
                        name: "FK_StudentFavoriteStudent_Students_FavoriteStudentId",
                        column: x => x.FavoriteStudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentFavoriteStudent_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorFavoriteScientificWork",
                columns: table => new
                {
                    ProfessorId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScientificWorkId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorFavoriteScientificWork", x => new { x.ProfessorId, x.ScientificWorkId });
                    table.ForeignKey(
                        name: "FK_ProfessorFavoriteScientificWork_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfessorFavoriteScientificWork_ScientificWorks_ScientificW~",
                        column: x => x.ScientificWorkId,
                        principalTable: "ScientificWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScientificAreaSubsectionScientificWork",
                columns: table => new
                {
                    ScientificAreaSubsectionsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScientificWorksId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificAreaSubsectionScientificWork", x => new { x.ScientificAreaSubsectionsId, x.ScientificWorksId });
                    table.ForeignKey(
                        name: "FK_ScientificAreaSubsectionScientificWork_ScientificAreaSubsec~",
                        column: x => x.ScientificAreaSubsectionsId,
                        principalTable: "ScientificAreaSubsections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScientificAreaSubsectionScientificWork_ScientificWorks_Scie~",
                        column: x => x.ScientificWorksId,
                        principalTable: "ScientificWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScientificInterestScientificWork",
                columns: table => new
                {
                    ScientificInterestsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScientificWorksId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificInterestScientificWork", x => new { x.ScientificInterestsId, x.ScientificWorksId });
                    table.ForeignKey(
                        name: "FK_ScientificInterestScientificWork_ScientificInterests_Scient~",
                        column: x => x.ScientificInterestsId,
                        principalTable: "ScientificInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScientificInterestScientificWork_ScientificWorks_Scientific~",
                        column: x => x.ScientificWorksId,
                        principalTable: "ScientificWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScientificWorkStudent",
                columns: table => new
                {
                    ScientificWorksId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificWorkStudent", x => new { x.ScientificWorksId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_ScientificWorkStudent_ScientificWorks_ScientificWorksId",
                        column: x => x.ScientificWorksId,
                        principalTable: "ScientificWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScientificWorkStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentFavoriteScientificWork",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScientificWorkId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFavoriteScientificWork", x => new { x.StudentId, x.ScientificWorkId });
                    table.ForeignKey(
                        name: "FK_StudentFavoriteScientificWork_ScientificWorks_ScientificWor~",
                        column: x => x.ScientificWorkId,
                        principalTable: "ScientificWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentFavoriteScientificWork_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentRequestProfessors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfessorId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScientificWorkId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentRequestProfessors", x => new { x.StudentId, x.ProfessorId, x.Id });
                    table.ForeignKey(
                        name: "FK_StudentRequestProfessors_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentRequestProfessors_ScientificWorks_ScientificWorkId",
                        column: x => x.ScientificWorkId,
                        principalTable: "ScientificWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentRequestProfessors_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentRequestStudents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentToId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentFromId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScientificWorkId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentRequestStudents", x => new { x.StudentFromId, x.StudentToId, x.Id });
                    table.ForeignKey(
                        name: "FK_StudentRequestStudents_ScientificWorks_ScientificWorkId",
                        column: x => x.ScientificWorkId,
                        principalTable: "ScientificWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentRequestStudents_Students_StudentFromId",
                        column: x => x.StudentFromId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentRequestStudents_Students_StudentToId",
                        column: x => x.StudentToId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ScientificAreas",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("13fa67ac-7d44-4d9d-9fd5-0bab99b78354"), "Естественные науки" },
                    { new Guid("716ba49a-504a-466d-a005-0d344e92df98"), "Гуманитарные науки" },
                    { new Guid("800e6c9d-87fb-467a-8f3f-1d81e4b60f8d"), "Техника и технологии" },
                    { new Guid("95d23fd7-5a90-4043-8eda-b12c637ebe1b"), "Сельскохозяйственные науки" },
                    { new Guid("a8277c69-2a4f-4f94-ab92-043c839c6f5b"), "Медицина и здравоохранение" },
                    { new Guid("d8fb160d-402e-4223-b715-fe34843f3f3f"), "Общественные науки" }
                });

            migrationBuilder.InsertData(
                table: "ScientificAreaSubsections",
                columns: new[] { "Id", "Name", "ScientificAreaId" },
                values: new object[,]
                {
                    { new Guid("04e5dfaf-031c-4929-9d3a-f67621f1df53"), "Социология", new Guid("d8fb160d-402e-4223-b715-fe34843f3f3f") },
                    { new Guid("06959a5d-b4a8-4ad9-94e9-52ea54053744"), "Сельскохозяйственная биотехнология", new Guid("95d23fd7-5a90-4043-8eda-b12c637ebe1b") },
                    { new Guid("07ff0cc3-b7a3-41aa-8693-0b24c0a90ee7"), "Промышленная биотехнология", new Guid("800e6c9d-87fb-467a-8f3f-1d81e4b60f8d") },
                    { new Guid("09f82fb0-f0ab-4b7d-9009-347f56fe76cb"), "Химическая инженерия", new Guid("800e6c9d-87fb-467a-8f3f-1d81e4b60f8d") },
                    { new Guid("0e3081a9-7cb0-4221-a36b-2609562252ca"), "Другие сельскохозяйственные науки", new Guid("95d23fd7-5a90-4043-8eda-b12c637ebe1b") },
                    { new Guid("13988d17-be35-4817-81d7-dd56f46bb670"), "Искусство (искусство, история искусств, исполнительское искусство, музыка)", new Guid("716ba49a-504a-466d-a005-0d344e92df98") },
                    { new Guid("14703d65-3e98-41fe-b702-4f2966222357"), "Образовательные науки", new Guid("d8fb160d-402e-4223-b715-fe34843f3f3f") },
                    { new Guid("2095f155-ecb5-4142-8032-efda6a985f6d"), "Науки о Земле и окружающей среде", new Guid("13fa67ac-7d44-4d9d-9fd5-0bab99b78354") },
                    { new Guid("31c8065d-206d-47c5-b9af-baf48326039a"), "Другие медицинские науки", new Guid("a8277c69-2a4f-4f94-ab92-043c839c6f5b") },
                    { new Guid("343f7368-c018-4305-ad0b-7043abee59e9"), "Компьютерные и информационные науки", new Guid("13fa67ac-7d44-4d9d-9fd5-0bab99b78354") },
                    { new Guid("44438ef1-1ce7-4cb3-a3b0-cf9e4e44fa1f"), "Биология", new Guid("13fa67ac-7d44-4d9d-9fd5-0bab99b78354") },
                    { new Guid("46234b50-4fca-425c-836c-03d9b75822f3"), "Фундаментальная медицина", new Guid("a8277c69-2a4f-4f94-ab92-043c839c6f5b") },
                    { new Guid("483fea58-b214-4cdf-bc18-370978da907f"), "Право", new Guid("d8fb160d-402e-4223-b715-fe34843f3f3f") },
                    { new Guid("49e04bef-c6f1-427b-9f9c-588a06b07336"), "Другая инженерия и технологии", new Guid("800e6c9d-87fb-467a-8f3f-1d81e4b60f8d") },
                    { new Guid("5a0a9cdc-578b-4eca-9c42-996a7b54bf0e"), "Материаловедение", new Guid("800e6c9d-87fb-467a-8f3f-1d81e4b60f8d") },
                    { new Guid("5acbade9-e537-42dd-8cd8-51042e7462e4"), "Клиническая медицина", new Guid("a8277c69-2a4f-4f94-ab92-043c839c6f5b") },
                    { new Guid("6d263e54-a386-498f-8085-bb41301983b3"), "Математика", new Guid("13fa67ac-7d44-4d9d-9fd5-0bab99b78354") },
                    { new Guid("77908fc8-489a-439b-bb9a-8423791477f0"), "Философия, этика и религия", new Guid("716ba49a-504a-466d-a005-0d344e92df98") },
                    { new Guid("7d9dd3a3-7d64-410a-b0ca-e5dbdbf18533"), "Гражданское строительство", new Guid("800e6c9d-87fb-467a-8f3f-1d81e4b60f8d") },
                    { new Guid("804f0cd2-222c-47a1-bc52-f971b4e370a2"), "Медицинская инженерия", new Guid("800e6c9d-87fb-467a-8f3f-1d81e4b60f8d") },
                    { new Guid("8b60b6b8-c7c0-4706-8cf2-857eecdd8ccf"), "Медицинская биотехнология", new Guid("a8277c69-2a4f-4f94-ab92-043c839c6f5b") },
                    { new Guid("98bbc039-ebf8-4004-97eb-93cdec4b9370"), "Ветеринария", new Guid("95d23fd7-5a90-4043-8eda-b12c637ebe1b") },
                    { new Guid("9bbf0a77-a72a-4c74-bbb6-0e6d7a00e6a4"), "Социально-экономическая география", new Guid("d8fb160d-402e-4223-b715-fe34843f3f3f") },
                    { new Guid("a36c2a8d-7432-4c6a-b8ac-5ebb8a3f88a2"), "Политология", new Guid("d8fb160d-402e-4223-b715-fe34843f3f3f") },
                    { new Guid("a6c91950-8000-4c13-807f-d88e3e4a633e"), "Животноводство и молочное производство", new Guid("95d23fd7-5a90-4043-8eda-b12c637ebe1b") },
                    { new Guid("a9708542-19fe-447d-a3fb-f2f83d9aeb13"), "Нанотехнологии", new Guid("800e6c9d-87fb-467a-8f3f-1d81e4b60f8d") },
                    { new Guid("ada6d6e1-5bf1-467b-ab58-44626f35bcb7"), "Науки о здоровье", new Guid("a8277c69-2a4f-4f94-ab92-043c839c6f5b") },
                    { new Guid("afe6ea5c-a3ff-4253-9ef8-dbff6dedc760"), "Экономика и бизнес", new Guid("d8fb160d-402e-4223-b715-fe34843f3f3f") },
                    { new Guid("b0f8129d-25c4-41cf-9118-262cdc4a56ae"), "Химия", new Guid("13fa67ac-7d44-4d9d-9fd5-0bab99b78354") },
                    { new Guid("b4d1d3b0-a712-4ba4-a6cd-045e874c0b90"), "История и археология", new Guid("716ba49a-504a-466d-a005-0d344e92df98") },
                    { new Guid("b98381c0-b75a-4f27-bbde-ab0eb812995e"), "Физика", new Guid("13fa67ac-7d44-4d9d-9fd5-0bab99b78354") },
                    { new Guid("c066f676-50a0-4b58-9191-c679e7b89ac3"), "Экологическая инженерия", new Guid("800e6c9d-87fb-467a-8f3f-1d81e4b60f8d") },
                    { new Guid("c3a0efe7-8bbe-44df-9b17-2cd1f7d4fc40"), "Языки и литература", new Guid("716ba49a-504a-466d-a005-0d344e92df98") },
                    { new Guid("c74a8aa6-11b1-41c6-8159-001427aa41de"), "Другие гуманитарные науки", new Guid("716ba49a-504a-466d-a005-0d344e92df98") },
                    { new Guid("cc1a29f5-dec9-477b-94cd-3b1b568db701"), "Другие естественные науки", new Guid("13fa67ac-7d44-4d9d-9fd5-0bab99b78354") },
                    { new Guid("cc7b16d7-277e-4c6f-b05f-78425d9b1e76"), "Сельское, лесное и рыбное хозяйство", new Guid("95d23fd7-5a90-4043-8eda-b12c637ebe1b") },
                    { new Guid("d85307c1-11fe-4ee6-93f8-d4f84a1a9f15"), "Психология", new Guid("d8fb160d-402e-4223-b715-fe34843f3f3f") },
                    { new Guid("d9b46ef1-c462-4047-8495-19e9accb4141"), "Машиностроение", new Guid("800e6c9d-87fb-467a-8f3f-1d81e4b60f8d") },
                    { new Guid("e1e17db9-ef14-45bd-b8bb-086fdc425a1b"), "Экологическая биотехнология", new Guid("800e6c9d-87fb-467a-8f3f-1d81e4b60f8d") },
                    { new Guid("e37379db-7f07-46d8-8b5c-67023031b619"), "Медиа и коммуникации", new Guid("d8fb160d-402e-4223-b715-fe34843f3f3f") },
                    { new Guid("ebc6f736-d10d-485c-879b-185c2a0f838e"), "Электротехника, электроника, информационная инженерия", new Guid("800e6c9d-87fb-467a-8f3f-1d81e4b60f8d") },
                    { new Guid("ffe53216-9a70-4bda-86b4-ac58fe41b409"), "Другие социальные науки", new Guid("d8fb160d-402e-4223-b715-fe34843f3f3f") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                name: "IX_Notifications_ReceiverId",
                table: "Notifications",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorFavoriteScientificWork_ScientificWorkId",
                table: "ProfessorFavoriteScientificWork",
                column: "ScientificWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorFavoriteStudent_StudentId",
                table: "ProfessorFavoriteStudent",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorScientificAreaSubsection_ScientificAreaSubsections~",
                table: "ProfessorScientificAreaSubsection",
                column: "ScientificAreaSubsectionsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorScientificInterest_ScientificInterestsId",
                table: "ProfessorScientificInterest",
                column: "ScientificInterestsId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificAreaSubsections_ScientificAreaId",
                table: "ScientificAreaSubsections",
                column: "ScientificAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificAreaSubsectionScientificWork_ScientificWorksId",
                table: "ScientificAreaSubsectionScientificWork",
                column: "ScientificWorksId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificAreaSubsectionStudent_StudentsId",
                table: "ScientificAreaSubsectionStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificInterestScientificWork_ScientificWorksId",
                table: "ScientificInterestScientificWork",
                column: "ScientificWorksId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificInterestStudent_StudentsId",
                table: "ScientificInterestStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificWorks_ProfessorId",
                table: "ScientificWorks",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificWorkStudent_StudentsId",
                table: "ScientificWorkStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentFavoriteProfessor_ProfessorId",
                table: "StudentFavoriteProfessor",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentFavoriteScientificWork_ScientificWorkId",
                table: "StudentFavoriteScientificWork",
                column: "ScientificWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentFavoriteStudent_FavoriteStudentId",
                table: "StudentFavoriteStudent",
                column: "FavoriteStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRequestProfessors_ProfessorId",
                table: "StudentRequestProfessors",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRequestProfessors_ScientificWorkId",
                table: "StudentRequestProfessors",
                column: "ScientificWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRequestStudents_ScientificWorkId",
                table: "StudentRequestStudents",
                column: "ScientificWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRequestStudents_StudentToId",
                table: "StudentRequestStudents",
                column: "StudentToId");

            migrationBuilder.CreateIndex(
                name: "Email",
                table: "Users",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RemovedAt",
                table: "Users",
                column: "RemovedAt");

            migrationBuilder.CreateIndex(
                name: "NormalizedEmail",
                table: "Users",
                column: "NormalizedEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
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
                name: "DataProtectionKeys");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "ProfessorFavoriteScientificWork");

            migrationBuilder.DropTable(
                name: "ProfessorFavoriteStudent");

            migrationBuilder.DropTable(
                name: "ProfessorScientificAreaSubsection");

            migrationBuilder.DropTable(
                name: "ProfessorScientificInterest");

            migrationBuilder.DropTable(
                name: "ScientificAreaSubsectionScientificWork");

            migrationBuilder.DropTable(
                name: "ScientificAreaSubsectionStudent");

            migrationBuilder.DropTable(
                name: "ScientificInterestScientificWork");

            migrationBuilder.DropTable(
                name: "ScientificInterestStudent");

            migrationBuilder.DropTable(
                name: "ScientificWorkStudent");

            migrationBuilder.DropTable(
                name: "StudentFavoriteProfessor");

            migrationBuilder.DropTable(
                name: "StudentFavoriteScientificWork");

            migrationBuilder.DropTable(
                name: "StudentFavoriteStudent");

            migrationBuilder.DropTable(
                name: "StudentRequestProfessors");

            migrationBuilder.DropTable(
                name: "StudentRequestStudents");

            migrationBuilder.DropTable(
                name: "SystemAdmins");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ScientificAreaSubsections");

            migrationBuilder.DropTable(
                name: "ScientificInterests");

            migrationBuilder.DropTable(
                name: "ScientificWorks");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "ScientificAreas");

            migrationBuilder.DropTable(
                name: "Professors");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
