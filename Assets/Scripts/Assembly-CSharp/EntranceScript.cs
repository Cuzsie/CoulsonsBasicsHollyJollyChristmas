using System;
using UnityEngine;

// Token: 0x020000C4 RID: 196
public class EntranceScript : MonoBehaviour
{
	// Token: 0x06000974 RID: 2420 RVA: 0x000222F8 File Offset: 0x000206F8
	public void Lower()
	{
		base.transform.position = base.transform.position - new Vector3(0f, 10f, 0f);
		if (this.gc.finaleMode)
		{
			this.wall.material = this.map;
		}
	}

	// Token: 0x06000975 RID: 2421 RVA: 0x00022355 File Offset: 0x00020755
	public void Raise()
	{
		base.transform.position = base.transform.position + new Vector3(0f, 10f, 0f);
	}

	// Token: 0x0400061C RID: 1564
	public GameControllerScript gc;

	// Token: 0x0400061D RID: 1565
	public Material map;

	// Token: 0x0400061E RID: 1566
	public MeshRenderer wall;
}
