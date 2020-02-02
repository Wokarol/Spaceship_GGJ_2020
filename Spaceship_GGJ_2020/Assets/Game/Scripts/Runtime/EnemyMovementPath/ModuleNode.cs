using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleNode : MovementNode
{
    public static List<ModuleNode> ModuleNodes = new List<ModuleNode>();
    public ShipModule Module;

    private void OnDrawGizmosSelected()
    {
        if (Module == null)
            return;
        Gizmos.DrawLine(transform.position, Module.transform.position);
    }

    private void OnEnable()
    {
        ModuleNodes.Add(this);
    }

    private void OnDisable()
    {
        ModuleNodes.Remove(this);
    }
}
