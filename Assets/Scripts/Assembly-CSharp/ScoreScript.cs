using System;
//using TMPro;
using UnityEngine.UI;
using UnityEngine;

// Token: 0x020000B7 RID: 183
public class ScoreScript : MonoBehaviour
{
	// Token: 0x06000930 RID: 2352 RVA: 0x00021440 File Offset: 0x0001F840
	private void Start()
	{
		if (PlayerPrefs.GetString("CurrentMode") == "endless")
		{
			this.scoreText.SetActive(true);
			this.text.text = "Score:\n" + PlayerPrefs.GetInt("CurrentBooks") + " Notebooks";
		}
	}

	// Token: 0x06000931 RID: 2353 RVA: 0x0002149B File Offset: 0x0001F89B
	private void Update()
	{
	}

	// Token: 0x040005CE RID: 1486
	public GameObject scoreText;

	// Token: 0x040005CF RID: 1487
	public Text text;
}
