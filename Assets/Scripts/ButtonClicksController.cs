using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClicksController : MonoBehaviour
{
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

    public void On1Click()  { SceneManager.LoadScene("Scenes/Levels/1");  }
    public void On2Click()  { SceneManager.LoadScene("Scenes/Levels/2");  }
    public void On3Click()  { SceneManager.LoadScene("Scenes/Levels/3");  }
    public void On4Click()  { SceneManager.LoadScene("Scenes/Levels/4");  }
    public void On5Click()  { SceneManager.LoadScene("Scenes/Levels/5");  }
    public void On6Click()  { SceneManager.LoadScene("Scenes/Levels/6");  }
    public void On7Click()  { SceneManager.LoadScene("Scenes/Levels/7");  }
    public void On8Click()  { SceneManager.LoadScene("Scenes/Levels/8");  }
    public void On9Click()  { SceneManager.LoadScene("Scenes/Levels/9");  }
    public void On10Click() { SceneManager.LoadScene("Scenes/Levels/10"); }
}
