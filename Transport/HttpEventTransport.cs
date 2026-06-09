using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sync.Contracts.Events;
using Sync.Contracts.Responses;

namespace Sync.Contracts.Transport;

public class HttpEventTransport : IEventTransport
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<HttpEventTransport> _logger;

    public HttpEventTransport(HttpClient httpClient, ILogger<HttpEventTransport> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<SyncEventResponse> PublishAsync(SyncEventPayload payload, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("/api/events/publish", payload, cancellationToken);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<SyncEventResponse>(cancellationToken: cancellationToken);
            return result ?? new SyncEventResponse(false, null, "Empty response from sync service");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to publish event {EventType} with correlation {CorrelationId}",
                payload.EventType, payload.CorrelationId);
            return new SyncEventResponse(false, null, ex.Message);
        }
    }

    public async Task<EventStatusResponse?> GetEventStatusAsync(string correlationId, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await _httpClient.GetAsync($"/api/events/{correlationId}/status", cancellationToken);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<EventStatusResponse>(cancellationToken: cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get event status for correlation {CorrelationId}", correlationId);
            return null;
        }
    }
}
