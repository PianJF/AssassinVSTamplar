using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;

    public int GetDefenderStarCost()
    {
        return starCost;
    }

    public void AddStar(int starAmount)
    {
        FindObjectOfType<DisplayStar>().AddStar(starAmount);
    }
}
