using System.Collections.Generic;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Drawing.Components;

public static class ComponentFactory
{
    public enum ComponentType { 
        PINK_PAINT,
        // COMPONENT_2,
        // COMPONENT_3,
        // COMPONENT_4,
        // COMPONENT_5,
    }

    private static readonly Dictionary<ComponentType, Texture2D> components = new();

    public static void LoadContent(ContentManager content) {
        components.Add(ComponentType.PINK_PAINT, content.Load<Texture2D>("Entities/pink-paint"));
        // components.Add(ComponentType.COMPONENT_2, content.Load<Texture2D>("2"));
        // components.Add(ComponentType.COMPONENT_4, content.Load<Texture2D>("4"));
        // components.Add(ComponentType.COMPONENT_5, content.Load<Texture2D>("5"));
        // components.Add(ComponentType.COMPONENT_3, content.Load<Texture2D>("3"));
    }

    public static Component Create(State state) 
    {
        switch (state.ComponentType) 
        {
            case ComponentType.PINK_PAINT:
                return new Component(state, components[state.ComponentType]);
            // case ComponentType.COMPONENT_2:
            // case ComponentType.COMPONENT_3:
            // case ComponentType.COMPONENT_4:
            // case ComponentType.COMPONENT_5:
            default:
                return null;
        }
    }

    public static ComponentType GetComponentType(string componentType) 
    {
        switch (componentType.Trim().ToUpper())
        {
            case "CHINESE_DRAGON":
                return ComponentType.PINK_PAINT;
            case "2":
                return ComponentType.PINK_PAINT;
            case "3":
                return ComponentType.PINK_PAINT;
            case "4":
                return ComponentType.PINK_PAINT;
            case "5":
                return ComponentType.PINK_PAINT;
            default:
                return ComponentType.PINK_PAINT;
        }
    }
}