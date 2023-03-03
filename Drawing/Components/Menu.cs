using Microsoft.Xna.Framework;

namespace Drawing.Components;

public class Menu
{
    private ComponentFactory.ComponentType _selected;

    public Vector2 Position;
    public int Width;
    public int Height;
    public Color Color;

    public Menu(Vector2 position, int width, int height)
    {
        Position = position;
        Width = width;
        Height = height;
    }

    public void Draw()
    {

    }
}