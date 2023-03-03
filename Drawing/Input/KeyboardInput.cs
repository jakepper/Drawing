using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Drawing.Commands;

namespace Drawing.Input;

public class KeyboardInput : IInputDevice
{
    private class CommandEntry
    {
        public Keys Key;
        public bool KeyPressOnly;
        public CommandFactory.CommandType CMD;
    }

    private readonly Invoker _invoker;
    private readonly Dictionary<Keys, CommandEntry> _commandEntries = new();
    private readonly List<CommandEntry> _toRegister = new();
    private readonly List<Keys> _toUnregister = new();
    private KeyboardState _statePrevious;

    public KeyboardInput(Invoker invoker)
    {
        _invoker = invoker;
    }

    public void Update(GameTime gameTime)
    {
        // Unregister Commands
        if (_toUnregister.Count > 0) 
        {
            foreach (Keys key in _toUnregister) 
            {
                _commandEntries.Remove(key);
            }
            _toUnregister.Clear();
        }

        // Register New Commands
        if (_toRegister.Count > 0) 
        {
            foreach (CommandEntry entry in _toRegister) 
            {
                _commandEntries.Add(entry.Key, entry);
            }
            _toRegister.Clear();
        }

        // Handle Keyboard Input (Execute Commands)
        KeyboardState state = Keyboard.GetState();
        foreach (CommandEntry entry in _commandEntries.Values)
        {
            if (entry.KeyPressOnly && keyPressed(state, entry.Key))
            {
                // entry.Callback();
                Invoker.EnqueueForExecution(CommandFactory.Create(entry.CMD, commandParameters));
            }
            else if (!entry.KeyPressOnly && keyReleased(state, entry.Key))
            {
                // entry.Callback();
                Invoker.EnqueueForExecution(CommandFactory.Create(entry.CMD, commandParameters));
            }
        }

        _statePrevious = state;
    }

    public void RegisterCommand(Keys key, bool keyPressOnly, CommandFactory.CommandType cmd)
    {
        if (_commandEntries.ContainsKey(key))
        {
            _toUnregister.Add(key);
        }
        
        _toRegister.Add(new CommandEntry{
            Key = key,
            KeyPressOnly = keyPressOnly,
            CMD = cmd
        });
    }

    public void UnregisterCommand(Keys key)
    {
        if (_commandEntries.ContainsKey(key))
        {
            _toUnregister.Add(key);
        }
    }

    private bool keyPressed(KeyboardState state, Keys key)
    {
        return (state.IsKeyDown(key) && !_statePrevious.IsKeyDown(key));
    }

    private bool keyReleased(KeyboardState state, Keys key)
    {
        return (state.IsKeyUp(key) && _statePrevious.IsKeyDown(key));
    }
}