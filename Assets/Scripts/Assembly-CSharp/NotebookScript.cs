using System;
//using Rewired;
using UnityEngine;

// Token: 0x020000CA RID: 202
public class NotebookScript : MonoBehaviour
{
	// Token: 0x060009AD RID: 2477 RVA: 0x000251B7 File Offset: 0x000235B7
	private void Start()
	{
		//this.playerInput = ReInput.players.GetPlayer(0);
		this.up = true;
	}

	// Token: 0x060009AE RID: 2478 RVA: 0x000251D4 File Offset: 0x000235D4
	private void Update()
	{
		if (this.gc.mode == "endless")
		{
			if (this.respawnTime > 0f)
			{
				if ((base.transform.position - this.player.position).magnitude > 60f)
				{
					this.respawnTime -= Time.deltaTime;
				}
			}
			else if (!this.up)
			{
				base.transform.position = new Vector3(base.transform.position.x, 4f, base.transform.position.z);
				this.up = true;
				this.audioDevice.Play();
			}
		}
		if (Input.GetMouseButtonDown(0) && Time.timeScale != 0f)
		{
			Ray ray = Camera.main.ScreenPointToRay(new Vector3((float)(Screen.width / 2), (float)(Screen.height / 2), 0f));
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit) && (raycastHit.transform.tag == "Notebook" & Vector3.Distance(this.player.position, base.transform.position) < this.openingDistance))
			{
				base.transform.position = new Vector3(base.transform.position.x, -20f, base.transform.position.z);
				this.up = false;
				this.respawnTime = 120f;
				this.gc.CollectNotebook();
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.learningGame);
				gameObject.GetComponent<MathGameScript>().gc = this.gc;
				gameObject.GetComponent<MathGameScript>().baldiScript = this.bsc;
				gameObject.GetComponent<MathGameScript>().playerPosition = this.player.position;
			}
		}
	}

	// Token: 0x040006A6 RID: 1702
	public float openingDistance;

	// Token: 0x040006A7 RID: 1703
	public GameControllerScript gc;

	// Token: 0x040006A8 RID: 1704
	public BaldiScript bsc;

	// Token: 0x040006A9 RID: 1705
	public float respawnTime;

	// Token: 0x040006AA RID: 1706
	public bool up;

	// Token: 0x040006AB RID: 1707
	public Transform player;

	// Token: 0x040006AC RID: 1708
	public GameObject learningGame;

	// Token: 0x040006AD RID: 1709
	public AudioSource audioDevice;

	// Token: 0x040006AE RID: 1710
	//private Player playerInput;
}
