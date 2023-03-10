using Microsoft.Xna.Framework;

using Drawing.Components;

namespace Drawing.Commands;

public class SelectCommand : Command
{
    private readonly Vector2 _location;
    private Component _component;
    private bool _originalState;
        
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

    internal override void Undo()
    {
        if (_component.IsSelected == _originalState) return;

        _component.IsSelected = _originalState;
        // Receiver.IsDirty = true;
    }

    internal override void Redo()
    {
        if (_component.IsSelected != _originalState) return;

        _component.IsSelected = !_originalState;
        // Receiver.IsDirty = true;
    }
}

