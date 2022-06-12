using System;
using UnityEngine;

// Token: 0x0200000C RID: 12
public class ButtonManager : MonoBehaviour
{
	// Token: 0x0600002B RID: 43 RVA: 0x00002C3C File Offset: 0x0000103C
	public void Check()
	{
		if (this.b0.val == 2 && this.b1.val == 0 && this.b2.val == 1 && this.b3.val == 6)
		{
			this.wallToRemove.SetActive(false);
			this.aud.Play();
		}
	}

	// Token: 0x04000035 RID: 53
	public ButtonController b0;

	// Token: 0x04000036 RID: 54
	public ButtonController b1;

	// Token: 0x04000037 RID: 55
	public ButtonController b2;

	// Token: 0x04000038 RID: 56
	public ButtonController b3;

	// Token: 0x04000039 RID: 57
	public GameObject wallToRemove;

	// Token: 0x0400003A RID: 58
	public AudioSource aud;
}
