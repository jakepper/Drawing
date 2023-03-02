using Microsoft.Xna.Framework;

namespace Drawing.Commands;

public class SelectCommand : Command
{
    private readonly Vector2 _location;
        
    internal SelectCommand(params object[] commandParameters)
    {
        if (commandParameters.Length>0)
            _location = (Vector2) commandParameters[0];
    }

    public override bool Execute()
    {
        if (Receiver == null) return false;

        Receiver.ToggleSelectionAtPosition(_location);

        return true;
    }
}

