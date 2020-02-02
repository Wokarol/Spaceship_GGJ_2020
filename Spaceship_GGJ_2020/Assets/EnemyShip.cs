using System;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float HP = 1;

    public PlayersShip PlayersShip { get; set; } = null;

    private void Awake()
    {
        HP = 1;
    }

    internal void Damage(float damage)
    {
        HP -= damage;
    }
}
