using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Drawing.Components;

public class Component 
{
    public State State { get; set; }
    public bool IsSelected { get; set; }
    public Texture2D Texture;

    public Component(State state, Texture2D texture) {
        State = state;
        Texture = texture;
    }

    public void Update(GameTime gameTime)
    {

    }
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(
            texture: Texture,
            position: State.Position,
            sourceRectangle: null,
            color: State.Color,
            rotation: 0.0f,
            origin: Vector2.Zero,
            scale: new Vector2(State.Scale, State.Scale),
            effects: SpriteEffects.None,
            layerDepth: 0
           );
    }
}