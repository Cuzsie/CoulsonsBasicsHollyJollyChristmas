using System;
//using Rewired;
using UnityEngine;

// Token: 0x020000BC RID: 188
public class CameraScript : MonoBehaviour
{
	// Token: 0x06000944 RID: 2372 RVA: 0x000216C4 File Offset: 0x0001FAC4
	private void Start()
	{
		//this.playerInput = ReInput.players.GetPlayer(0);
		this.offset = base.transform.position - this.player.transform.position;
	}

	// Token: 0x06000945 RID: 2373 RVA: 0x00021700 File Offset: 0x0001FB00
	private void Update()
	{
		if (this.ps.jumpRope)
		{
			this.velocity -= this.gravity * Time.deltaTime;
			this.jumpHeight += this.velocity * Time.deltaTime;
			if (this.jumpHeight <= 0f)
			{
				this.jumpHeight = 0f;
				if (Input.GetKeyDown(KeyCode.Space))
				{
					this.velocity = this.initVelocity;
				}
			}
			this.jumpHeightV3 = new Vector3(0f, this.jumpHeight, 0f);
		}
		else if (Input.GetButton("Look Behind"))
		{
			this.lookBehind = 180;
		}
		else
		{
			this.lookBehind = 0;
		}
	}

	// Token: 0x06000946 RID: 2374 RVA: 0x000217D8 File Offset: 0x0001FBD8
	private void LateUpdate()
	{
		base.transform.position = this.player.transform.position + this.offset;
		if (!this.ps.gameOver & !this.ps.jumpRope)
		{
			base.transform.position = this.player.transform.position + this.offset;
			base.transform.rotation = this.player.transform.rotation * Quaternion.Euler(0f, (float)this.lookBehind, 0f);
		}
		else if (this.ps.gameOver)
		{
			base.transform.position = this.baldi.transform.position + this.baldi.transform.forward * 2f + new Vector3(0f, 5f, 0f);
			base.transform.LookAt(new Vector3(this.baldi.position.x, this.baldi.position.y + 5f, this.baldi.position.z));
		}
		else if (this.ps.jumpRope)
		{
			base.transform.position = this.player.transform.position + this.offset + this.jumpHeightV3;
			base.transform.rotation = this.player.transform.rotation;
		}
	}

	// Token: 0x040005D9 RID: 1497
	public GameObject player;

	// Token: 0x040005DA RID: 1498
	public PlayerScript ps;

	// Token: 0x040005DB RID: 1499
	public Transform baldi;

	// Token: 0x040005DC RID: 1500
	public float initVelocity;

	// Token: 0x040005DD RID: 1501
	public float velocity;

	// Token: 0x040005DE RID: 1502
	public float gravity;

	// Token: 0x040005DF RID: 1503
	private int lookBehind;

	// Token: 0x040005E0 RID: 1504
	public Vector3 offset;

	// Token: 0x040005E1 RID: 1505
	public float jumpHeight;

	// Token: 0x040005E2 RID: 1506
	public Vector3 jumpHeightV3;

	// Token: 0x040005E3 RID: 1507
	//private Player playerInput;
}
