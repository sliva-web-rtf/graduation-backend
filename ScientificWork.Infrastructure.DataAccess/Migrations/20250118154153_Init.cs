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
                    LastPasswordChange = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
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
                    Degree = table.Column<string>(type: "text", unicode: false, nullable: true),
                    SearchStatus_Status = table.Column<int>(type: "integer", nullable: true),
                    SearchStatus_Limit = table.Column<int>(type: "integer", nullable: true),
                    Fullness = table.Column<int>(type: "integer", nullable: true),
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
                    Message = table.Column<string>(type: "text", unicode: false, nullable: true)
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
                    Message = table.Column<string>(type: "text", unicode: false, nullable: true)
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
                    { new Guid("243d65dd-16f0-426d-be10-0202ca133029"), "Гуманитарные науки" },
                    { new Guid("49d83ccd-5a46-4d1e-9e1e-437d1666922a"), "Естественные науки" },
                    { new Guid("8a2dbe51-897b-4da7-9880-5cf2ee02882f"), "Медицина и здравоохранение" },
                    { new Guid("9030412f-db3f-49b9-8af6-f436c47854ad"), "Техника и технологии" },
                    { new Guid("9bd5aeb3-6d21-446e-bf7e-0b9a607aa9ec"), "Общественные науки" },
                    { new Guid("d6b1b967-ec58-4656-bb06-160c911385a8"), "Сельскохозяйственные науки" }
                });

            migrationBuilder.InsertData(
                table: "ScientificAreaSubsections",
                columns: new[] { "Id", "Name", "ScientificAreaId" },
                values: new object[,]
                {
                    { new Guid("093b968f-e175-4a48-9ca2-c12dbc3acbe8"), "Гражданское строительство", new Guid("9030412f-db3f-49b9-8af6-f436c47854ad") },
                    { new Guid("0aa58a78-1742-4720-b639-0565284c0550"), "Экономика и бизнес", new Guid("9bd5aeb3-6d21-446e-bf7e-0b9a607aa9ec") },
                    { new Guid("0d696575-5097-49f7-8a64-5948a5a83769"), "Политология", new Guid("9bd5aeb3-6d21-446e-bf7e-0b9a607aa9ec") },
                    { new Guid("15ed4ad2-40c1-457d-84df-c1cd353a851f"), "Животноводство и молочное производство", new Guid("d6b1b967-ec58-4656-bb06-160c911385a8") },
                    { new Guid("16c5a1b2-6247-4731-a3d0-5336cc63c14b"), "Другие сельскохозяйственные науки", new Guid("d6b1b967-ec58-4656-bb06-160c911385a8") },
                    { new Guid("185eeb7b-936c-4859-a7e1-89566fa61d81"), "Другие естественные науки", new Guid("49d83ccd-5a46-4d1e-9e1e-437d1666922a") },
                    { new Guid("208757a5-826e-40d9-af38-85ca7b7d6788"), "Клиническая медицина", new Guid("8a2dbe51-897b-4da7-9880-5cf2ee02882f") },
                    { new Guid("2214e438-34b1-4395-95aa-ae9cc430c3b1"), "Экологическая биотехнология", new Guid("9030412f-db3f-49b9-8af6-f436c47854ad") },
                    { new Guid("2547d032-e60e-4b54-be58-ccb6559f8cf5"), "Электротехника, электроника, информационная инженерия", new Guid("9030412f-db3f-49b9-8af6-f436c47854ad") },
                    { new Guid("32d7d18b-07f8-4b8a-950b-6ce754ba52dc"), "Социология", new Guid("9bd5aeb3-6d21-446e-bf7e-0b9a607aa9ec") },
                    { new Guid("38cb7c20-d2fb-4cd2-b772-cd12dbcc9065"), "Другие гуманитарные науки", new Guid("243d65dd-16f0-426d-be10-0202ca133029") },
                    { new Guid("392bf2df-d02a-4e5f-be6b-8877889eb70a"), "Психология", new Guid("9bd5aeb3-6d21-446e-bf7e-0b9a607aa9ec") },
                    { new Guid("471da449-4916-454f-9d2d-534d90579720"), "Образовательные науки", new Guid("9bd5aeb3-6d21-446e-bf7e-0b9a607aa9ec") },
                    { new Guid("488b55f1-c63a-4f8c-888e-a5a92e4ceab4"), "Компьютерные и информационные науки", new Guid("49d83ccd-5a46-4d1e-9e1e-437d1666922a") },
                    { new Guid("50882dab-5c63-45c6-adca-7de47d889256"), "Искусство (искусство, история искусств, исполнительское искусство, музыка)", new Guid("243d65dd-16f0-426d-be10-0202ca133029") },
                    { new Guid("5447df47-a097-42c7-8a29-bd37142069f3"), "Нанотехнологии", new Guid("9030412f-db3f-49b9-8af6-f436c47854ad") },
                    { new Guid("5b3698fb-aed5-467f-a482-65bc1679fd87"), "Медиа и коммуникации", new Guid("9bd5aeb3-6d21-446e-bf7e-0b9a607aa9ec") },
                    { new Guid("62670708-430c-42fd-9515-5b93b43843bf"), "Сельское, лесное и рыбное хозяйство", new Guid("d6b1b967-ec58-4656-bb06-160c911385a8") },
                    { new Guid("6282932d-c7d2-4686-9f95-ce4db083afec"), "Философия, этика и религия", new Guid("243d65dd-16f0-426d-be10-0202ca133029") },
                    { new Guid("6636dfc5-e126-4ed0-bc98-1f9c6c9db795"), "Химическая инженерия", new Guid("9030412f-db3f-49b9-8af6-f436c47854ad") },
                    { new Guid("6e23957c-de4f-4b36-b333-36dcb81f93c5"), "История и археология", new Guid("243d65dd-16f0-426d-be10-0202ca133029") },
                    { new Guid("8c68101a-1d1f-407a-827d-d868b07ae205"), "Другая инженерия и технологии", new Guid("9030412f-db3f-49b9-8af6-f436c47854ad") },
                    { new Guid("91201366-dca6-4deb-91a7-62284f958a6f"), "Биология", new Guid("49d83ccd-5a46-4d1e-9e1e-437d1666922a") },
                    { new Guid("949f39b8-879c-47d2-a9be-a8529680c200"), "Машиностроение", new Guid("9030412f-db3f-49b9-8af6-f436c47854ad") },
                    { new Guid("9a4f274a-e870-4e49-a1fd-96050125542f"), "Науки о здоровье", new Guid("8a2dbe51-897b-4da7-9880-5cf2ee02882f") },
                    { new Guid("ac23ba63-670f-4302-9bb8-440903f9ca9b"), "Материаловедение", new Guid("9030412f-db3f-49b9-8af6-f436c47854ad") },
                    { new Guid("acd91910-8648-405c-b17d-50d991263d3c"), "Промышленная биотехнология", new Guid("9030412f-db3f-49b9-8af6-f436c47854ad") },
                    { new Guid("ad19a5e5-d774-4277-98d6-f305fc542858"), "Медицинская биотехнология", new Guid("8a2dbe51-897b-4da7-9880-5cf2ee02882f") },
                    { new Guid("ae27cd0e-b82e-418d-8b15-45756acb8556"), "Другие медицинские науки", new Guid("8a2dbe51-897b-4da7-9880-5cf2ee02882f") },
                    { new Guid("b541fbce-8272-4703-a259-b05c424b0902"), "Медицинская инженерия", new Guid("9030412f-db3f-49b9-8af6-f436c47854ad") },
                    { new Guid("be3fc563-3145-4cb3-b0d6-080421aca0d4"), "Сельскохозяйственная биотехнология", new Guid("d6b1b967-ec58-4656-bb06-160c911385a8") },
                    { new Guid("c60a5c45-1015-41af-88cc-4b78364497ae"), "Языки и литература", new Guid("243d65dd-16f0-426d-be10-0202ca133029") },
                    { new Guid("c6da9860-98b1-49ed-989c-0f81b2f20e0e"), "Экологическая инженерия", new Guid("9030412f-db3f-49b9-8af6-f436c47854ad") },
                    { new Guid("c8316d83-8ad4-494a-a261-f09c23b6919f"), "Математика", new Guid("49d83ccd-5a46-4d1e-9e1e-437d1666922a") },
                    { new Guid("ca1cc4db-6342-4fa6-afb8-8b9f899e8b30"), "Социально-экономическая география", new Guid("9bd5aeb3-6d21-446e-bf7e-0b9a607aa9ec") },
                    { new Guid("cb5f1c57-5947-4e90-83b4-b6f17f5f0904"), "Ветеринария", new Guid("d6b1b967-ec58-4656-bb06-160c911385a8") },
                    { new Guid("cd20a1f4-5bc9-4dec-b736-31c958cb4785"), "Физика", new Guid("49d83ccd-5a46-4d1e-9e1e-437d1666922a") },
                    { new Guid("d3636264-ed0a-48ef-97c5-3e9a307477f5"), "Химия", new Guid("49d83ccd-5a46-4d1e-9e1e-437d1666922a") },
                    { new Guid("d6a0d570-af2d-4b17-a245-7de35e10559e"), "Фундаментальная медицина", new Guid("8a2dbe51-897b-4da7-9880-5cf2ee02882f") },
                    { new Guid("dd97de2c-bc12-46aa-8e57-df5a215801d9"), "Науки о Земле и окружающей среде", new Guid("49d83ccd-5a46-4d1e-9e1e-437d1666922a") },
                    { new Guid("e6abf079-724e-495a-b082-9102789620b7"), "Право", new Guid("9bd5aeb3-6d21-446e-bf7e-0b9a607aa9ec") },
                    { new Guid("f1219865-5303-4f43-8cd3-d5efe56b006f"), "Другие социальные науки", new Guid("9bd5aeb3-6d21-446e-bf7e-0b9a607aa9ec") }
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
