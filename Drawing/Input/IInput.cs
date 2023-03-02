using Microsoft.Xna.Framework;

namespace Drawing.Input;

public interface IInputDevice
{
    void Update (GameTime gameTime);
}

public interface IControls
{
    void RegisterControls(KeyboardInput keyboardInput);
    void UnregisterControls(KeyboardInput keyboardInput);
}