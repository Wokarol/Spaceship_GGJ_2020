using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    [SerializeField] private float timeBetweenShots = 10f;
    [SerializeField] private float baseDamage = 0.05f;
    [Space]
    [SerializeField, Range(0, 1)] private float HP = 1;


    public PlayersShip PlayersShip { get; set; } = null;
    public static List<IDamageModifier> DamageModifiers { get; private set; } = new List<IDamageModifier>();

    private float timer;

    private void Awake()
    {
        HP = 1;
    }

    public void Damage(float damage)
    {
        Debug.Log($"[FIGHT]  Enemy Damaged ({damage})");
        HP -= damage;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > timeBetweenShots)
        {
            timer -= timeBetweenShots;
            ShotPlayer();
        }
    }

    private void ShotPlayer()
    {
        float damage = baseDamage;
        float evade = 0;

        foreach (var m in DamageModifiers)
        {
            m.ModifyDamage(ref damage, ref evade);
        }

        float random = Random.value;
        if (random > evade)
        {
            PlayersShip.Damage(damage);
        }
        else
        {
            Debug.Log($"[FIGHT]  Player Evaded ({damage})");
        }
    }
}
