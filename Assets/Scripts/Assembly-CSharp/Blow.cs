using System;
//using Rewired;
using UnityEngine;

// Token: 0x02000007 RID: 7
public class Blow : MonoBehaviour
{
	// Token: 0x06000013 RID: 19 RVA: 0x0000232A File Offset: 0x0000072A
	private void Start()
	{
		//this.playerInput = ReInput.players.GetPlayer(0);
	}

	// Token: 0x06000014 RID: 20 RVA: 0x00002340 File Offset: 0x00000740
	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && Time.timeScale != 0f)
		{
			Ray ray = Camera.main.ScreenPointToRay(new Vector3((float)(Screen.width / 2), (float)(Screen.height / 2), 0f));
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit) && (raycastHit.transform.name == "BlowSphere" & Vector3.Distance(this.player.position, base.transform.position) < 15f))
			{
				this.gc.Glitch();
				foreach (GameObject obj in this.objectsToDestroy)
				{
					UnityEngine.Object.Destroy(obj);
				}
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}

	// Token: 0x04000012 RID: 18
	[SerializeField]
	private Transform player;

	// Token: 0x04000013 RID: 19
	[SerializeField]
	private GameControllerScript gc;

	// Token: 0x04000014 RID: 20
	//private Player playerInput;

	// Token: 0x04000015 RID: 21
	[SerializeField]
	private GameObject[] objectsToDestroy;
}
