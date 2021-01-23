using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayBaseHealth : MonoBehaviour
{
    [SerializeField] Text livesText;
    [SerializeField] float baseLives = 5;

    float lives;

    // Start is called before the first frame update
    void Start()
    {
        AdjustLivesByDifficulty();
        DisplayCurrentHealth();
    }

    private void AdjustLivesByDifficulty()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty(); 
    }

    private void DisplayCurrentHealth()
    {   
        livesText.text = Mathf.Clamp(lives, 0f, baseLives).ToString();

        // level lose
        if (lives <= 0)
        {
            FindObjectOfType<LevelController>().LevelLoseHandler();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Attacker otherAttacker = other.GetComponent<Attacker>();
        if (otherAttacker)
        {
            lives -= 1;
        }
        DisplayCurrentHealth();
        Destroy(other.gameObject);
    }
}
