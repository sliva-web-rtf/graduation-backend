using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.ScientificAreas;

namespace ScientificWork.Infrastructure.DataAccess.ModelConfigurations;

public static class CreateScientificAreas
{
    public static void CreateDefaultScientificArea(this ModelBuilder modelBuilder)
    {
        var scientificAreas = new List<ScientificArea>
        {
            new()
            {
                Id = new Guid("49d83ccd-5a46-4d1e-9e1e-437d1666922a"),
                Name = "Естественные науки"
            },
            new()
            {
                Id = new Guid("9030412f-db3f-49b9-8af6-f436c47854ad"),
                Name = "Техника и технологии"
            },
            new()
            {
                Id = new Guid("8a2dbe51-897b-4da7-9880-5cf2ee02882f"),
                Name = "Медицина и здравоохранение"
            },
            new()
            {
                Id = new Guid("d6b1b967-ec58-4656-bb06-160c911385a8"),
                Name = "Сельскохозяйственные науки"
            },
            new()
            {
                Id = new Guid("9bd5aeb3-6d21-446e-bf7e-0b9a607aa9ec"),
                Name = "Общественные науки"
            },
            new()
            {
                Id = new Guid("243d65dd-16f0-426d-be10-0202ca133029"),
                Name = "Гуманитарные науки"
            }
        };
        var scientificAreaSubsection = new List<ScientificAreaSubsection>
        {
            new()
            {
                Id = new Guid("c8316d83-8ad4-494a-a261-f09c23b6919f"),
                Name = "Математика",
                ScientificAreaId = new Guid("49d83ccd-5a46-4d1e-9e1e-437d1666922a")
            },
            new()
            {
                Id = new Guid("488b55f1-c63a-4f8c-888e-a5a92e4ceab4"),
                Name = "Компьютерные и информационные науки",
                ScientificAreaId = new Guid("49d83ccd-5a46-4d1e-9e1e-437d1666922a")
            },
            new()
            {
                Id = new Guid("cd20a1f4-5bc9-4dec-b736-31c958cb4785"),
                Name = "Физика",
                ScientificAreaId = new Guid("49d83ccd-5a46-4d1e-9e1e-437d1666922a")
            },
            new()
            {
                Id = new Guid("d3636264-ed0a-48ef-97c5-3e9a307477f5"),
                Name = "Химия",
                ScientificAreaId = new Guid("49d83ccd-5a46-4d1e-9e1e-437d1666922a")
            },
            new()
            {
                Id = new Guid("dd97de2c-bc12-46aa-8e57-df5a215801d9"),
                Name = "Науки о Земле и окружающей среде",
                ScientificAreaId = new Guid("49d83ccd-5a46-4d1e-9e1e-437d1666922a")
            },
            new()
            {
                Id = new Guid("91201366-dca6-4deb-91a7-62284f958a6f"),
                Name = "Биология",
                ScientificAreaId = new Guid("49d83ccd-5a46-4d1e-9e1e-437d1666922a")
            },
            new()
            {
                Id = new Guid("185eeb7b-936c-4859-a7e1-89566fa61d81"),
                Name = "Другие естественные науки",
                ScientificAreaId = new Guid("49d83ccd-5a46-4d1e-9e1e-437d1666922a")
            },
            new()
            {
                Id = new Guid("093b968f-e175-4a48-9ca2-c12dbc3acbe8"),
                Name = "Гражданское строительство",
                ScientificAreaId = new Guid("9030412f-db3f-49b9-8af6-f436c47854ad")
            },
            new()
            {
                Id = new Guid("c6da9860-98b1-49ed-989c-0f81b2f20e0e"),
                Name = "Экологическая инженерия",
                ScientificAreaId = new Guid("9030412f-db3f-49b9-8af6-f436c47854ad")
            },
            new()
            {
                Id = new Guid("949f39b8-879c-47d2-a9be-a8529680c200"),
                Name = "Машиностроение",
                ScientificAreaId = new Guid("9030412f-db3f-49b9-8af6-f436c47854ad")
            },
            new()
            {
                Id = new Guid("2547d032-e60e-4b54-be58-ccb6559f8cf5"),
                Name = "Электротехника, электроника, информационная инженерия",
                ScientificAreaId = new Guid("9030412f-db3f-49b9-8af6-f436c47854ad")
            },
            new()
            {
                Id = new Guid("6636dfc5-e126-4ed0-bc98-1f9c6c9db795"),
                Name = "Химическая инженерия",
                ScientificAreaId = new Guid("9030412f-db3f-49b9-8af6-f436c47854ad")
            },
            new()
            {
                Id = new Guid("ac23ba63-670f-4302-9bb8-440903f9ca9b"),
                Name = "Материаловедение",
                ScientificAreaId = new Guid("9030412f-db3f-49b9-8af6-f436c47854ad")
            },
            new()
            {
                Id = new Guid("b541fbce-8272-4703-a259-b05c424b0902"),
                Name = "Медицинская инженерия",
                ScientificAreaId = new Guid("9030412f-db3f-49b9-8af6-f436c47854ad")
            },
            new()
            {
                Id = new Guid("2214e438-34b1-4395-95aa-ae9cc430c3b1"),
                Name = "Экологическая биотехнология",
                ScientificAreaId = new Guid("9030412f-db3f-49b9-8af6-f436c47854ad")
            },
            new()
            {
                Id = new Guid("acd91910-8648-405c-b17d-50d991263d3c"),
                Name = "Промышленная биотехнология",
                ScientificAreaId = new Guid("9030412f-db3f-49b9-8af6-f436c47854ad")
            },
            new()
            {
                Id = new Guid("5447df47-a097-42c7-8a29-bd37142069f3"),
                Name = "Нанотехнологии",
                ScientificAreaId = new Guid("9030412f-db3f-49b9-8af6-f436c47854ad")
            },
            new()
            {
                Id = new Guid("8c68101a-1d1f-407a-827d-d868b07ae205"),
                Name = "Другая инженерия и технологии",
                ScientificAreaId = new Guid("9030412f-db3f-49b9-8af6-f436c47854ad")
            },
            new()
            {
                Id = new Guid("d6a0d570-af2d-4b17-a245-7de35e10559e"),
                Name = "Фундаментальная медицина",
                ScientificAreaId = new Guid("8a2dbe51-897b-4da7-9880-5cf2ee02882f")
            },
            new()
            {
                Id = new Guid("208757a5-826e-40d9-af38-85ca7b7d6788"),
                Name = "Клиническая медицина",
                ScientificAreaId = new Guid("8a2dbe51-897b-4da7-9880-5cf2ee02882f")
            },
            new()
            {
                Id = new Guid("9a4f274a-e870-4e49-a1fd-96050125542f"),
                Name = "Науки о здоровье",
                ScientificAreaId = new Guid("8a2dbe51-897b-4da7-9880-5cf2ee02882f")
            },
            new()
            {
                Id = new Guid("ad19a5e5-d774-4277-98d6-f305fc542858"),
                Name = "Медицинская биотехнология",
                ScientificAreaId = new Guid("8a2dbe51-897b-4da7-9880-5cf2ee02882f")
            },
            new()
            {
                Id = new Guid("ae27cd0e-b82e-418d-8b15-45756acb8556"),
                Name = "Другие медицинские науки",
                ScientificAreaId = new Guid("8a2dbe51-897b-4da7-9880-5cf2ee02882f")
            },
            new()
            {
                Id = new Guid("62670708-430c-42fd-9515-5b93b43843bf"),
                Name = "Сельское, лесное и рыбное хозяйство",
                ScientificAreaId = new Guid("d6b1b967-ec58-4656-bb06-160c911385a8")
            },
            new()
            {
                Id = new Guid("15ed4ad2-40c1-457d-84df-c1cd353a851f"),
                Name = "Животноводство и молочное производство",
                ScientificAreaId = new Guid("d6b1b967-ec58-4656-bb06-160c911385a8")
            },
            new()
            {
                Id = new Guid("cb5f1c57-5947-4e90-83b4-b6f17f5f0904"),
                Name = "Ветеринария",
                ScientificAreaId = new Guid("d6b1b967-ec58-4656-bb06-160c911385a8")
            },
            new()
            {
                Id = new Guid("be3fc563-3145-4cb3-b0d6-080421aca0d4"),
                Name = "Сельскохозяйственная биотехнология",
                ScientificAreaId = new Guid("d6b1b967-ec58-4656-bb06-160c911385a8")
            },
            new()
            {
                Id = new Guid("16c5a1b2-6247-4731-a3d0-5336cc63c14b"),
                Name = "Другие сельскохозяйственные науки",
                ScientificAreaId = new Guid("d6b1b967-ec58-4656-bb06-160c911385a8")
            },
            new()
            {
                Id = new Guid("392bf2df-d02a-4e5f-be6b-8877889eb70a"),
                Name = "Психология",
                ScientificAreaId = new Guid("9bd5aeb3-6d21-446e-bf7e-0b9a607aa9ec")
            },
            new()
            {
                Id = new Guid("0aa58a78-1742-4720-b639-0565284c0550"),
                Name = "Экономика и бизнес",
                ScientificAreaId = new Guid("9bd5aeb3-6d21-446e-bf7e-0b9a607aa9ec")
            },
            new()
            {
                Id = new Guid("471da449-4916-454f-9d2d-534d90579720"),
                Name = "Образовательные науки",
                ScientificAreaId = new Guid("9bd5aeb3-6d21-446e-bf7e-0b9a607aa9ec")
            },
            new()
            {
                Id = new Guid("32d7d18b-07f8-4b8a-950b-6ce754ba52dc"),
                Name = "Социология",
                ScientificAreaId = new Guid("9bd5aeb3-6d21-446e-bf7e-0b9a607aa9ec")
            },
            new()
            {
                Id = new Guid("e6abf079-724e-495a-b082-9102789620b7"),
                Name = "Право",
                ScientificAreaId = new Guid("9bd5aeb3-6d21-446e-bf7e-0b9a607aa9ec")
            },
            new()
            {
                Id = new Guid("0d696575-5097-49f7-8a64-5948a5a83769"),
                Name = "Политология",
                ScientificAreaId = new Guid("9bd5aeb3-6d21-446e-bf7e-0b9a607aa9ec")
            },
            new()
            {
                Id = new Guid("ca1cc4db-6342-4fa6-afb8-8b9f899e8b30"),
                Name = "Социально-экономическая география",
                ScientificAreaId = new Guid("9bd5aeb3-6d21-446e-bf7e-0b9a607aa9ec")
            },
            new()
            {
                Id = new Guid("5b3698fb-aed5-467f-a482-65bc1679fd87"),
                Name = "Медиа и коммуникации",
                ScientificAreaId = new Guid("9bd5aeb3-6d21-446e-bf7e-0b9a607aa9ec")
            },
            new()
            {
                Id = new Guid("f1219865-5303-4f43-8cd3-d5efe56b006f"),
                Name = "Другие социальные науки",
                ScientificAreaId = new Guid("9bd5aeb3-6d21-446e-bf7e-0b9a607aa9ec")
            },
            new()
            {
                Id = new Guid("6e23957c-de4f-4b36-b333-36dcb81f93c5"),
                Name = "История и археология",
                ScientificAreaId = new Guid("243d65dd-16f0-426d-be10-0202ca133029")
            },
            new()
            {
                Id = new Guid("c60a5c45-1015-41af-88cc-4b78364497ae"),
                Name = "Языки и литература",
                ScientificAreaId = new Guid("243d65dd-16f0-426d-be10-0202ca133029")
            },
            new()
            {
                Id = new Guid("6282932d-c7d2-4686-9f95-ce4db083afec"),
                Name = "Философия, этика и религия",
                ScientificAreaId = new Guid("243d65dd-16f0-426d-be10-0202ca133029")
            },
            new()
            {
                Id = new Guid("50882dab-5c63-45c6-adca-7de47d889256"),
                Name = "Искусство (искусство, история искусств, исполнительское искусство, музыка)",
                ScientificAreaId = new Guid("243d65dd-16f0-426d-be10-0202ca133029")
            },
            new()
            {
                Id = new Guid("38cb7c20-d2fb-4cd2-b772-cd12dbcc9065"),
                Name = "Другие гуманитарные науки",
                ScientificAreaId = new Guid("243d65dd-16f0-426d-be10-0202ca133029")
            }
        };
        modelBuilder.Entity<ScientificArea>().HasData(scientificAreas);
        modelBuilder.Entity<ScientificAreaSubsection>().HasData(scientificAreaSubsection);
    }
}