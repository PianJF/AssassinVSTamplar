using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStar : MonoBehaviour
{
    [SerializeField] Text currentStarText, starCostText;
    [SerializeField] int currentStar = 600;


    // Update is called once per frame
    void Update()
    {
        DisplayCurrentStar();
    }

    public void AddStar(int starAdded)
    {
        currentStar += starAdded;
        DisplayCurrentStar();
    }

    public void SpendStar(int starDeduct)
    {   
        if (currentStar >= starDeduct)
        {
            currentStar -= starDeduct;
            DisplayCurrentStar();
        }
        else
        {
            Debug.Log("Not have enough star to spend");
        }
    }

    public bool EnoughToSpawn(int cost)
    {
        return currentStar >= cost;
    }

    private void DisplayCurrentStar()
    {
        currentStarText.text = currentStar.ToString();
    }

    public void DisplayStarCost(int targetStarCost)
    {
        starCostText.text = targetStarCost.ToString();
    }
}
