using System;
//using Rewired;
using UnityEngine;

// Token: 0x0200000A RID: 10
public class ButtonController : MonoBehaviour
{
	// Token: 0x06000023 RID: 35 RVA: 0x000029BA File Offset: 0x00000DBA
	private void Start()
	{
		//this.playerInput = ReInput.players.GetPlayer(0);
	}

	// Token: 0x06000024 RID: 36 RVA: 0x000029D0 File Offset: 0x00000DD0
	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && Time.timeScale != 0f)
		{
			Ray ray = Camera.main.ScreenPointToRay(new Vector3((float)(Screen.width / 2), (float)(Screen.height / 2), 0f));
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit) && (raycastHit.transform == base.transform & Vector3.Distance(this.player.position, base.transform.position) < 15f))
			{
				this.Push();
			}
		}
	}

	// Token: 0x06000025 RID: 37 RVA: 0x00002A74 File Offset: 0x00000E74
	private void Push()
	{
		this.aud.Play();
		this.val++;
		if (this.val > 9)
		{
			this.val = 0;
		}
		this._wallMat[0] = this.wall.sharedMaterials[0];
		this._wallMat[1] = this.numbers[this.val];
		this.wall.sharedMaterials = this._wallMat;
		this.man.Check();
	}

	// Token: 0x04000028 RID: 40
	public MeshRenderer wall;

	// Token: 0x04000029 RID: 41
	public int val;

	// Token: 0x0400002A RID: 42
	public Material[] numbers;

	// Token: 0x0400002B RID: 43
	private Material[] _wallMat = new Material[2];

	// Token: 0x0400002C RID: 44
	//private Player playerInput;

	// Token: 0x0400002D RID: 45
	[SerializeField]
	private Transform player;

	// Token: 0x0400002E RID: 46
	public AudioSource aud;

	// Token: 0x0400002F RID: 47
	public ButtonManager man;
}
