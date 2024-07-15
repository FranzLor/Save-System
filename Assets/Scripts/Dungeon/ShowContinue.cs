using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowContinue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (System.IO.File.Exists(Application.persistentDataPath + "/Dungeon.save") == false)
        {
            gameObject.SetActive(false);
        }
    }
    
}
