using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceStringLoader : MonoBehaviour
{
    public string name;
	private Text t;

    void Start()
    {
		t = transform.Find("Text").gameObject.GetComponent<Text>();
		t.text = LoadString();
    }

    string LoadString()
    {
		TextAsset ta = Resources.Load("ResourceString") as TextAsset;
		string[] text = ta.text.Split('\n');
		foreach (string line in text)
		{
			if (line.Split(';')[0].ToLower() == name.ToLower())
			{
				return line.Split(';')[1];
			}
		}
		return "";
    }
}
