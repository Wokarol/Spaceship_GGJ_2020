using System;
using UnityEngine;

public abstract class GameObjectItem : MonoBehaviour
{
    public abstract void Use(IShipModule currentModule);
}