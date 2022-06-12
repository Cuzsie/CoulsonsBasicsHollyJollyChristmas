using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x020000E2 RID: 226
public class SweepScript : MonoBehaviour
{
	// Token: 0x06000A15 RID: 2581 RVA: 0x00027E84 File Offset: 0x00026284
	private void Start()
	{
		this.agent = base.GetComponent<NavMeshAgent>();
		this.audioDevice = base.GetComponent<AudioSource>();
		this.origin = base.transform.position;
		this.waitTime = UnityEngine.Random.Range(120f, 180f);
	}

	// Token: 0x06000A16 RID: 2582 RVA: 0x00027EC4 File Offset: 0x000262C4
	private void Update()
	{
		if (this.coolDown > 0f)
		{
			this.coolDown -= 1f * Time.deltaTime;
		}
		if (this.waitTime > 0f)
		{
			this.waitTime -= Time.deltaTime;
		}
		else if (!this.active)
		{
			this.active = true;
			this.wanders = 0;
			this.Wander();
			this.audioDevice.PlayOneShot(this.aud_Intro);
		}
	}

	// Token: 0x06000A17 RID: 2583 RVA: 0x00027F50 File Offset: 0x00026350
	private void FixedUpdate()
	{
		if ((double)this.agent.velocity.magnitude <= 0.1 & this.coolDown <= 0f & this.wanders < 5 & this.active)
		{
			this.Wander();
		}
		else if (this.wanders >= 5)
		{
			this.GoHome();
		}
	}

	// Token: 0x06000A18 RID: 2584 RVA: 0x00027FC6 File Offset: 0x000263C6
	private void Wander()
	{
		this.wanderer.GetNewTargetHallway();
		this.agent.SetDestination(this.wanderTarget.position);
		this.coolDown = 1f;
		this.wanders++;
	}

	// Token: 0x06000A19 RID: 2585 RVA: 0x00028003 File Offset: 0x00026403
	private void GoHome()
	{
		this.agent.SetDestination(this.origin);
		this.waitTime = UnityEngine.Random.Range(120f, 180f);
		this.wanders = 0;
		this.active = false;
	}

	// Token: 0x06000A1A RID: 2586 RVA: 0x0002803A File Offset: 0x0002643A
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "NPC" || other.tag == "Player")
		{
			this.audioDevice.PlayOneShot(this.aud_Sweep);
		}
	}

	// Token: 0x04000766 RID: 1894
	public Transform wanderTarget;

	// Token: 0x04000767 RID: 1895
	public AILocationSelectorScript wanderer;

	// Token: 0x04000768 RID: 1896
	public float coolDown;

	// Token: 0x04000769 RID: 1897
	public float waitTime;

	// Token: 0x0400076A RID: 1898
	public int wanders;

	// Token: 0x0400076B RID: 1899
	public bool active;

	// Token: 0x0400076C RID: 1900
	private Vector3 origin;

	// Token: 0x0400076D RID: 1901
	public AudioClip aud_Sweep;

	// Token: 0x0400076E RID: 1902
	public AudioClip aud_Intro;

	// Token: 0x0400076F RID: 1903
	private NavMeshAgent agent;

	// Token: 0x04000770 RID: 1904
	private AudioSource audioDevice;
}
