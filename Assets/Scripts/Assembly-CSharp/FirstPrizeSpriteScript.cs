using System;
using UnityEngine;

// Token: 0x020000D3 RID: 211
public class FirstPrizeSpriteScript : MonoBehaviour
{
	// Token: 0x060009D7 RID: 2519 RVA: 0x00025FFD File Offset: 0x000243FD
	private void Start()
	{
		this.sprite = base.GetComponent<SpriteRenderer>();
	}

	// Token: 0x060009D8 RID: 2520 RVA: 0x0002600C File Offset: 0x0002440C
	private void Update()
	{
		this.angleF = Mathf.Atan2(this.cam.position.z - this.body.position.z, this.cam.position.x - this.body.position.x) * 57.29578f;
		if (this.angleF < 0f)
		{
			this.angleF += 360f;
		}
		this.debug = this.body.eulerAngles.y;
		this.angleF += this.body.eulerAngles.y;
		this.angle = Mathf.RoundToInt(this.angleF / 22.5f);
		while (this.angle < 0 || this.angle >= 16)
		{
			this.angle += (int)(-16f * Mathf.Sign((float)this.angle));
		}
		this.sprite.sprite = this.sprites[this.angle];
	}

	// Token: 0x040006EE RID: 1774
	public float debug;

	// Token: 0x040006EF RID: 1775
	public int angle;

	// Token: 0x040006F0 RID: 1776
	public float angleF;

	// Token: 0x040006F1 RID: 1777
	private SpriteRenderer sprite;

	// Token: 0x040006F2 RID: 1778
	public Transform cam;

	// Token: 0x040006F3 RID: 1779
	public Transform body;

	// Token: 0x040006F4 RID: 1780
	public Sprite[] sprites = new Sprite[16];
}
