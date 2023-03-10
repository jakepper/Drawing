using System.Collections.Generic;

using Drawing.Components;

namespace Drawing.Commands;

public class RemoveSelectedCommand : Command
{
    private List<Component> _deletedComponents;
    public override bool Execute()
    {
        if (Receiver == null) return false;

        Receiver.DeleteAllSelected();

        return true;
    }

    internal override void Undo()
    {
        if (_deletedComponents == null || _deletedComponents.Count == 0) return;

        foreach (var c in _deletedComponents)
            Receiver?.Add(c);
    }

    internal override void Redo()
    {
        if (_deletedComponents == null || _deletedComponents.Count == 0) return;

        foreach (var c in _deletedComponents)
            Receiver?.Delete(c);
    }
}
