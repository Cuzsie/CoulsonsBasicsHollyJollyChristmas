using System;
//using Rewired;
using UnityEngine;

// Token: 0x020000C0 RID: 192
public class DoorScript : MonoBehaviour
{
	// Token: 0x06000951 RID: 2385 RVA: 0x00021B4F File Offset: 0x0001FF4F
	private void Start()
	{
		//this.playerInput = ReInput.players.GetPlayer(0);
		this.myAudio = base.GetComponent<AudioSource>();
	}

	// Token: 0x06000952 RID: 2386 RVA: 0x00021B70 File Offset: 0x0001FF70
	private void Update()
	{
		if (this.lockTime > 0f)
		{
			this.lockTime -= 1f * Time.deltaTime;
		}
		else if (this.bDoorLocked)
		{
			this.UnlockDoor();
		}
		if (this.openTime > 0f)
		{
			this.openTime -= 1f * Time.deltaTime;
		}
		if (this.openTime <= 0f & this.bDoorOpen)
		{
			this.barrier.enabled = true;
			this.invisibleBarrier.enabled = true;
			this.bDoorOpen = false;
			this.inside.material = this.closed;
			this.outside.material = this.closed;
			if (this.silentOpens <= 0)
			{
				this.myAudio.PlayOneShot(this.doorClose, 1f);
			}
		}
		if (Input.GetMouseButtonDown(0) && Time.timeScale != 0f)
		{
			Ray ray = Camera.main.ScreenPointToRay(new Vector3((float)(Screen.width / 2), (float)(Screen.height / 2), 0f));
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit) && (raycastHit.collider == this.trigger & Vector3.Distance(this.player.position, base.transform.position) < this.openingDistance & !this.bDoorLocked))
			{
				if (this.baldi.isActiveAndEnabled & this.silentOpens <= 0)
				{
					this.baldi.Hear(base.transform.position, 1f);
				}
				this.OpenDoor();
				if (this.silentOpens > 0)
				{
					this.silentOpens--;
				}
			}
		}
	}

	// Token: 0x06000953 RID: 2387 RVA: 0x00021D5C File Offset: 0x0002015C
	public void OpenDoor()
	{
		if (this.silentOpens <= 0 && !this.bDoorOpen)
		{
			this.myAudio.PlayOneShot(this.doorOpen, 1f);
		}
		this.barrier.enabled = false;
		this.invisibleBarrier.enabled = false;
		this.bDoorOpen = true;
		this.inside.material = this.open;
		this.outside.material = this.open;
		this.openTime = 3f;
	}

	// Token: 0x06000954 RID: 2388 RVA: 0x00021DE2 File Offset: 0x000201E2
	private void OnTriggerStay(Collider other)
	{
		if (!this.bDoorLocked & other.CompareTag("NPC"))
		{
			this.OpenDoor();
		}
	}

	// Token: 0x06000955 RID: 2389 RVA: 0x00021E04 File Offset: 0x00020204
	public void LockDoor(float time)
	{
		this.bDoorLocked = true;
		this.lockTime = time;
	}

	// Token: 0x06000956 RID: 2390 RVA: 0x00021E14 File Offset: 0x00020214
	public void UnlockDoor()
	{
		this.bDoorLocked = false;
	}

	// Token: 0x17000396 RID: 918
	// (get) Token: 0x06000957 RID: 2391 RVA: 0x00021E1D File Offset: 0x0002021D
	public bool DoorLocked
	{
		get
		{
			return this.bDoorLocked;
		}
	}

	// Token: 0x06000958 RID: 2392 RVA: 0x00021E25 File Offset: 0x00020225
	public void SilenceDoor()
	{
		this.silentOpens = 4;
	}

	// Token: 0x040005EC RID: 1516
	public float openingDistance;

	// Token: 0x040005ED RID: 1517
	public Transform player;

	// Token: 0x040005EE RID: 1518
	public BaldiScript baldi;

	// Token: 0x040005EF RID: 1519
	public MeshCollider barrier;

	// Token: 0x040005F0 RID: 1520
	public MeshCollider trigger;

	// Token: 0x040005F1 RID: 1521
	public MeshCollider invisibleBarrier;

	// Token: 0x040005F2 RID: 1522
	public MeshRenderer inside;

	// Token: 0x040005F3 RID: 1523
	public MeshRenderer outside;

	// Token: 0x040005F4 RID: 1524
	public AudioClip doorOpen;

	// Token: 0x040005F5 RID: 1525
	public AudioClip doorClose;

	// Token: 0x040005F6 RID: 1526
	public Material closed;

	// Token: 0x040005F7 RID: 1527
	public Material open;

	// Token: 0x040005F8 RID: 1528
	private bool bDoorOpen;

	// Token: 0x040005F9 RID: 1529
	private bool bDoorLocked;

	// Token: 0x040005FA RID: 1530
	public int silentOpens;

	// Token: 0x040005FB RID: 1531
	private float openTime;

	// Token: 0x040005FC RID: 1532
	public float lockTime;

	// Token: 0x040005FD RID: 1533
	private AudioSource myAudio;

	// Token: 0x040005FE RID: 1534
	//private Player playerInput;
}
