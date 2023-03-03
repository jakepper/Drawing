using Microsoft.Xna.Framework;

using Drawing.Commands;

namespace Drawing.Input;

public class InputHandler : IInputDevice
{
    private readonly Invoker _invoker = new();
    private readonly MouseInput _mouseInput;
    private readonly KeyboardInput _keyboardInput;

    public InputHandler()
    {
        _keyboardInput = new(_invoker);
        _mouseInput = new(_invoker);
    }

    public void Update(GameTime gameTime)
    {
        _mouseInput.Update(gameTime);
        _keyboardInput.Update(gameTime);
    }
}