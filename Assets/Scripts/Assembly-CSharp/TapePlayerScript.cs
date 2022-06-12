using System;
using UnityEngine;

// Token: 0x020000E3 RID: 227
public class TapePlayerScript : MonoBehaviour
{
	// Token: 0x06000A1C RID: 2588 RVA: 0x0002807F File Offset: 0x0002647F
	private void Start()
	{
		this.audioDevice = base.GetComponent<AudioSource>();
	}

	// Token: 0x06000A1D RID: 2589 RVA: 0x00028090 File Offset: 0x00026490
	private void Update()
	{
		if (this.audioDevice.isPlaying & Time.timeScale == 0f)
		{
			this.audioDevice.Pause();
		}
		else if (Time.timeScale > 0f & this.baldi.antiHearingTime > 0f)
		{
			this.audioDevice.UnPause();
		}
	}

	// Token: 0x06000A1E RID: 2590 RVA: 0x000280F9 File Offset: 0x000264F9
	public void Play()
	{
		this.sprite.sprite = this.closedSprite;
		this.audioDevice.Play();
		this.baldi.ActivateAntiHearing(30f);
	}

	// Token: 0x04000771 RID: 1905
	public Sprite closedSprite;

	// Token: 0x04000772 RID: 1906
	public SpriteRenderer sprite;

	// Token: 0x04000773 RID: 1907
	public BaldiScript baldi;

	// Token: 0x04000774 RID: 1908
	private AudioSource audioDevice;
}
