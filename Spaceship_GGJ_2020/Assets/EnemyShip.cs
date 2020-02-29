using DG.Tweening;
using System;
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
    [SerializeField] private Transform pewEffect;
    [Space]
    [SerializeField, Range(0, 1)] private float HP = 1;


    public PlayersShip PlayersShip { get; set; } = null;
    public float Health => HP;

    List<float>[] options = new List<float>[2];
    int currentPoolIndex = 0; 

    public static List<IDamageModifier> DamageModifiers { get; private set; } = new List<IDamageModifier>();
    private float timer;

    private void Awake()
    {
        HP = 1;

        GenerateRNGPool(0, 10);
        GenerateRNGPool(1, 10);
    }

    private void GenerateRNGPool(int id, int pool)
    {
        options[id] = new List<float>();
        for (int i = 0; i < pool; i++)
        {
            options[id].Add(i / (float)pool);
        }

        options[id].Shuffle();
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

    private float GetRandom(int id)
    {
        float random = options[id][currentPoolIndex];

        currentPoolIndex += 1;
        if(currentPoolIndex >= options[id].Count)
        {
            currentPoolIndex = 0;
            options[id].Shuffle();
        }

        return random;
    }

    private void ShotPlayer()
    {
        float damage = baseDamage;
        float evade = 0;

        foreach (var m in DamageModifiers)
        {
            m.ModifyDamage(ref damage, ref evade);
        }

        float random = GetRandom(0);
        if (random > evade)
        {
            List<ShipModule> viableModules = new List<ShipModule>();
            foreach (var m in modules)
            {
                if(!m.Broken)
                {
                    viableModules.Add(m);
                }
            }

            if(GetRandom(1) < moduleHitChance && viableModules.Count > 0)
            {
                viableModules.Shuffle();
                ShipModule shipModule = viableModules[0];
                ShotAt(shipModule.transform.position)
                    .OnComplete(() => shipModule.Attack(damage));
            }
            else
            {
                Transform hitpoint = randomHitpoints[UnityEngine.Random.Range(0, randomHitpoints.Length)];
                ShotAt(hitpoint.position)
                    .OnComplete(() => PlayersShip.Damage(damage));
            }
        }
        else
        {
            // Attacking nothing
        }
    }

    private Tween ShotAt(Vector3 position)
    {
        var ob = Instantiate(pewEffect);
        ob.position = UnityEngine.Random.insideUnitCircle.normalized * 100;
        ob.right = position - ob.position;

        var sequence = DOTween.Sequence();
        sequence.Append(ob.DOMove(position, 2f).SetEase(Ease.Linear));
        sequence.AppendCallback(() => Destroy(ob.gameObject));

        return sequence;
    }
}
