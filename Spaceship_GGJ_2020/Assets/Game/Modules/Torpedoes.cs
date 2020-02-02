using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedoes : ShipModule
{
    [SerializeField] private TorpedoLoader loader;

    [Button("Load")]
    public void Load()
    {
        loader.LoadTorpedo(() => { });
    }

    public override void Interact()
    {
        Debug.Log("I've been interacted with");
    }
}
