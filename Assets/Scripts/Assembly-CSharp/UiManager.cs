using System;
using MaterialKit;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000E6 RID: 230
public class UiManager : MonoBehaviour
{
	// Token: 0x06000A2D RID: 2605 RVA: 0x000282DC File Offset: 0x000266DC
	private void Start()
	{
		int @int = PlayerPrefs.GetInt("UiSize");
		int int2 = PlayerPrefs.GetInt("UiHeight");
		if (@int == 1)
		{
			this.dpiScaler.enabled = false;
			this.normScaler.referenceResolution = new Vector2(640f, 480f);
			this.normScaler.enabled = true;
		}
		else if (@int == 2)
		{
			this.dpiScaler.enabled = false;
			this.normScaler.referenceResolution = new Vector2(800f, 600f);
			this.normScaler.enabled = true;
		}
		else if (@int == 3)
		{
			this.dpiScaler.enabled = false;
			this.normScaler.referenceResolution = new Vector2(900f, 720f);
			this.normScaler.enabled = true;
		}
		else if (@int == 4)
		{
			this.dpiScaler.enabled = false;
			this.normScaler.referenceResolution = new Vector2(1024f, 720f);
			this.normScaler.enabled = true;
		}
		if (int2 == 1)
		{
			foreach (RectTransform rectTransform in this.transforms)
			{
				rectTransform.position = new Vector3(rectTransform.position.x, rectTransform.position.y + (float)(Screen.height / 8), rectTransform.position.z);
			}
		}
		else if (int2 == 2)
		{
			foreach (RectTransform rectTransform2 in this.transforms)
			{
				rectTransform2.position = new Vector3(rectTransform2.position.x, rectTransform2.position.y + (float)(Screen.height / 4), rectTransform2.position.z);
			}
		}
	}

	// Token: 0x04000780 RID: 1920
	public CanvasScaler normScaler;

	// Token: 0x04000781 RID: 1921
	public DpCanvasScaler dpiScaler;

	// Token: 0x04000782 RID: 1922
	public RectTransform[] transforms;
}
