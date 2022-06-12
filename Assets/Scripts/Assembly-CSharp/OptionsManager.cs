using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000021 RID: 33
public class OptionsManager : MonoBehaviour
{
	// Token: 0x06000076 RID: 118 RVA: 0x00003ED8 File Offset: 0x000022D8
	private void Start()
	{
		if (PlayerPrefs.HasKey("OptionsSet"))
		{
			this.slider.value = PlayerPrefs.GetFloat("MouseSensitivity");
			if (PlayerPrefs.GetInt("Rumble") == 1)
			{
				this.rumble.isOn = true;
			}
			else
			{
				this.rumble.isOn = false;
			}
			if (PlayerPrefs.GetInt("AnalogMove") == 1)
			{
				this.analog.isOn = true;
			}
			else
			{
				this.analog.isOn = false;
			}
		}
		else
		{
			PlayerPrefs.SetInt("OptionsSet", 1);
		}
	}

	// Token: 0x06000077 RID: 119 RVA: 0x00003F74 File Offset: 0x00002374
	private void Update()
	{
		PlayerPrefs.SetFloat("MouseSensitivity", this.slider.value);
		if (this.rumble.isOn)
		{
			PlayerPrefs.SetInt("Rumble", 1);
		}
		else
		{
			PlayerPrefs.SetInt("Rumble", 0);
		}
		if (this.analog.isOn)
		{
			PlayerPrefs.SetInt("AnalogMove", 1);
		}
		else
		{
			PlayerPrefs.SetInt("AnalogMove", 0);
		}
	}

	// Token: 0x0400008E RID: 142
	public Slider slider;

	// Token: 0x0400008F RID: 143
	public Toggle rumble;

	// Token: 0x04000090 RID: 144
	public Toggle analog;
}
