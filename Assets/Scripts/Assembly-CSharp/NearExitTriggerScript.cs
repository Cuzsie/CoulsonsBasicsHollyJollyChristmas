using System;
using UnityEngine;

// Token: 0x020000CC RID: 204
public class NearExitTriggerScript : MonoBehaviour
{
	// Token: 0x060009B3 RID: 2483 RVA: 0x00025444 File Offset: 0x00023844
	private void OnTriggerEnter(Collider other)
	{
		if (this.gc.exitsReached < 3 & this.gc.finaleMode & other.tag == "Player")
		{
			this.gc.ExitReached();
			this.es.Lower();
			this.gc.baldiScrpt.Hear(base.transform.position, 8f);
		}
	}

	// Token: 0x040006B0 RID: 1712
	public GameControllerScript gc;

	// Token: 0x040006B1 RID: 1713
	public EntranceScript es;
}
