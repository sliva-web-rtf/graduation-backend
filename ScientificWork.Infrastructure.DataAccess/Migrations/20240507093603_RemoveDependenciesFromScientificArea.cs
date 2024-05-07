using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ScientificWork.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDependenciesFromScientificArea : Migration
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
                keyValue: new Guid("04e61890-8754-43eb-9eca-f67c731b3ec6"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("0e1e10c3-5371-4245-803f-39f70ba33326"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("0fb83cd3-65da-4fbc-b4cb-c17ea28b60cc"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("1270d921-6e38-49d1-963c-e2967747c954"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("139c3624-9e19-4500-8972-9e41900fac4f"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("195f7eb4-3277-466a-9d2b-d598a9c80774"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("1acdeef2-9ed9-496f-aa0b-e95aaa2ada40"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("363caaf6-e360-4bde-b29c-705f2b0d92b8"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("3673ca3d-1e5f-4796-8c89-dce365e7a9c7"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("3e15ce98-1ec4-484c-b421-327d5bf27a7a"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("48b89ee2-66de-4107-af90-67be4fd86f56"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("48d8e39b-522d-4b1a-92f6-6120c422048e"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("4c2bd2a9-1bb3-476c-90c0-c6af7f4f89c6"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("4ef94582-ab1b-4861-8381-03c8f4d1d44c"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("5b444798-93ae-4f0b-af2c-d3f9ffe32682"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("699c2b1c-7ca5-4909-8f69-73c339ed1edf"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("703fe571-7309-422e-b660-7cdd7c29911f"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("77ab53a0-faec-4443-be90-71f047789510"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("7ad8af4d-8125-4945-a1b1-1152c982f9e4"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("7e13e96c-4e8d-404c-9def-be23a95fd8b3"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("841e6079-d0d5-4a53-bc77-8f9081d82785"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("84c2a1af-9f5e-401e-a0f5-d33ceff30a78"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("8a5ca348-a24f-4169-a53c-57cc40d12f3a"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("929693a2-2cb5-4e64-90e0-18cbcd7c0f99"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("956c1dbc-faca-4c6b-87c5-fc5e3eea0b78"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("96ff00a6-218f-4784-a453-b5b8095b0d9c"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("a485ab5a-ec0d-4247-9a2f-fac177818216"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("acf964d2-2ad5-4a3c-8ce4-cf1d5601439e"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("b3c220be-d184-461e-a52b-62ad9178d1cc"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("be317e91-e36d-4ca0-be5d-6e1c18c8ebdd"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("d038f03e-1096-45a5-87ee-189db6da9dfb"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("d2727ff0-7ab7-438e-8dd0-8993ed313460"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("d7d79e07-b3b0-412e-924a-21905305c21c"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("dc849d54-4119-4ad9-a482-1ee1f25f1b70"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("dcc75bba-b845-4776-936b-fa088180dc05"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("eb3150f6-1e94-48e2-88d9-07ad27fcbe96"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("f11b809b-6a5b-4baa-ad3a-20ee1fdd42f9"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("f4937c21-099e-49f6-9868-2bc61ca2b1cd"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("f76b4ad2-c068-4e6f-a17a-34ae80d171de"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("fab1efbb-f333-4867-92ab-154f1f861eb1"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("fbcb483d-2a9b-4c12-a40f-375f0a5cf43b"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("fcf32bdc-e039-4df1-8173-9f90fa8e45f7"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("0f2758bb-ee55-4d24-9e28-7ae3b0af052f"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("5eb466be-81f0-4af1-85ff-3626ffaad5cd"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("700fb95f-8de8-4c68-b323-2b9cfc732dba"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("ab21f0f4-c0e6-4c45-b0e2-9303fdd76bff"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("ea2f5aa3-90c3-4a2b-bb0c-a8d5234b1354"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("ef2e443c-ea76-40f2-bc9e-ad12b26467aa"));

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
                    { new Guid("0f918953-8ca9-4191-8c06-0ea97b66f2b0"), "Гуманитарные науки" },
                    { new Guid("1eb09ee0-b791-417c-a670-e61f6bcff8c6"), "Техника и технологии" },
                    { new Guid("2ae412a7-ce75-49f8-9b4a-1e485f3024d9"), "Естественные науки" },
                    { new Guid("ab55c51b-c9af-4e26-89d2-38bd43e95dab"), "Медицина и здравоохранение" },
                    { new Guid("e98e8a06-fe72-4a79-928d-8498afcf374c"), "Сельскохозяйственные науки" },
                    { new Guid("fa35c8d0-0333-4293-8c87-1e5d3f170c4d"), "Общественные науки" }
                });

            migrationBuilder.InsertData(
                table: "ScientificAreaSubsections",
                columns: new[] { "Id", "Name", "ScientificAreaId" },
                values: new object[,]
                {
                    { new Guid("0069f195-730d-49a3-a293-d3c6a13132a0"), "Языки и литература", new Guid("0f918953-8ca9-4191-8c06-0ea97b66f2b0") },
                    { new Guid("0fd501bb-5a0a-44d8-9246-5973eb0455c4"), "Науки о здоровье", new Guid("ab55c51b-c9af-4e26-89d2-38bd43e95dab") },
                    { new Guid("1308322c-aef5-44e5-b21c-ad3d6efb65d8"), "Сельское, лесное и рыбное хозяйство", new Guid("e98e8a06-fe72-4a79-928d-8498afcf374c") },
                    { new Guid("1394deae-bb80-4b66-ba4b-c210403504ff"), "Материаловедение", new Guid("1eb09ee0-b791-417c-a670-e61f6bcff8c6") },
                    { new Guid("2409924b-b522-455d-86b9-c5b88821c8cc"), "Физика", new Guid("2ae412a7-ce75-49f8-9b4a-1e485f3024d9") },
                    { new Guid("2d22aeb2-e382-4a2d-b554-b15f3e1e71e7"), "Машиностроение", new Guid("1eb09ee0-b791-417c-a670-e61f6bcff8c6") },
                    { new Guid("2ddccb9d-43c0-49c3-8895-dd3c6fd78c11"), "Другие сельскохозяйственные науки", new Guid("e98e8a06-fe72-4a79-928d-8498afcf374c") },
                    { new Guid("33168a49-c8e2-4a27-b2e3-6a415144773e"), "Образовательные науки", new Guid("fa35c8d0-0333-4293-8c87-1e5d3f170c4d") },
                    { new Guid("36554dd6-d631-48b3-9988-3ff4fc935a3b"), "Гражданское строительство", new Guid("1eb09ee0-b791-417c-a670-e61f6bcff8c6") },
                    { new Guid("397882ab-b46a-4808-a135-864f44047405"), "Право", new Guid("fa35c8d0-0333-4293-8c87-1e5d3f170c4d") },
                    { new Guid("475e2a80-2153-4453-b451-2c80974679c4"), "Промышленная биотехнология", new Guid("1eb09ee0-b791-417c-a670-e61f6bcff8c6") },
                    { new Guid("4c0ddbd2-3276-4f16-ad06-139e2eaa0b95"), "Экологическая инженерия", new Guid("1eb09ee0-b791-417c-a670-e61f6bcff8c6") },
                    { new Guid("53c4081d-4164-48e9-80fe-4fd68e62f932"), "Химическая инженерия", new Guid("1eb09ee0-b791-417c-a670-e61f6bcff8c6") },
                    { new Guid("5614f071-b04d-4f16-ac9c-148d42003d9e"), "Нанотехнологии", new Guid("1eb09ee0-b791-417c-a670-e61f6bcff8c6") },
                    { new Guid("59ec8fc8-b4ce-492c-90a4-75f353589dbb"), "Сельскохозяйственная биотехнология", new Guid("e98e8a06-fe72-4a79-928d-8498afcf374c") },
                    { new Guid("6702b279-7e5e-4faf-9568-e3126236921e"), "История и археология", new Guid("0f918953-8ca9-4191-8c06-0ea97b66f2b0") },
                    { new Guid("67dd0e1d-ec4e-49b6-a9bc-e881b1f01d9f"), "Фундаментальная медицина", new Guid("ab55c51b-c9af-4e26-89d2-38bd43e95dab") },
                    { new Guid("6c4f3748-7892-44d4-a4b4-85b00348c6f0"), "Философия, этика и религия", new Guid("0f918953-8ca9-4191-8c06-0ea97b66f2b0") },
                    { new Guid("74aa8a42-1b53-48f5-8dcc-74f7636673be"), "Медицинская инженерия", new Guid("1eb09ee0-b791-417c-a670-e61f6bcff8c6") },
                    { new Guid("7901c6d6-f679-46da-a5a8-a35166d91ab9"), "Другие социальные науки", new Guid("fa35c8d0-0333-4293-8c87-1e5d3f170c4d") },
                    { new Guid("7c129470-4085-45aa-b5bb-233e172f433e"), "Биология", new Guid("2ae412a7-ce75-49f8-9b4a-1e485f3024d9") },
                    { new Guid("7db6d952-7c78-44d9-9387-5d92c4ac4787"), "Клиническая медицина", new Guid("ab55c51b-c9af-4e26-89d2-38bd43e95dab") },
                    { new Guid("847c5c61-595a-476e-904f-239d7a2b3be8"), "Математика", new Guid("2ae412a7-ce75-49f8-9b4a-1e485f3024d9") },
                    { new Guid("8c4a2c41-148f-48bd-9358-dc6c5e58f7e7"), "Социально-экономическая география", new Guid("fa35c8d0-0333-4293-8c87-1e5d3f170c4d") },
                    { new Guid("8c7e4826-36b2-4bf0-929d-c17766fbc674"), "Животноводство и молочное производство", new Guid("e98e8a06-fe72-4a79-928d-8498afcf374c") },
                    { new Guid("8dbbf0f2-fd29-41e9-9cfc-9e7c18cc7438"), "Ветеринария", new Guid("e98e8a06-fe72-4a79-928d-8498afcf374c") },
                    { new Guid("97a2fb90-fc9d-49ff-a811-58b9d75cc003"), "Медиа и коммуникации", new Guid("fa35c8d0-0333-4293-8c87-1e5d3f170c4d") },
                    { new Guid("97d12ba5-d929-401b-b19b-165099eb222b"), "Другие гуманитарные науки", new Guid("0f918953-8ca9-4191-8c06-0ea97b66f2b0") },
                    { new Guid("ac1bd525-64bb-4342-a498-eab2e686f42c"), "Экологическая биотехнология", new Guid("1eb09ee0-b791-417c-a670-e61f6bcff8c6") },
                    { new Guid("af198457-44ec-4f65-a73e-b45bffecabc4"), "Социология", new Guid("fa35c8d0-0333-4293-8c87-1e5d3f170c4d") },
                    { new Guid("b4726ec7-86f8-46bf-ac62-5446508dfdd4"), "Химия", new Guid("2ae412a7-ce75-49f8-9b4a-1e485f3024d9") },
                    { new Guid("c35860b1-07ef-4523-8c4a-796431ffe6d2"), "Медицинская биотехнология", new Guid("ab55c51b-c9af-4e26-89d2-38bd43e95dab") },
                    { new Guid("c9e01411-2e02-45c0-9ce7-42c17674b00b"), "Экономика и бизнес", new Guid("fa35c8d0-0333-4293-8c87-1e5d3f170c4d") },
                    { new Guid("d3321236-bb62-4d6f-806d-87ce103752a4"), "Другие естественные науки", new Guid("2ae412a7-ce75-49f8-9b4a-1e485f3024d9") },
                    { new Guid("dadcd1c6-40aa-4b10-8a1d-d8408294c7cf"), "Другая инженерия и технологии", new Guid("1eb09ee0-b791-417c-a670-e61f6bcff8c6") },
                    { new Guid("e465e24c-3604-4ee1-8722-a4c95c490348"), "Электротехника, электроника, информационная инженерия", new Guid("1eb09ee0-b791-417c-a670-e61f6bcff8c6") },
                    { new Guid("ef1ed3b7-0724-4b5c-b65d-081d1dbcdb8c"), "Политология", new Guid("fa35c8d0-0333-4293-8c87-1e5d3f170c4d") },
                    { new Guid("f0e16825-4a54-4249-b13e-407001c6e3cc"), "Компьютерные и информационные науки", new Guid("2ae412a7-ce75-49f8-9b4a-1e485f3024d9") },
                    { new Guid("f19fe290-6057-4202-ba53-f1bcac686ed4"), "Науки о Земле и окружающей среде", new Guid("2ae412a7-ce75-49f8-9b4a-1e485f3024d9") },
                    { new Guid("f2cbc046-8c69-4a5b-a3f7-0e150656893a"), "Психология", new Guid("fa35c8d0-0333-4293-8c87-1e5d3f170c4d") },
                    { new Guid("fb2d2396-f564-44a6-9164-7127f90c55da"), "Искусство (искусство, история искусств, исполнительское искусство, музыка)", new Guid("0f918953-8ca9-4191-8c06-0ea97b66f2b0") },
                    { new Guid("fd809530-cb21-4147-bbdc-fc21d6a5afdd"), "Другие медицинские науки", new Guid("ab55c51b-c9af-4e26-89d2-38bd43e95dab") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("0069f195-730d-49a3-a293-d3c6a13132a0"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("0fd501bb-5a0a-44d8-9246-5973eb0455c4"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("1308322c-aef5-44e5-b21c-ad3d6efb65d8"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("1394deae-bb80-4b66-ba4b-c210403504ff"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("2409924b-b522-455d-86b9-c5b88821c8cc"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("2d22aeb2-e382-4a2d-b554-b15f3e1e71e7"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("2ddccb9d-43c0-49c3-8895-dd3c6fd78c11"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("33168a49-c8e2-4a27-b2e3-6a415144773e"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("36554dd6-d631-48b3-9988-3ff4fc935a3b"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("397882ab-b46a-4808-a135-864f44047405"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("475e2a80-2153-4453-b451-2c80974679c4"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("4c0ddbd2-3276-4f16-ad06-139e2eaa0b95"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("53c4081d-4164-48e9-80fe-4fd68e62f932"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("5614f071-b04d-4f16-ac9c-148d42003d9e"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("59ec8fc8-b4ce-492c-90a4-75f353589dbb"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("6702b279-7e5e-4faf-9568-e3126236921e"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("67dd0e1d-ec4e-49b6-a9bc-e881b1f01d9f"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("6c4f3748-7892-44d4-a4b4-85b00348c6f0"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("74aa8a42-1b53-48f5-8dcc-74f7636673be"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("7901c6d6-f679-46da-a5a8-a35166d91ab9"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("7c129470-4085-45aa-b5bb-233e172f433e"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("7db6d952-7c78-44d9-9387-5d92c4ac4787"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("847c5c61-595a-476e-904f-239d7a2b3be8"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("8c4a2c41-148f-48bd-9358-dc6c5e58f7e7"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("8c7e4826-36b2-4bf0-929d-c17766fbc674"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("8dbbf0f2-fd29-41e9-9cfc-9e7c18cc7438"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("97a2fb90-fc9d-49ff-a811-58b9d75cc003"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("97d12ba5-d929-401b-b19b-165099eb222b"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("ac1bd525-64bb-4342-a498-eab2e686f42c"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("af198457-44ec-4f65-a73e-b45bffecabc4"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("b4726ec7-86f8-46bf-ac62-5446508dfdd4"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("c35860b1-07ef-4523-8c4a-796431ffe6d2"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("c9e01411-2e02-45c0-9ce7-42c17674b00b"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("d3321236-bb62-4d6f-806d-87ce103752a4"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("dadcd1c6-40aa-4b10-8a1d-d8408294c7cf"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("e465e24c-3604-4ee1-8722-a4c95c490348"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("ef1ed3b7-0724-4b5c-b65d-081d1dbcdb8c"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("f0e16825-4a54-4249-b13e-407001c6e3cc"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("f19fe290-6057-4202-ba53-f1bcac686ed4"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("f2cbc046-8c69-4a5b-a3f7-0e150656893a"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("fb2d2396-f564-44a6-9164-7127f90c55da"));

            migrationBuilder.DeleteData(
                table: "ScientificAreaSubsections",
                keyColumn: "Id",
                keyValue: new Guid("fd809530-cb21-4147-bbdc-fc21d6a5afdd"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("0f918953-8ca9-4191-8c06-0ea97b66f2b0"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("1eb09ee0-b791-417c-a670-e61f6bcff8c6"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("2ae412a7-ce75-49f8-9b4a-1e485f3024d9"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("ab55c51b-c9af-4e26-89d2-38bd43e95dab"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("e98e8a06-fe72-4a79-928d-8498afcf374c"));

            migrationBuilder.DeleteData(
                table: "ScientificAreas",
                keyColumn: "Id",
                keyValue: new Guid("fa35c8d0-0333-4293-8c87-1e5d3f170c4d"));

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
                    { new Guid("0f2758bb-ee55-4d24-9e28-7ae3b0af052f"), "Техника и технологии" },
                    { new Guid("5eb466be-81f0-4af1-85ff-3626ffaad5cd"), "Гуманитарные науки" },
                    { new Guid("700fb95f-8de8-4c68-b323-2b9cfc732dba"), "Общественные науки" },
                    { new Guid("ab21f0f4-c0e6-4c45-b0e2-9303fdd76bff"), "Сельскохозяйственные науки" },
                    { new Guid("ea2f5aa3-90c3-4a2b-bb0c-a8d5234b1354"), "Естественные науки" },
                    { new Guid("ef2e443c-ea76-40f2-bc9e-ad12b26467aa"), "Медицина и здравоохранение" }
                });

            migrationBuilder.InsertData(
                table: "ScientificAreaSubsections",
                columns: new[] { "Id", "Name", "ScientificAreaId" },
                values: new object[,]
                {
                    { new Guid("04e61890-8754-43eb-9eca-f67c731b3ec6"), "Языки и литература", new Guid("5eb466be-81f0-4af1-85ff-3626ffaad5cd") },
                    { new Guid("0e1e10c3-5371-4245-803f-39f70ba33326"), "Экологическая инженерия", new Guid("0f2758bb-ee55-4d24-9e28-7ae3b0af052f") },
                    { new Guid("0fb83cd3-65da-4fbc-b4cb-c17ea28b60cc"), "Ветеринария", new Guid("ab21f0f4-c0e6-4c45-b0e2-9303fdd76bff") },
                    { new Guid("1270d921-6e38-49d1-963c-e2967747c954"), "Другие естественные науки", new Guid("ea2f5aa3-90c3-4a2b-bb0c-a8d5234b1354") },
                    { new Guid("139c3624-9e19-4500-8972-9e41900fac4f"), "Политология", new Guid("700fb95f-8de8-4c68-b323-2b9cfc732dba") },
                    { new Guid("195f7eb4-3277-466a-9d2b-d598a9c80774"), "Философия, этика и религия", new Guid("5eb466be-81f0-4af1-85ff-3626ffaad5cd") },
                    { new Guid("1acdeef2-9ed9-496f-aa0b-e95aaa2ada40"), "Экологическая биотехнология", new Guid("0f2758bb-ee55-4d24-9e28-7ae3b0af052f") },
                    { new Guid("363caaf6-e360-4bde-b29c-705f2b0d92b8"), "Медицинская инженерия", new Guid("0f2758bb-ee55-4d24-9e28-7ae3b0af052f") },
                    { new Guid("3673ca3d-1e5f-4796-8c89-dce365e7a9c7"), "Математика", new Guid("ea2f5aa3-90c3-4a2b-bb0c-a8d5234b1354") },
                    { new Guid("3e15ce98-1ec4-484c-b421-327d5bf27a7a"), "Медиа и коммуникации", new Guid("700fb95f-8de8-4c68-b323-2b9cfc732dba") },
                    { new Guid("48b89ee2-66de-4107-af90-67be4fd86f56"), "Животноводство и молочное производство", new Guid("ab21f0f4-c0e6-4c45-b0e2-9303fdd76bff") },
                    { new Guid("48d8e39b-522d-4b1a-92f6-6120c422048e"), "Науки о Земле и окружающей среде", new Guid("ea2f5aa3-90c3-4a2b-bb0c-a8d5234b1354") },
                    { new Guid("4c2bd2a9-1bb3-476c-90c0-c6af7f4f89c6"), "Сельское, лесное и рыбное хозяйство", new Guid("ab21f0f4-c0e6-4c45-b0e2-9303fdd76bff") },
                    { new Guid("4ef94582-ab1b-4861-8381-03c8f4d1d44c"), "Медицинская биотехнология", new Guid("ef2e443c-ea76-40f2-bc9e-ad12b26467aa") },
                    { new Guid("5b444798-93ae-4f0b-af2c-d3f9ffe32682"), "Компьютерные и информационные науки", new Guid("ea2f5aa3-90c3-4a2b-bb0c-a8d5234b1354") },
                    { new Guid("699c2b1c-7ca5-4909-8f69-73c339ed1edf"), "Образовательные науки", new Guid("700fb95f-8de8-4c68-b323-2b9cfc732dba") },
                    { new Guid("703fe571-7309-422e-b660-7cdd7c29911f"), "Другие социальные науки", new Guid("700fb95f-8de8-4c68-b323-2b9cfc732dba") },
                    { new Guid("77ab53a0-faec-4443-be90-71f047789510"), "Экономика и бизнес", new Guid("700fb95f-8de8-4c68-b323-2b9cfc732dba") },
                    { new Guid("7ad8af4d-8125-4945-a1b1-1152c982f9e4"), "Фундаментальная медицина", new Guid("ef2e443c-ea76-40f2-bc9e-ad12b26467aa") },
                    { new Guid("7e13e96c-4e8d-404c-9def-be23a95fd8b3"), "История и археология", new Guid("5eb466be-81f0-4af1-85ff-3626ffaad5cd") },
                    { new Guid("841e6079-d0d5-4a53-bc77-8f9081d82785"), "Нанотехнологии", new Guid("0f2758bb-ee55-4d24-9e28-7ae3b0af052f") },
                    { new Guid("84c2a1af-9f5e-401e-a0f5-d33ceff30a78"), "Социология", new Guid("700fb95f-8de8-4c68-b323-2b9cfc732dba") },
                    { new Guid("8a5ca348-a24f-4169-a53c-57cc40d12f3a"), "Машиностроение", new Guid("0f2758bb-ee55-4d24-9e28-7ae3b0af052f") },
                    { new Guid("929693a2-2cb5-4e64-90e0-18cbcd7c0f99"), "Науки о здоровье", new Guid("ef2e443c-ea76-40f2-bc9e-ad12b26467aa") },
                    { new Guid("956c1dbc-faca-4c6b-87c5-fc5e3eea0b78"), "Искусство (искусство, история искусств, исполнительское искусство, музыка)", new Guid("5eb466be-81f0-4af1-85ff-3626ffaad5cd") },
                    { new Guid("96ff00a6-218f-4784-a453-b5b8095b0d9c"), "Психология", new Guid("700fb95f-8de8-4c68-b323-2b9cfc732dba") },
                    { new Guid("a485ab5a-ec0d-4247-9a2f-fac177818216"), "Социально-экономическая география", new Guid("700fb95f-8de8-4c68-b323-2b9cfc732dba") },
                    { new Guid("acf964d2-2ad5-4a3c-8ce4-cf1d5601439e"), "Химия", new Guid("ea2f5aa3-90c3-4a2b-bb0c-a8d5234b1354") },
                    { new Guid("b3c220be-d184-461e-a52b-62ad9178d1cc"), "Физика", new Guid("ea2f5aa3-90c3-4a2b-bb0c-a8d5234b1354") },
                    { new Guid("be317e91-e36d-4ca0-be5d-6e1c18c8ebdd"), "Гражданское строительство", new Guid("0f2758bb-ee55-4d24-9e28-7ae3b0af052f") },
                    { new Guid("d038f03e-1096-45a5-87ee-189db6da9dfb"), "Промышленная биотехнология", new Guid("0f2758bb-ee55-4d24-9e28-7ae3b0af052f") },
                    { new Guid("d2727ff0-7ab7-438e-8dd0-8993ed313460"), "Материаловедение", new Guid("0f2758bb-ee55-4d24-9e28-7ae3b0af052f") },
                    { new Guid("d7d79e07-b3b0-412e-924a-21905305c21c"), "Биология", new Guid("ea2f5aa3-90c3-4a2b-bb0c-a8d5234b1354") },
                    { new Guid("dc849d54-4119-4ad9-a482-1ee1f25f1b70"), "Другая инженерия и технологии", new Guid("0f2758bb-ee55-4d24-9e28-7ae3b0af052f") },
                    { new Guid("dcc75bba-b845-4776-936b-fa088180dc05"), "Право", new Guid("700fb95f-8de8-4c68-b323-2b9cfc732dba") },
                    { new Guid("eb3150f6-1e94-48e2-88d9-07ad27fcbe96"), "Химическая инженерия", new Guid("0f2758bb-ee55-4d24-9e28-7ae3b0af052f") },
                    { new Guid("f11b809b-6a5b-4baa-ad3a-20ee1fdd42f9"), "Клиническая медицина", new Guid("ef2e443c-ea76-40f2-bc9e-ad12b26467aa") },
                    { new Guid("f4937c21-099e-49f6-9868-2bc61ca2b1cd"), "Электротехника, электроника, информационная инженерия", new Guid("0f2758bb-ee55-4d24-9e28-7ae3b0af052f") },
                    { new Guid("f76b4ad2-c068-4e6f-a17a-34ae80d171de"), "Другие медицинские науки", new Guid("ef2e443c-ea76-40f2-bc9e-ad12b26467aa") },
                    { new Guid("fab1efbb-f333-4867-92ab-154f1f861eb1"), "Другие гуманитарные науки", new Guid("5eb466be-81f0-4af1-85ff-3626ffaad5cd") },
                    { new Guid("fbcb483d-2a9b-4c12-a40f-375f0a5cf43b"), "Другие сельскохозяйственные науки", new Guid("ab21f0f4-c0e6-4c45-b0e2-9303fdd76bff") },
                    { new Guid("fcf32bdc-e039-4df1-8173-9f90fa8e45f7"), "Сельскохозяйственная биотехнология", new Guid("ab21f0f4-c0e6-4c45-b0e2-9303fdd76bff") }
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
