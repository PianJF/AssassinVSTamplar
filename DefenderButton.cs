using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    Color oriColor;

    private void OnMouseDown()
    {
        // Set previous seleted button to origin color
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton defenderButton in buttons)
        {
            defenderButton.GetComponent<SpriteRenderer>().color = oriColor;
        }

        // Set selected button to white
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
        // Show star cost of the selected defender
        FindObjectOfType<DisplayStar>().DisplayStarCost(defenderPrefab.GetDefenderStarCost());
    }


    private void Start()
    {
        oriColor = GetComponent<SpriteRenderer>().color;
    }
}
