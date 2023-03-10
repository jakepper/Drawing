using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Drawing.Components;
using Drawing.Commands;

namespace Drawing.Input;

public class InputHandler : IInputDevice
{
    private readonly MouseInput _mouseInput;
    private readonly KeyboardInput _keyboardInput;

    public InputHandler(Menu menu)
    {
        _keyboardInput = new();
        _mouseInput = new(menu);
    }

    public void Update(GameTime gameTime)
    {
        _mouseInput.Update(gameTime);
        _keyboardInput.Update(gameTime);
    }

    public void RegisterKeyboardCommand(Keys key, bool keyPressOnly, CommandFactory.CommandType cmd)
    {
        _keyboardInput.RegisterCommand(key, keyPressOnly, cmd);
    }

    public void UnregisterKeyboardCommand(Keys key)
    {
        _keyboardInput.UnregisterCommand(key);
    }
}