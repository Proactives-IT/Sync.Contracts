namespace Sync.Contracts.Events;

public record SyncEventPayload(
    string Source,
    string EventType,
    string CorrelationId,
    object Payload
);
