using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000012 RID: 18
public class DefaultSettingsScript : MonoBehaviour
{
	// Token: 0x0600003C RID: 60 RVA: 0x00002F46 File Offset: 0x00001346
	private void Start()
	{
		if (!PlayerPrefs.HasKey("OptionsSet"))
		{
			this.options.SetActive(true);
			base.StartCoroutine(this.CloseOptions());
			this.canvas.enabled = false;
		}
	}

	// Token: 0x0600003D RID: 61 RVA: 0x00002F7C File Offset: 0x0000137C
	public IEnumerator CloseOptions()
	{
		yield return new WaitForEndOfFrame();
		this.canvas.enabled = true;
		this.options.SetActive(false);
		yield break;
	}

	// Token: 0x04000047 RID: 71
	public GameObject options;

	// Token: 0x04000048 RID: 72
	public Canvas canvas;
}
