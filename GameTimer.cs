using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{   
    [Tooltip("Level timer in seconds")]
    [SerializeField] float levelTime = 10f;

    bool levelTimesUp = false;

    //cached variable
    LevelController levelController;
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        levelController = FindObjectOfType<LevelController>();
    }

    // Update is called once per frame
    void Update()
    {   
        // stop unnecessary updates
        if(levelTimesUp) { return; }

        slider.value = Time.timeSinceLevelLoad / levelTime;

        bool timeUp = (Time.timeSinceLevelLoad >= levelTime);
        if (timeUp)
        {
            levelController.LevelTimesUp();
        }
    }
}
