using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Drawing.Commands;

public static class Invoker
{
    private static readonly Queue<Command> _toExecute = new();
    private static readonly Stack<Command> _undo = new();
    private static readonly Stack<Command> _redo = new();

    public static void EnqueueForExecution(Command cmd)
    {
        if (cmd == null) return;

        _toExecute.Enqueue(cmd);
    }

    public static void Update()
    {
        while (_toExecute.TryDequeue(out Command cmd))
        {
            Debug.WriteLine("Executed Command");
            if (cmd is UndoCommand)
                ExecuteUndo();
            else if (cmd is RedoCommand)
                ExecuteRedo();
            else
                if (cmd.Execute()) _undo.Push(cmd);
        }
    }

    public static void Undo()
    {
        EnqueueForExecution(new UndoCommand());
    }

    public static void Redo()
    {
        EnqueueForExecution(new RedoCommand());
    }

    private static void ExecuteUndo()
    {
        if (_undo.Count < 1) return;

        var cmd = _undo.Pop();
        cmd.Undo();
        _redo.Push(cmd);
    }

    private static void ExecuteRedo()
    {
        if (_redo.Count < 1) return;

        var cmd = _redo.Pop();
        cmd.Redo();
        _undo.Push(cmd);
    }
}