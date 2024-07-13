using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformerLevelSelectButton : MonoBehaviour
{
    public string sceneToLoad;

    public bool isLocked;
    public GameObject lockedDisplay;

    public string LevelToCheck;

    private void Start()
    {
        //check if level is locked
        if (LevelToCheck != "") 
        {
           if (PlayerPrefs.HasKey(LevelToCheck + "_complete"))
           {
                if (PlayerPrefs.GetString(LevelToCheck + "_complete") == "true")
                {
                    isLocked = false;
                }
           }
        }

        lockedDisplay.SetActive(isLocked);
    }

    public void SelectLevel()
    {
        if (PlatformerLevelSelect.instance.levelLoading == false && isLocked == false)
        {
            PlatformerLevelSelect.instance.StartLevelLoad(sceneToLoad);
        }
    }
}
