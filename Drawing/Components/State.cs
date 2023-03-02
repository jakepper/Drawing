using System.Runtime.Serialization;

using Microsoft.Xna.Framework;

namespace Drawing.Components;

[DataContract]
public class State
{
    [DataMember]
    public ComponentFactory.ComponentType ComponentType;
    [DataMember]
    public Vector2 Position;
    [DataMember]
    public int Width;
    [DataMember]
    public int Height;
    [DataMember]
    public Color Color;
}