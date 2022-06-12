using System;
using UnityEngine;

// Token: 0x02000011 RID: 17
public class DebugScript : MonoBehaviour
{
	// Token: 0x06000039 RID: 57 RVA: 0x00002F1E File Offset: 0x0000131E
	private void Start()
	{
		if (this.limitFramerate)
		{
			QualitySettings.vSyncCount = 0;
			Application.targetFrameRate = this.framerate;
		}
	}

	// Token: 0x0600003A RID: 58 RVA: 0x00002F3C File Offset: 0x0000133C
	private void Update()
	{
	}

	// Token: 0x04000045 RID: 69
	public bool limitFramerate;

	// Token: 0x04000046 RID: 70
	public int framerate;
}
