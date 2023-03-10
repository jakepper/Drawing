using System.IO;
using System.Collections.Generic;

using Drawing.Components;

namespace Drawing.Commands;

public class LoadCommand : Command
{
    private readonly string _filename;
    private List<Component> _previousComponents;

    internal LoadCommand(params object[] commandParameters)
    {
        if (commandParameters.Length > 0)
            _filename = commandParameters[0] as string;
    }

    public override bool Execute()
    {
        if (Receiver == null) return false;

        StreamReader reader = new StreamReader(_filename);

        Receiver.Load(reader.BaseStream);
        reader.Close();

        return true;
    }

    internal override void Undo()
    {
        Receiver.Clear();

        if (_previousComponents == null || _previousComponents.Count == 0) return;

        foreach (var c in _previousComponents)
            Receiver?.Add(c);
    }

    internal override void Redo()
    {
        Execute();
    }
}
