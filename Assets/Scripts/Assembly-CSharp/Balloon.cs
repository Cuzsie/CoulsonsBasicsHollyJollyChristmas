using System;
using UnityEngine;

// Token: 0x02000005 RID: 5
public class Balloon : MonoBehaviour
{
	// Token: 0x0600000C RID: 12 RVA: 0x0000222C File Offset: 0x0000062C
	private void Start()
	{
		this.ChangeDirection();
	}

	// Token: 0x0600000D RID: 13 RVA: 0x00002234 File Offset: 0x00000634
	private void Update()
	{
		this.directionTime -= Time.deltaTime;
		if (this.directionTime <= 0f)
		{
			this.ChangeDirection();
			this.directionTime = 10f;
		}
		this.rb.velocity = this.direction * this.speed;
	}

	// Token: 0x0600000E RID: 14 RVA: 0x00002290 File Offset: 0x00000690
	private void ChangeDirection()
	{
		this.direction.x = UnityEngine.Random.Range(-1f, 1f);
		this.direction.z = UnityEngine.Random.Range(-1f, 1f);
		this.direction = this.direction.normalized;
	}

	// Token: 0x0400000C RID: 12
	[SerializeField]
	private Rigidbody rb;

	// Token: 0x0400000D RID: 13
	private float directionTime = 10f;

	// Token: 0x0400000E RID: 14
	private Vector3 direction;

	// Token: 0x0400000F RID: 15
	public float speed = 10f;
}
