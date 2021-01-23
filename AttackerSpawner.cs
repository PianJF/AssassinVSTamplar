using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] Attacker[] attackers;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;

    bool spawn = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RandomIntervalSpawn());    
    }

    // Spawn every random seconds between MIN and MAX
    IEnumerator RandomIntervalSpawn()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        int attackerIndex = UnityEngine.Random.Range(0, attackers.Length);
        Spawn(attackerIndex);
    }

    private void Spawn(int attackerIndex)
    {
        Attacker newAttacker = Instantiate(attackers[attackerIndex],
                                gameObject.transform.position,
                                Quaternion.identity) as Attacker;
        newAttacker.transform.parent = transform;
    }

    public void StopSpawnAttacker()
    {
        spawn = false;
    }
}
 