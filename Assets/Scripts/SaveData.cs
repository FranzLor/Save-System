using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    //data types
    public string text;
    public int intNum;
    public float floatNum;

    public List<SaveVector3> location;

    public enum InfoType { whatever, info, needs, to, be,  here };
    public InfoType typeOfInfo;


    //ref to sub save class
    public SubSave subSave;
}

[System.Serializable]
public class SubSave
{
    public string text;
    public bool isTrue;
}


[System.Serializable]
public class SaveVector3
{
    public float x, y, z;
}
