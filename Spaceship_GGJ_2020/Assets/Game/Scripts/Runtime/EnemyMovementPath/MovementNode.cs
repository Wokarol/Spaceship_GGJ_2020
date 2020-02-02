using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementNode : MonoBehaviour
{
    [SerializeField] private MovementNode[] transitions = new MovementNode[0];

    private void OnDrawGizmos()
    {
        foreach (var node in transitions)
        {
            if (node == null)
                continue;

            Gizmos.color = Color.Lerp(Color.gray, Color.white, 0.5f);
            Gizmos.DrawLine(transform.position, (node.transform.position + transform.position) / 2);
        }
    }
}
