using System;
//using Rewired;
using UnityEngine;

// Token: 0x020000D6 RID: 214
public class PickupScript : MonoBehaviour
{
	// Token: 0x060009E7 RID: 2535 RVA: 0x00026803 File Offset: 0x00024C03
	private void Start()
	{
		//this.playerInput = ReInput.players.GetPlayer(0);
	}

	// Token: 0x060009E8 RID: 2536 RVA: 0x00026818 File Offset: 0x00024C18
	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && Time.timeScale != 0f)
		{
			Ray ray = Camera.main.ScreenPointToRay(new Vector3((float)(Screen.width / 2), (float)(Screen.height / 2), 0f));
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit))
			{
				if (raycastHit.transform.name == "Pickup_EnergyFlavoredZestyBar" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
				{
					raycastHit.transform.gameObject.SetActive(false);
					this.gc.CollectItem(1);
				}
				else if (raycastHit.transform.name == "Pickup_YellowDoorLock" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
				{
					raycastHit.transform.gameObject.SetActive(false);
					this.gc.CollectItem(2);
				}
				else if (raycastHit.transform.name == "Pickup_Key" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
				{
					raycastHit.transform.gameObject.SetActive(false);
					this.gc.CollectItem(3);
				}
				else if (raycastHit.transform.name == "Pickup_BSODA" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
				{
					raycastHit.transform.gameObject.SetActive(false);
					this.gc.CollectItem(4);
				}
				else if (raycastHit.transform.name == "Pickup_Quarter" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
				{
					raycastHit.transform.gameObject.SetActive(false);
					this.gc.CollectItem(5);
				}
				else if (raycastHit.transform.name == "Pickup_Tape" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
				{
					raycastHit.transform.gameObject.SetActive(false);
					this.gc.CollectItem(6);
				}
				else if (raycastHit.transform.name == "Pickup_AlarmClock" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
				{
					raycastHit.transform.gameObject.SetActive(false);
					this.gc.CollectItem(7);
				}
				else if (raycastHit.transform.name == "Pickup_WD-3D" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
				{
					raycastHit.transform.gameObject.SetActive(false);
					this.gc.CollectItem(8);
				}
				else if (raycastHit.transform.name == "Pickup_SafetyScissors" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
				{
					raycastHit.transform.gameObject.SetActive(false);
					this.gc.CollectItem(9);
				}
				else if (raycastHit.transform.name == "Pickup_HeavyBoots" & Vector3.Distance(this.player.position, base.transform.position) < 10f)
				{
					raycastHit.transform.gameObject.SetActive(false);
					this.gc.CollectItem(10);
				}
			}
		}
	}

	// Token: 0x04000718 RID: 1816
	public GameControllerScript gc;

	// Token: 0x04000719 RID: 1817
	public Transform player;

	// Token: 0x0400071A RID: 1818
	//private Player playerInput;
}
