namespace Sync.Contracts.Responses;

public record SyncEventResponse(
    bool Accepted,
    string? EventId,
    string? Message
);
