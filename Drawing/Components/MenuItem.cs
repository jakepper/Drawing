using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Drawing.Commands;

namespace Drawing.Components;

public class MenuItem
{
    public Vector2 Position;
    public int Width;
    public int Height;
    public CommandFactory.CommandType Cmd;
    private Texture2D _texture;

    public MenuItem(Vector2 position, int width, int height, CommandFactory.CommandType cmd, Texture2D texture)
    {
        Position = position;
        Width = width;
        Height = height;
        Cmd = cmd;
        _texture = texture;
    }

    public bool Clicked(Vector2 position)
    {
        return (position.X >= Position.X && position.X <= Position.X + Width) &&
                (position.Y >= Position.Y && position.Y <= Position.Y + Height);
    }

    public void OnClicked()
    {
        CommandFactory.Create(Cmd, new object[] {

        });
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        
    }
}