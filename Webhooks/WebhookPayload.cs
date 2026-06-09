namespace Sync.Contracts.Webhooks;

public record WebhookPayload<T>(
    string EventType,
    T Data,
    string? Signature,
    DateTime Timestamp
);
