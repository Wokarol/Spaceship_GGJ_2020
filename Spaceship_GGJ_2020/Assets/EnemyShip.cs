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

        float random = UnityEngine.Random.value;
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

            if(UnityEngine.Random.value < moduleHitChance && viableModules.Count > 0)
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
