using System;
using UnityEngine;

// Token: 0x020000B8 RID: 184
public class Script : MonoBehaviour
{
	// Token: 0x06000933 RID: 2355 RVA: 0x000214A5 File Offset: 0x0001F8A5
	private void Start()
	{
	}

	// Token: 0x06000934 RID: 2356 RVA: 0x000214A7 File Offset: 0x0001F8A7
	private void Update()
	{
		if (!this.audioDevice.isPlaying & this.played)
		{
			Application.Quit();
		}
	}

	// Token: 0x06000935 RID: 2357 RVA: 0x000214CB File Offset: 0x0001F8CB
	private void OnTriggerEnter(Collider other)
	{
		if (other.name == "Player" & !this.played)
		{
			this.audioDevice.Play();
			this.played = true;
		}
	}

	// Token: 0x040005D0 RID: 1488
	public AudioSource audioDevice;

	// Token: 0x040005D1 RID: 1489
	private bool played;
}
