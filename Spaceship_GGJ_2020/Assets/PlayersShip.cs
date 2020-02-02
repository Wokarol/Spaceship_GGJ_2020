using UnityEngine;

public class PlayersShip : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float HP = 1;

    public EnemyShip EnemyShip { get; set; } = null;

    private void Awake()
    {
        HP = 1;
    }

    public void Damage(float damage)
    {
        Debug.Log($"[FIGHT]  Player Damaged ({damage})");
        HP -= damage;
    }
}
