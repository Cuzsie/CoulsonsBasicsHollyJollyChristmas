using System;
//using TMPro;
using UnityEngine.UI;
using UnityEngine;

// Token: 0x02000015 RID: 21
public class EndlessTextScript : MonoBehaviour
{
	// Token: 0x06000045 RID: 69 RVA: 0x000031C4 File Offset: 0x000015C4
	private void Start()
	{
		this.text.text = string.Concat(new object[]
		{
			this.text.text,
			"\nHigh Score: ",
			PlayerPrefs.GetInt("HighBooks"),
			" Notebooks"
		});
	}

	// Token: 0x04000050 RID: 80
	public Text text;
}
