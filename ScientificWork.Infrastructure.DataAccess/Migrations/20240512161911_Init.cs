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
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
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
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Message = table.Column<string>(type: "text", unicode: false, nullable: false),
                    Attachment_AgreeLink = table.Column<string>(type: "text", unicode: false, nullable: true),
                    Attachment_DisagreeLink = table.Column<string>(type: "text", unicode: false, nullable: true),
                    ReceiverId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReadAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
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
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
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
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Message = table.Column<string>(type: "text", unicode: false, nullable: false)
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
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Message = table.Column<string>(type: "text", unicode: false, nullable: false)
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
                    { new Guid("41a40827-a2b4-426c-b468-0b10d5b4b749"), "Сельскохозяйственные науки" },
                    { new Guid("51677870-a34f-4b31-bbbf-fcfdfb8cf3de"), "Общественные науки" },
                    { new Guid("79f46426-04ad-490f-8997-894cd1c3b3b7"), "Медицина и здравоохранение" },
                    { new Guid("a33ffb3b-a64a-4139-a721-e99490549605"), "Гуманитарные науки" },
                    { new Guid("b0d7873e-c6b0-4166-9296-d535cbe5a3db"), "Техника и технологии" },
                    { new Guid("b8d040a2-6991-4e76-a161-1c9b1768f766"), "Естественные науки" }
                });

            migrationBuilder.InsertData(
                table: "ScientificAreaSubsections",
                columns: new[] { "Id", "Name", "ScientificAreaId" },
                values: new object[,]
                {
                    { new Guid("03aa17be-1f6d-4aa9-82d5-b34bcf3a82ad"), "Сельскохозяйственная биотехнология", new Guid("41a40827-a2b4-426c-b468-0b10d5b4b749") },
                    { new Guid("0b75484b-c3b8-4007-b9b3-7f2f3bdff65d"), "Животноводство и молочное производство", new Guid("41a40827-a2b4-426c-b468-0b10d5b4b749") },
                    { new Guid("0d325d8a-2fad-45cc-aba3-897f722597fd"), "Социально-экономическая география", new Guid("51677870-a34f-4b31-bbbf-fcfdfb8cf3de") },
                    { new Guid("0e1bd7b8-df90-4268-8ca4-11b9e66c6914"), "Гражданское строительство", new Guid("b0d7873e-c6b0-4166-9296-d535cbe5a3db") },
                    { new Guid("186f81d7-136d-444d-9b92-cea4cf6843f6"), "Другие сельскохозяйственные науки", new Guid("41a40827-a2b4-426c-b468-0b10d5b4b749") },
                    { new Guid("2247d065-a78d-42b3-8a91-5d2621384c20"), "Материаловедение", new Guid("b0d7873e-c6b0-4166-9296-d535cbe5a3db") },
                    { new Guid("24486e18-bfcd-4809-b463-77b0255a35a2"), "Право", new Guid("51677870-a34f-4b31-bbbf-fcfdfb8cf3de") },
                    { new Guid("27aabde3-42c2-48f3-91ce-b002e35bc213"), "Философия, этика и религия", new Guid("a33ffb3b-a64a-4139-a721-e99490549605") },
                    { new Guid("27ef6eb7-9acf-41a0-9cf0-154e733872e4"), "Машиностроение", new Guid("b0d7873e-c6b0-4166-9296-d535cbe5a3db") },
                    { new Guid("27f2a445-4b0e-40a3-be95-cf7d3f12d24e"), "Социология", new Guid("51677870-a34f-4b31-bbbf-fcfdfb8cf3de") },
                    { new Guid("3799f365-124c-44b8-8297-cf3c62421c49"), "Экономика и бизнес", new Guid("51677870-a34f-4b31-bbbf-fcfdfb8cf3de") },
                    { new Guid("39987995-0462-40c3-8b57-effd6816a9bd"), "Компьютерные и информационные науки", new Guid("b8d040a2-6991-4e76-a161-1c9b1768f766") },
                    { new Guid("3a3873bb-46b1-4f86-840d-920f1c455243"), "Языки и литература", new Guid("a33ffb3b-a64a-4139-a721-e99490549605") },
                    { new Guid("3db7eb42-960d-42b2-8018-bca75da35c92"), "Физика", new Guid("b8d040a2-6991-4e76-a161-1c9b1768f766") },
                    { new Guid("4274fe06-60f4-48e2-8823-35f6c43a8571"), "Биология", new Guid("b8d040a2-6991-4e76-a161-1c9b1768f766") },
                    { new Guid("44b4a374-171d-4adc-a273-f71f74845804"), "Нанотехнологии", new Guid("b0d7873e-c6b0-4166-9296-d535cbe5a3db") },
                    { new Guid("45a83e1e-92d0-4f34-add9-3d78eb5df620"), "История и археология", new Guid("a33ffb3b-a64a-4139-a721-e99490549605") },
                    { new Guid("58e6ada7-9830-4fe2-92ac-175b2cb1be7d"), "Другие медицинские науки", new Guid("79f46426-04ad-490f-8997-894cd1c3b3b7") },
                    { new Guid("71730d89-e959-42b2-8b22-3f7065862891"), "Сельское, лесное и рыбное хозяйство", new Guid("41a40827-a2b4-426c-b468-0b10d5b4b749") },
                    { new Guid("750a5093-ca4d-42a9-9a4e-986a7ae7fba1"), "Психология", new Guid("51677870-a34f-4b31-bbbf-fcfdfb8cf3de") },
                    { new Guid("78ca54ce-1c20-4cf4-a41a-b6bc4fe69b75"), "Другие естественные науки", new Guid("b8d040a2-6991-4e76-a161-1c9b1768f766") },
                    { new Guid("8182527c-addc-41de-9da9-ec3674674c6a"), "Экологическая биотехнология", new Guid("b0d7873e-c6b0-4166-9296-d535cbe5a3db") },
                    { new Guid("839a3e06-511d-426b-9fd2-a657358c2f56"), "Медицинская биотехнология", new Guid("79f46426-04ad-490f-8997-894cd1c3b3b7") },
                    { new Guid("88552a80-755d-461e-aaa7-c8a8819cab12"), "Политология", new Guid("51677870-a34f-4b31-bbbf-fcfdfb8cf3de") },
                    { new Guid("8a4f7bdd-17b5-476a-a8e5-ad0d5a818b10"), "Науки о Земле и окружающей среде", new Guid("b8d040a2-6991-4e76-a161-1c9b1768f766") },
                    { new Guid("8c1b6f60-9ec2-47bf-bdb6-ed0cf7d462e4"), "Другие гуманитарные науки", new Guid("a33ffb3b-a64a-4139-a721-e99490549605") },
                    { new Guid("90ecf6bd-7d45-4db4-95b6-92e3ba4be149"), "Науки о здоровье", new Guid("79f46426-04ad-490f-8997-894cd1c3b3b7") },
                    { new Guid("94ddd827-458b-4eb0-8b18-849ddfc2183d"), "Математика", new Guid("b8d040a2-6991-4e76-a161-1c9b1768f766") },
                    { new Guid("95fe7e3b-e7e7-4594-bc51-dbfe014ac153"), "Промышленная биотехнология", new Guid("b0d7873e-c6b0-4166-9296-d535cbe5a3db") },
                    { new Guid("96cc3e5c-c52d-4a18-ab24-f9edadcb20e3"), "Искусство (искусство, история искусств, исполнительское искусство, музыка)", new Guid("a33ffb3b-a64a-4139-a721-e99490549605") },
                    { new Guid("9bb29178-a2ed-4cfc-8810-7f18c0caa2f8"), "Ветеринария", new Guid("41a40827-a2b4-426c-b468-0b10d5b4b749") },
                    { new Guid("a46598ca-5558-46e4-a234-550414ef4d6b"), "Клиническая медицина", new Guid("79f46426-04ad-490f-8997-894cd1c3b3b7") },
                    { new Guid("a4faf693-f704-4a1d-8337-b66ad3c2912a"), "Экологическая инженерия", new Guid("b0d7873e-c6b0-4166-9296-d535cbe5a3db") },
                    { new Guid("a616bba9-710a-4fc6-b1ff-f9feb1fbe9ed"), "Медиа и коммуникации", new Guid("51677870-a34f-4b31-bbbf-fcfdfb8cf3de") },
                    { new Guid("b880af83-8286-4b54-8e5c-7e13c4388c3d"), "Другие социальные науки", new Guid("51677870-a34f-4b31-bbbf-fcfdfb8cf3de") },
                    { new Guid("c3f1ff02-c86f-461e-9fb4-170ad8814269"), "Электротехника, электроника, информационная инженерия", new Guid("b0d7873e-c6b0-4166-9296-d535cbe5a3db") },
                    { new Guid("c80ee5e0-dd53-4a8d-b164-5a16f39cc92d"), "Медицинская инженерия", new Guid("b0d7873e-c6b0-4166-9296-d535cbe5a3db") },
                    { new Guid("ca8288e4-3533-4385-b653-8ed89b0732f1"), "Фундаментальная медицина", new Guid("79f46426-04ad-490f-8997-894cd1c3b3b7") },
                    { new Guid("e29b207a-1168-456b-94ca-3e9cbf2ca421"), "Химическая инженерия", new Guid("b0d7873e-c6b0-4166-9296-d535cbe5a3db") },
                    { new Guid("e8fbf283-1162-4adc-bcaf-81955977bc7a"), "Образовательные науки", new Guid("51677870-a34f-4b31-bbbf-fcfdfb8cf3de") },
                    { new Guid("f0e30676-d96c-4354-bea1-c31342c2fd69"), "Другая инженерия и технологии", new Guid("b0d7873e-c6b0-4166-9296-d535cbe5a3db") },
                    { new Guid("fe69d2b2-331c-496e-a5eb-f714fd97ed08"), "Химия", new Guid("b8d040a2-6991-4e76-a161-1c9b1768f766") }
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
