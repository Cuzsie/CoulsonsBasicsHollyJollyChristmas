using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x02000025 RID: 37
public class PlaytimeScript : MonoBehaviour
{
	// Token: 0x06000080 RID: 128 RVA: 0x00004384 File Offset: 0x00002784
	private void Start()
	{
		this.agent = base.GetComponent<NavMeshAgent>();
		this.audioDevice = base.GetComponent<AudioSource>();
		this.Wander();
	}

	// Token: 0x06000081 RID: 129 RVA: 0x000043A4 File Offset: 0x000027A4
	private void Update()
	{
		if (this.coolDown > 0f)
		{
			this.coolDown -= 1f * Time.deltaTime;
		}
		if (this.playCool >= 0f)
		{
			this.playCool -= Time.deltaTime;
		}
		else if (this.animator.GetBool("disappointed"))
		{
			this.playCool = 0f;
			this.animator.SetBool("disappointed", false);
		}
	}

	// Token: 0x06000082 RID: 130 RVA: 0x00004434 File Offset: 0x00002834
	private void FixedUpdate()
	{
		if (!this.ps.jumpRope)
		{
			Vector3 direction = this.player.position - base.transform.position;
			RaycastHit raycastHit;
			if (Physics.Raycast(base.transform.position, direction, out raycastHit, float.PositiveInfinity, 769, QueryTriggerInteraction.Ignore) && (raycastHit.transform.tag == "Player" & (base.transform.position - this.player.position).magnitude <= 80f & this.playCool <= 0f))
			{
				this.playerSeen = true;
				this.TargetPlayer();
			}
			else if (this.playerSeen & this.coolDown <= 0f)
			{
				this.playerSeen = false;
				this.Wander();
			}
			else if (this.agent.velocity.magnitude <= 1f & this.coolDown <= 0f)
			{
				this.Wander();
			}
			this.jumpRopeStarted = false;
		}
		else
		{
			if (!this.jumpRopeStarted)
			{
				this.agent.Warp(base.transform.position - base.transform.forward * 10f);
			}
			this.jumpRopeStarted = true;
			this.agent.speed = 0f;
			this.playCool = 15f;
		}
	}

	// Token: 0x06000083 RID: 131 RVA: 0x000045D0 File Offset: 0x000029D0
	private void Wander()
	{
		this.wanderer.GetNewTargetHallway();
		this.agent.SetDestination(this.wanderTarget.position);
		this.agent.speed = 15f;
		this.playerSpotted = false;
		this.audVal = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 1f));
		if (!this.audioDevice.isPlaying)
		{
			this.audioDevice.PlayOneShot(this.aud_Random[this.audVal]);
		}
		this.coolDown = 1f;
	}

	// Token: 0x06000084 RID: 132 RVA: 0x00004664 File Offset: 0x00002A64
	private void TargetPlayer()
	{
		this.animator.SetBool("disappointed", false);
		this.agent.SetDestination(this.player.position);
		this.agent.speed = 20f;
		this.coolDown = 0.2f;
		if (!this.playerSpotted)
		{
			this.playerSpotted = true;
			this.audioDevice.PlayOneShot(this.aud_LetsPlay);
		}
	}

	// Token: 0x06000085 RID: 133 RVA: 0x000046D7 File Offset: 0x00002AD7
	public void Disappoint()
	{
		this.animator.SetBool("disappointed", true);
		this.audioDevice.Stop();
		this.audioDevice.PlayOneShot(this.aud_Sad);
	}

	// Token: 0x0400009E RID: 158
	public bool db;

	// Token: 0x0400009F RID: 159
	public bool playerSeen;

	// Token: 0x040000A0 RID: 160
	public bool disappointed;

	// Token: 0x040000A1 RID: 161
	public int audVal;

	// Token: 0x040000A2 RID: 162
	public Animator animator;

	// Token: 0x040000A3 RID: 163
	public Transform player;

	// Token: 0x040000A4 RID: 164
	public PlayerScript ps;

	// Token: 0x040000A5 RID: 165
	public Transform wanderTarget;

	// Token: 0x040000A6 RID: 166
	public AILocationSelectorScript wanderer;

	// Token: 0x040000A7 RID: 167
	public float coolDown;

	// Token: 0x040000A8 RID: 168
	public float playCool;

	// Token: 0x040000A9 RID: 169
	public bool playerSpotted;

	// Token: 0x040000AA RID: 170
	public bool jumpRopeStarted;

	// Token: 0x040000AB RID: 171
	private NavMeshAgent agent;

	// Token: 0x040000AC RID: 172
	public AudioClip[] aud_Numbers = new AudioClip[10];

	// Token: 0x040000AD RID: 173
	public AudioClip[] aud_Random = new AudioClip[2];

	// Token: 0x040000AE RID: 174
	public AudioClip aud_Instrcutions;

	// Token: 0x040000AF RID: 175
	public AudioClip aud_Oops;

	// Token: 0x040000B0 RID: 176
	public AudioClip aud_LetsPlay;

	// Token: 0x040000B1 RID: 177
	public AudioClip aud_Congrats;

	// Token: 0x040000B2 RID: 178
	public AudioClip aud_ReadyGo;

	// Token: 0x040000B3 RID: 179
	public AudioClip aud_Sad;

	// Token: 0x040000B4 RID: 180
	public AudioSource audioDevice;
}
