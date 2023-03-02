using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Drawing.Components;

public class Component 
{
    public State State { get; set; }
    public bool IsSelected { get; set; }
    private Texture2D _texture;

    public Component(State state, Texture2D texture) {
        State = state;
        _texture = texture;
    }

    // public abstract void Initialize();
    public void Update(GameTime gameTime)
    {

    }
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, State.Position, State.Color);
    }
}