using System;
//using Rewired;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020000DB RID: 219
public class WarningScreenScript : MonoBehaviour
{
	// Token: 0x06000A03 RID: 2563 RVA: 0x00027967 File Offset: 0x00025D67
	private void Start()
	{
		//this.player = ReInput.players.GetPlayer(0);
	}

	// Token: 0x06000A04 RID: 2564 RVA: 0x0002797A File Offset: 0x00025D7A
	private void Update()
	{
		if (Input.anyKeyDown)
		{
			SceneManager.LoadScene("MainMenu");
		}
	}

	// Token: 0x04000756 RID: 1878
	//public Player player;
}
