using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderProjectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 3f;
    [SerializeField] float projectileRotate = 30f;
    [SerializeField] float projectileDamage = 100f;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {   
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
        transform.GetChild(0).transform.Rotate(0f, 0f, projectileRotate * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health health = other.GetComponent<Health>();
        Attacker attacker = other.GetComponent<Attacker>();
        if (health && attacker)
        {
            // Destroy projectile on hit
            Hit();
            health.DealDamage(projectileDamage);
        }
    }

    public float GetDamage()
    {
        return projectileDamage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
