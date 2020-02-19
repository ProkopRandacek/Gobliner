using UnityEngine;
using UnityEngine.UI;

public class Unlocker : MonoBehaviour
{
    public int Me;
    public Image image;
    public Sprite[] sprites;

    private int Level;

    void Start()
    {
        Level = PlayerPrefs.GetInt("Score", 1);

        Debug.Log(Level);

        if (Level > Me)
        {
            Debug.Log(2);
            image.sprite = sprites[2];
        }
        else if (Level < Me)
        {
            Debug.Log(1);
            image.sprite = sprites[1];
        }
        else
        {
            Debug.Log(0);
            image.sprite = sprites[0];
        }
    }
}
