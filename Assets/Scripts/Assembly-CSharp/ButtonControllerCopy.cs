using System;
//using Rewired;
using UnityEngine;

// Token: 0x0200000B RID: 11
public class ButtonControllerCopy : MonoBehaviour
{
	// Token: 0x06000027 RID: 39 RVA: 0x00002AFC File Offset: 0x00000EFC
	private void Start()
	{
		Debug.Log("What the heck?");
		//this.playerInput = ReInput.players.GetPlayer(0);
	}

	// Token: 0x06000028 RID: 40 RVA: 0x00002B1C File Offset: 0x00000F1C
	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && Time.timeScale != 0f)
		{
			Debug.Log("TEST");
			Ray ray = Camera.main.ScreenPointToRay(new Vector3((float)(Screen.width / 2), (float)(Screen.height / 2), 0f));
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit))
			{
				Debug.Log(raycastHit.transform.name);
				if (raycastHit.transform.name == "ButtonController" & Vector3.Distance(this.player.position, base.transform.position) < 15f)
				{
					this.Push();
				}
			}
		}
	}

	// Token: 0x06000029 RID: 41 RVA: 0x00002BE0 File Offset: 0x00000FE0
	private void Push()
	{
		Debug.Log("Click");
		this.val++;
		if (this.val > 9)
		{
			this.val = 0;
		}
		this.wall.sharedMaterials[1] = this.numbers[this.val];
	}

	// Token: 0x04000030 RID: 48
	public MeshRenderer wall;

	// Token: 0x04000031 RID: 49
	public int val;

	// Token: 0x04000032 RID: 50
	public Material[] numbers;

	// Token: 0x04000033 RID: 51
	//private Player playerInput;

	// Token: 0x04000034 RID: 52
	[SerializeField]
	private Transform player;
}
