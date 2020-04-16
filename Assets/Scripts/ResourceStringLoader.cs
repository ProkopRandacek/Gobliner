using TinyJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceStringLoader : MonoBehaviour
{
    string ResourceStringPath = "/ResourceString.json";

    void Start()
    {
        Debug.Log(LoadString());
    }

    void Update()
    {
        
    }

    string LoadString()
    {
        string filePath = "/" + path.Replace(".json", "");
 
        TextAsset targetFile = Resources.Load<TextAsset>(filePath);

	return targetFile.text;
    }

    Dictionary Json2Dict(string json)
    {
        string fileJson = File.ReadAllText("test.json");
        List<int> fileValues = fileJson.FromJson<List<int>>();
    }
}

