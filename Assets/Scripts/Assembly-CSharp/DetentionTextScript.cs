using System;
//using TMPro;
using UnityEngine.UI;
using UnityEngine;

// Token: 0x02000013 RID: 19
public class DetentionTextScript : MonoBehaviour
{
	// Token: 0x0600003F RID: 63 RVA: 0x00003048 File Offset: 0x00001448
	private void Start()
	{
		this.text = base.GetComponent<Text>();
	}

	// Token: 0x06000040 RID: 64 RVA: 0x00003058 File Offset: 0x00001458
	private void Update()
	{
		if (this.door.lockTime > 0f)
		{
			this.text.text = "You have detention! \n" + Mathf.CeilToInt(this.door.lockTime) + " seconds remain!";
		}
		else
		{
			this.text.text = string.Empty;
		}
	}

	// Token: 0x04000049 RID: 73
	public DoorScript door;

	// Token: 0x0400004A RID: 74
	private Text text;
}
