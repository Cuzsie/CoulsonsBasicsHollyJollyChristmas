using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x020000CE RID: 206
public class AgentTest : MonoBehaviour
{
	// Token: 0x060009B7 RID: 2487 RVA: 0x000254D9 File Offset: 0x000238D9
	private void Start()
	{
		this.agent = base.GetComponent<NavMeshAgent>();
		this.Wander();
	}

	// Token: 0x060009B8 RID: 2488 RVA: 0x000254ED File Offset: 0x000238ED
	private void Update()
	{
		if (this.coolDown > 0f)
		{
			this.coolDown -= 1f * Time.deltaTime;
		}
	}

	// Token: 0x060009B9 RID: 2489 RVA: 0x00025518 File Offset: 0x00023918
	private void FixedUpdate()
	{
		Vector3 direction = this.player.position - base.transform.position;
		RaycastHit raycastHit;
		if (Physics.Raycast(base.transform.position, direction, out raycastHit, float.PositiveInfinity, 3, QueryTriggerInteraction.Ignore) && raycastHit.transform.tag == "Player")
		{
			this.db = true;
			this.TargetPlayer();
		}
		else
		{
			this.db = false;
			if (this.agent.velocity.magnitude <= 1f & this.coolDown <= 0f)
			{
				this.Wander();
			}
		}
	}

	// Token: 0x060009BA RID: 2490 RVA: 0x000255CD File Offset: 0x000239CD
	private void Wander()
	{
		this.wanderer.GetNewTarget();
		this.agent.SetDestination(this.wanderTarget.position);
		this.coolDown = 1f;
	}

	// Token: 0x060009BB RID: 2491 RVA: 0x000255FC File Offset: 0x000239FC
	private void TargetPlayer()
	{
		this.agent.SetDestination(this.player.position);
		this.coolDown = 1f;
	}

	// Token: 0x040006B2 RID: 1714
	public bool db;

	// Token: 0x040006B3 RID: 1715
	public Transform player;

	// Token: 0x040006B4 RID: 1716
	public Transform wanderTarget;

	// Token: 0x040006B5 RID: 1717
	public AILocationSelectorScript wanderer;

	// Token: 0x040006B6 RID: 1718
	public float coolDown;

	// Token: 0x040006B7 RID: 1719
	private NavMeshAgent agent;
}
