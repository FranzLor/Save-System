using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

public class SaveSystem : MonoBehaviour
{
    //singleton for save system throughout levels
    public static SaveSystem instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            //loads save data
            Load();

        } else
        {
            Destroy(gameObject);
        }
    }

    //save data ref
    public SaveSystemData activeSave;

    public void Save()
    {
        Debug.Log("Saving...");
        //directory to save to
        string dataPath = Application.persistentDataPath;

        //create new XML serializer
        var serializer = new XmlSerializer(typeof(SaveSystemData));
        var stream = new FileStream(dataPath + "/Dungeon.save", FileMode.Create);
        serializer.Serialize(stream, activeSave);

        stream.Close();
    }

    public void Load()
    {
        string dataPath = Application.persistentDataPath;

        //error check ensure file exists
        if (File.Exists(dataPath + "/Dungeon.save"))
        {
            Debug.Log("Loading Data");

            var serializer = new XmlSerializer(typeof(SaveSystemData));
            var stream = new FileStream(dataPath + "/Dungeon.save", FileMode.Open);
            activeSave = serializer.Deserialize(stream) as SaveSystemData;
            stream.Close();
        }
        else
        {
            Debug.LogWarning("No Save File Found");
        }
    }
}
