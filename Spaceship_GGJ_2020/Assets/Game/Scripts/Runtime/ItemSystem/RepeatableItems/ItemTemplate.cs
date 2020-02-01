using System;
using UnityEngine;

public abstract class ItemTemplate : ScriptableObject
{
    public abstract IItem GetItem(Action<Vector3> droppedCallback);
}
