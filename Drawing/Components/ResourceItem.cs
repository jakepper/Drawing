using Microsoft.Xna.Framework;

namespace Drawing.Components;

public class ResourceItem
{
    public readonly string Name;
    public readonly Component Component;

    public ResourceItem(string name, Component component)
    {
        Name = name;
        Component = component;
    }

    public bool Clicked(Vector2 position)
    {
        return (position.X >= Component.State.Position.X && position.X <= Component.State.Position.X + Component.Texture.Width) &&
                (position.Y >= Component.State.Position.Y && position.Y <= Component.State.Position.Y + Component.Texture.Height);
    }
}