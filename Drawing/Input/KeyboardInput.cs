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
        public InputDeviceHelper.CommandDelegate Callback;
    }

    private Dictionary<Keys, CommandEntry> _commandEntries = new();
    private List<CommandEntry> _toRegister = new();
    private List<Keys> _toUnregister = new();
    private KeyboardState _statePrevious;

    private bool keyPressed(KeyboardState state, Keys key)
    {
        return (state.IsKeyDown(key) && !_statePrevious.IsKeyDown(key));
    }

    public bool keyReleased(KeyboardState state, Keys key)
    {
        return (state.IsKeyUp(key) && _statePrevious.IsKeyDown(key));
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
                entry.Callback();
            }
            else if (!entry.KeyPressOnly && keyReleased(state, entry.Key))
            {
                entry.Callback();
            }
        }

        _statePrevious = state;
    }

    public void RegisterCommand(Keys key, bool keyPressOnly, InputDeviceHelper.CommandDelegate callback)
    {
        if (_commandEntries.ContainsKey(key))
        {
            _toUnregister.Add(key);
        }
        
        _toRegister.Add(new CommandEntry{
            Key = key,
            KeyPressOnly = keyPressOnly,
            Callback = callback
        });
    }

    public void UnregisterCommand(Keys key)
    {
        if (_commandEntries.ContainsKey(key))
        {
            _toUnregister.Add(key);
        }
    }
}