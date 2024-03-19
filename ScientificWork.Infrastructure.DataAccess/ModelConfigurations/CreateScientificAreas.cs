using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.ScientificAreas;

namespace ScientificWork.Infrastructure.DataAccess.ModelConfigurations;

public static class CreateScientificAreas
{
    public static void CreateDefaultScientificArea(this ModelBuilder modelBuilder)
    {
        var scientificAreas = new[]
        {
            new ScientificArea(Guid.NewGuid(), "Естественные науки"),
            new ScientificArea(Guid.NewGuid(), "Техника и технологии"),
            new ScientificArea(Guid.NewGuid(), "Медицина и здравоохранение"),
            new ScientificArea(Guid.NewGuid(), "Сельскохозяйственные науки"),
            new ScientificArea(Guid.NewGuid(), "Общественные науки"),
            new ScientificArea(Guid.NewGuid(), "Гуманитарные науки"),
        };
        var scientificAreaSubsection = new List<ScientificAreaSubsection>()
        {
            new() { Id = Guid.NewGuid(), Name = "Математика", ScientificAreaId = scientificAreas[0].Id },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Компьютерные и информационные науки",
                ScientificAreaId = scientificAreas[0].Id
            },
            new() { Id = Guid.NewGuid(), Name = "Физика", ScientificAreaId = scientificAreas[0].Id },
            new() { Id = Guid.NewGuid(), Name = "Химия", ScientificAreaId = scientificAreas[0].Id },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Науки о Земле и окружающей среде",
                ScientificAreaId = scientificAreas[0].Id
            },
            new() { Id = Guid.NewGuid(), Name = "Биология", ScientificAreaId = scientificAreas[0].Id },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Другие естественные науки",
                ScientificAreaId = scientificAreas[0].Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Гражданское строительство",
                ScientificAreaId = scientificAreas[1].Id
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "Экологическая инженерия", ScientificAreaId = scientificAreas[1].Id
            },
            new() { Id = Guid.NewGuid(), Name = "Машиностроение", ScientificAreaId = scientificAreas[1].Id },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Электротехника, электроника, информационная инженерия",
                ScientificAreaId = scientificAreas[1].Id
            },
            new() { Id = Guid.NewGuid(), Name = "Химическая инженерия", ScientificAreaId = scientificAreas[1].Id },
            new() { Id = Guid.NewGuid(), Name = "Материаловедение", ScientificAreaId = scientificAreas[1].Id },
            new() { Id = Guid.NewGuid(), Name = "Медицинская инженерия", ScientificAreaId = scientificAreas[1].Id },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Экологическая биотехнология",
                ScientificAreaId = scientificAreas[1].Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Промышленная биотехнология",
                ScientificAreaId = scientificAreas[1].Id
            },
            new() { Id = Guid.NewGuid(), Name = "Нанотехнологии", ScientificAreaId = scientificAreas[1].Id },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Другая инженерия и технологии",
                ScientificAreaId = scientificAreas[1].Id
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "Фундаментальная медицина", ScientificAreaId = scientificAreas[2].Id
            },
            new() { Id = Guid.NewGuid(), Name = "Клиническая медицина", ScientificAreaId = scientificAreas[2].Id },
            new() { Id = Guid.NewGuid(), Name = "Науки о здоровье", ScientificAreaId = scientificAreas[2].Id },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Медицинская биотехнология",
                ScientificAreaId = scientificAreas[2].Id
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "Другие медицинские науки", ScientificAreaId = scientificAreas[2].Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Сельское, лесное и рыбное хозяйство",
                ScientificAreaId = scientificAreas[3].Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Животноводство и молочное производство",
                ScientificAreaId = scientificAreas[3].Id
            },
            new() { Id = Guid.NewGuid(), Name = "Ветеринария", ScientificAreaId = scientificAreas[3].Id },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Сельскохозяйственная биотехнология",
                ScientificAreaId = scientificAreas[3].Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Другие сельскохозяйственные науки",
                ScientificAreaId = scientificAreas[3].Id
            },
            new() { Id = Guid.NewGuid(), Name = "Психология", ScientificAreaId = scientificAreas[4].Id },
            new() { Id = Guid.NewGuid(), Name = "Экономика и бизнес", ScientificAreaId = scientificAreas[4].Id },
            new() { Id = Guid.NewGuid(), Name = "Образовательные науки", ScientificAreaId = scientificAreas[4].Id },
            new() { Id = Guid.NewGuid(), Name = "Социология", ScientificAreaId = scientificAreas[4].Id },
            new() { Id = Guid.NewGuid(), Name = "Право", ScientificAreaId = scientificAreas[4].Id },
            new() { Id = Guid.NewGuid(), Name = "Политология", ScientificAreaId = scientificAreas[4].Id },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Социально-экономическая география",
                ScientificAreaId = scientificAreas[4].Id
            },
            new() { Id = Guid.NewGuid(), Name = "Медиа и коммуникации", ScientificAreaId = scientificAreas[4].Id },
            new()
            {
                Id = Guid.NewGuid(), Name = "Другие социальные науки", ScientificAreaId = scientificAreas[4].Id
            },
            new() { Id = Guid.NewGuid(), Name = "История и археология", ScientificAreaId = scientificAreas[5].Id },
            new() { Id = Guid.NewGuid(), Name = "Языки и литература", ScientificAreaId = scientificAreas[5].Id },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Философия, этика и религия",
                ScientificAreaId = scientificAreas[5].Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Искусство (искусство, история искусств, исполнительское искусство, музыка)",
                ScientificAreaId = scientificAreas[5].Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Другие гуманитарные науки",
                ScientificAreaId = scientificAreas[5].Id
            }
        };
        modelBuilder.Entity<ScientificArea>().HasData(scientificAreas);
        modelBuilder.Entity<ScientificAreaSubsection>().HasData(scientificAreaSubsection);
    }
}
