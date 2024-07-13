using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Xml.Serialization;

using UnityEditor;

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
        //open save file
        if (Input.GetKeyDown(KeyCode.O))
        {
            EditorUtility.RevealInFinder(Application.persistentDataPath);
            EditorUtility.RevealInFinder(Application.dataPath);
        }
    }

    void Save()
    {
        Debug.Log("Saving...");
        //directory to save to
        string dataPath = Application.persistentDataPath;

        //create new XML serializer
        var serializer = new XmlSerializer(typeof(string));
        var stream = new FileStream(dataPath + "/Save.xml", FileMode.Create);
        serializer.Serialize(stream, testingString);

        stream.Close();
    }

    void Load()
    {
        Debug.Log("Loading Data");

        string dataPath = Application.persistentDataPath;

        var serializer = new XmlSerializer(typeof(string));
        var stream = new FileStream(dataPath + "/Save.xml", FileMode.Open);
        testingString = serializer.Deserialize(stream) as string;
        stream.Close();
    }

    void ClearSave()
    {
        Debug.Log("Clearing Save...");
    }
}
