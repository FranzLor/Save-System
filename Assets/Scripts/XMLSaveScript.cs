using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

public class NewBehaviourScript : MonoBehaviour
{
    //testing saving string
    public string testingString;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //save string
        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }
        //load string
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
        //clear string
        if (Input.GetKeyDown(KeyCode.C))
        {
            ClearSave();
        }
    }

    void Save()
    {
        Debug.Log("Saving...");
        //directory to save to
        string dataPath = Application.persistentDataPath;

        //create new XML serializer
        var serializer = new XmlSerializer(typeof(string));
        var stream = new FileStream(dataPath + "/save.xml", FileMode.Create);
        serializer.Serialize(stream, testingString);

        stream.Close();
    }

    void Load()
    {
        Debug.Log("Loading...");
    }

    void ClearSave()
    {
        Debug.Log("Clearing Save...");
    }
}
