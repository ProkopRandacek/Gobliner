using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClicksController : MonoBehaviour
{
    public GameObject[] Btns;

    void Start()
    {
        PlayerPrefs.SetInt("Lives", 5);
        PlayerPrefs.SetInt("Level", 1);
    }

    public void OnExitClick()
    {
        Application.Quit();
    }

    public void OnNewGameClick()
    {
        On1Click();
    }

    public void OnContinueClick()
    {

    }

    public void OnBackToMenuClick() { SceneManager.LoadScene("Scenes/Menu"); }

    public void OnPlayClick()   { SceneManager.LoadScene("Scenes/GameSelect"); }
    public void OnLevelsClick() { SceneManager.LoadScene("Scenes/Levels");     }

    public void On1Click()  { if (Btns[0].GetComponentInChildren<Unlocker>().unlocked) { SceneManager.LoadScene("Scenes/Levels/1");  } }
    public void On2Click()  { if (Btns[1].GetComponentInChildren<Unlocker>().unlocked) { SceneManager.LoadScene("Scenes/Levels/2");  } }
    public void On3Click()  { if (Btns[2].GetComponentInChildren<Unlocker>().unlocked) { SceneManager.LoadScene("Scenes/Levels/3");  } }
    public void On4Click()  { if (Btns[3].GetComponentInChildren<Unlocker>().unlocked) { SceneManager.LoadScene("Scenes/Levels/4");  } }
    public void On5Click()  { if (Btns[4].GetComponentInChildren<Unlocker>().unlocked) { SceneManager.LoadScene("Scenes/Levels/5");  } }
    public void On6Click()  { if (Btns[5].GetComponentInChildren<Unlocker>().unlocked) { SceneManager.LoadScene("Scenes/Levels/6");  } }
    public void On7Click()  { if (Btns[6].GetComponentInChildren<Unlocker>().unlocked) { SceneManager.LoadScene("Scenes/Levels/7");  } }
    public void On8Click()  { if (Btns[7].GetComponentInChildren<Unlocker>().unlocked) { SceneManager.LoadScene("Scenes/Levels/8");  } }
    public void On9Click()  { if (Btns[8].GetComponentInChildren<Unlocker>().unlocked) { SceneManager.LoadScene("Scenes/Levels/9");  } }
    public void On10Click() { if (Btns[9].GetComponentInChildren<Unlocker>().unlocked) { SceneManager.LoadScene("Scenes/Levels/10"); } }
}
