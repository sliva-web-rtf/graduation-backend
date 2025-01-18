﻿using ScientificWork.UseCases.Common.Dtos;

namespace ScientificWork.UseCases.Professors.GetProfileById;

public record GetProfileByIdResult
{
    public Guid Id { get; init; }

    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    public string? Patronymic { get; init; }

    public string? PhoneNumber { get; init; }

    required public string Email { get; init; }

    public string? Contacts { get; init; }

    public string? Degree { get; init; }

    public string? About { get; init; }

    public string? SearchStatus { get; set; }
    
    required public int Limit { get; init; }

    required public int Fullness { get; init; } = 1;

    required public List<ScientificAreasDto> ScientificArea { get; init; } = new List<ScientificAreasDto>();

    required public IList<string> ScientificInterests { get; init; }

    public string? URPUri { get; init; }

    public string? ScopusUri { get; init; }

    public string? RISCUri { get; init; }

    public bool IsFavorite { get; set; }

    public bool CanJoin { get; set; }

    public string? AvatarImagePath { get; init; }
}
