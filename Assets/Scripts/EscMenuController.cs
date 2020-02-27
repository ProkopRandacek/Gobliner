using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenuController : MonoBehaviour
{
    public GameObject Menu;
    void Start()
    {
        Menu.GetComponent<Canvas>().enabled = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Menu.GetComponent<Canvas>().enabled = true;
        }
    }
    public void Hide()
    {
        Menu.GetComponent<Canvas>().enabled = false;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Scenes/Levels");
    }
}
