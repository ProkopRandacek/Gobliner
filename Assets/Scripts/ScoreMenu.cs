using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMenu : MonoBehaviour
{
	public Text text;

    void Awake()
    {
		int Lives = PlayerPrefs.GetInt("Lives", 5);
		int Score = 0;
		for (int i = 0; i < 10; i++)
		{
			Score += PlayerPrefs.GetInt("ScoreLvl" + i.ToString(), 0);
		}
		int Kills = PlayerPrefs.GetInt("Kills", 0);
		int Sale = CalculateSale(Score);

        text.text = Lives + "\n" + Score.ToString() + "\n" + Kills.ToString() + "\n" + Sale.ToString();
    }

	int CalculateSale(int Score)
	{
		return 3;
	}
}
