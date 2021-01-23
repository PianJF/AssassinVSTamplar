using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    const string DEFENDER_PARENT_NAME = "Defenders";
    Defender defenderToSpawn;
    GameObject defenders;

    private void Start()
    {
        SetDefenderParent();
    }

    private void SetDefenderParent()
    {
        defenders = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenders)
        {
            defenders = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    // Spawn selected defender at clicked grid position
    private void OnMouseDown()
    {
        Vector2 worldpos = GetSquareClicked();
        Vector2 gridPos = SnapToGrid(worldpos);
        AttempToSpawnDefender(gridPos);
    }
    
    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return worldPos;
    }

    // Adjust postion to grid position
    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);

        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 worldPos)
    {
        if (defenderToSpawn)
        {
            Defender newDefender = Instantiate(defenderToSpawn, worldPos, Quaternion.identity) as Defender;
            newDefender.transform.parent = defenders.transform;
        }
    }

    // Check all requirements before spawn
    private void AttempToSpawnDefender(Vector2 gridPos)
    {   
        if (!defenderToSpawn) { return; }
        var displayStar = FindObjectOfType<DisplayStar>();
        int defenderCost = defenderToSpawn.GetDefenderStarCost();
        if (displayStar.EnoughToSpawn(defenderCost))
        {
            SpawnDefender(gridPos);
            displayStar.SpendStar(defenderCost);
        }
        else
        {
            Debug.Log("Not have enough star to spawn");
        }
    }

    public void SetSelectedDefender(Defender targetDefender)
    {
        defenderToSpawn = targetDefender;
    }
}
