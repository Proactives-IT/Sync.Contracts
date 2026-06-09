using Sync.Contracts.Events;
using Sync.Contracts.Responses;

namespace Sync.Contracts.Transport;

public interface IEventTransport
{
    Task<SyncEventResponse> PublishAsync(SyncEventPayload payload, CancellationToken cancellationToken = default);
    Task<EventStatusResponse?> GetEventStatusAsync(string correlationId, CancellationToken cancellationToken = default);
}
