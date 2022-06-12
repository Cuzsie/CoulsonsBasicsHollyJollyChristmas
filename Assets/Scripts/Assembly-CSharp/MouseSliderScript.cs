using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000CB RID: 203
public class MouseSliderScript : MonoBehaviour
{
	// Token: 0x060009B0 RID: 2480 RVA: 0x000253E8 File Offset: 0x000237E8
	private void Start()
	{
		if (PlayerPrefs.GetFloat("MouseSensitivity") < 100f)
		{
			PlayerPrefs.SetFloat("MouseSensitivity", 200f);
		}
		this.slider.value = PlayerPrefs.GetFloat("MouseSensitivity");
	}

	// Token: 0x060009B1 RID: 2481 RVA: 0x00025422 File Offset: 0x00023822
	private void Update()
	{
		PlayerPrefs.SetFloat("MouseSensitivity", this.slider.value);
	}

	// Token: 0x040006AF RID: 1711
	public Slider slider;
}
