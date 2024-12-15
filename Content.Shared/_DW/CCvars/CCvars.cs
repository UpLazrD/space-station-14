using Robust.Shared.Configuration;
namespace Content.Shared._DW.CCVars;
[CVarDefs]
public sealed class DWCCVars
{
    /**
     * Lobby
     */

    public static readonly CVarDef<string> LobbyBackground =
        CVarDef.Create("lobby.background", "Paralax", CVar.CLIENTONLY | CVar.ARCHIVE);
}