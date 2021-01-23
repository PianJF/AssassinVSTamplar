using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Badman : MonoBehaviour
{
    GameObject currentTarget;
    private void OnTriggerEnter2D(Collider2D other)
    {
        currentTarget = other.gameObject;

        if (currentTarget.GetComponent<Defender>())
        {
            if (currentTarget.GetComponent<Shooter>().HaveSword())
            {
                currentTarget.GetComponent<Shooter>().SwingSword();
            }
            GetComponent<Attacker>().Attack(currentTarget);
        }
    }
}
