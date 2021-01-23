 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string DIFFICULTY_KEY = "difficulty";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;
    const float MIN_Difficulty = 0;
    const float MAX_Difficulty = 2;

    public static void SetMasterVolume(float volume)
    {   
        if(volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            Debug.Log("Master volume set to " + volume);
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);

        }
        else
        {
            Debug.LogError("Master volume out of range");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetDifficulty(float difficultyValue)
    {
        if (difficultyValue >= MIN_Difficulty && difficultyValue <= MAX_Difficulty)
        {
            Debug.Log("Master difficulty set to " + difficultyValue);
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficultyValue);

        }
        else
        {
            Debug.LogError("Master difficulty out of range");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

}
