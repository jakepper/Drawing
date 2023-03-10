using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Drawing.Commands;
using System.Diagnostics;

namespace Drawing.Components;

public class Menu
{
    private const int RESOURCES_MENU_HEIGHT = 600;
    private string _selectedResource;
    private readonly List<ResourceItem> _resources = new();
    private readonly List<MenuItem> _menuItems = new();
    private readonly Texture2D _texture;

    public Vector2 Position;
    public int Width;
    public int Height;
    public Color Color;

    public Menu(Vector2 position, int width, int height, Texture2D texture)
    {
        Position = position;
        Width = width;
        Height = height;
        _texture = texture;

        _selectedResource = "PINK_PAINT";

        Vector2 resourcePosition = new(Position.X + 16, Position.Y + 16);
        foreach (ComponentFactory.ComponentType c in Enum.GetValues(typeof(ComponentFactory.ComponentType)))
        {
            var component = ComponentFactory.Create(new State() {
                ComponentType = c,
                Position = new Vector2(),
                Scale = 1.0F,
                Color = Color.White
            });

            _resources.Add(new ResourceItem(
                Enum.GetName(typeof(CommandFactory.CommandType), c),
                component
            ));

            Position.Y += component.Texture.Height + 16;
        }
    }

    public void HandleClick(Vector2 position)
    {
        if (!MenuItemClicked(position)) {
            if (_selectedResource != null) {
                var cmd = CommandFactory.Create(CommandFactory.CommandType.ADD, new object[] {
                _selectedResource,
                position
                });
                Invoker.EnqueueForExecution(cmd);
            }
            return;
        }

        if (ResourceClicked(position)) {
            foreach (var resource in _resources)
            {
                if (resource.Clicked(position))
                {
                    _selectedResource = resource.Name;
                    Debug.WriteLine("Selected " + resource.Name);
                    break;
                }
            }
            return;
        }

        foreach (var item in _menuItems)
        {
            if (item.Clicked(position)) {
                item.OnClicked();
                break;
            }
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // draw background
        spriteBatch.Draw(_texture, new Rectangle(0, 0, Width, Height), Color.Beige);

        // draw available resources
        foreach (var r in _resources)
        {
            r.Component.Draw(spriteBatch);
        }

        // draw menu items
        foreach (var item in _menuItems)
        {
            item.Draw(spriteBatch);
        }
    }

    private bool MenuItemClicked(Vector2 position)
    {
        return (position.X >= Position.X && position.X <= Position.X + Width) && 
                (position.Y >= Position.Y && position.Y <= Position.Y + Height);
    }

    private bool ResourceClicked(Vector2 position)
    {
        return position.Y < RESOURCES_MENU_HEIGHT;
    }
}