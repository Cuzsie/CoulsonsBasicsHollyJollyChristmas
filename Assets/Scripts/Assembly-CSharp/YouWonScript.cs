using System;
using UnityEngine;

// Token: 0x020000DE RID: 222
public class YouWonScript : MonoBehaviour
{
	// Token: 0x06000A09 RID: 2569 RVA: 0x00027A47 File Offset: 0x00025E47
	private void Start()
	{
		this.delay = 10f;
	}

	// Token: 0x06000A0A RID: 2570 RVA: 0x00027A54 File Offset: 0x00025E54
	private void Update()
	{
		this.delay -= Time.deltaTime;
		if (this.delay <= 0f)
		{
			Application.Quit();
		}
	}

	// Token: 0x04000759 RID: 1881
	private float delay;
}
