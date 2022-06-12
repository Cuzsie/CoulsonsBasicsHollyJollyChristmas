using System;
using UnityEngine;

// Token: 0x0200000F RID: 15
public class DarkDoorScript : MonoBehaviour
{
	// Token: 0x06000034 RID: 52 RVA: 0x00002E34 File Offset: 0x00001234
	private void Update()
	{
		if (this.door.bDoorOpen)
		{
			this.mesh.material = this.lightDoo60;
		}
		else if (this.door.bDoorLocked)
		{
			this.mesh.material = this.lightDooLock;
		}
		else
		{
			this.mesh.material = this.lightDoo0;
		}
	}

	// Token: 0x0400003E RID: 62
	public SwingingDoorScript door;

	// Token: 0x0400003F RID: 63
	public Material lightDoo0;

	// Token: 0x04000040 RID: 64
	public Material lightDoo60;

	// Token: 0x04000041 RID: 65
	public Material lightDooLock;

	// Token: 0x04000042 RID: 66
	public MeshRenderer mesh;
}
