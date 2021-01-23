using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 200f;
    [SerializeField] GameObject deathVFX, coin;
    [SerializeField] int enemyCoin = 100;

    float VFXDelay = 1f;
    float coinDelay = 0.8f

    public void DealDamage(float damage)
    {   
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {   
        // Check if object is an defender or attacker
        if (GetComponent<Defender>())
        {
            DefenderDied();
        }
        else if (GetComponent<Attacker>())
        {
            AttackerDied();
        }
    }

    private void DefenderDied()
    {
        GetComponent<Animator>().SetBool("isDied", true);
        Destroy(gameObject, 1.5f);
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX)
        {
            return;
        }
        GameObject deathVFXObj = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObj, VFXDelay);   // Destroy death affect after 1s
    }

    private void TriggerCoin()
    {
        if (!coin)
        {
            return;
        }
        FindObjectOfType<DisplayStar>().AddStar(enemyCoin);
        GameObject coinGained = Instantiate(coin, transform.position, transform.rotation);
        Destroy(coinGained, coinDelay);
    }

    private void AttackerDied()
    {
        GetComponent<Attacker>().SwitchBowShoot();
        TriggerDeathVFX();
        TriggerCoin();
        Destroy(gameObject);
    }

    public float GetHealth()
    {
        return health;
    }
}
