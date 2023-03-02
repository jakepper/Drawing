using System.Collections.Generic;

namespace Drawing.Commands;

public class Invoker
{
    private readonly Queue<Command> _toExecute = new();
    private readonly Stack<Command> _undo = new();
    private readonly Stack<Command> _redo = new();

    public void EnqueueForExecution(Command cmd)
    {
        if (cmd == null) return;

        _toExecute.Enqueue(cmd);
    }

     public void Undo()
        {
            EnqueueForExecution(new UndoCommand());
        }

        public void Redo()
        {
            EnqueueForExecution(new RedoCommand());
        }

    private void ExecuteUndo()
    {
        if (_undo.Count < 1) return;

        var cmd = _undo.Pop();
        cmd.Undo();
        _redo.Push(cmd);
    }

    private void ExecuteRedo()
    {
        if (_redo.Count < 1) return;

        var cmd = _redo.Pop();
        cmd.Redo();
        _undo.Push(cmd);
    }
}