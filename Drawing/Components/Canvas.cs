using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Drawing.Components;

public class Canvas 
{
    private static readonly DataContractJsonSerializer jsonSerializer = new(typeof(List<State>));
    private readonly List<Component> _components = new();

    public Vector2 Position;
    public int Width;
    public int Height;
    public Color Color = Color.White;

    public Canvas(Vector2 position, int width, int height)
    {
        Position = position;
        Width = width;
        Height = height;
    }

    public void Load(Stream stream) 
    {
        var states = jsonSerializer.ReadObject(stream) as List<State>;

        if (states == null) return;

        _components.Clear();
        foreach (var state in states) 
        {
            _components.Add(ComponentFactory.Create(state));
        }
    }

    public void Save(Stream stream) 
    {
        var states = new List<State>();

        foreach (var component in _components) 
        {
            states.Add(component.State);
        }

        jsonSerializer.WriteObject(stream, states);
    }

    public void Add(Component component) 
    {
        _components.Add(component);
    }

    public void Remove(Component component)
    {
        _components.Remove(component);
    }

    public void ToggleSelectionAtPosition(Vector2 position) 
    {
        var component = _components.FindLast(c => {
            return position.X >= c.State.Position.X && position.X < c.State.Position.X + c.State.Width
            && position.Y >= c.State.Position.Y && position.Y < c.State.Position.Y + c.State.Height;
        });

        if (component == null) return;

        component.IsSelected = !component.IsSelected;
    }

    public void DeselectAll()
    {
        foreach (var component in _components)
        {
            component.IsSelected = false;
        }
    }

    public void DeleteAllSelected()
    {
        _components.RemoveAll(c => c.IsSelected);
    }

    public List<Component> GetClonedComponents()
    {
        var cloneList = new List<Component>();
        foreach (var component in _components)
        {
            cloneList.Add(ComponentFactory.Create(component.State));
        }

        return cloneList;
    }

    public void Clear() {
        _components.Clear();
    }

    public void Draw(SpriteBatch spriteBatch) {
        foreach (var component in _components) {
            component.Draw(spriteBatch);
        }
    }
}