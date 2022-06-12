using System;
//using Rewired;
using UnityEngine;

// Token: 0x02000014 RID: 20
public class EndlessNotebookScript : MonoBehaviour
{
	// Token: 0x06000042 RID: 66 RVA: 0x000030C6 File Offset: 0x000014C6
	private void Start()
	{
		//this.playerInput = ReInput.players.GetPlayer(0);
		this.gc = GameObject.Find("Game Controller").GetComponent<GameControllerScript>();
		this.player = GameObject.Find("Player").GetComponent<Transform>();
	}

	// Token: 0x06000043 RID: 67 RVA: 0x00003104 File Offset: 0x00001504
	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(new Vector3((float)(Screen.width / 2), (float)(Screen.height / 2), 0f));
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit) && (raycastHit.transform.tag == "Notebook" & Vector3.Distance(this.player.position, base.transform.position) < this.openingDistance))
			{
				base.gameObject.SetActive(false);
				this.gc.CollectNotebook();
				this.learningGame.SetActive(true);
			}
		}
	}

	// Token: 0x0400004B RID: 75
	public float openingDistance;

	// Token: 0x0400004C RID: 76
	public GameControllerScript gc;

	// Token: 0x0400004D RID: 77
	public Transform player;

	// Token: 0x0400004E RID: 78
	public GameObject learningGame;

	// Token: 0x0400004F RID: 79
	//private Player playerInput;
}
