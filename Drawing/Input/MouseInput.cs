using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Drawing.Components;

namespace Drawing.Input;

public class MouseInput : IInputDevice
{
    private Menu _menu;
    private MouseState _statePrevious;

    public MouseInput(Menu menu)
    {
        _menu = menu;
    }

    public void Update(GameTime gameTime)
    {
        // Handle Keyboard Input (Execute Commands)
        MouseState state = Mouse.GetState();
        
        if (RightClicked(state)) {
            // do nothing
        }

        if (LeftClicked(state)) {
            _menu.HandleClick(new Vector2(state.X, state.Y));
        }

        _statePrevious = state;
    }

    private bool RightClicked(MouseState state)
    {
        return state.RightButton != ButtonState.Pressed && _statePrevious.RightButton == ButtonState.Pressed;
    }

    private bool LeftClicked(MouseState state)
    {
        return state.LeftButton != ButtonState.Pressed && _statePrevious.LeftButton == ButtonState.Pressed;
    }
}