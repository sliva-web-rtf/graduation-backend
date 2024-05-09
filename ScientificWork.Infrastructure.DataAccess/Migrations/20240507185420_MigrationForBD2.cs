using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ScientificWork.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MigrationForBD2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professors_ScientificAreas_ScientificAreaId",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "FK_ScientificWorks_ScientificAreas_ScientificAreaId",
                table: "ScientificWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_ScientificAreas_ScientificAreaId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ScientificAreaId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_ScientificWorks_ScientificAreaId",
                table: "ScientificWorks");

            migrationBuilder.DropIndex(
                name: "IX_Professors_ScientificAreaId",
                table: "Professors");

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("03e3006e-76a6-40b5-be9d-e5f531aa9820"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("0b2ec8f4-3ed0-4dd5-b676-1126859f019f"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("0c39e607-cc56-45f4-b3d9-b9cd7a1c01a9"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("0d5f5138-3aa8-4669-9462-e805d10c3ee1"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("165019f6-0eea-4079-851b-1f20e1170f0f"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("1b044bae-2750-4a85-a096-8207c0d95fb4"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("22bb63c8-d767-4bed-8731-1b69ef3e4829"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("265aee78-ecad-48cc-909a-a1e5138b023d"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("39dfb678-e407-4c5c-9906-1f5502577ff3"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("3e5d0490-5606-4244-aa1a-628368901b66"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("3f0f26e8-0148-4e3f-80c8-d04c09202055"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("438be3e0-10d7-4db4-ab4b-d4d09654cfa2"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("4777dd92-2fda-4312-b0c8-b66caacc05c8"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("4a305866-ebfd-4193-acca-04f90d90b17e"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("4cf536cb-3319-458b-8a0a-13e1cbbae253"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("55ae2a6f-c402-4ebc-8655-01e26c186473"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("57c25130-1bc7-464d-ae68-46d386582c76"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("580a85ae-1065-46b0-b96b-01615cdd4977"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("624d2a5f-041c-4e51-ba02-2ded5f7b9b74"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("64ef4d41-b5b6-49ba-9358-8fc5ab664c9e"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("6918faf4-b5da-4cdc-978e-f6b2ff0cbe5d"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("6b2c2785-b51c-4876-a31f-050a2d23ed42"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("6fd81b50-c619-4ddf-b2d1-ad96654cbde8"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("77a66026-36c5-43b1-9fe7-f54b97c1bd6e"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("789f1dfa-a4ec-4dd8-afbe-0c989dbbae30"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("78f36a4c-e238-4405-aee8-bc66e513238e"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("84994bf7-9e83-48d3-b6da-0ecdd97a1abe"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("89bbad88-ac75-41e0-8e63-2639e04d6df7"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("8caf91cf-f881-4a53-b500-64b89f7e9cb6"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("91275bd7-31fd-4338-92be-0013e1acdd6b"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("9e554df3-7f1c-40c4-b6aa-17fd303a48ec"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("a101eb37-6338-43a0-99e6-6eda9eb15bf7"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("ac6e6694-1bba-4170-847d-c715f2270ef7"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("b1ae13be-ad26-4098-82f1-e232bfdc69b2"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("cd25d45d-2803-42da-8d36-28c3e4eb76b5"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("d8e680de-f3e2-4d8e-8212-f7216574d82e"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("db51d57a-80ba-4f7c-a2c5-cf420a51a23e"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("ea995256-d632-4b17-94c0-859ef3ff7cc2"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("f055ba40-6f50-482d-a6dc-b3dfeccbfb5e"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("f38ab110-eb12-4302-a42c-13f4f23e8907"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("f5cc6c92-1a22-417f-ad66-42f47821bd3f"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("f9d77947-5d3b-4f4e-b0f3-33effeda4c73"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("009362e8-f7ba-44c8-bb50-f4831549ebc2"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("0ab6b566-a2e9-43a1-8469-ade0f2d8498f"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("5f83c0e3-9647-4213-9898-20690f5764a5"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("7e26d2ea-f0a6-450e-880c-2dfc0b4c71cb"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("8c0e690c-9093-467a-9594-20ad7eca39cf"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("c67789e3-b196-4bde-adeb-746efb0d018f"));

            migrationBuilder.DropColumn(
                name: "ScientificAreaId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ScientificAreaId",
                table: "ScientificWorks");

            migrationBuilder.DropColumn(
                name: "ScientificAreaId",
                table: "Professors");

            migrationBuilder.RenameColumn(
                name: "Titile",
                table: "ScientificWorks",
                newName: "Result");

            migrationBuilder.RenameColumn(
                name: "Problem",
                table: "ScientificWorks",
                newName: "Description");

            migrationBuilder.InsertData(
                table: "ScientificAreas",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("504e19de-408a-4e0a-8cb7-48ef54f77927"), "Техника и технологии" },
                    { new Guid("9333925b-600e-490d-8799-3cfc568c055c"), "Общественные науки" },
                    { new Guid("a1fab631-3a9d-4406-817a-81a142457bc9"), "Сельскохозяйственные науки" },
                    { new Guid("c02575a8-f8f6-443b-bf34-cc4c611eaa56"), "Естественные науки" },
                    { new Guid("ea637f26-0f94-4a20-8a4c-cbdb0e9d5b03"), "Гуманитарные науки" },
                    { new Guid("f0295263-40ad-4c76-ae74-84b62204f960"), "Медицина и здравоохранение" }
                });

            migrationBuilder.InsertData(
                table: "ScientificAreaSubsections",
                columns: new[] { "Id", "Name", "ScientificAreaId" },
                values: new object[,]
                {
                    { new Guid("1547e7c6-a7ce-4578-b89a-9243a21c4477"), "Философия, этика и религия", new Guid("ea637f26-0f94-4a20-8a4c-cbdb0e9d5b03") },
                    { new Guid("1789267c-cc66-4860-9014-7eb4bcf808d3"), "Сельское, лесное и рыбное хозяйство", new Guid("a1fab631-3a9d-4406-817a-81a142457bc9") },
                    { new Guid("19cdea20-0e7b-45db-9718-4e63188f911b"), "Материаловедение", new Guid("504e19de-408a-4e0a-8cb7-48ef54f77927") },
                    { new Guid("1cf61729-9b81-4404-8392-eaaf667e2b55"), "Нанотехнологии", new Guid("504e19de-408a-4e0a-8cb7-48ef54f77927") },
                    { new Guid("2522b61e-0c20-4722-9fdb-2d3a460e5094"), "Гражданское строительство", new Guid("504e19de-408a-4e0a-8cb7-48ef54f77927") },
                    { new Guid("2581d7b6-be07-4192-8596-0d4e0ff3d6d2"), "Другая инженерия и технологии", new Guid("504e19de-408a-4e0a-8cb7-48ef54f77927") },
                    { new Guid("2700c1f0-1e12-4cfe-9d53-3a6f4958868c"), "Психология", new Guid("9333925b-600e-490d-8799-3cfc568c055c") },
                    { new Guid("270470e4-45e9-4102-b36f-76ffce1cf1e5"), "Медицинская инженерия", new Guid("504e19de-408a-4e0a-8cb7-48ef54f77927") },
                    { new Guid("295a59ac-4ae8-4581-bab9-217aeffd7965"), "Электротехника, электроника, информационная инженерия", new Guid("504e19de-408a-4e0a-8cb7-48ef54f77927") },
                    { new Guid("2d516cb4-aaaa-43fc-a350-a2e85980a594"), "Биология", new Guid("c02575a8-f8f6-443b-bf34-cc4c611eaa56") },
                    { new Guid("334d234f-df7f-4d21-96a1-dfbe153e1d77"), "Искусство (искусство, история искусств, исполнительское искусство, музыка)", new Guid("ea637f26-0f94-4a20-8a4c-cbdb0e9d5b03") },
                    { new Guid("485e3787-e565-4248-8f57-b0bf22115746"), "Фундаментальная медицина", new Guid("f0295263-40ad-4c76-ae74-84b62204f960") },
                    { new Guid("541c065f-163f-4865-ab00-99e7396a78b9"), "История и археология", new Guid("ea637f26-0f94-4a20-8a4c-cbdb0e9d5b03") },
                    { new Guid("5c55b5a8-0a45-4190-a519-5b75c107f2a6"), "Социально-экономическая география", new Guid("9333925b-600e-490d-8799-3cfc568c055c") },
                    { new Guid("6583f065-39b4-4815-ba2b-56cef64eeb9f"), "Медицинская биотехнология", new Guid("f0295263-40ad-4c76-ae74-84b62204f960") },
                    { new Guid("6e04e447-7ceb-44b5-8306-570ab5e463e0"), "Языки и литература", new Guid("ea637f26-0f94-4a20-8a4c-cbdb0e9d5b03") },
                    { new Guid("72d60c11-a8d2-43cc-b654-6561252a24de"), "Компьютерные и информационные науки", new Guid("c02575a8-f8f6-443b-bf34-cc4c611eaa56") },
                    { new Guid("78357a86-0215-48e2-bf9a-76018b12eada"), "Машиностроение", new Guid("504e19de-408a-4e0a-8cb7-48ef54f77927") },
                    { new Guid("8460d38e-06fc-4a9b-91fc-3890860c22c4"), "Химия", new Guid("c02575a8-f8f6-443b-bf34-cc4c611eaa56") },
                    { new Guid("9137ba50-832b-48c8-92fe-521a90ba5a4f"), "Другие гуманитарные науки", new Guid("ea637f26-0f94-4a20-8a4c-cbdb0e9d5b03") },
                    { new Guid("950eaa3b-6d4d-4150-b67a-75baf4068b1e"), "Медиа и коммуникации", new Guid("9333925b-600e-490d-8799-3cfc568c055c") },
                    { new Guid("959343b9-920d-424e-9258-0280311e12ce"), "Другие медицинские науки", new Guid("f0295263-40ad-4c76-ae74-84b62204f960") },
                    { new Guid("95a333b5-ef29-4002-aa2f-e9a2d2bea612"), "Экономика и бизнес", new Guid("9333925b-600e-490d-8799-3cfc568c055c") },
                    { new Guid("96748663-7b1a-4f90-92f4-89ae5ea31590"), "Физика", new Guid("c02575a8-f8f6-443b-bf34-cc4c611eaa56") },
                    { new Guid("9fcc23a2-040d-4c41-be0d-25cdea04b3c1"), "Ветеринария", new Guid("a1fab631-3a9d-4406-817a-81a142457bc9") },
                    { new Guid("a0843abe-dc53-4a7a-b124-520330df23da"), "Науки о здоровье", new Guid("f0295263-40ad-4c76-ae74-84b62204f960") },
                    { new Guid("a2aadc74-bf10-4c15-b452-e5ec410167a0"), "Политология", new Guid("9333925b-600e-490d-8799-3cfc568c055c") },
                    { new Guid("a46f7bf8-46cd-4ef7-ae84-f42e1f98766b"), "Другие естественные науки", new Guid("c02575a8-f8f6-443b-bf34-cc4c611eaa56") },
                    { new Guid("bf8311e8-41c1-43be-bc7f-d80d69ed201e"), "Другие сельскохозяйственные науки", new Guid("a1fab631-3a9d-4406-817a-81a142457bc9") },
                    { new Guid("d03aea70-6ec6-470a-b9e2-b02e8198b9e9"), "Математика", new Guid("c02575a8-f8f6-443b-bf34-cc4c611eaa56") },
                    { new Guid("d053a8c6-2c6f-44b6-be38-43f67247c52a"), "Промышленная биотехнология", new Guid("504e19de-408a-4e0a-8cb7-48ef54f77927") },
                    { new Guid("d17df812-4f7f-4b6c-b4e1-a3554d92f7bc"), "Социология", new Guid("9333925b-600e-490d-8799-3cfc568c055c") },
                    { new Guid("d6d6afca-3126-4e00-948e-2d22291da2d7"), "Животноводство и молочное производство", new Guid("a1fab631-3a9d-4406-817a-81a142457bc9") },
                    { new Guid("dadd22e7-f5ca-4b67-859f-1a4978eb1613"), "Образовательные науки", new Guid("9333925b-600e-490d-8799-3cfc568c055c") },
                    { new Guid("decf020f-c2f8-45b7-bc89-d6f82c01f52d"), "Химическая инженерия", new Guid("504e19de-408a-4e0a-8cb7-48ef54f77927") },
                    { new Guid("e13cd49f-235d-4c1e-974c-50a4b55647a2"), "Экологическая биотехнология", new Guid("504e19de-408a-4e0a-8cb7-48ef54f77927") },
                    { new Guid("f180ff85-7e87-4ee4-b836-263c4e88f62e"), "Науки о Земле и окружающей среде", new Guid("c02575a8-f8f6-443b-bf34-cc4c611eaa56") },
                    { new Guid("f20828ce-69a4-4e77-b4f0-83c3d92554c3"), "Право", new Guid("9333925b-600e-490d-8799-3cfc568c055c") },
                    { new Guid("f3fe3772-ca92-43ce-9e30-0b9d13cdf4ad"), "Сельскохозяйственная биотехнология", new Guid("a1fab631-3a9d-4406-817a-81a142457bc9") },
                    { new Guid("f771d067-c21d-40b9-be59-d7762a88c8bb"), "Экологическая инженерия", new Guid("504e19de-408a-4e0a-8cb7-48ef54f77927") },
                    { new Guid("fbd78354-ad08-4e1f-8e10-ebbaff7d82e7"), "Клиническая медицина", new Guid("f0295263-40ad-4c76-ae74-84b62204f960") },
                    { new Guid("fbeb7038-1a0a-4499-a59a-f33bc6463c2b"), "Другие социальные науки", new Guid("9333925b-600e-490d-8799-3cfc568c055c") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("1547e7c6-a7ce-4578-b89a-9243a21c4477"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("1789267c-cc66-4860-9014-7eb4bcf808d3"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("19cdea20-0e7b-45db-9718-4e63188f911b"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("1cf61729-9b81-4404-8392-eaaf667e2b55"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("2522b61e-0c20-4722-9fdb-2d3a460e5094"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("2581d7b6-be07-4192-8596-0d4e0ff3d6d2"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("2700c1f0-1e12-4cfe-9d53-3a6f4958868c"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("270470e4-45e9-4102-b36f-76ffce1cf1e5"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("295a59ac-4ae8-4581-bab9-217aeffd7965"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("2d516cb4-aaaa-43fc-a350-a2e85980a594"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("334d234f-df7f-4d21-96a1-dfbe153e1d77"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("485e3787-e565-4248-8f57-b0bf22115746"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("541c065f-163f-4865-ab00-99e7396a78b9"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("5c55b5a8-0a45-4190-a519-5b75c107f2a6"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("6583f065-39b4-4815-ba2b-56cef64eeb9f"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("6e04e447-7ceb-44b5-8306-570ab5e463e0"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("72d60c11-a8d2-43cc-b654-6561252a24de"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("78357a86-0215-48e2-bf9a-76018b12eada"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("8460d38e-06fc-4a9b-91fc-3890860c22c4"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("9137ba50-832b-48c8-92fe-521a90ba5a4f"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("950eaa3b-6d4d-4150-b67a-75baf4068b1e"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("959343b9-920d-424e-9258-0280311e12ce"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("95a333b5-ef29-4002-aa2f-e9a2d2bea612"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("96748663-7b1a-4f90-92f4-89ae5ea31590"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("9fcc23a2-040d-4c41-be0d-25cdea04b3c1"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("a0843abe-dc53-4a7a-b124-520330df23da"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("a2aadc74-bf10-4c15-b452-e5ec410167a0"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("a46f7bf8-46cd-4ef7-ae84-f42e1f98766b"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("bf8311e8-41c1-43be-bc7f-d80d69ed201e"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("d03aea70-6ec6-470a-b9e2-b02e8198b9e9"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("d053a8c6-2c6f-44b6-be38-43f67247c52a"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("d17df812-4f7f-4b6c-b4e1-a3554d92f7bc"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("d6d6afca-3126-4e00-948e-2d22291da2d7"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("dadd22e7-f5ca-4b67-859f-1a4978eb1613"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("decf020f-c2f8-45b7-bc89-d6f82c01f52d"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("e13cd49f-235d-4c1e-974c-50a4b55647a2"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("f180ff85-7e87-4ee4-b836-263c4e88f62e"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("f20828ce-69a4-4e77-b4f0-83c3d92554c3"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("f3fe3772-ca92-43ce-9e30-0b9d13cdf4ad"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("f771d067-c21d-40b9-be59-d7762a88c8bb"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("fbd78354-ad08-4e1f-8e10-ebbaff7d82e7"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("fbeb7038-1a0a-4499-a59a-f33bc6463c2b"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("504e19de-408a-4e0a-8cb7-48ef54f77927"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("9333925b-600e-490d-8799-3cfc568c055c"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("a1fab631-3a9d-4406-817a-81a142457bc9"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("c02575a8-f8f6-443b-bf34-cc4c611eaa56"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("ea637f26-0f94-4a20-8a4c-cbdb0e9d5b03"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("f0295263-40ad-4c76-ae74-84b62204f960"));

            migrationBuilder.RenameColumn(
                name: "Result",
                table: "ScientificWorks",
                newName: "Titile");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ScientificWorks",
                newName: "Problem");

            migrationBuilder.AddColumn<Guid>(
                name: "ScientificAreaId",
                table: "Students",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ScientificAreaId",
                table: "ScientificWorks",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ScientificAreaId",
                table: "Professors",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "ScientificAreas",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("009362e8-f7ba-44c8-bb50-f4831549ebc2"), "Сельскохозяйственные науки" },
                    { new Guid("0ab6b566-a2e9-43a1-8469-ade0f2d8498f"), "Медицина и здравоохранение" },
                    { new Guid("5f83c0e3-9647-4213-9898-20690f5764a5"), "Естественные науки" },
                    { new Guid("7e26d2ea-f0a6-450e-880c-2dfc0b4c71cb"), "Общественные науки" },
                    { new Guid("8c0e690c-9093-467a-9594-20ad7eca39cf"), "Техника и технологии" },
                    { new Guid("c67789e3-b196-4bde-adeb-746efb0d018f"), "Гуманитарные науки" }
                });

            migrationBuilder.InsertData(
                table: "ScientificAreaSubsections",
                columns: new[] { "Id", "Name", "ScientificAreaId" },
                values: new object[,]
                {
                    { new Guid("03e3006e-76a6-40b5-be9d-e5f531aa9820"), "Философия, этика и религия", new Guid("c67789e3-b196-4bde-adeb-746efb0d018f") },
                    { new Guid("0b2ec8f4-3ed0-4dd5-b676-1126859f019f"), "Сельское, лесное и рыбное хозяйство", new Guid("009362e8-f7ba-44c8-bb50-f4831549ebc2") },
                    { new Guid("0c39e607-cc56-45f4-b3d9-b9cd7a1c01a9"), "Науки о здоровье", new Guid("0ab6b566-a2e9-43a1-8469-ade0f2d8498f") },
                    { new Guid("0d5f5138-3aa8-4669-9462-e805d10c3ee1"), "Социология", new Guid("7e26d2ea-f0a6-450e-880c-2dfc0b4c71cb") },
                    { new Guid("165019f6-0eea-4079-851b-1f20e1170f0f"), "Другие сельскохозяйственные науки", new Guid("009362e8-f7ba-44c8-bb50-f4831549ebc2") },
                    { new Guid("1b044bae-2750-4a85-a096-8207c0d95fb4"), "Науки о Земле и окружающей среде", new Guid("5f83c0e3-9647-4213-9898-20690f5764a5") },
                    { new Guid("22bb63c8-d767-4bed-8731-1b69ef3e4829"), "Экологическая биотехнология", new Guid("8c0e690c-9093-467a-9594-20ad7eca39cf") },
                    { new Guid("265aee78-ecad-48cc-909a-a1e5138b023d"), "История и археология", new Guid("c67789e3-b196-4bde-adeb-746efb0d018f") },
                    { new Guid("39dfb678-e407-4c5c-9906-1f5502577ff3"), "Право", new Guid("7e26d2ea-f0a6-450e-880c-2dfc0b4c71cb") },
                    { new Guid("3e5d0490-5606-4244-aa1a-628368901b66"), "Искусство (искусство, история искусств, исполнительское искусство, музыка)", new Guid("c67789e3-b196-4bde-adeb-746efb0d018f") },
                    { new Guid("3f0f26e8-0148-4e3f-80c8-d04c09202055"), "Социально-экономическая география", new Guid("7e26d2ea-f0a6-450e-880c-2dfc0b4c71cb") },
                    { new Guid("438be3e0-10d7-4db4-ab4b-d4d09654cfa2"), "Экологическая инженерия", new Guid("8c0e690c-9093-467a-9594-20ad7eca39cf") },
                    { new Guid("4777dd92-2fda-4312-b0c8-b66caacc05c8"), "Медицинская биотехнология", new Guid("0ab6b566-a2e9-43a1-8469-ade0f2d8498f") },
                    { new Guid("4a305866-ebfd-4193-acca-04f90d90b17e"), "Нанотехнологии", new Guid("8c0e690c-9093-467a-9594-20ad7eca39cf") },
                    { new Guid("4cf536cb-3319-458b-8a0a-13e1cbbae253"), "Образовательные науки", new Guid("7e26d2ea-f0a6-450e-880c-2dfc0b4c71cb") },
                    { new Guid("55ae2a6f-c402-4ebc-8655-01e26c186473"), "Биология", new Guid("5f83c0e3-9647-4213-9898-20690f5764a5") },
                    { new Guid("57c25130-1bc7-464d-ae68-46d386582c76"), "Машиностроение", new Guid("8c0e690c-9093-467a-9594-20ad7eca39cf") },
                    { new Guid("580a85ae-1065-46b0-b96b-01615cdd4977"), "Другие гуманитарные науки", new Guid("c67789e3-b196-4bde-adeb-746efb0d018f") },
                    { new Guid("624d2a5f-041c-4e51-ba02-2ded5f7b9b74"), "Другие социальные науки", new Guid("7e26d2ea-f0a6-450e-880c-2dfc0b4c71cb") },
                    { new Guid("64ef4d41-b5b6-49ba-9358-8fc5ab664c9e"), "Промышленная биотехнология", new Guid("8c0e690c-9093-467a-9594-20ad7eca39cf") },
                    { new Guid("6918faf4-b5da-4cdc-978e-f6b2ff0cbe5d"), "Ветеринария", new Guid("009362e8-f7ba-44c8-bb50-f4831549ebc2") },
                    { new Guid("6b2c2785-b51c-4876-a31f-050a2d23ed42"), "Экономика и бизнес", new Guid("7e26d2ea-f0a6-450e-880c-2dfc0b4c71cb") },
                    { new Guid("6fd81b50-c619-4ddf-b2d1-ad96654cbde8"), "Психология", new Guid("7e26d2ea-f0a6-450e-880c-2dfc0b4c71cb") },
                    { new Guid("77a66026-36c5-43b1-9fe7-f54b97c1bd6e"), "Другая инженерия и технологии", new Guid("8c0e690c-9093-467a-9594-20ad7eca39cf") },
                    { new Guid("789f1dfa-a4ec-4dd8-afbe-0c989dbbae30"), "Животноводство и молочное производство", new Guid("009362e8-f7ba-44c8-bb50-f4831549ebc2") },
                    { new Guid("78f36a4c-e238-4405-aee8-bc66e513238e"), "Медиа и коммуникации", new Guid("7e26d2ea-f0a6-450e-880c-2dfc0b4c71cb") },
                    { new Guid("84994bf7-9e83-48d3-b6da-0ecdd97a1abe"), "Клиническая медицина", new Guid("0ab6b566-a2e9-43a1-8469-ade0f2d8498f") },
                    { new Guid("89bbad88-ac75-41e0-8e63-2639e04d6df7"), "Другие медицинские науки", new Guid("0ab6b566-a2e9-43a1-8469-ade0f2d8498f") },
                    { new Guid("8caf91cf-f881-4a53-b500-64b89f7e9cb6"), "Материаловедение", new Guid("8c0e690c-9093-467a-9594-20ad7eca39cf") },
                    { new Guid("91275bd7-31fd-4338-92be-0013e1acdd6b"), "Химическая инженерия", new Guid("8c0e690c-9093-467a-9594-20ad7eca39cf") },
                    { new Guid("9e554df3-7f1c-40c4-b6aa-17fd303a48ec"), "Электротехника, электроника, информационная инженерия", new Guid("8c0e690c-9093-467a-9594-20ad7eca39cf") },
                    { new Guid("a101eb37-6338-43a0-99e6-6eda9eb15bf7"), "Химия", new Guid("5f83c0e3-9647-4213-9898-20690f5764a5") },
                    { new Guid("ac6e6694-1bba-4170-847d-c715f2270ef7"), "Физика", new Guid("5f83c0e3-9647-4213-9898-20690f5764a5") },
                    { new Guid("b1ae13be-ad26-4098-82f1-e232bfdc69b2"), "Математика", new Guid("5f83c0e3-9647-4213-9898-20690f5764a5") },
                    { new Guid("cd25d45d-2803-42da-8d36-28c3e4eb76b5"), "Политология", new Guid("7e26d2ea-f0a6-450e-880c-2dfc0b4c71cb") },
                    { new Guid("d8e680de-f3e2-4d8e-8212-f7216574d82e"), "Компьютерные и информационные науки", new Guid("5f83c0e3-9647-4213-9898-20690f5764a5") },
                    { new Guid("db51d57a-80ba-4f7c-a2c5-cf420a51a23e"), "Гражданское строительство", new Guid("8c0e690c-9093-467a-9594-20ad7eca39cf") },
                    { new Guid("ea995256-d632-4b17-94c0-859ef3ff7cc2"), "Фундаментальная медицина", new Guid("0ab6b566-a2e9-43a1-8469-ade0f2d8498f") },
                    { new Guid("f055ba40-6f50-482d-a6dc-b3dfeccbfb5e"), "Языки и литература", new Guid("c67789e3-b196-4bde-adeb-746efb0d018f") },
                    { new Guid("f38ab110-eb12-4302-a42c-13f4f23e8907"), "Сельскохозяйственная биотехнология", new Guid("009362e8-f7ba-44c8-bb50-f4831549ebc2") },
                    { new Guid("f5cc6c92-1a22-417f-ad66-42f47821bd3f"), "Медицинская инженерия", new Guid("8c0e690c-9093-467a-9594-20ad7eca39cf") },
                    { new Guid("f9d77947-5d3b-4f4e-b0f3-33effeda4c73"), "Другие естественные науки", new Guid("5f83c0e3-9647-4213-9898-20690f5764a5") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ScientificAreaId",
                table: "Students",
                column: "ScientificAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificWorks_ScientificAreaId",
                table: "ScientificWorks",
                column: "ScientificAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Professors_ScientificAreaId",
                table: "Professors",
                column: "ScientificAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professors_ScientificAreas_ScientificAreaId",
                table: "Professors",
                column: "ScientificAreaId",
                principalTable: "ScientificAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScientificWorks_ScientificAreas_ScientificAreaId",
                table: "ScientificWorks",
                column: "ScientificAreaId",
                principalTable: "ScientificAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ScientificAreas_ScientificAreaId",
                table: "Students",
                column: "ScientificAreaId",
                principalTable: "ScientificAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
