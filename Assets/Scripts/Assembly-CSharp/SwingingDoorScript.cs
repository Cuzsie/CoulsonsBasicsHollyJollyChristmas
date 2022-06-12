using System;
using UnityEngine;

// Token: 0x020000C2 RID: 194
public class SwingingDoorScript : MonoBehaviour
{
	// Token: 0x0600095C RID: 2396 RVA: 0x00021E7A File Offset: 0x0002027A
	private void Start()
	{
		this.myAudio = base.GetComponent<AudioSource>();
		this.bDoorLocked = true;
	}

	// Token: 0x0600095D RID: 2397 RVA: 0x00021E90 File Offset: 0x00020290
	private void Update()
	{
		if (!this.requirementMet & this.gc.notebooks >= 2)
		{
			this.requirementMet = true;
			this.UnlockDoor();
		}
		if (this.openTime > 0f)
		{
			this.openTime -= 1f * Time.deltaTime;
		}
		if (this.lockTime > 0f)
		{
			this.lockTime -= Time.deltaTime;
		}
		else if (this.bDoorLocked & this.requirementMet)
		{
			this.UnlockDoor();
		}
		if (this.openTime <= 0f & this.bDoorOpen & !this.bDoorLocked)
		{
			this.bDoorOpen = false;
			this.inside.material = this.closed;
			this.outside.material = this.closed;
		}
	}

	// Token: 0x0600095E RID: 2398 RVA: 0x00021F8C File Offset: 0x0002038C
	private void OnTriggerStay(Collider other)
	{
		if (!this.bDoorLocked)
		{
			this.bDoorOpen = true;
			this.inside.material = this.open;
			this.outside.material = this.open;
			this.openTime = 2f;
		}
	}

	// Token: 0x0600095F RID: 2399 RVA: 0x00021FD8 File Offset: 0x000203D8
	private void OnTriggerEnter(Collider other)
	{
		if (!(this.gc.notebooks < 2 & other.tag == "Player"))
		{
			if (!this.bDoorLocked)
			{
				this.myAudio.PlayOneShot(this.doorOpen, 1f);
				if (other.tag == "Player" && this.baldi.isActiveAndEnabled)
				{
					this.baldi.Hear(base.transform.position, 1f);
				}
			}
		}
	}

	// Token: 0x06000960 RID: 2400 RVA: 0x00022070 File Offset: 0x00020470
	public void LockDoor(float time)
	{
		this.barrier.enabled = true;
		this.obstacle.SetActive(true);
		this.bDoorLocked = true;
		this.lockTime = time;
		this.inside.material = this.locked;
		this.outside.material = this.locked;
	}

	// Token: 0x06000961 RID: 2401 RVA: 0x000220C8 File Offset: 0x000204C8
	private void UnlockDoor()
	{
		this.barrier.enabled = false;
		this.obstacle.SetActive(false);
		this.bDoorLocked = false;
		this.inside.material = this.closed;
		this.outside.material = this.closed;
	}

	// Token: 0x04000602 RID: 1538
	public GameControllerScript gc;

	// Token: 0x04000603 RID: 1539
	public BaldiScript baldi;

	// Token: 0x04000604 RID: 1540
	public MeshCollider barrier;

	// Token: 0x04000605 RID: 1541
	public GameObject obstacle;

	// Token: 0x04000606 RID: 1542
	public MeshCollider trigger;

	// Token: 0x04000607 RID: 1543
	public MeshRenderer inside;

	// Token: 0x04000608 RID: 1544
	public MeshRenderer outside;

	// Token: 0x04000609 RID: 1545
	public Material closed;

	// Token: 0x0400060A RID: 1546
	public Material open;

	// Token: 0x0400060B RID: 1547
	public Material locked;

	// Token: 0x0400060C RID: 1548
	public AudioClip doorOpen;

	// Token: 0x0400060D RID: 1549
	public AudioClip baldiDoor;

	// Token: 0x0400060E RID: 1550
	private float openTime;

	// Token: 0x0400060F RID: 1551
	private float lockTime;

	// Token: 0x04000610 RID: 1552
	public bool bDoorOpen;

	// Token: 0x04000611 RID: 1553
	public bool bDoorLocked;

	// Token: 0x04000612 RID: 1554
	private bool requirementMet;

	// Token: 0x04000613 RID: 1555
	private AudioSource myAudio;
}
