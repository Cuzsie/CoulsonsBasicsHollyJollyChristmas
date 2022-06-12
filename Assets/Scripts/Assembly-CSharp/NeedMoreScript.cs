using System;
using UnityEngine;

// Token: 0x020000C1 RID: 193
public class NeedMoreScript : MonoBehaviour
{
	// Token: 0x0600095A RID: 2394 RVA: 0x00021E36 File Offset: 0x00020236
	private void OnTriggerEnter(Collider other)
	{
		if (this.gc.notebooks < 2 & other.tag == "Player")
		{
			this.audioDevice.PlayOneShot(this.baldiDoor, 1f);
		}
	}

	// Token: 0x040005FF RID: 1535
	public GameControllerScript gc;

	// Token: 0x04000600 RID: 1536
	public AudioSource audioDevice;

	// Token: 0x04000601 RID: 1537
	public AudioClip baldiDoor;
}
