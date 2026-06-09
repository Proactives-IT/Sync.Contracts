namespace Sync.Contracts.Mapping;

public record MappedEntityDto(
    Guid Id,
    string EntityType,
    string SourceEntityId,
    string TargetEntityId,
    string? EntityName,
    string? Metadata,
    bool IsVerified,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);
