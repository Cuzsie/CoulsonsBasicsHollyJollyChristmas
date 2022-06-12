using System;
using UnityEngine;

// Token: 0x02000026 RID: 38
public class QuarterSpawnScript : MonoBehaviour
{
	// Token: 0x06000087 RID: 135 RVA: 0x0000470E File Offset: 0x00002B0E
	private void Start()
	{
		this.wanderer.QuarterExclusive();
		base.transform.position = this.location.position + Vector3.up * 4f;
	}

	// Token: 0x040000B5 RID: 181
	public AILocationSelectorScript wanderer;

	// Token: 0x040000B6 RID: 182
	public Transform location;
}
