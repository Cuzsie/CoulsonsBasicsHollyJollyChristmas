using System;
using UnityEngine;

// Token: 0x020000B9 RID: 185
public class AudioQueueScript : MonoBehaviour
{
	// Token: 0x06000937 RID: 2359 RVA: 0x00021513 File Offset: 0x0001F913
	private void Start()
	{
		this.audioDevice = base.GetComponent<AudioSource>();
	}

	// Token: 0x06000938 RID: 2360 RVA: 0x00021521 File Offset: 0x0001F921
	private void Update()
	{
		if (!this.audioDevice.isPlaying && this.audioInQueue > 0)
		{
			this.PlayQueue();
		}
	}

	// Token: 0x06000939 RID: 2361 RVA: 0x00021545 File Offset: 0x0001F945
	public void QueueAudio(AudioClip sound)
	{
		this.audioQueue[this.audioInQueue] = sound;
		this.audioInQueue++;
	}

	// Token: 0x0600093A RID: 2362 RVA: 0x00021563 File Offset: 0x0001F963
	private void PlayQueue()
	{
		this.audioDevice.PlayOneShot(this.audioQueue[0]);
		this.UnqueueAudio();
	}

	// Token: 0x0600093B RID: 2363 RVA: 0x00021580 File Offset: 0x0001F980
	private void UnqueueAudio()
	{
		for (int i = 1; i < this.audioInQueue; i++)
		{
			this.audioQueue[i - 1] = this.audioQueue[i];
		}
		this.audioInQueue--;
	}

	// Token: 0x0600093C RID: 2364 RVA: 0x000215C4 File Offset: 0x0001F9C4
	public void ClearAudioQueue()
	{
		this.audioInQueue = 0;
	}

	// Token: 0x040005D2 RID: 1490
	private AudioSource audioDevice;

	// Token: 0x040005D3 RID: 1491
	private int audioInQueue;

	// Token: 0x040005D4 RID: 1492
	private AudioClip[] audioQueue = new AudioClip[100];
}
