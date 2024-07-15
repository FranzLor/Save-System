using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonLevelManager : MonoBehaviour
{
    public static DungeonLevelManager instance;
    private void Awake()
    {
        instance = this;
    }

    public string nextLevel;

    private bool isEnding;

    public void LeaveLevel()
    {
        if (isEnding == false)
        {
            isEnding = true;
            StartCoroutine(LeaveLevelCo());
        }
    }

    IEnumerator LeaveLevelCo()
    {
        DungeonUIController.instance.StartFadeToBlack();

        //call save system update
        UpdateSaveSystem();

        //save system save
        SaveSystem.instance.Save();

        yield return new WaitForSeconds(.5f);

        if (nextLevel != "")
        {
            SceneManager.LoadScene(nextLevel);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    //update save system
    void UpdateSaveSystem()
    {
        DungeonPlayerStats stats = DungeonPlayerStats.instance;

        SaveSystem.instance.activeSave.strength = stats.strength;
        SaveSystem.instance.activeSave.defence = stats.defence;

        SaveSystem.instance.activeSave.level = stats.level;
        SaveSystem.instance.activeSave.currentXP = stats.currentXP;

        SaveSystem.instance.activeSave.xpToLevel = stats.xpToLevel;
        SaveSystem.instance.activeSave.maxHP = stats.maxHP;

        SaveSystem.instance.activeSave.currentHealth = DungeonPlayer.instance.currentHealth;



    }
}
