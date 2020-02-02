using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayersShip))]
[RequireComponent(typeof(EnemyShip))]
public class GameDirector : MonoBehaviour
{
    private EnemyShip enemy = null;
    private PlayersShip player = null;

    public EnemyShip Enemy => enemy;
    public PlayersShip Player => player;

    private void Awake()
    {
        TryGetComponent(out player);
        TryGetComponent(out enemy);

        enemy.PlayersShip = player;
        player.EnemyShip = enemy;
    }
}
