using System;
//using Rewired;
using UnityEngine;

// Token: 0x020000BD RID: 189
public class CameraScript_Simple : MonoBehaviour
{
	// Token: 0x06000948 RID: 2376 RVA: 0x000219A9 File Offset: 0x0001FDA9
	private void Start()
	{
		//this.playerInput = ReInput.players.GetPlayer(0);
		this.offset = base.transform.position - this.player.transform.position;
	}

	// Token: 0x06000949 RID: 2377 RVA: 0x000219E4 File Offset: 0x0001FDE4
	private void LateUpdate()
	{
		base.transform.position = this.player.transform.position + this.offset;
		base.transform.rotation = this.player.transform.rotation * Quaternion.Euler(0f, (float)this.lookBehind, 0f);
	}

	// Token: 0x040005E4 RID: 1508
	public GameObject player;

	// Token: 0x040005E5 RID: 1509
	private int lookBehind;

	// Token: 0x040005E6 RID: 1510
	private Vector3 offset;

	// Token: 0x040005E7 RID: 1511
	//private Player playerInput;
}
