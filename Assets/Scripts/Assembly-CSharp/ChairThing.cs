using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200000D RID: 13
public class ChairThing : MonoBehaviour
{
	// Token: 0x0600002D RID: 45 RVA: 0x00002CAC File Offset: 0x000010AC
	private void Start()
	{
		this.init = this.check.transform.position;
		base.StartCoroutine(this.Checker());
	}

	// Token: 0x0600002E RID: 46 RVA: 0x00002CD4 File Offset: 0x000010D4
	private IEnumerator Checker()
	{
		while (this.check.transform.position == this.init)
		{
			yield return null;
		}
		foreach (Transform transform in this.opbjects)
		{
			transform.position = base.transform.position;
		}
		yield break;
	}

	// Token: 0x0400003B RID: 59
	public GameObject check;

	// Token: 0x0400003C RID: 60
	public Transform[] opbjects;

	// Token: 0x0400003D RID: 61
	private Vector3 init;
}
