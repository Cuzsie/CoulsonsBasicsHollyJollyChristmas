using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x020000D4 RID: 212
public class PrincipalScript : MonoBehaviour
{
	// Token: 0x060009DA RID: 2522 RVA: 0x00026179 File Offset: 0x00024579
	private void Start()
	{
		this.agent = base.GetComponent<NavMeshAgent>();
		this.audioQueue = base.GetComponent<AudioQueueScript>();
		this.audioDevice = base.GetComponent<AudioSource>();
	}

	// Token: 0x060009DB RID: 2523 RVA: 0x000261A0 File Offset: 0x000245A0
	private void Update()
	{
		if (this.seesRuleBreak)
		{
			this.timeSeenRuleBreak += 1f * Time.deltaTime;
			if ((double)this.timeSeenRuleBreak >= 0.5 & !this.angry)
			{
				this.angry = true;
				this.seesRuleBreak = false;
				this.timeSeenRuleBreak = 0f;
				this.TargetPlayer();
				this.CorrectPlayer();
			}
		}
		else
		{
			this.timeSeenRuleBreak = 0f;
		}
		if (this.coolDown > 0f)
		{
			this.coolDown -= 1f * Time.deltaTime;
		}
	}

	// Token: 0x060009DC RID: 2524 RVA: 0x00026254 File Offset: 0x00024654
	private void FixedUpdate()
	{
		if (!this.angry)
		{
			this.aim = this.player.position - base.transform.position;
			if (Physics.Raycast(base.transform.position, this.aim, out this.hit, float.PositiveInfinity, 769, QueryTriggerInteraction.Ignore) && (this.hit.transform.tag == "Player" & this.playerScript.guilt > 0f & !this.inOffice & !this.angry))
			{
				this.seesRuleBreak = true;
			}
			else
			{
				this.seesRuleBreak = false;
				if (this.agent.velocity.magnitude <= 1f & this.coolDown <= 0f)
				{
					this.Wander();
				}
			}
			this.aim = this.bully.position - base.transform.position;
			if (Physics.Raycast(base.transform.position, this.aim, out this.hit, float.PositiveInfinity, 769) && (this.hit.transform.name == "Its a Bully" & this.bullyScript.guilt > 0f & !this.inOffice & !this.angry))
			{
				this.TargetBully();
			}
		}
		else
		{
			this.TargetPlayer();
		}
	}

	// Token: 0x060009DD RID: 2525 RVA: 0x000263F0 File Offset: 0x000247F0
	private void Wander()
	{
		this.playerScript.principalBugFixer = 1;
		this.wanderer.GetNewTarget();
		this.agent.SetDestination(this.wanderTarget.position);
		if (this.agent.isStopped)
		{
			this.agent.isStopped = false;
		}
		this.coolDown = 1f;
		if (UnityEngine.Random.Range(0f, 10f) <= 1f)
		{
			this.quietAudioDevice.PlayOneShot(this.aud_Whistle);
		}
	}

	// Token: 0x060009DE RID: 2526 RVA: 0x0002647C File Offset: 0x0002487C
	private void TargetPlayer()
	{
		this.agent.SetDestination(this.player.position);
		this.coolDown = 1f;
	}

	// Token: 0x060009DF RID: 2527 RVA: 0x000264A0 File Offset: 0x000248A0
	private void TargetBully()
	{
		if (!this.bullySeen)
		{
			this.agent.SetDestination(this.bully.position);
			this.audioQueue.QueueAudio(this.audNoBullying);
			this.bullySeen = true;
		}
	}

	// Token: 0x060009E0 RID: 2528 RVA: 0x000264DC File Offset: 0x000248DC
	private void CorrectPlayer()
	{
		this.audioQueue.ClearAudioQueue();
		if (this.playerScript.guiltType == "faculty")
		{
			this.audioQueue.QueueAudio(this.audNoFaculty);
		}
		else if (this.playerScript.guiltType == "running")
		{
			this.audioQueue.QueueAudio(this.audNoRunning);
		}
		else if (this.playerScript.guiltType == "drink")
		{
			this.audioQueue.QueueAudio(this.audNoDrinking);
		}
		else if (this.playerScript.guiltType == "escape")
		{
			this.audioQueue.QueueAudio(this.audNoEscaping);
		}
	}

