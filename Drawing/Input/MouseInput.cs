using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Drawing.Commands;

namespace Drawing.Input;

public class MouseInput : IInputDevice
{
    private class CommandEntry
    {
        public ButtonState state;
        public CommandFactory.CommandType CMD;
    }
    private readonly Invoker _invoker;
    private readonly Dictionary<Keys, CommandEntry> _commandEntries = new();
    private readonly List<CommandEntry> _toRegister = new();
    private readonly List<Keys> _toUnregister = new();
    private MouseState _statePrevious;

    public MouseInput(Invoker invoker)
    {
        _invoker = invoker;
    }
    public void Update(GameTime gameTime)
    {
        throw new System.NotImplementedException();
    }
}