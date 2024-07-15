using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

using UnityEditor;
using System.Runtime.Serialization.Formatters.Binary;

public class BinaryFormatterSaveTest : MonoBehaviour
{
    //testing saving string
    public string testingString;

    public List<float> testingList;

    public SaveData dataToSave;

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
        //LIST---------------------------
        Debug.Log("Saving...");

        Vector3 newVector = new Vector3(1f, 2f, 3f);

        dataToSave.location.Add(new SaveVector3());
        dataToSave.location[dataToSave.location.Count - 1].x = newVector.x;
        dataToSave.location[dataToSave.location.Count - 1].y = newVector.y;
        dataToSave.location[dataToSave.location.Count - 1].z = newVector.z;

        //directory to save to
        string dataPath = Application.persistentDataPath;

        //create new XML serializer
        var serializer = new BinaryFormatter();
        var stream = new FileStream(dataPath + "/BinaryTest.xml", FileMode.Create);
        serializer.Serialize(stream, dataToSave);

        stream.Close();
        //--------------------------------
    }

    void Load()
    {
        //LIST---------------------------
        string dataPath = Application.persistentDataPath;

        //error check ensure file exists
        if (File.Exists(dataPath + "/BinaryTest.xml"))
        {
            Debug.Log("Loading Data");

            var serializer = new BinaryFormatter();
            var stream = new FileStream(dataPath + "/BinaryTest.xml", FileMode.Open);
            dataToSave = serializer.Deserialize(stream) as SaveData;
            stream.Close();
        }
        else
        {
            Debug.LogWarning("No Save File Found");
        }
        //--------------------------------
    }

    void ClearSave()
    {
        //error check ensure file exists
        if (File.Exists(Application.persistentDataPath + "/BinaryTest.xml"))
        {
            Debug.Log("Deleting Save File");

            File.Delete(Application.persistentDataPath + "/BinaryTest.xml");
        }
        else
        {
            Debug.LogWarning("No Save File Found");
        }
    }
}
