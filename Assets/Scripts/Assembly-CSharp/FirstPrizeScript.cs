using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x02000016 RID: 22
public class FirstPrizeScript : MonoBehaviour
{
	// Token: 0x06000047 RID: 71 RVA: 0x0000324F File Offset: 0x0000164F
	private void Start()
	{
		this.agent = base.GetComponent<NavMeshAgent>();
		this.coolDown = 1f;
		this.Wander();
	}

	// Token: 0x06000048 RID: 72 RVA: 0x00003270 File Offset: 0x00001670
	private void Update()
	{
		if (this.coolDown > 0f)
		{
			this.coolDown -= 1f * Time.deltaTime;
		}
		if (this.autoBrakeCool > 0f)
		{
			this.autoBrakeCool -= 1f * Time.deltaTime;
		}
		else
		{
			this.agent.autoBraking = true;
		}
		this.angleDiff = Mathf.DeltaAngle(base.transform.eulerAngles.y, Mathf.Atan2(this.agent.steeringTarget.x - base.transform.position.x, this.agent.steeringTarget.z - base.transform.position.z) * 57.29578f);
		if (this.crazyTime <= 0f)
		{
			if (Mathf.Abs(this.angleDiff) < 5f)
			{
				base.transform.LookAt(new Vector3(this.agent.steeringTarget.x, base.transform.position.y, this.agent.steeringTarget.z));
				this.agent.speed = this.currentSpeed;
			}
			else
			{
				base.transform.Rotate(new Vector3(0f, this.turnSpeed * Mathf.Sign(this.angleDiff) * Time.deltaTime, 0f));
				this.agent.speed = 0f;
			}
		}
		else
		{
			this.agent.speed = 0f;
			base.transform.Rotate(new Vector3(0f, 180f * Time.deltaTime, 0f));
			this.crazyTime -= Time.deltaTime;
		}
		this.motorAudio.pitch = (this.agent.velocity.magnitude + 1f) * Time.timeScale;
		if (this.prevSpeed - this.agent.velocity.magnitude > 15f)
		{
			this.audioDevice.PlayOneShot(this.audBang);
		}
		this.prevSpeed = this.agent.velocity.magnitude;
	}

	// Token: 0x06000049 RID: 73 RVA: 0x000034E8 File Offset: 0x000018E8
	private void FixedUpdate()
	{
		Vector3 direction = this.player.position - base.transform.position;
		RaycastHit raycastHit;
		if (Physics.Raycast(base.transform.position, direction, out raycastHit, float.PositiveInfinity, 769, QueryTriggerInteraction.Ignore) && raycastHit.transform.tag == "Player")
		{
			if (!this.playerSeen && !this.audioDevice.isPlaying)
			{
				int num = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 1f));
				this.audioDevice.PlayOneShot(this.aud_Found[num]);
			}
			this.playerSeen = true;
			this.TargetPlayer();
			this.currentSpeed = this.runSpeed;
		}
		else
		{
			this.currentSpeed = this.normSpeed;
			if (this.playerSeen & this.coolDown <= 0f)
			{
				if (!this.audioDevice.isPlaying)
				{
					int num2 = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 1f));
					this.audioDevice.PlayOneShot(this.aud_Lost[num2]);
				}
				this.playerSeen = false;
				this.Wander();
			}
			else if (this.agent.velocity.magnitude <= 1f & this.coolDown <= 0f & (base.transform.position - this.agent.destination).magnitude < 5f)
			{
				this.Wander();
			}
		}
	}

	// Token: 0x0600004A RID: 74 RVA: 0x0000368C File Offset: 0x00001A8C
	private void Wander()
	{
		this.wanderer.GetNewTargetHallway();
		this.agent.SetDestination(this.wanderTarget.position);
		this.hugAnnounced = false;
		int num = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 9f));
		if (!this.audioDevice.isPlaying & num == 0 & this.coolDown <= 0f)
		{
			int num2 = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 1f));
			this.audioDevice.PlayOneShot(this.aud_Random[num2]);
		}
		this.coolDown = 1f;
	}

	// Token: 0x0600004B RID: 75 RVA: 0x00003733 File Offset: 0x00001B33
	private void TargetPlayer()
	{
		this.agent.SetDestination(this.player.position);
		this.coolDown = 0.5f;
	}

	// Token: 0x0600004C RID: 76 RVA: 0x00003758 File Offset: 0x00001B58
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (!this.audioDevice.isPlaying & !this.hugAnnounced)
			{
				int num = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 1f));
				this.audioDevice.PlayOneShot(this.aud_Hug[num]);
				this.hugAnnounced = true;
			}
			this.agent.autoBraking = false;
		}
	}

	// Token: 0x0600004D RID: 77 RVA: 0x000037D2 File Offset: 0x00001BD2
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.autoBrakeCool = 1f;
		}
	}

	// Token: 0x0600004E RID: 78 RVA: 0x000037F4 File Offset: 0x00001BF4
	public void GoCrazy()
	{
		this.crazyTime = 15f;
	}

	// Token: 0x04000051 RID: 81
	public float debug;

	// Token: 0x04000052 RID: 82
	public float turnSpeed;

	// Token: 0x04000053 RID: 83
	public float str;

	// Token: 0x04000054 RID: 84
	public float angleDiff;

	// Token: 0x04000055 RID: 85
	public float normSpeed;

	// Token: 0x04000056 RID: 86
	public float runSpeed;

	// Token: 0x04000057 RID: 87
	public float currentSpeed;

	// Token: 0x04000058 RID: 88
	public float acceleration;

	// Token: 0x04000059 RID: 89
	public float speed;

	// Token: 0x0400005A RID: 90
	public float autoBrakeCool;

	// Token: 0x0400005B RID: 91
	public float crazyTime;

	// Token: 0x0400005C RID: 92
	public Quaternion targetRotation;

	// Token: 0x0400005D RID: 93
	public float coolDown;

	// Token: 0x0400005E RID: 94
	private float prevSpeed;

	// Token: 0x0400005F RID: 95
	public bool playerSeen;

	// Token: 0x04000060 RID: 96
	public bool hugAnnounced;

	// Token: 0x04000061 RID: 97
	public AILocationSelectorScript wanderer;

	// Token: 0x04000062 RID: 98
	public Transform player;

	// Token: 0x04000063 RID: 99
	public Transform wanderTarget;

	// Token: 0x04000064 RID: 100
	public AudioClip[] aud_Found = new AudioClip[2];

	// Token: 0x04000065 RID: 101
	public AudioClip[] aud_Lost = new AudioClip[2];

	// Token: 0x04000066 RID: 102
	public AudioClip[] aud_Hug = new AudioClip[2];

	// Token: 0x04000067 RID: 103
	public AudioClip[] aud_Random = new AudioClip[2];

	// Token: 0x04000068 RID: 104
	public AudioClip audBang;

	// Token: 0x04000069 RID: 105
	public AudioSource audioDevice;

	// Token: 0x0400006A RID: 106
	public AudioSource motorAudio;

	// Token: 0x0400006B RID: 107
	private NavMeshAgent agent;
}
