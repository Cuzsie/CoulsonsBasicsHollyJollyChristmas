using System;
using UnityEngine;

// Token: 0x020000CF RID: 207
public class AILocationSelectorScript : MonoBehaviour
{
	// Token: 0x060009BD RID: 2493 RVA: 0x00025638 File Offset: 0x00023A38
	public void GetNewTarget()
	{
		this.id = UnityEngine.Random.Range(0, 29);
		while (this.id == this.previousId)
		{
			this.id = UnityEngine.Random.Range(0, 29);
		}
		base.transform.position = this.newLocation[this.id].position;
		this.ambience.PlayAudio();
		this.previousId = this.id;
	}

	// Token: 0x060009BE RID: 2494 RVA: 0x000256AC File Offset: 0x00023AAC
	public void GetNewTargetHallway()
	{
		this.id = UnityEngine.Random.Range(0, 16);
		while (this.id == this.previousId)
		{
			this.id = UnityEngine.Random.Range(0, 16);
		}
		base.transform.position = this.newLocation[this.id].position;
		this.ambience.PlayAudio();
		this.previousId = this.id;
	}

	// Token: 0x060009BF RID: 2495 RVA: 0x0002571F File Offset: 0x00023B1F
	public void QuarterExclusive()
	{
		this.id = Mathf.RoundToInt(UnityEngine.Random.Range(1f, 15f));
		base.transform.position = this.newLocation[this.id].position;
	}

	// Token: 0x040006B8 RID: 1720
	public Transform[] newLocation = new Transform[29];

	// Token: 0x040006B9 RID: 1721
	public AmbienceScript ambience;

	// Token: 0x040006BA RID: 1722
	private int id;

	// Token: 0x040006BB RID: 1723
	private int previousId;
}
