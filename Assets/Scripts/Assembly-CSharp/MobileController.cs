using System;
using UnityEngine;

// Token: 0x0200001D RID: 29
public class MobileController : MonoBehaviour
{
	// Token: 0x06000067 RID: 103 RVA: 0x00003DCD File Offset: 0x000021CD
	private void Start()
	{
		base.gameObject.SetActive(false);
	}

	// Token: 0x06000068 RID: 104 RVA: 0x00003DDB File Offset: 0x000021DB
	private void Update()
	{
		if (InputTypeManager.usingTouch)
		{
			if (!this.active)
			{
				this.ActivateMobileControls();
			}
		}
		else if (this.active)
		{
			this.DeactivateMobileControls();
		}
	}

	// Token: 0x06000069 RID: 105 RVA: 0x00003E0E File Offset: 0x0000220E
	private void ActivateMobileControls()
	{
		this.simpleControls.SetActive(true);
		this.active = true;
	}

	// Token: 0x0600006A RID: 106 RVA: 0x00003E23 File Offset: 0x00002223
	private void DeactivateMobileControls()
	{
		this.proControls.SetActive(false);
		this.simpleControls.SetActive(false);
		this.active = false;
	}

	// Token: 0x04000088 RID: 136
	public GameObject simpleControls;

	// Token: 0x04000089 RID: 137
	public GameObject proControls;

	// Token: 0x0400008A RID: 138
	private bool active;
}
