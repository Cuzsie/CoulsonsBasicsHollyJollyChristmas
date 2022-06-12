using System;
using UnityEngine;

// Token: 0x020000D5 RID: 213
public class PickupAnimationScript : MonoBehaviour
{
	// Token: 0x060009E4 RID: 2532 RVA: 0x000267B4 File Offset: 0x00024BB4
	private void Start()
	{
		this.itemPosition = base.GetComponent<Transform>();
	}

	// Token: 0x060009E5 RID: 2533 RVA: 0x000267C2 File Offset: 0x00024BC2
	private void Update()
	{
		this.itemPosition.localPosition = new Vector3(0f, Mathf.Sin((float)Time.frameCount * 0.017453292f) / 2f + 1f, 0f);
	}

	// Token: 0x04000717 RID: 1815
	private Transform itemPosition;
}
