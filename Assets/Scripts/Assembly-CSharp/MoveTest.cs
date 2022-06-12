using System;
using UnityEngine;

// Token: 0x0200001F RID: 31
public class MoveTest : MonoBehaviour
{
	// Token: 0x06000071 RID: 113 RVA: 0x00003E88 File Offset: 0x00002288
	private void Start()
	{
	}

	// Token: 0x06000072 RID: 114 RVA: 0x00003E8A File Offset: 0x0000228A
	private void Update()
	{
		base.transform.position = base.transform.position + new Vector3(0.1f, 0f, 0f);
	}
}
