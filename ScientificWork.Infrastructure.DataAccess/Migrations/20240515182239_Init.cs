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
                    SearchStatus_Status = table.Column<int>(type: "integer", nullable: true),
                    SearchStatus_Limit = table.Column<int>(type: "integer", nullable: true),
                    Fullness = table.Column<int>(type: "integer", nullable: true),
                    WorkExperienceYears = table.Column<int>(type: "integer", nullable: true),
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
                name: "ScientificInterestUser",
                columns: table => new
                {
                    ScientificInterestsId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificInterestUser", x => new { x.ScientificInterestsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ScientificInterestUser_ScientificInterests_ScientificIntere~",
                        column: x => x.ScientificInterestsId,
                        principalTable: "ScientificInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScientificInterestUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Degree = table.Column<string>(type: "text", unicode: false, nullable: true),
                    Year = table.Column<int>(type: "integer", nullable: false),
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
                name: "ScientificAreaSubsectionUser",
                columns: table => new
                {
                    ScientificAreaSubsectionsId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificAreaSubsectionUser", x => new { x.ScientificAreaSubsectionsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ScientificAreaSubsectionUser_ScientificAreaSubsections_Scie~",
                        column: x => x.ScientificAreaSubsectionsId,
                        principalTable: "ScientificAreaSubsections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScientificAreaSubsectionUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
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
                    { new Guid("393a14d1-e9a2-4095-8769-8fa1bc285680"), "Сельскохозяйственные науки" },
                    { new Guid("58422d99-1090-436b-809a-e48d962f0ed0"), "Медицина и здравоохранение" },
                    { new Guid("660a636e-f129-483f-8aa4-8c75f7988439"), "Гуманитарные науки" },
                    { new Guid("779ce45b-ae67-486f-9a46-ba0bf3587d72"), "Естественные науки" },
                    { new Guid("e43ffe61-e46e-44e2-8009-f47b10b73673"), "Техника и технологии" },
                    { new Guid("ecf9f875-b6fc-425b-ba57-7068fb4b8f32"), "Общественные науки" }
                });

            migrationBuilder.InsertData(
                table: "ScientificAreaSubsections",
                columns: new[] { "Id", "Name", "ScientificAreaId" },
                values: new object[,]
                {
                    { new Guid("04d6c8de-4b66-4163-8edf-0708c28e31e4"), "Клиническая медицина", new Guid("58422d99-1090-436b-809a-e48d962f0ed0") },
                    { new Guid("1255272d-03bf-414b-b4cd-24231fa40ca1"), "Сельскохозяйственная биотехнология", new Guid("393a14d1-e9a2-4095-8769-8fa1bc285680") },
                    { new Guid("1339caf6-bbb4-4922-98c5-3a9e3d24bc4b"), "Экологическая биотехнология", new Guid("e43ffe61-e46e-44e2-8009-f47b10b73673") },
                    { new Guid("1618f676-d632-4f71-aa88-71a1d1d37e4f"), "Материаловедение", new Guid("e43ffe61-e46e-44e2-8009-f47b10b73673") },
                    { new Guid("1b5213f6-6257-4d31-b15b-0de0a0d3446b"), "Науки о Земле и окружающей среде", new Guid("779ce45b-ae67-486f-9a46-ba0bf3587d72") },
                    { new Guid("22460c85-b9b9-4ac2-80d9-980110a26748"), "Психология", new Guid("ecf9f875-b6fc-425b-ba57-7068fb4b8f32") },
                    { new Guid("291f563f-2320-41da-a56c-9839bd5dcb52"), "Другие гуманитарные науки", new Guid("660a636e-f129-483f-8aa4-8c75f7988439") },
                    { new Guid("2aab8239-3822-48d6-acda-eab1e1822655"), "Электротехника, электроника, информационная инженерия", new Guid("e43ffe61-e46e-44e2-8009-f47b10b73673") },
                    { new Guid("2f083e8c-8350-4a2d-a315-9eaba03d320e"), "Экономика и бизнес", new Guid("ecf9f875-b6fc-425b-ba57-7068fb4b8f32") },
                    { new Guid("3375f815-aceb-451c-bf06-bdbbc7249a28"), "Науки о здоровье", new Guid("58422d99-1090-436b-809a-e48d962f0ed0") },
                    { new Guid("3607ae75-549b-43ae-9058-e034e26c0acd"), "Промышленная биотехнология", new Guid("e43ffe61-e46e-44e2-8009-f47b10b73673") },
                    { new Guid("374ddfe0-ba5b-4ee7-a705-2743a6020df9"), "Ветеринария", new Guid("393a14d1-e9a2-4095-8769-8fa1bc285680") },
                    { new Guid("3a17b17f-98b5-469f-889c-b97d2a4f9642"), "Другие медицинские науки", new Guid("58422d99-1090-436b-809a-e48d962f0ed0") },
                    { new Guid("447b7e44-120a-433f-abff-e706933aa4eb"), "Биология", new Guid("779ce45b-ae67-486f-9a46-ba0bf3587d72") },
                    { new Guid("4d154370-4c0e-46ba-b792-ea1cbb147612"), "Образовательные науки", new Guid("ecf9f875-b6fc-425b-ba57-7068fb4b8f32") },
                    { new Guid("5dd2694c-a4c7-4d57-ae32-8c4e7486da73"), "Социология", new Guid("ecf9f875-b6fc-425b-ba57-7068fb4b8f32") },
                    { new Guid("6e14293e-9b8c-4c6c-92b3-b609119bf335"), "Другие естественные науки", new Guid("779ce45b-ae67-486f-9a46-ba0bf3587d72") },
                    { new Guid("74030c95-5bc0-4768-9456-7d6f52a3e23e"), "Физика", new Guid("779ce45b-ae67-486f-9a46-ba0bf3587d72") },
                    { new Guid("76cc1cdd-d00c-46b1-8e8a-556aa0d945b9"), "Политология", new Guid("ecf9f875-b6fc-425b-ba57-7068fb4b8f32") },
                    { new Guid("833b48d5-6062-4c1e-b022-3bd01c6b233b"), "Химическая инженерия", new Guid("e43ffe61-e46e-44e2-8009-f47b10b73673") },
                    { new Guid("9434c3b2-1ebd-422c-a61e-c3d7c7ab61d1"), "Фундаментальная медицина", new Guid("58422d99-1090-436b-809a-e48d962f0ed0") },
                    { new Guid("96362297-9a7a-4bbe-8963-08bf44608261"), "Право", new Guid("ecf9f875-b6fc-425b-ba57-7068fb4b8f32") },
                    { new Guid("978c46ff-f4bb-4656-8d59-9a343838b2aa"), "Медицинская инженерия", new Guid("e43ffe61-e46e-44e2-8009-f47b10b73673") },
                    { new Guid("99ae0154-0038-43fd-98f5-c6ad863bff01"), "Социально-экономическая география", new Guid("ecf9f875-b6fc-425b-ba57-7068fb4b8f32") },
                    { new Guid("9ddc2a15-9685-439a-9dac-f65c76a9650b"), "История и археология", new Guid("660a636e-f129-483f-8aa4-8c75f7988439") },
                    { new Guid("9ee0b9bb-ddb1-4b25-99ab-37bf467305fe"), "Медиа и коммуникации", new Guid("ecf9f875-b6fc-425b-ba57-7068fb4b8f32") },
                    { new Guid("9ff3a3c7-50f5-41e7-9375-c2d91e07ca38"), "Другие социальные науки", new Guid("ecf9f875-b6fc-425b-ba57-7068fb4b8f32") },
                    { new Guid("a358b0c9-d45f-4563-94eb-10169b7c353b"), "Химия", new Guid("779ce45b-ae67-486f-9a46-ba0bf3587d72") },
                    { new Guid("a84a75e2-6bb5-40a1-a221-3027764aa939"), "Сельское, лесное и рыбное хозяйство", new Guid("393a14d1-e9a2-4095-8769-8fa1bc285680") },
                    { new Guid("aa93786a-d21a-40c0-b362-fd6f27654360"), "Философия, этика и религия", new Guid("660a636e-f129-483f-8aa4-8c75f7988439") },
                    { new Guid("aef70ba1-0c93-4445-8a04-ad3248923227"), "Животноводство и молочное производство", new Guid("393a14d1-e9a2-4095-8769-8fa1bc285680") },
                    { new Guid("b367a746-30a2-48f9-84b7-774cf29c8801"), "Компьютерные и информационные науки", new Guid("779ce45b-ae67-486f-9a46-ba0bf3587d72") },
                    { new Guid("b5507216-ec8f-401c-bd2b-6b2994356765"), "Математика", new Guid("779ce45b-ae67-486f-9a46-ba0bf3587d72") },
                    { new Guid("bc9f53b5-3e18-43a1-a612-1d3f2e9c871a"), "Экологическая инженерия", new Guid("e43ffe61-e46e-44e2-8009-f47b10b73673") },
                    { new Guid("bea51890-b44c-4cdb-a2aa-6bc37fea2a23"), "Искусство (искусство, история искусств, исполнительское искусство, музыка)", new Guid("660a636e-f129-483f-8aa4-8c75f7988439") },
                    { new Guid("bf7cba3d-afa8-46b6-ab94-ab533754d902"), "Медицинская биотехнология", new Guid("58422d99-1090-436b-809a-e48d962f0ed0") },
                    { new Guid("c9e35564-fead-4e3c-af2d-cc8f68b24c8d"), "Другая инженерия и технологии", new Guid("e43ffe61-e46e-44e2-8009-f47b10b73673") },
                    { new Guid("e2f45047-1a9e-40b8-9653-d8ec1dc4ecac"), "Гражданское строительство", new Guid("e43ffe61-e46e-44e2-8009-f47b10b73673") },
                    { new Guid("e73e3017-6ca1-475b-a039-d5dccb805532"), "Машиностроение", new Guid("e43ffe61-e46e-44e2-8009-f47b10b73673") },
                    { new Guid("e7559dac-8f47-4e8a-83aa-841ea07c7a6a"), "Языки и литература", new Guid("660a636e-f129-483f-8aa4-8c75f7988439") },
                    { new Guid("f0a30224-dac0-4843-a30e-456cd24fea9f"), "Другие сельскохозяйственные науки", new Guid("393a14d1-e9a2-4095-8769-8fa1bc285680") },
                    { new Guid("f6d02b60-777b-4b8b-9ebd-74096e84812b"), "Нанотехнологии", new Guid("e43ffe61-e46e-44e2-8009-f47b10b73673") }
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
                name: "IX_ScientificAreaSubsections_ScientificAreaId",
                table: "ScientificAreaSubsections",
                column: "ScientificAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificAreaSubsectionScientificWork_ScientificWorksId",
                table: "ScientificAreaSubsectionScientificWork",
                column: "ScientificWorksId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificAreaSubsectionUser_UsersId",
                table: "ScientificAreaSubsectionUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificInterestScientificWork_ScientificWorksId",
                table: "ScientificInterestScientificWork",
                column: "ScientificWorksId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificInterestUser_UsersId",
                table: "ScientificInterestUser",
                column: "UsersId");

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
                name: "ScientificAreaSubsectionScientificWork");

            migrationBuilder.DropTable(
                name: "ScientificAreaSubsectionUser");

            migrationBuilder.DropTable(
                name: "ScientificInterestScientificWork");

            migrationBuilder.DropTable(
                name: "ScientificInterestUser");

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
