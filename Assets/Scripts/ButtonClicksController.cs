using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClicksController : MonoBehaviour
{
    public void OnPlayClick()
    {
        Debug.Log("Play");
    }

    public void OnExitClick()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
