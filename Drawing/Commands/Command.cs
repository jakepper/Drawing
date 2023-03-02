using Drawing.Components;

namespace Drawing.Commands;

public abstract class Command
{
    public Canvas Receiver { get; set; }
    public abstract bool Execute();
    internal abstract void Undo();
    internal abstract void Redo();

}