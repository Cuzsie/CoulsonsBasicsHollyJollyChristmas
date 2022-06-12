using System;
//using Rewired;
using UnityEngine;

// Token: 0x020000BE RID: 190
public class ClickableTest : MonoBehaviour
{
	// Token: 0x0600094B RID: 2379 RVA: 0x00021A55 File Offset: 0x0001FE55
	private void Start()
	{
		//this.playerInput = ReInput.players.GetPlayer(0);
	}

	// Token: 0x0600094C RID: 2380 RVA: 0x00021A68 File Offset: 0x0001FE68
	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(new Vector3((float)(Screen.width / 2), (float)(Screen.height / 2), 0f));
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit) && raycastHit.transform.name == "MathNotebook")
			{
				base.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x040005E8 RID: 1512
	//private Player playerInput;
}
