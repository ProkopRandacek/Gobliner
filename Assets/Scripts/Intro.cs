using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
	public Image img;

	private float time = 0;

	void Update()
	{

		time += Time.deltaTime;

		if (time < 1)
		{
			img.color = new Color(1, 1, 1, time - 0);
		}
		else if (time < 3)
		{
			
		}
		else if (time <= 4)
		{
			img.color = new Color(1, 1, 1, 1 - (time - 3));
		}
		else if (time > 4.5)
		{
			SceneManager.LoadScene("Scenes/Menu");
		}
	}
}
