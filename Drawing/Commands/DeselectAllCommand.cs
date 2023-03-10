using System.Collections.Generic;

using Drawing.Components;

namespace Drawing.Commands;

public class DeselectAllCommand : Command
{
    private List<Component> _selectedComponents = new();

    internal DeselectAllCommand() { }

    public override bool Execute()
    {        
        _selectedComponents = Receiver?.DeselectAll();

        return true;
    }

    internal override void Undo()
        {
            if (_selectedComponents == null || _selectedComponents.Count == 0) return;

            foreach (var c in _selectedComponents)
            {
                if (!c.IsSelected)
                {
                    c.IsSelected = true;
                    // Receiver.IsDirty = true;
                }
            }

        }
        internal override void Redo()
        {
            if (_selectedComponents == null || _selectedComponents.Count == 0) return;

            foreach (var c in _selectedComponents)
            {
                if (c.IsSelected)
                {
                    c.IsSelected = false;
                    // Receiver.IsDirty = true;
                }
            }
        }
}
