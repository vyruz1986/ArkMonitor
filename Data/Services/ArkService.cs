using CoreRCON;

namespace ArkMonitor.Data.Services;

public class ArkService(RCON rcon)
{
    public async Task<string> GetPlayersAsync()
    {
        await EnsureConnected();
        var response = await rcon.SendCommandAsync(Commands.ListPlayers);

        return response;
    }

    public Task EnsureConnected() => rcon.ConnectAsync();

    private static class Commands
    {
        public const string ListPlayers = "listplayers";
    }
}