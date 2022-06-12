using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200001A RID: 26
public class ItemScrambler : MonoBehaviour
{
	// Token: 0x0600005B RID: 91 RVA: 0x00003A28 File Offset: 0x00001E28
	private void Start()
	{
		List<Vector3> list = new List<Vector3>();
		foreach (PickupScript pickupScript in this.items)
		{
			list.Add(pickupScript.transform.position);
		}
		foreach (PickupScript pickupScript2 in this.items)
		{
			int index = UnityEngine.Random.Range(0, list.Count);
			pickupScript2.transform.position = list[index];
			list.RemoveAt(index);
		}
	}

	// Token: 0x04000076 RID: 118
	public PickupScript[] items;
}
