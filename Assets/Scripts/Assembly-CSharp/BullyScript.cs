using System;
using UnityEngine;

// Token: 0x02000009 RID: 9
public class BullyScript : MonoBehaviour
{
	// Token: 0x0600001B RID: 27 RVA: 0x0000256A File Offset: 0x0000096A
	private void Start()
	{
		this.audioDevice = base.GetComponent<AudioSource>();
		this.waitTime = UnityEngine.Random.Range(60f, 120f);
	}

	// Token: 0x0600001C RID: 28 RVA: 0x00002590 File Offset: 0x00000990
	private void Update()
	{
		if (this.waitTime > 0f)
		{
			this.waitTime -= Time.deltaTime;
		}
		else if (!this.active)
		{
			this.Activate();
		}
		if (this.active)
		{
			this.activeTime += Time.deltaTime;
			if (this.activeTime >= 180f & (base.transform.position - this.player.position).magnitude >= 120f)
			{
				this.Reset();
			}
		}
		if (this.guilt > 0f)
		{
			this.guilt -= Time.deltaTime;
		}
	}

	// Token: 0x0600001D RID: 29 RVA: 0x00002660 File Offset: 0x00000A60
	private void FixedUpdate()
	{
		Vector3 direction = this.player.position - base.transform.position;
		RaycastHit raycastHit;
		if (Physics.Raycast(base.transform.position + new Vector3(0f, 4f, 0f), direction, out raycastHit, float.PositiveInfinity, 769, QueryTriggerInteraction.Ignore) && (raycastHit.transform.tag == "Player" & (base.transform.position - this.player.position).magnitude <= 30f & this.active))
		{
			if (!this.spoken)
			{
				int num = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 1f));
				this.audioDevice.PlayOneShot(this.aud_Taunts[num]);
				this.spoken = true;
			}
			this.guilt = 10f;
		}
	}

	// Token: 0x0600001E RID: 30 RVA: 0x00002760 File Offset: 0x00000B60
	private void Activate()
	{
		this.wanderer.GetNewTargetHallway();
		base.transform.position = this.wanderTarget.position + new Vector3(0f, 5f, 0f);
		while ((base.transform.position - this.player.position).magnitude < 20f)
		{
			this.wanderer.GetNewTargetHallway();
			base.transform.position = this.wanderTarget.position + new Vector3(0f, 5f, 0f);
		}
		this.active = true;
	}

	// Token: 0x0600001F RID: 31 RVA: 0x0000281C File Offset: 0x00000C1C
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Player")
		{
			if (this.gc.item[0] == 0 & this.gc.item[1] == 0 & this.gc.item[2] == 0)
			{
				this.audioDevice.PlayOneShot(this.aud_Denied);
			}
			else
			{
				int num = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 2f));
				while (this.gc.item[num] == 0)
				{
					num = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 2f));
				}
				this.gc.LoseItem(num);
				int num2 = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 1f));
				this.audioDevice.PlayOneShot(this.aud_Thanks[num2]);
				this.Reset();
			}
		}
	}

	// Token: 0x06000020 RID: 32 RVA: 0x0000290B File Offset: 0x00000D0B
	private void OnTriggerStay(Collider other)
	{
		if (other.transform.name == "Principal of the Thing" & this.guilt > 0f)
		{
			this.Reset();
		}
	}

	// Token: 0x06000021 RID: 33 RVA: 0x0000293C File Offset: 0x00000D3C
	private void Reset()
	{
		base.transform.position = base.transform.position - new Vector3(0f, 20f, 0f);
		this.waitTime = UnityEngine.Random.Range(60f, 120f);
		this.active = false;
		this.activeTime = 0f;
		this.spoken = false;
	}

	// Token: 0x0400001A RID: 26
	public Transform player;

	// Token: 0x0400001B RID: 27
	public GameControllerScript gc;

	// Token: 0x0400001C RID: 28
	public Renderer bullyRenderer;

	// Token: 0x0400001D RID: 29
	public Transform wanderTarget;

	// Token: 0x0400001E RID: 30
	public AILocationSelectorScript wanderer;

	// Token: 0x0400001F RID: 31
	public float waitTime;

	// Token: 0x04000020 RID: 32
	public float activeTime;

	// Token: 0x04000021 RID: 33
	public float guilt;

	// Token: 0x04000022 RID: 34
	public bool active;

	// Token: 0x04000023 RID: 35
	public bool spoken;

	// Token: 0x04000024 RID: 36
	private AudioSource audioDevice;

	// Token: 0x04000025 RID: 37
	public AudioClip[] aud_Taunts = new AudioClip[2];

	// Token: 0x04000026 RID: 38
	public AudioClip[] aud_Thanks = new AudioClip[2];

	// Token: 0x04000027 RID: 39
	public AudioClip aud_Denied;
}