	// Token: 0x060009E1 RID: 2529 RVA: 0x000265B0 File Offset: 0x000249B0
	private void OnTriggerStay(Collider other)
	{
		if (other.name == "Office Trigger")
		{
			this.inOffice = true;
		}
		if (other.tag == "Player" & this.angry & !this.inOffice)
		{
			this.inOffice = true;
			this.playerScript.principalBugFixer = 0;
			this.agent.Warp(new Vector3(10f, 0f, 170f));
			this.agent.isStopped = true;
			this.cc.enabled = false;
			other.transform.position = new Vector3(10f, 4f, 160f);
			other.transform.LookAt(new Vector3(base.transform.position.x, other.transform.position.y, base.transform.position.z));
			this.cc.enabled = true;
			this.audioQueue.QueueAudio(this.aud_Delay);
			this.audioQueue.QueueAudio(this.audTimes[this.detentions]);
			this.audioQueue.QueueAudio(this.audDetention);
			int num = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 2f));
			this.audioQueue.QueueAudio(this.audScolds[num]);
			this.officeDoor.LockDoor((float)this.lockTime[this.detentions]);
			this.baldiScript.Hear(base.transform.position, 8f);
			this.coolDown = 5f;
			this.angry = false;
			this.detentions++;
			if (this.detentions > 4)
			{
				this.detentions = 4;
			}
		}
	}

	// Token: 0x060009E2 RID: 2530 RVA: 0x00026772 File Offset: 0x00024B72
	private void OnTriggerExit(Collider other)
	{
		if (other.name == "Office Trigger")
		{
			this.inOffice = false;
		}
		if (other.name == "Its a Bully")
		{
			this.bullySeen = false;
		}
	}

	// Token: 0x040006F5 RID: 1781
	public bool seesRuleBreak;

	// Token: 0x040006F6 RID: 1782
	public Transform player;

	public CharacterController cc;

	// Token: 0x040006F7 RID: 1783
	public Transform bully;

	// Token: 0x040006F8 RID: 1784
	public bool bullySeen;

	// Token: 0x040006F9 RID: 1785
	public PlayerScript playerScript;

	// Token: 0x040006FA RID: 1786
	public BullyScript bullyScript;

	// Token: 0x040006FB RID: 1787
	public BaldiScript baldiScript;

	// Token: 0x040006FC RID: 1788
	public Transform wanderTarget;

	// Token: 0x040006FD RID: 1789
	public AILocationSelectorScript wanderer;

	// Token: 0x040006FE RID: 1790
	public DoorScript officeDoor;

	// Token: 0x040006FF RID: 1791
	public float coolDown;

	// Token: 0x04000700 RID: 1792
	public float timeSeenRuleBreak;

	// Token: 0x04000701 RID: 1793
	public bool angry;

	// Token: 0x04000702 RID: 1794
	public bool inOffice;

	// Token: 0x04000703 RID: 1795
	private int detentions;

	// Token: 0x04000704 RID: 1796
	private int[] lockTime = new int[]
	{
		15,
		30,
		45,
		60,
		99
	};

	// Token: 0x04000705 RID: 1797
	public AudioClip[] audTimes = new AudioClip[5];

	// Token: 0x04000706 RID: 1798
	public AudioClip[] audScolds = new AudioClip[3];

	// Token: 0x04000707 RID: 1799
	public AudioClip audDetention;

	// Token: 0x04000708 RID: 1800
	public AudioClip audNoDrinking;

	// Token: 0x04000709 RID: 1801
	public AudioClip audNoBullying;

	// Token: 0x0400070A RID: 1802
	public AudioClip audNoFaculty;

	// Token: 0x0400070B RID: 1803
	public AudioClip audNoLockers;

	// Token: 0x0400070C RID: 1804
	public AudioClip audNoRunning;

	// Token: 0x0400070D RID: 1805
	public AudioClip audNoStabbing;

	// Token: 0x0400070E RID: 1806
	public AudioClip audNoEscaping;

	// Token: 0x0400070F RID: 1807
	public AudioClip aud_Whistle;

	// Token: 0x04000710 RID: 1808
	public AudioClip aud_Delay;

	// Token: 0x04000711 RID: 1809
	private NavMeshAgent agent;

	// Token: 0x04000712 RID: 1810
	private AudioQueueScript audioQueue;

	// Token: 0x04000713 RID: 1811
	private AudioSource audioDevice;

	// Token: 0x04000714 RID: 1812
	public AudioSource quietAudioDevice;

	// Token: 0x04000715 RID: 1813
	private RaycastHit hit;

	// Token: 0x04000716 RID: 1814
	private Vector3 aim;
}
