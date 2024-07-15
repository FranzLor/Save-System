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
        SetupInstance();
    }

    public void SetupInstance()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            //loads save data
            //Load();

        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    //save data ref
    public SaveSystemData activeSave;

    //doesnt save for ending game
    public string sceneNotToSave;

    //name save file
    public string saveName;

    //dont save for testing
    public bool dontSave;

    public void Save()
    {
#if UNITY_EDITOR
        if (dontSave == false)
        {
#endif
            Debug.Log("Saving...");
            //directory to save to
            string dataPath = Application.persistentDataPath;

            //create new XML serializer
            var serializer = new XmlSerializer(typeof(SaveSystemData));
            var stream = new FileStream(dataPath + "/" + saveName + ".save", FileMode.Create);
            serializer.Serialize(stream, activeSave);

            stream.Close();
#if UNITY_EDITOR
    }
#endif
    }

    public void Load()
    {
        string dataPath = Application.persistentDataPath;

        //error check ensure file exists
        if (File.Exists(dataPath + "/" + saveName + ".save"))
        {
            Debug.Log("Loading Data");

            var serializer = new XmlSerializer(typeof(SaveSystemData));
            var stream = new FileStream(dataPath + "/" + saveName + ".save", FileMode.Open);
            activeSave = serializer.Deserialize(stream) as SaveSystemData;
            stream.Close();
        }
        else
        {
            Debug.LogWarning("No Save File Found");
        }
    }

    public void DestroySaveSystem()
    {
        instance = null;
        Destroy(gameObject);
    }
}
