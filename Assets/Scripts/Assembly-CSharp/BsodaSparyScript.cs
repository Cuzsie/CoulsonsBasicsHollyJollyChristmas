using System;
using UnityEngine;

// Token: 0x020000BB RID: 187
public class BsodaSparyScript : MonoBehaviour
{
	// Token: 0x06000941 RID: 2369 RVA: 0x00021621 File Offset: 0x0001FA21
	private void Start()
	{
		this.rb = base.GetComponent<Rigidbody>();
		this.rb.velocity = base.transform.forward * this.speed;
		this.lifeSpan = 30f;
	}

	// Token: 0x06000942 RID: 2370 RVA: 0x0002165C File Offset: 0x0001FA5C
	private void Update()
	{
		this.rb.velocity = base.transform.forward * this.speed;
		this.lifeSpan -= Time.deltaTime;
		if (this.lifeSpan < 0f)
		{
			UnityEngine.Object.Destroy(base.gameObject, 0f);
		}
	}

	// Token: 0x040005D6 RID: 1494
	public float speed;

	// Token: 0x040005D7 RID: 1495
	private float lifeSpan;

	// Token: 0x040005D8 RID: 1496
	private Rigidbody rb;
}
