using System;
using Drawing.Components;

using Microsoft.Xna.Framework;

namespace Drawing.Commands;

public class AddCommand : Command
{
    private const int DefaultWidth = 80;
    private const int DefaultHeight = 80;
    private readonly ComponentFactory.ComponentType _componentType;
    private Vector2 _position;
    private readonly float _scale;
    private Component _componentAdded;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="commandParameters">
    ///     An array of parameters, where
    ///     [1]: ComponentType      component type -- a fully qualified resource name
    ///     [2]: Vector2            center location for the tree, defaut = top left corner
    ///     [3]: float              scale factor
    /// </param>
    internal AddCommand(params object[] commandParameters)
    {
        if (commandParameters.Length>0)
            _componentType = ComponentFactory.GetComponentType(commandParameters[0] as string);

        if (commandParameters.Length > 1)
            _position = (Vector2) commandParameters[1];
        else
            _position = new(0, 0);

        if (commandParameters.Length > 2)
            _scale = (float) commandParameters[2];
        else
            _scale = 1.0F;
    }

    public override bool Execute()
    {
        if (_componentType == ComponentFactory.ComponentType.NONE || Receiver == null) return false;

        
        var width = Convert.ToInt16(Math.Round(DefaultWidth * _scale, 0));
        var height = Convert.ToInt16(Math.Round(DefaultHeight * _scale, 0));

        _position.X -= width / 2;
        _position.Y -= height / 2;

        var state = new State()
        {
            ComponentType = _componentType,
            Position = _position,
            Width = width,
            Height = height,
            Color = Color.White
        };

        _componentAdded = ComponentFactory.Create(state);
        Receiver.Add(_componentAdded);

        return true;
    }

    internal override void Undo()
    {
        Receiver.Remove(_componentAdded);
    }

    internal override void Redo()
    {
        Receiver.Add(_componentAdded);
    }
}

