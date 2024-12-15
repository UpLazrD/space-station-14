using Content.Server.GameTicking.Prototypes;
using Robust.Shared.Random;
using Robust.Shared.Utility;
using System.Linq;
using System.Numerics;
using Content.Shared.GameTicking;

namespace Content.Server.GameTicking;

public sealed partial class GameTicker
{
    [ViewVariables]
    public string? LobbyBackground { get; private set; }

    [ViewVariables]
    private List<ResPath>? _lobbyBackgrounds;

    private static readonly string[] WhitelistedBackgroundExtensions = new string[] {"png", "jpg", "jpeg", "webp"};

    // Sunrise-Start
    [ViewVariables]
    public string? LobbyParalax { get; private set; }
    [ViewVariables]
    private readonly List<string> _lobbyParalaxes =
    [
        "AspidParallax",
        "FastSpace",
        "Default",
        "BagelStation",
        "KettleStation",
        "AvriteStation",
        "DeltaStation",
        "OutpostStation",
        "TrainStation",
        "CoreStation"
    ];

    private void InitializeLobbyBackground()
    {
        _lobbyBackgrounds = _prototypeManager.EnumeratePrototypes<LobbyBackgroundPrototype>()
            .Select(x => x.Background)
            .Where(x => WhitelistedBackgroundExtensions.Contains(x.Extension))
            .ToList();

        RandomizeLobbyParalax();
        RandomizeLobbyBackground();
    }
    private void RandomizeLobbyParalax() {
        LobbyParalax = _lobbyParalaxes.Any() ? _robustRandom.Pick(_lobbyParalaxes) : null;
    }
    // Sunrise-End

    private void RandomizeLobbyBackground() {
        LobbyBackground = _lobbyBackgrounds!.Any() ? _robustRandom.Pick(_lobbyBackgrounds!).ToString() : null;
    }
}
