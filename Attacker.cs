using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    /*[Range(0f, 5f)]
    [SerializeField] float walkSpeed;*/
    [SerializeField] float attackerDamage = 25f;

    float currentSpeed = 1f;
    GameObject currentTarget;

    // cached variables
    Animator animator;
    LevelController levelController;

    private void Awake()
    {
        levelController = FindObjectOfType<LevelController>();
        levelController.AddAttackerCount();
    }

    // Keep track of number of current attackers
    private void OnDestroy()
    {
        if (levelController)
        {
            levelController.SubtractAttackerCount();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        CheckCurrentTargetAlive();
    }

    private void CheckCurrentTargetAlive()
    {   
        // if current target been destroied then change back to walk stage
        if (!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float targetSpeed)
    {
        currentSpeed = targetSpeed;
    }

    // Trigger into attack stage
    public void Attack(GameObject defender)
    {
        currentTarget = defender;
        animator.SetBool("isAttacking", true);
    }

    // attack defender and deal damage
    public void AttackCurrentTarget()
    {
        if (!currentTarget) { return; }

        Health targetHealth = currentTarget.GetComponent<Health>();
        targetHealth.DealDamage(attackerDamage);
        
    }

    // Switch back to bow shoot when enemy is not in front
    public void SwitchBowShoot()
    {
        if (currentTarget)
        {
            currentTarget.GetComponent<Shooter>().ShootBow();
        }
    }
}
