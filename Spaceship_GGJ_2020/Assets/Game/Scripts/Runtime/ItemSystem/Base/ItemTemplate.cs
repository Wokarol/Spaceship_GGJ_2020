using System;
using UnityEngine;

public abstract class ItemTemplate : ScriptableObject, IItemID
{
    public abstract IItem GetItem(Action<Vector3> droppedCallback);
}
