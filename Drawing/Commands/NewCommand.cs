using System.Collections.Generic;

using Drawing.Components;

namespace Drawing.Commands;

public class NewCommand : Command
{
    private List<Component> _previousComponents;
    public override bool Execute()
    {
        if (Receiver == null) return false;

        _previousComponents = Receiver.GetClonedComponents();
        
        Receiver.Clear();

        return _previousComponents != null;
    }

    internal override void Redo()
    {
        if (Receiver == null) return;
        if (_previousComponents == null || _previousComponents.Count == 0) return;

        foreach (var component in _previousComponents)
        {
            Receiver.Add(component);
        }
    }

    internal override void Undo()
    {
        Execute();
    }
}
