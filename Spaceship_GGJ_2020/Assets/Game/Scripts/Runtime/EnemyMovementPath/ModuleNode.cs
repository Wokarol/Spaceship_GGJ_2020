using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleNode : MovementNode
{
    [SerializeField] private ShipModule module;

    private void OnDrawGizmosSelected()
    {
        if (module == null)
            return;
        Gizmos.DrawLine(transform.position, module.transform.position);
    }
}
