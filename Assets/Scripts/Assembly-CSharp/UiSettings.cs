using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000E7 RID: 231
public class UiSettings : MonoBehaviour
{
	// Token: 0x06000A2F RID: 2607 RVA: 0x000284E0 File Offset: 0x000268E0
	public void UpdateState()
	{
		if (this.sAuto.isOn)
		{
			PlayerPrefs.SetInt("UiSize", 0);
		}
		else if (this.sXLarge.isOn)
		{
			PlayerPrefs.SetInt("UiSize", 1);
		}
		else if (this.sLarge.isOn)
		{
			PlayerPrefs.SetInt("UiSize", 2);
		}
		else if (this.sMed.isOn)
		{
			PlayerPrefs.SetInt("UiSize", 3);
		}
		else if (this.sSmall.isOn)
		{
			PlayerPrefs.SetInt("UiSize", 4);
		}
		if (this.hLow.isOn)
		{
			PlayerPrefs.SetInt("UiHeight", 0);
		}
		else if (this.hMed.isOn)
		{
			PlayerPrefs.SetInt("UiHeight", 1);
		}
		else if (this.hHigh.isOn)
		{
			PlayerPrefs.SetInt("UiHeight", 2);
		}
	}

	// Token: 0x06000A30 RID: 2608 RVA: 0x000285E4 File Offset: 0x000269E4
	public void RestoreState()
	{
		this.size = PlayerPrefs.GetInt("UiSize");
		this.height = PlayerPrefs.GetInt("UiHeight");
		if (this.size == 0)
		{
			this.sAuto.isOn = true;
		}
		else if (this.size == 1)
		{
			this.sXLarge.isOn = true;
		}
		else if (this.size == 2)
		{
			this.sLarge.isOn = true;
		}
		else if (this.size == 3)
		{
			this.sMed.isOn = true;
		}
		else if (this.size == 4)
		{
			this.sSmall.isOn = true;
		}
		if (this.height == 0)
		{
			this.hLow.isOn = true;
		}
		else if (this.height == 1)
		{
			this.hMed.isOn = true;
		}
		else if (this.height == 2)
		{
			this.hHigh.isOn = true;
		}
	}

	// Token: 0x04000783 RID: 1923
	public Toggle sAuto;

	// Token: 0x04000784 RID: 1924
	public Toggle sXLarge;

	// Token: 0x04000785 RID: 1925
	public Toggle sLarge;

	// Token: 0x04000786 RID: 1926
	public Toggle sMed;

	// Token: 0x04000787 RID: 1927
	public Toggle sSmall;

	// Token: 0x04000788 RID: 1928
	public Toggle hLow;

	// Token: 0x04000789 RID: 1929
	public Toggle hMed;

	// Token: 0x0400078A RID: 1930
	public Toggle hHigh;

	// Token: 0x0400078B RID: 1931
	private int size;

	// Token: 0x0400078C RID: 1932
	private int height;
}
