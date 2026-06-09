namespace Sync.Contracts.Mapping;

public record MappedAgencyDto(
    Guid PmsAgencyId,
    string Name,
    Guid? LocalAgencyId,
    bool IsMapped
);
