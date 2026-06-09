namespace Sync.Contracts.Responses;

public record ProjectMappingDto(
    string SuggestionId,
    string? PmsProjectId,
    string Status,
    DateTime CreatedAt,
    DateTime? ConfirmedAt
);
