using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, swordProjectile, firePoint;
    [SerializeField] bool haveSword = false;

    AttackerSpawner myLaneSpawner;
    GameObject projectiles;
    GameObject currentProjectile;
    const string PROJECTILE_PARENT_NAME = "Projectiles";
    
    // cached variable
    Animator animator;

    private void Start()
    {
        SetLaneSpawner();
        SetProjectileParent();
        animator = GetComponent<Animator>();
        currentProjectile = projectile;
    }


    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);

        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
  
    }

    private void SetProjectileParent()
    {
        projectiles = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectiles)
        {
            projectiles = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    // Set the attacker spawner of current lane
    private void SetLaneSpawner()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner attackerSpawner in attackerSpawners)
        {   
            // check the spawner y position with this game object
            bool isCloseEnough = Mathf.Abs(transform.position.y - attackerSpawner.transform.position.y) <= Mathf.Epsilon;
            
            if (isCloseEnough)
            {
                myLaneSpawner = attackerSpawner;
            }
        }
    }

    // check the number of child of my lane spawner, because the attacker as spawn as the child of the spawner
    private bool IsAttackerInLane()
    {
        return myLaneSpawner.transform.childCount > 0;
    }

    public void Fire()
    {
        GameObject newProjectile = Instantiate(currentProjectile, 
            firePoint.transform.position, firePoint.transform.rotation) as GameObject;
        newProjectile.transform.parent = projectiles.transform;
    }


    public void SwingSword()
    {
        animator.SetBool("isEnemyClose", true);
        currentProjectile = swordProjectile;
    }

    public void ShootBow()
    {
        animator.SetBool("isEnemyClose", false);
        currentProjectile = projectile;
    }


    public bool HaveSword()
    {
        return haveSword;
    }

}
