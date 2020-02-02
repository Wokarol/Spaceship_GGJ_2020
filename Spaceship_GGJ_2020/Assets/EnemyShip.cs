using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    [SerializeField] private float timeBetweenShots = 10f;
    [SerializeField] private float baseDamage = 0.05f;
    [Space]
    [SerializeField] private ShipModule[] modules;
    [SerializeField] private Transform[] randomHitpoints;
    [SerializeField, Range(0, 1)] private float moduleHitChance = 0.2f;
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
            List<ShipModule> viableModules = new List<ShipModule>();
            foreach (var m in modules)
            {
                if(!m.Broken && m.CurrentEffect == ShipModule.Effect.None)
                {
                    viableModules.Add(m);
                }
            }

            if(Random.value < moduleHitChance && viableModules.Count > 0)
            {
                viableModules.Shuffle();
                viableModules[0].Attack(damage);
            }
            else
            {
                // Attacking of random point
            }
        }
        else
        {
            // Attacking nothing
        }
    }
}
