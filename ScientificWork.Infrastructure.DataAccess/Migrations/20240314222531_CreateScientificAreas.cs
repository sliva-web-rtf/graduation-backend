using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ScientificWork.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateScientificAreas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
