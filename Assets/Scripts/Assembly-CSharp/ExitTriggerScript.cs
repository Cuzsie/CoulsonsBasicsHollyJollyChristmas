using System;
using UnityEngine;

// Token: 0x020000C6 RID: 198
public class ExitTriggerScript : MonoBehaviour
{
	// Token: 0x06000979 RID: 2425 RVA: 0x000223A0 File Offset: 0x000207A0
	private void OnTriggerEnter(Collider other)
	{
		if (this.gc.notebooks >= 7 & other.tag == "Player" & !this.gc.surpriseActive & this.gc.exitsReached == 3)
		{
			this.gc.Surprise();
		}
	}

	// Token: 0x0400061F RID: 1567
	public GameControllerScript gc;
}
