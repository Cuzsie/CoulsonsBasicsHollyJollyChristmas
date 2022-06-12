using System;
//using Rewired;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x020000D0 RID: 208
public class BaldiScript : MonoBehaviour
{
	// Token: 0x060009C1 RID: 2497 RVA: 0x0002576C File Offset: 0x00023B6C
	private void Start()
	{
		this.baldiAudio = base.GetComponent<AudioSource>();
		this.agent = base.GetComponent<NavMeshAgent>();
		this.timeToMove = this.baseTime;
		this.Wander();
		//this.controller = ReInput.players.GetPlayer(0);
		if (PlayerPrefs.GetInt("Rumble") == 1)
		{
			this.rumble = true;
		}
	}

	// Token: 0x060009C2 RID: 2498 RVA: 0x000257CC File Offset: 0x00023BCC
	private void Update()
	{
		if (this.timeToMove > 0f)
		{
			this.timeToMove -= 1f * Time.deltaTime;
		}
		else
		{
			this.Move();
		}
		if (this.coolDown > 0f)
		{
			this.coolDown -= 1f * Time.deltaTime;
		}
		if (this.baldiTempAnger > 0f)
		{
			this.baldiTempAnger -= 0.02f * Time.deltaTime;
		}
		else
		{
			this.baldiTempAnger = 0f;
		}
		if (this.antiHearingTime > 0f)
		{
			this.antiHearingTime -= Time.deltaTime;
		}
		else
		{
			this.antiHearing = false;
		}
		if (this.endless)
		{
			if (this.timeToAnger > 0f)
			{
				this.timeToAnger -= 1f * Time.deltaTime;
			}
			else
			{
				this.timeToAnger = this.angerFrequency;
				this.GetAngry(this.angerRate);
				this.angerRate += this.angerRateRate;
			}
		}
	}

	// Token: 0x060009C3 RID: 2499 RVA: 0x00025900 File Offset: 0x00023D00
	private void FixedUpdate()
	{
		if (this.moveFrames > 0f)
		{
			this.moveFrames -= 1f;
			this.agent.speed = this.speed;
		}
		else
		{
			this.agent.speed = 0f;
		}
		Vector3 direction = this.player.position - base.transform.position;
		RaycastHit raycastHit;
		if (Physics.Raycast(base.transform.position + Vector3.up * 2f, direction, out raycastHit, float.PositiveInfinity, 769, QueryTriggerInteraction.Ignore) && raycastHit.transform.tag == "Player")
		{
			this.db = true;
			this.TargetPlayer();
		}
		else
		{
			this.db = false;
		}
	}

	// Token: 0x060009C4 RID: 2500 RVA: 0x000259DC File Offset: 0x00023DDC
	private void Wander()
	{
		this.wanderer.GetNewTarget();
		this.agent.SetDestination(this.wanderTarget.position);
		this.coolDown = 1f;
		this.currentPriority = 0f;
	}

	// Token: 0x060009C5 RID: 2501 RVA: 0x00025A16 File Offset: 0x00023E16
	public void TargetPlayer()
	{
		this.agent.SetDestination(this.player.position);
		this.coolDown = 1f;
		this.currentPriority = 0f;
	}

	// Token: 0x060009C6 RID: 2502 RVA: 0x00025A48 File Offset: 0x00023E48
	private void Move()
	{
		if (base.transform.position == this.previous & this.coolDown < 0f)
		{
			this.Wander();
		}
		this.moveFrames = 10f;
		this.timeToMove = this.baldiWait - this.baldiTempAnger;
		this.previous = base.transform.position;
		this.baldiAudio.PlayOneShot(this.slap);
		this.baldiAnimator.SetTrigger("slap");
		if (this.rumble)
		{
			float num = Vector3.Distance(base.transform.position, this.player.position);
			if (num < this.vibrationDistance)
			{
				float motorLevel = 1f - num / this.vibrationDistance;
				//this.controller.SetVibration(0, motorLevel, 0.2f);
				//this.controller.SetVibration(1, motorLevel, 0.2f);
			}
		}
	}

	// Token: 0x060009C7 RID: 2503 RVA: 0x00025B3C File Offset: 0x00023F3C
	public void GetAngry(float value)
	{
		this.baldiAnger += value;
		if (this.baldiAnger < 0.5f)
		{
			this.baldiAnger = 0.5f;
		}
		this.baldiWait = -3f * this.baldiAnger / (this.baldiAnger + 2f / this.baldiSpeedScale) + 3f;
	}

	// Token: 0x060009C8 RID: 2504 RVA: 0x00025B9E File Offset: 0x00023F9E
	public void GetTempAngry(float value)
	{
		this.baldiTempAnger += value;
	}

	// Token: 0x060009C9 RID: 2505 RVA: 0x00025BAE File Offset: 0x00023FAE
	public void Hear(Vector3 soundLocation, float priority)
	{
		if (!this.antiHearing && priority >= this.currentPriority)
		{
			this.agent.SetDestination(soundLocation);
			this.currentPriority = priority;
		}
	}

	// Token: 0x060009CA RID: 2506 RVA: 0x00025BDB File Offset: 0x00023FDB
	public void ActivateAntiHearing(float t)
	{
		this.Wander();
		this.antiHearing = true;
		this.antiHearingTime = t;
	}

	// Token: 0x040006BC RID: 1724
	public bool db;

	// Token: 0x040006BD RID: 1725
	public float baseTime;

	// Token: 0x040006BE RID: 1726
	public float speed;

	// Token: 0x040006BF RID: 1727
	public float timeToMove;

	// Token: 0x040006C0 RID: 1728
	public float baldiAnger;

	// Token: 0x040006C1 RID: 1729
	public float baldiTempAnger;

	// Token: 0x040006C2 RID: 1730
	public float baldiWait;

	// Token: 0x040006C3 RID: 1731
	public float baldiSpeedScale;

	// Token: 0x040006C4 RID: 1732
	private float moveFrames;

	// Token: 0x040006C5 RID: 1733
	private float currentPriority;

	// Token: 0x040006C6 RID: 1734
	public bool antiHearing;

	// Token: 0x040006C7 RID: 1735
	public float antiHearingTime;

	// Token: 0x040006C8 RID: 1736
	public float vibrationDistance;

	// Token: 0x040006C9 RID: 1737
	public float angerRate;

	// Token: 0x040006CA RID: 1738
	public float angerRateRate;

	// Token: 0x040006CB RID: 1739
	public float angerFrequency;

	// Token: 0x040006CC RID: 1740
	public float timeToAnger;

	// Token: 0x040006CD RID: 1741
	public bool endless;

	// Token: 0x040006CE RID: 1742
	public Transform player;

	// Token: 0x040006CF RID: 1743
	public Transform wanderTarget;

	// Token: 0x040006D0 RID: 1744
	public AILocationSelectorScript wanderer;

	// Token: 0x040006D1 RID: 1745
	private AudioSource baldiAudio;

	// Token: 0x040006D2 RID: 1746
	public AudioClip slap;

	// Token: 0x040006D3 RID: 1747
	public AudioClip[] speech = new AudioClip[3];

	// Token: 0x040006D4 RID: 1748
	public Animator baldiAnimator;

	// Token: 0x040006D5 RID: 1749
	public float coolDown;

	// Token: 0x040006D6 RID: 1750
	private Vector3 previous;

	// Token: 0x040006D7 RID: 1751
	private bool rumble;

	// Token: 0x040006D8 RID: 1752
	private NavMeshAgent agent;

	// Token: 0x040006D9 RID: 1753
	//private Player controller;
}
