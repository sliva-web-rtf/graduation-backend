using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ScientificWork.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeScientificWorkDomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScientificWorks_Professors_ProfessorId",
                table: "ScientificWorks");

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("08435c18-6127-42db-a11e-c3a3daeea002"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("0c4df644-5dfa-4b63-9557-fecb8c6f2b3e"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("0ef3bfb8-c0c1-4797-99a6-bcdd90ecbd33"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("138ca349-69b9-4346-96ab-81aa83e24cbe"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("13cc8271-62d8-4e91-8cdf-a99a04e7ed48"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("1457bb5e-0779-435b-b2c2-59adb3c422d8"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("1b229315-f6e7-43a3-b0f6-dd8d97917c79"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("1f26e143-26ce-41e8-8bc9-94daf39d01d7"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("24443aac-dcca-496a-8427-a1949480cc29"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("3bcef72b-093f-419a-9188-50cebb231bfe"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("3c57ea01-75ef-473f-ab02-b25dcefd6447"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("3faeb47b-3bc0-4de0-bfc9-782fa9684687"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("456413f3-c2b1-4235-b9e5-e8e936d24da5"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("47ec8d7b-6af2-4f51-bbab-3752041c17fc"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("4c8605c6-206e-41d3-8ad2-7ba14fa20450"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("4fca4294-e7cf-4fc7-9580-18a8dcaed388"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("581ca504-1437-45af-9933-a1bb52fc58f6"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("61bf800d-7014-4400-a30e-62297b8cab3d"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("6cac6bec-5f67-4a0b-9c28-4fdfae70d50c"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("6e49377e-ee86-4dbf-8980-15beaba8c32a"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("7287df13-56d2-43e7-a140-c772ec0f70fd"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("7a1afdf3-6ed7-4e67-8c09-6a03bcc3f43c"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("8299329c-ffd8-4106-8159-89ad1646faf4"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("84aefb80-3710-43b7-9402-e691f45dd29d"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("8cf2d4bb-eef8-44a0-9c5f-fed4fdebfc48"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("9756d303-2518-4b81-9c11-b86f788fd27b"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("97a8a352-9ff8-4f6a-91ed-9b9e198af6f2"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("9d7fac29-d4b7-44fe-862e-9429690db40c"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("9f467c4f-ea7d-4e98-be8a-c94ac0c97ba4"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("a903ce1c-98a3-4a54-9890-70bd9ed394c7"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("a9370a7a-9e4c-4d4c-a883-7a18e0f53630"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("af7a2c55-9cf7-45ff-93b8-9aa73946b719"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("be990cfc-183b-4fee-850e-61c735af460e"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("c77d1c56-436c-4f73-a0b9-4467e81e7030"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("cb2fe1fa-c007-453b-924b-43e19a1c92d1"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("dcd43019-1172-48c6-b1a7-c430807b654c"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("e0e4505d-bf80-4046-9a56-48436d4f0f48"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("e28e9d02-5076-4b58-ade0-e7b935f2adb5"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("e326e34c-4c4c-4514-bcc7-9bc4a5983a54"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("e95ce659-3baa-49d3-9590-44c95f8cdb31"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("f57a67a3-3a33-4d1d-b1fd-cf520bfe8a73"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("fdeecb82-a7cb-4b44-8a8b-f4f124ecf390"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("72c7ceb6-e25d-4453-b18f-0c41223b205f"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("9a0c4e12-6d4f-4b04-b9b7-e5c111089524"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("a6f71ad2-31a1-45cf-8d5c-307377697a42"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("ab45ec15-577c-45fd-aec9-28886596050f"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("df10ecfd-16d2-47bf-8302-060c539743bd"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("e2c6d3e7-27ad-4582-828e-0c6708762849"));

            migrationBuilder.DropColumn(
                name: "Relevance",
                table: "ScientificWorks");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfessorId",
                table: "ScientificWorks",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.InsertData(
                table: "ScientificAreas",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2fa01484-0ef6-42f2-af50-4079e1d985ac"), "Гуманитарные науки" },
                    { new Guid("3aee1f38-c544-438e-8915-9c1b1ee06403"), "Сельскохозяйственные науки" },
                    { new Guid("3cb706b1-5eed-4a59-9166-360dafd5d9e3"), "Естественные науки" },
                    { new Guid("52934529-73bf-41f7-ad06-e2186e15e047"), "Техника и технологии" },
                    { new Guid("84507b0f-6e49-4423-954c-a67fbf8901f4"), "Медицина и здравоохранение" },
                    { new Guid("8a2f3c52-395e-40fa-b03b-4238b1f9cdf9"), "Общественные науки" }
                });

            migrationBuilder.InsertData(
                table: "ScientificAreaSubsections",
                columns: new[] { "Id", "Name", "ScientificAreaId" },
                values: new object[,]
                {
                    { new Guid("020f104f-b7f1-4eac-89aa-404a422d77d4"), "Химия", new Guid("3cb706b1-5eed-4a59-9166-360dafd5d9e3") },
                    { new Guid("03abc1f1-2b3c-4d34-bfec-1d2f7e24c0fa"), "Медицинская биотехнология", new Guid("84507b0f-6e49-4423-954c-a67fbf8901f4") },
                    { new Guid("0e8aa4e8-a3b5-4adb-b123-4814a65e1e33"), "Искусство (искусство, история искусств, исполнительское искусство, музыка)", new Guid("2fa01484-0ef6-42f2-af50-4079e1d985ac") },
                    { new Guid("1d59af06-f278-4421-9caa-9cd07d83eac4"), "Экономика и бизнес", new Guid("8a2f3c52-395e-40fa-b03b-4238b1f9cdf9") },
                    { new Guid("1e8eb223-7b08-44dc-b865-f83750a22455"), "Политология", new Guid("8a2f3c52-395e-40fa-b03b-4238b1f9cdf9") },
                    { new Guid("2f247bf7-d965-4586-a311-9f63a59d8f54"), "Химическая инженерия", new Guid("52934529-73bf-41f7-ad06-e2186e15e047") },
                    { new Guid("3ac07b78-4dd4-430a-9aaf-976329cb35ea"), "Право", new Guid("8a2f3c52-395e-40fa-b03b-4238b1f9cdf9") },
                    { new Guid("3ae8091d-d4c2-4861-8c0b-a11eff8b0a7b"), "Промышленная биотехнология", new Guid("52934529-73bf-41f7-ad06-e2186e15e047") },
                    { new Guid("4b354d55-b44d-436f-94da-7e59a61418e8"), "Математика", new Guid("3cb706b1-5eed-4a59-9166-360dafd5d9e3") },
                    { new Guid("4b6aaae3-b594-477d-8dd0-86e58c4c8d4c"), "Электротехника, электроника, информационная инженерия", new Guid("52934529-73bf-41f7-ad06-e2186e15e047") },
                    { new Guid("4b798426-deed-4f45-ba42-010bc4f93f3c"), "Медицинская инженерия", new Guid("52934529-73bf-41f7-ad06-e2186e15e047") },
                    { new Guid("5c30aeb3-c627-46e8-b271-e7b187591578"), "Науки о Земле и окружающей среде", new Guid("3cb706b1-5eed-4a59-9166-360dafd5d9e3") },
                    { new Guid("63c01766-e761-46c7-8183-ac7239d84e31"), "Компьютерные и информационные науки", new Guid("3cb706b1-5eed-4a59-9166-360dafd5d9e3") },
                    { new Guid("66b2e654-61f3-4165-8081-9780d8f51a69"), "Медиа и коммуникации", new Guid("8a2f3c52-395e-40fa-b03b-4238b1f9cdf9") },
                    { new Guid("6bde455d-901f-438e-bce3-10fe40b0990d"), "Биология", new Guid("3cb706b1-5eed-4a59-9166-360dafd5d9e3") },
                    { new Guid("73713f2f-fe6c-4181-8f18-0f46fb39ccb6"), "Нанотехнологии", new Guid("52934529-73bf-41f7-ad06-e2186e15e047") },
                    { new Guid("76124e80-ebf4-49f3-a459-40f81db339dc"), "Экологическая биотехнология", new Guid("52934529-73bf-41f7-ad06-e2186e15e047") },
                    { new Guid("76e1827c-412b-4834-a671-a2e70c19b7c8"), "Материаловедение", new Guid("52934529-73bf-41f7-ad06-e2186e15e047") },
                    { new Guid("7a0f5b7f-cb7c-4075-aa0a-b55eec5c4fee"), "Сельское, лесное и рыбное хозяйство", new Guid("3aee1f38-c544-438e-8915-9c1b1ee06403") },
                    { new Guid("7a17511c-d688-46dc-bf79-178bb1bf0c09"), "Языки и литература", new Guid("2fa01484-0ef6-42f2-af50-4079e1d985ac") },
                    { new Guid("89b1865a-9ee7-42d4-be9e-09c1912b837f"), "Другие социальные науки", new Guid("8a2f3c52-395e-40fa-b03b-4238b1f9cdf9") },
                    { new Guid("8a922192-6d6d-4dc1-997d-73b30a1da0ff"), "Физика", new Guid("3cb706b1-5eed-4a59-9166-360dafd5d9e3") },
                    { new Guid("9bebc716-7784-48f8-88b5-52d532864134"), "Другие сельскохозяйственные науки", new Guid("3aee1f38-c544-438e-8915-9c1b1ee06403") },
                    { new Guid("a2d429cc-6e6a-4d0b-8fb4-a62c72a2ed6c"), "История и археология", new Guid("2fa01484-0ef6-42f2-af50-4079e1d985ac") },
                    { new Guid("a3cc343e-a0c4-4954-9baf-fd3fe02def4f"), "Клиническая медицина", new Guid("84507b0f-6e49-4423-954c-a67fbf8901f4") },
                    { new Guid("a45cbbe3-d7b2-4d0d-821d-e385c0015cf2"), "Ветеринария", new Guid("3aee1f38-c544-438e-8915-9c1b1ee06403") },
                    { new Guid("b0243043-aaa5-466f-af3a-bc0f58ccd185"), "Философия, этика и религия", new Guid("2fa01484-0ef6-42f2-af50-4079e1d985ac") },
                    { new Guid("b0e8fc5f-182d-4b04-b11d-630645324e72"), "Другие гуманитарные науки", new Guid("2fa01484-0ef6-42f2-af50-4079e1d985ac") },
                    { new Guid("b3c56ae0-8873-4c4e-b47a-94d63bd55600"), "Машиностроение", new Guid("52934529-73bf-41f7-ad06-e2186e15e047") },
                    { new Guid("b6f9a4e4-ac8e-42f1-9306-b06d4c77dd28"), "Сельскохозяйственная биотехнология", new Guid("3aee1f38-c544-438e-8915-9c1b1ee06403") },
                    { new Guid("b90d8bac-4ea0-4a8e-b297-66892fec23c8"), "Образовательные науки", new Guid("8a2f3c52-395e-40fa-b03b-4238b1f9cdf9") },
                    { new Guid("c719bb02-e5af-4c0c-a0af-8526ba1c81cb"), "Другие медицинские науки", new Guid("84507b0f-6e49-4423-954c-a67fbf8901f4") },
                    { new Guid("cd41596f-67b4-43b5-8b58-0f99d98c14f9"), "Фундаментальная медицина", new Guid("84507b0f-6e49-4423-954c-a67fbf8901f4") },
                    { new Guid("cf788827-0ece-490b-bdff-cf6dd9c51d84"), "Гражданское строительство", new Guid("52934529-73bf-41f7-ad06-e2186e15e047") },
                    { new Guid("da79cf46-ef40-479d-bc2c-83828a21635b"), "Науки о здоровье", new Guid("84507b0f-6e49-4423-954c-a67fbf8901f4") },
                    { new Guid("df7c1c6c-b76d-4368-b32b-72ddbbe48226"), "Социология", new Guid("8a2f3c52-395e-40fa-b03b-4238b1f9cdf9") },
                    { new Guid("e015ff04-a0be-4412-8c1c-2ff99c4b8973"), "Психология", new Guid("8a2f3c52-395e-40fa-b03b-4238b1f9cdf9") },
                    { new Guid("e052af3f-207e-4656-b1ef-2e1bc0400d0e"), "Животноводство и молочное производство", new Guid("3aee1f38-c544-438e-8915-9c1b1ee06403") },
                    { new Guid("ec1a129a-0e77-4801-b147-7910a9ab7c53"), "Другие естественные науки", new Guid("3cb706b1-5eed-4a59-9166-360dafd5d9e3") },
                    { new Guid("f2ca1f87-4fe4-4c74-acc0-8d3ccf684361"), "Экологическая инженерия", new Guid("52934529-73bf-41f7-ad06-e2186e15e047") },
                    { new Guid("f7675dff-440c-4314-bc1b-6bd2d7c8235f"), "Социально-экономическая география", new Guid("8a2f3c52-395e-40fa-b03b-4238b1f9cdf9") },
                    { new Guid("fd1c2a2b-7a12-4635-89dc-e48c8c73aa44"), "Другая инженерия и технологии", new Guid("52934529-73bf-41f7-ad06-e2186e15e047") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ScientificWorks_Professors_ProfessorId",
                table: "ScientificWorks",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScientificWorks_Professors_ProfessorId",
                table: "ScientificWorks");

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("020f104f-b7f1-4eac-89aa-404a422d77d4"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("03abc1f1-2b3c-4d34-bfec-1d2f7e24c0fa"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("0e8aa4e8-a3b5-4adb-b123-4814a65e1e33"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("1d59af06-f278-4421-9caa-9cd07d83eac4"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("1e8eb223-7b08-44dc-b865-f83750a22455"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("2f247bf7-d965-4586-a311-9f63a59d8f54"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("3ac07b78-4dd4-430a-9aaf-976329cb35ea"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("3ae8091d-d4c2-4861-8c0b-a11eff8b0a7b"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("4b354d55-b44d-436f-94da-7e59a61418e8"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("4b6aaae3-b594-477d-8dd0-86e58c4c8d4c"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("4b798426-deed-4f45-ba42-010bc4f93f3c"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("5c30aeb3-c627-46e8-b271-e7b187591578"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("63c01766-e761-46c7-8183-ac7239d84e31"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("66b2e654-61f3-4165-8081-9780d8f51a69"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("6bde455d-901f-438e-bce3-10fe40b0990d"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("73713f2f-fe6c-4181-8f18-0f46fb39ccb6"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("76124e80-ebf4-49f3-a459-40f81db339dc"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("76e1827c-412b-4834-a671-a2e70c19b7c8"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("7a0f5b7f-cb7c-4075-aa0a-b55eec5c4fee"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("7a17511c-d688-46dc-bf79-178bb1bf0c09"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("89b1865a-9ee7-42d4-be9e-09c1912b837f"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("8a922192-6d6d-4dc1-997d-73b30a1da0ff"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("9bebc716-7784-48f8-88b5-52d532864134"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("a2d429cc-6e6a-4d0b-8fb4-a62c72a2ed6c"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("a3cc343e-a0c4-4954-9baf-fd3fe02def4f"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("a45cbbe3-d7b2-4d0d-821d-e385c0015cf2"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("b0243043-aaa5-466f-af3a-bc0f58ccd185"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("b0e8fc5f-182d-4b04-b11d-630645324e72"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("b3c56ae0-8873-4c4e-b47a-94d63bd55600"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("b6f9a4e4-ac8e-42f1-9306-b06d4c77dd28"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("b90d8bac-4ea0-4a8e-b297-66892fec23c8"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("c719bb02-e5af-4c0c-a0af-8526ba1c81cb"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("cd41596f-67b4-43b5-8b58-0f99d98c14f9"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("cf788827-0ece-490b-bdff-cf6dd9c51d84"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("da79cf46-ef40-479d-bc2c-83828a21635b"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("df7c1c6c-b76d-4368-b32b-72ddbbe48226"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("e015ff04-a0be-4412-8c1c-2ff99c4b8973"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("e052af3f-207e-4656-b1ef-2e1bc0400d0e"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("ec1a129a-0e77-4801-b147-7910a9ab7c53"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("f2ca1f87-4fe4-4c74-acc0-8d3ccf684361"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("f7675dff-440c-4314-bc1b-6bd2d7c8235f"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("fd1c2a2b-7a12-4635-89dc-e48c8c73aa44"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("2fa01484-0ef6-42f2-af50-4079e1d985ac"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("3aee1f38-c544-438e-8915-9c1b1ee06403"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("3cb706b1-5eed-4a59-9166-360dafd5d9e3"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("52934529-73bf-41f7-ad06-e2186e15e047"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("84507b0f-6e49-4423-954c-a67fbf8901f4"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("8a2f3c52-395e-40fa-b03b-4238b1f9cdf9"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfessorId",
                table: "ScientificWorks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Relevance",
                table: "ScientificWorks",
                type: "text",
                unicode: false,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "ScientificAreas",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("72c7ceb6-e25d-4453-b18f-0c41223b205f"), "Сельскохозяйственные науки" },
                    { new Guid("9a0c4e12-6d4f-4b04-b9b7-e5c111089524"), "Естественные науки" },
                    { new Guid("a6f71ad2-31a1-45cf-8d5c-307377697a42"), "Общественные науки" },
                    { new Guid("ab45ec15-577c-45fd-aec9-28886596050f"), "Медицина и здравоохранение" },
                    { new Guid("df10ecfd-16d2-47bf-8302-060c539743bd"), "Техника и технологии" },
                    { new Guid("e2c6d3e7-27ad-4582-828e-0c6708762849"), "Гуманитарные науки" }
                });

            migrationBuilder.InsertData(
                table: "ScientificAreaSubsections",
                columns: new[] { "Id", "Name", "ScientificAreaId" },
                values: new object[,]
                {
                    { new Guid("08435c18-6127-42db-a11e-c3a3daeea002"), "Другая инженерия и технологии", new Guid("df10ecfd-16d2-47bf-8302-060c539743bd") },
                    { new Guid("0c4df644-5dfa-4b63-9557-fecb8c6f2b3e"), "Науки о здоровье", new Guid("ab45ec15-577c-45fd-aec9-28886596050f") },
                    { new Guid("0ef3bfb8-c0c1-4797-99a6-bcdd90ecbd33"), "Фундаментальная медицина", new Guid("ab45ec15-577c-45fd-aec9-28886596050f") },
                    { new Guid("138ca349-69b9-4346-96ab-81aa83e24cbe"), "Химия", new Guid("9a0c4e12-6d4f-4b04-b9b7-e5c111089524") },
                    { new Guid("13cc8271-62d8-4e91-8cdf-a99a04e7ed48"), "Другие социальные науки", new Guid("a6f71ad2-31a1-45cf-8d5c-307377697a42") },
                    { new Guid("1457bb5e-0779-435b-b2c2-59adb3c422d8"), "Политология", new Guid("a6f71ad2-31a1-45cf-8d5c-307377697a42") },
                    { new Guid("1b229315-f6e7-43a3-b0f6-dd8d97917c79"), "Право", new Guid("a6f71ad2-31a1-45cf-8d5c-307377697a42") },
                    { new Guid("1f26e143-26ce-41e8-8bc9-94daf39d01d7"), "Психология", new Guid("a6f71ad2-31a1-45cf-8d5c-307377697a42") },
                    { new Guid("24443aac-dcca-496a-8427-a1949480cc29"), "Электротехника, электроника, информационная инженерия", new Guid("df10ecfd-16d2-47bf-8302-060c539743bd") },
                    { new Guid("3bcef72b-093f-419a-9188-50cebb231bfe"), "Социология", new Guid("a6f71ad2-31a1-45cf-8d5c-307377697a42") },
                    { new Guid("3c57ea01-75ef-473f-ab02-b25dcefd6447"), "Экологическая биотехнология", new Guid("df10ecfd-16d2-47bf-8302-060c539743bd") },
                    { new Guid("3faeb47b-3bc0-4de0-bfc9-782fa9684687"), "Машиностроение", new Guid("df10ecfd-16d2-47bf-8302-060c539743bd") },
                    { new Guid("456413f3-c2b1-4235-b9e5-e8e936d24da5"), "Науки о Земле и окружающей среде", new Guid("9a0c4e12-6d4f-4b04-b9b7-e5c111089524") },
                    { new Guid("47ec8d7b-6af2-4f51-bbab-3752041c17fc"), "Животноводство и молочное производство", new Guid("72c7ceb6-e25d-4453-b18f-0c41223b205f") },
                    { new Guid("4c8605c6-206e-41d3-8ad2-7ba14fa20450"), "Медицинская инженерия", new Guid("df10ecfd-16d2-47bf-8302-060c539743bd") },
                    { new Guid("4fca4294-e7cf-4fc7-9580-18a8dcaed388"), "Философия, этика и религия", new Guid("e2c6d3e7-27ad-4582-828e-0c6708762849") },
                    { new Guid("581ca504-1437-45af-9933-a1bb52fc58f6"), "Химическая инженерия", new Guid("df10ecfd-16d2-47bf-8302-060c539743bd") },
                    { new Guid("61bf800d-7014-4400-a30e-62297b8cab3d"), "Другие сельскохозяйственные науки", new Guid("72c7ceb6-e25d-4453-b18f-0c41223b205f") },
                    { new Guid("6cac6bec-5f67-4a0b-9c28-4fdfae70d50c"), "Ветеринария", new Guid("72c7ceb6-e25d-4453-b18f-0c41223b205f") },
                    { new Guid("6e49377e-ee86-4dbf-8980-15beaba8c32a"), "Экологическая инженерия", new Guid("df10ecfd-16d2-47bf-8302-060c539743bd") },
                    { new Guid("7287df13-56d2-43e7-a140-c772ec0f70fd"), "Социально-экономическая география", new Guid("a6f71ad2-31a1-45cf-8d5c-307377697a42") },
                    { new Guid("7a1afdf3-6ed7-4e67-8c09-6a03bcc3f43c"), "Компьютерные и информационные науки", new Guid("9a0c4e12-6d4f-4b04-b9b7-e5c111089524") },
                    { new Guid("8299329c-ffd8-4106-8159-89ad1646faf4"), "Промышленная биотехнология", new Guid("df10ecfd-16d2-47bf-8302-060c539743bd") },
                    { new Guid("84aefb80-3710-43b7-9402-e691f45dd29d"), "История и археология", new Guid("e2c6d3e7-27ad-4582-828e-0c6708762849") },
                    { new Guid("8cf2d4bb-eef8-44a0-9c5f-fed4fdebfc48"), "Другие медицинские науки", new Guid("ab45ec15-577c-45fd-aec9-28886596050f") },
                    { new Guid("9756d303-2518-4b81-9c11-b86f788fd27b"), "Другие естественные науки", new Guid("9a0c4e12-6d4f-4b04-b9b7-e5c111089524") },
                    { new Guid("97a8a352-9ff8-4f6a-91ed-9b9e198af6f2"), "Языки и литература", new Guid("e2c6d3e7-27ad-4582-828e-0c6708762849") },
                    { new Guid("9d7fac29-d4b7-44fe-862e-9429690db40c"), "Клиническая медицина", new Guid("ab45ec15-577c-45fd-aec9-28886596050f") },
                    { new Guid("9f467c4f-ea7d-4e98-be8a-c94ac0c97ba4"), "Экономика и бизнес", new Guid("a6f71ad2-31a1-45cf-8d5c-307377697a42") },
                    { new Guid("a903ce1c-98a3-4a54-9890-70bd9ed394c7"), "Физика", new Guid("9a0c4e12-6d4f-4b04-b9b7-e5c111089524") },
                    { new Guid("a9370a7a-9e4c-4d4c-a883-7a18e0f53630"), "Образовательные науки", new Guid("a6f71ad2-31a1-45cf-8d5c-307377697a42") },
                    { new Guid("af7a2c55-9cf7-45ff-93b8-9aa73946b719"), "Биология", new Guid("9a0c4e12-6d4f-4b04-b9b7-e5c111089524") },
                    { new Guid("be990cfc-183b-4fee-850e-61c735af460e"), "Медиа и коммуникации", new Guid("a6f71ad2-31a1-45cf-8d5c-307377697a42") },
                    { new Guid("c77d1c56-436c-4f73-a0b9-4467e81e7030"), "Нанотехнологии", new Guid("df10ecfd-16d2-47bf-8302-060c539743bd") },
                    { new Guid("cb2fe1fa-c007-453b-924b-43e19a1c92d1"), "Сельскохозяйственная биотехнология", new Guid("72c7ceb6-e25d-4453-b18f-0c41223b205f") },
                    { new Guid("dcd43019-1172-48c6-b1a7-c430807b654c"), "Математика", new Guid("9a0c4e12-6d4f-4b04-b9b7-e5c111089524") },
                    { new Guid("e0e4505d-bf80-4046-9a56-48436d4f0f48"), "Материаловедение", new Guid("df10ecfd-16d2-47bf-8302-060c539743bd") },
                    { new Guid("e28e9d02-5076-4b58-ade0-e7b935f2adb5"), "Медицинская биотехнология", new Guid("ab45ec15-577c-45fd-aec9-28886596050f") },
                    { new Guid("e326e34c-4c4c-4514-bcc7-9bc4a5983a54"), "Другие гуманитарные науки", new Guid("e2c6d3e7-27ad-4582-828e-0c6708762849") },
                    { new Guid("e95ce659-3baa-49d3-9590-44c95f8cdb31"), "Сельское, лесное и рыбное хозяйство", new Guid("72c7ceb6-e25d-4453-b18f-0c41223b205f") },
                    { new Guid("f57a67a3-3a33-4d1d-b1fd-cf520bfe8a73"), "Искусство (искусство, история искусств, исполнительское искусство, музыка)", new Guid("e2c6d3e7-27ad-4582-828e-0c6708762849") },
                    { new Guid("fdeecb82-a7cb-4b44-8a8b-f4f124ecf390"), "Гражданское строительство", new Guid("df10ecfd-16d2-47bf-8302-060c539743bd") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ScientificWorks_Professors_ProfessorId",
                table: "ScientificWorks",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
