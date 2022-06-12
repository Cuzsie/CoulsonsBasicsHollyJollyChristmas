using System;
//using TMPro;
using UnityEngine.UI;
using UnityEngine;

// Token: 0x0200001B RID: 27
public class JumpRopeScript : MonoBehaviour
{
	// Token: 0x0600005D RID: 93 RVA: 0x00003AC8 File Offset: 0x00001EC8
	private void OnEnable()
	{
		this.jumpDelay = 1f;
		this.ropeHit = true;
		this.jumpStarted = false;
		this.jumps = 0;
		this.jumpCount.text = 0 + "/5";
		this.cs.jumpHeight = 0f;
		this.playtime.audioDevice.PlayOneShot(this.playtime.aud_ReadyGo);
	}

	// Token: 0x0600005E RID: 94 RVA: 0x00003B3C File Offset: 0x00001F3C
	private void Update()
	{
		if (this.jumpDelay > 0f)
		{
			this.jumpDelay -= Time.deltaTime;
		}
		else if (!this.jumpStarted)
		{
			this.jumpStarted = true;
			this.ropePosition = 1f;
			this.rope.SetTrigger("ActivateJumpRope");
			this.ropeHit = false;
		}
		if (this.ropePosition > 0f)
		{
			this.ropePosition -= Time.deltaTime;
		}
		else if (!this.ropeHit)
		{
			this.RopeHit();
		}
	}

	// Token: 0x0600005F RID: 95 RVA: 0x00003BDC File Offset: 0x00001FDC
	private void RopeHit()
	{
		this.ropeHit = true;
		if (this.cs.jumpHeight <= 0.2f)
		{
			this.Fail();
		}
		else
		{
			this.Success();
		}
		this.jumpStarted = false;
	}

	// Token: 0x06000060 RID: 96 RVA: 0x00003C14 File Offset: 0x00002014
	private void Success()
	{
		this.playtime.audioDevice.Stop();
		this.playtime.audioDevice.PlayOneShot(this.playtime.aud_Numbers[this.jumps]);
		this.jumps++;
		this.jumpCount.text = this.jumps + "/5";
		this.jumpDelay = 0.5f;
		if (this.jumps >= 5)
		{
			this.playtime.audioDevice.Stop();
			this.playtime.audioDevice.PlayOneShot(this.playtime.aud_Congrats);
			this.ps.DeactivateJumpRope();
		}
	}

	// Token: 0x06000061 RID: 97 RVA: 0x00003CD0 File Offset: 0x000020D0
	private void Fail()
	{
		this.jumps = 0;
		this.jumpCount.text = this.jumps + "/5";
		this.jumpDelay = 2f;
		this.playtime.audioDevice.PlayOneShot(this.playtime.aud_Oops);
	}

	// Token: 0x04000077 RID: 119
	public Text jumpCount;

	// Token: 0x04000078 RID: 120
	public Animator rope;

	// Token: 0x04000079 RID: 121
	public CameraScript cs;

	// Token: 0x0400007A RID: 122
	public PlayerScript ps;

	// Token: 0x0400007B RID: 123
	public PlaytimeScript playtime;

	// Token: 0x0400007C RID: 124
	public GameObject mobileIns;

	// Token: 0x0400007D RID: 125
	public int jumps;

	// Token: 0x0400007E RID: 126
	public float jumpDelay;

	// Token: 0x0400007F RID: 127
	public float ropePosition;

	// Token: 0x04000080 RID: 128
	public bool ropeHit;

	// Token: 0x04000081 RID: 129
	public bool jumpStarted;
}
