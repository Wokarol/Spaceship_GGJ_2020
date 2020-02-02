using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float attackPerSecond = 0.1f;
    [SerializeField] private Animator animator = null; 

    private ShipModule module;

    public void Target(ShipModule module)
    {
        this.module = module;
    }

    private void Update()
    {
        module.Damage(attackPerSecond * Time.deltaTime);
        if (module.Broken)
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetTrigger("Die");
        Destroy(gameObject, 2f);
    }
}
