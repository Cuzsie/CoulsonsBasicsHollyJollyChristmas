using System;
using UnityEngine;

// Token: 0x020000BF RID: 191
public class CraftersTriggerScript : MonoBehaviour
{
	// Token: 0x0600094E RID: 2382 RVA: 0x00021AEB File Offset: 0x0001FEEB
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.crafters.GiveLocation(this.goTarget.position, false);
		}
	}

	// Token: 0x0600094F RID: 2383 RVA: 0x00021B19 File Offset: 0x0001FF19
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.crafters.GiveLocation(this.fleeTarget.position, true);
		}
	}

	// Token: 0x040005E9 RID: 1513
	public Transform goTarget;

	// Token: 0x040005EA RID: 1514
	public Transform fleeTarget;

	// Token: 0x040005EB RID: 1515
	public CraftersScript crafters;
}
