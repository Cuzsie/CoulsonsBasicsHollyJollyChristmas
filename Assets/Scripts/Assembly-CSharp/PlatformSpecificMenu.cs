using System;
using UnityEngine;

// Token: 0x02000024 RID: 36
public class PlatformSpecificMenu : MonoBehaviour
{
	// Token: 0x0600007E RID: 126 RVA: 0x00004355 File Offset: 0x00002755
	private void Start()
	{
		this.pC.SetActive(true);
	}

	// Token: 0x0400009C RID: 156
	public GameObject pC;

	// Token: 0x0400009D RID: 157
	public GameObject mobile;
}
