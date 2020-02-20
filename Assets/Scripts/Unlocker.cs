using UnityEngine;
using UnityEngine.UI;

public class Unlocker : MonoBehaviour
{
    public int Me;
    public Image image;
    public Sprite[] sprites;
    public bool unlocked = false;

    private int Level;

    void Start()
    {
    }

    void Awake()
    {
        Level = PlayerPrefs.GetInt("Level", 1);

        Debug.Log(Level);

        if (Level > Me)
        {
            image.sprite = sprites[2];
        }
        else if (Level < Me)
        {
            image.sprite = sprites[1];
        }
        else
        {
            image.sprite = sprites[0];
            unlocked = true;
        }
    }
}
