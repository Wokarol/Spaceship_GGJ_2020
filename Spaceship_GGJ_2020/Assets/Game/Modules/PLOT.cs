using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLOT : ShipModule
{
    [SerializeField] private float casualShootingInterval;
    [SerializeField] private float timeToAttack;
    [SerializeField] private float firstTimeToAttack;
    [Space]
    [SerializeField] private Animator animator;
    [Space]
    [SerializeField] private EnemyAI enemy;

    //HashSet<ShipModule> 

    float timer = 0;
    float attackCountdown = 0;

    bool firstTime = false;

    protected override void Update()
    {
        base.Update();
        if (IsWorking)
        {
            animator.speed = 1;
            timer += Time.deltaTime;
            if (timer > casualShootingInterval)
            {
                timer -= casualShootingInterval;
                animator.SetTrigger("Shot");
            }

            firstTime = true;
        }
        else
        {
            animator.speed = 0;
            attackCountdown -= Time.deltaTime;
            if (attackCountdown <= 0)
            {
                if (firstTime)
                {
                    attackCountdown = firstTimeToAttack;
                    firstTime = false;
                }
                else
                {
                    attackCountdown = timeToAttack;
                    SpawnAttack();
                }
            }

        }
    }

    private void SpawnAttack()
    {
        List<ModuleNode> potentialNodes = new List<ModuleNode>();
        foreach (var n in ModuleNode.ModuleNodes)
        {
            if (!n.Module.Broken)
                potentialNodes.Add(n);
        }

        potentialNodes.Shuffle();
        ModuleNode node = potentialNodes[0];
        var createdEnemy = Instantiate(enemy, node.transform.position, Quaternion.identity);
        createdEnemy.Target(node.Module);
    }
}
