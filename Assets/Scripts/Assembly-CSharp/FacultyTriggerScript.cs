using System;
using UnityEngine;

// Token: 0x020000D2 RID: 210
public class FacultyTriggerScript : MonoBehaviour
{
	// Token: 0x060009D3 RID: 2515 RVA: 0x00025FAC File Offset: 0x000243AC
	private void Start()
	{
		this.hitBox = base.GetComponent<BoxCollider>();
	}

	// Token: 0x060009D4 RID: 2516 RVA: 0x00025FBA File Offset: 0x000243BA
	private void Update()
	{
	}

	// Token: 0x060009D5 RID: 2517 RVA: 0x00025FBC File Offset: 0x000243BC
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			this.ps.ResetGuilt("faculty", 1f);
		}
	}

	// Token: 0x040006EC RID: 1772
	public PlayerScript ps;

	// Token: 0x040006ED RID: 1773
	private BoxCollider hitBox;
}
