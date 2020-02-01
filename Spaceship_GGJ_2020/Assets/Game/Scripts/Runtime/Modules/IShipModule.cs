using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShipModule
{
    string Name { get; }
    void UseItem(IItem simpleItem);
}
