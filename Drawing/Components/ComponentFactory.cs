using System.Collections.Generic;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Drawing.Components;

public static class ComponentFactory
{
    public enum ComponentType { 
        CHINESE_DRAGON,
        // COMPONENT_2,
        // COMPONENT_3,
        // COMPONENT_4,
        // COMPONENT_5,
    }

    private static readonly Dictionary<ComponentType, Texture2D> components = new();

    public static void LoadContent(ContentManager content) {
        components.Add(ComponentType.CHINESE_DRAGON, content.Load<Texture2D>("Entities/chinese-dragon"));
        // components.Add(ComponentType.COMPONENT_2, content.Load<Texture2D>("2"));
        // components.Add(ComponentType.COMPONENT_4, content.Load<Texture2D>("4"));
        // components.Add(ComponentType.COMPONENT_5, content.Load<Texture2D>("5"));
        // components.Add(ComponentType.COMPONENT_3, content.Load<Texture2D>("3"));
    }

    public static Component Create(State state) 
    {
        switch (state.ComponentType) 
        {
            case ComponentType.CHINESE_DRAGON:
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
                return ComponentType.CHINESE_DRAGON;
            case "2":
                return ComponentType.CHINESE_DRAGON;
            case "3":
                return ComponentType.CHINESE_DRAGON;
            case "4":
                return ComponentType.CHINESE_DRAGON;
            case "5":
                return ComponentType.CHINESE_DRAGON;
            default:
                return ComponentType.CHINESE_DRAGON;
        }
    }
}