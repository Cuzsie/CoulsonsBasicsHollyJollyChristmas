using System;
using UnityEngine;

// Token: 0x020000E0 RID: 224
public class SpoopBalloon : MonoBehaviour
{
	// Token: 0x06000A0E RID: 2574 RVA: 0x00027A9C File Offset: 0x00025E9C
	private void FixedUpdate()
	{
		this.rb.AddForce((this.player.position - base.transform.position).normalized * this.speed);
	}

	// Token: 0x0400075A RID: 1882
	[SerializeField]
	private Rigidbody rb;

	// Token: 0x0400075B RID: 1883
	public Transform player;

	// Token: 0x0400075C RID: 1884
	public float speed;
}
