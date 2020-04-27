using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreViewer : MonoBehaviour
{
    public Text text;

    void Awake()
    {
        PlayerPrefs.SetInt("Score", 0);
    }

    void Update()
    {
        text.text = PlayerPrefs.GetInt("Lives", 0).ToString() + "\n" + PlayerPrefs.GetInt("Score", 0);
    }
}
