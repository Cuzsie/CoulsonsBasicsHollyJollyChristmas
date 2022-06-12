using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020000D9 RID: 217
public class StartButton : MonoBehaviour
{
	// Token: 0x06000A01 RID: 2561 RVA: 0x00027924 File Offset: 0x00025D24
	public void StartGame()
	{
		if (this.currentMode == StartButton.Mode.Story)
		{
			PlayerPrefs.SetString("CurrentMode", "story");
		}
		else
		{
			PlayerPrefs.SetString("CurrentMode", "endless");
		}
		SceneManager.LoadSceneAsync("School");
	}

	// Token: 0x04000752 RID: 1874
	public StartButton.Mode currentMode;

	// Token: 0x020000DA RID: 218
	public enum Mode
	{
		// Token: 0x04000754 RID: 1876
		Story,
		// Token: 0x04000755 RID: 1877
		Endless
	}
}
