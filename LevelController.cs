using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{   
    [SerializeField] GameObject levelCompleteCanvas, levelLoseCanvas;
    [SerializeField] float loadNextSceneDelay = 4f;

    int currentAttackerNum = 0;
    bool levelTimesUp = false;
    bool noAttackerRemaining = false;

    // Cached variables
    LevelLoader levelLoader;

    // Start is called before the first frame update
    void Start()
    {
        levelCompleteCanvas.SetActive(false);
        levelLoseCanvas.SetActive(false);
        levelLoader = FindObjectOfType<LevelLoader>();
    }

    public void AddAttackerCount()
    {
        currentAttackerNum += 1;
    }

    public void SubtractAttackerCount()
    {
        currentAttackerNum -= 1;

        if (currentAttackerNum <= 0)
        {
            noAttackerRemaining = true;
            if (levelTimesUp && noAttackerRemaining && !levelLoseCanvas.activeSelf)
            {
                LevelCompleteHandler();
            }
        }
    }

    // Handle time's up for level
    public void LevelTimesUp()
    {
        levelTimesUp = true;
        StopAllAttackerSpawners();
    }


    private void StopAllAttackerSpawners()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner attSpr in attackerSpawners)
        {
            attSpr.StopSpawnAttacker();
        }
    }

    // Handle level win
    private void LevelCompleteHandler()
    {   
        levelCompleteCanvas.SetActive(true);
        levelCompleteCanvas.GetComponent<AudioSource>().Play();
        levelLoader.LoadSceneByNameWithDelay("nextScene", loadNextSceneDelay);
    }

    //// Handle level lose
    public void LevelLoseHandler()
    {
        levelLoseCanvas.SetActive(true);
        Time.timeScale = 0;
    }

}
