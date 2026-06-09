namespace Sync.Contracts.Webhooks;

public record ProjectCreatedNotification(
    string PmsProjectId,
    string SuggestionId,
    string ProjectName
);
