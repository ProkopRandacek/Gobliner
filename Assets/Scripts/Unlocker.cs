using UnityEngine;
using UnityEngine.UI;

public class Unlocker : MonoBehaviour
{
    public int Me;
	public Text text;
    public Image image;
    public Sprite[] sprites;
    public bool unlocked = false;

    private int Level;

    void Start()
    {
    }

    void Awake()
    {
		int MeScore = PlayerPrefs.GetInt("ScoreLvl" + Me.ToString(), -1); //uz je done
		int PreScore = PlayerPrefs.GetInt("ScoreLvl" + (Me - 1).ToString(), -1); // ten predtim je done
		
		if (MeScore != -1)
		{
			image.sprite = sprites[2];
			unlocked = true;
		}
		else if (PreScore != -1 || Me == 1)
		{
			image.sprite = sprites[0];
			unlocked = true;
		}
		else
		{
            image.sprite = sprites[1];
		}

		TextAsset ta = Resources.Load("MaxScores") as TextAsset;
		string[] scores = ta.text.Split('\n');
		string MeMax = scores[Me - 1];
		if (MeScore == -1)
			MeScore = 0;

		text.text = MeScore + "/" + MeMax.ToString();
    }
}
