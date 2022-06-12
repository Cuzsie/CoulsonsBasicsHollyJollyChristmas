using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x02000017 RID: 23
public class HuggingScript : MonoBehaviour
{
	// Token: 0x06000050 RID: 80 RVA: 0x00003809 File Offset: 0x00001C09
	private void Start()
	{
		this.rb = base.GetComponent<Rigidbody>();
	}

	// Token: 0x06000051 RID: 81 RVA: 0x00003817 File Offset: 0x00001C17
	private void Update()
	{
		if (this.failSave > 0f)
		{
			this.failSave -= Time.deltaTime;
		}
		else
		{
			this.inBsoda = false;
		}
	}

	// Token: 0x06000052 RID: 82 RVA: 0x00003847 File Offset: 0x00001C47
	private void FixedUpdate()
	{
		if (this.inBsoda)
		{
			this.rb.velocity = this.otherVelocity;
		}
	}

	// Token: 0x06000053 RID: 83 RVA: 0x00003868 File Offset: 0x00001C68
	private void OnTriggerStay(Collider other)
	{
		if (other.transform.name == "1st Prize")
		{
			this.inBsoda = true;
			this.otherVelocity = this.rb.velocity * 0.1f + other.GetComponent<NavMeshAgent>().velocity;
			this.failSave = 1f;
		}
	}

	// Token: 0x06000054 RID: 84 RVA: 0x000038CC File Offset: 0x00001CCC
	private void OnTriggerExit()
	{
		this.inBsoda = false;
	}

	// Token: 0x0400006C RID: 108
	private Rigidbody rb;

	// Token: 0x0400006D RID: 109
	private Vector3 otherVelocity;

	// Token: 0x0400006E RID: 110
	public bool inBsoda;

	// Token: 0x0400006F RID: 111
	private float failSave;
}
