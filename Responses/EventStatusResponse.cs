namespace Sync.Contracts.Responses;

public record EventStatusResponse(
    string CorrelationId,
    string Status,
    string? TargetSystem,
    string? ErrorMessage,
    DateTime? ProcessedAt
);
