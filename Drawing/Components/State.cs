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
    public float Scale;
    [DataMember]
    public Color Color;
}