using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformerLevelManager : MonoBehaviour
{
    public static PlatformerLevelManager instance;
    private void Awake()
    {
        instance = this;
    }

    public int coinCount;
    public string sceneToload;

    // Start is called before the first frame update
    void Start()
    {
        //save and update coin count
        if (PlayerPrefs.HasKey("coinCount"))
        {  
            coinCount = PlayerPrefs.GetInt("coinCount");
            //update coin UI
            PlatformerUIController.instance.UpdateCoinText(coinCount);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddCoin()
    {
        coinCount++;

        PlatformerUIController.instance.UpdateCoinText(coinCount);
    }

    public void ExitLevel()
    {
        StartCoroutine(ExitLevelCo());
    }

    IEnumerator ExitLevelCo()
    {
        FindObjectOfType<PlatformerPlayer>().canMove = false;
        
        //save coin count after ext
        PlayerPrefs.SetInt("coinCount", coinCount);

        yield return new WaitForSeconds(1f);

        if(sceneToload != "")
        {
            SceneManager.LoadScene(sceneToload);
        } else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
