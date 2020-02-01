using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestModule : MonoBehaviour, IShipModule
{
    public string Name => name;

    public void UseItem(IItem simpleItem)
    {
        Debug.Log($"[Module] Used {simpleItem} on me ({Name})");
    }
}
