using System;
using UnityEngine;

// Token: 0x02000010 RID: 16
public class DebugFirstPrizeScript : MonoBehaviour
{
	// Token: 0x06000036 RID: 54 RVA: 0x00002EA6 File Offset: 0x000012A6
	private void Start()
	{
	}

	// Token: 0x06000037 RID: 55 RVA: 0x00002EA8 File Offset: 0x000012A8
	private void Update()
	{
		base.transform.position = this.first.position + new Vector3((float)Mathf.RoundToInt(this.first.forward.x), 0f, (float)Mathf.RoundToInt(this.first.forward.z)) * 3f;
	}

	// Token: 0x04000043 RID: 67
	public Transform player;

	// Token: 0x04000044 RID: 68
	public Transform first;
}
