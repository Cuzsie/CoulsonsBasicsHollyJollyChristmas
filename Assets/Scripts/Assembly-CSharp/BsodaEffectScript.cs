using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x02000008 RID: 8
public class BsodaEffectScript : MonoBehaviour
{
	// Token: 0x06000016 RID: 22 RVA: 0x00002429 File Offset: 0x00000829
	private void Start()
	{
		this.agent = base.GetComponent<NavMeshAgent>();
	}

	// Token: 0x06000017 RID: 23 RVA: 0x00002438 File Offset: 0x00000838
	private void Update()
	{
		if (this.inBsoda)
		{
			this.agent.velocity = this.otherVelocity;
		}
		if (this.failSave > 0f)
		{
			this.failSave -= Time.deltaTime;
		}
		else
		{
			this.inBsoda = false;
		}
	}

	// Token: 0x06000018 RID: 24 RVA: 0x00002490 File Offset: 0x00000890
	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "BSODA")
		{
			this.inBsoda = true;
			this.otherVelocity = other.GetComponent<Rigidbody>().velocity;
			this.failSave = 1f;
		}
		else if (other.transform.name == "Gotta Sweep")
		{
			this.inBsoda = true;
			this.otherVelocity = base.transform.forward * this.agent.speed * 0.1f + other.GetComponent<NavMeshAgent>().velocity;
			this.failSave = 1f;
		}
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00002541 File Offset: 0x00000941
	private void OnTriggerExit()
	{
		this.inBsoda = false;
	}

	// Token: 0x04000016 RID: 22
	private NavMeshAgent agent;

	// Token: 0x04000017 RID: 23
	private Vector3 otherVelocity;

	// Token: 0x04000018 RID: 24
	private bool inBsoda;

	// Token: 0x04000019 RID: 25
	private float failSave;
}
