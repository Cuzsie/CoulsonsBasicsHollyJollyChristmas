using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000E1 RID: 225
public class SpoopManager : MonoBehaviour
{
	// Token: 0x06000A10 RID: 2576 RVA: 0x00027AEC File Offset: 0x00025EEC
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && !this.activated)
		{
			this.activated = true;
			base.StartCoroutine(this.Spawner());
			base.StartCoroutine(this.Changer());
		}
	}

	// Token: 0x06000A11 RID: 2577 RVA: 0x00027B3C File Offset: 0x00025F3C
	private IEnumerator Spawner()
	{
		float time = this.initialTime;
		this.SpawnBalloon();
		for (;;)
		{
			while (time > 0f)
			{
				time -= Time.deltaTime;
				yield return null;
			}
			this.SpawnBalloon();
			this.initialTime -= this.inc;
			time = this.initialTime;
			yield return null;
		}
		yield break;
	}

	// Token: 0x06000A12 RID: 2578 RVA: 0x00027B58 File Offset: 0x00025F58
	private IEnumerator Changer()
	{
		float time = 2f;
		int times = 0;
		while (times < 70)
		{
			while (time > 0f)
			{
				time -= Time.deltaTime;
				yield return null;
			}
			this.renderers[UnityEngine.Random.Range(0, this.renderers.Length)].sharedMaterial = this.DSCI_0000;
			time = 2f;
			times++;
			yield return null;
		}
		this.thanks.SetActive(true);
		base.StopAllCoroutines();
		yield break;
	}

	// Token: 0x06000A13 RID: 2579 RVA: 0x00027B74 File Offset: 0x00025F74
	private void SpawnBalloon()
	{
		Vector3 a = default(Vector3);
		a.x = UnityEngine.Random.Range(-1f, 1f);
		a.z = UnityEngine.Random.Range(-1f, 1f);
		a = a.normalized;
		SpoopBalloon spoopBalloon = UnityEngine.Object.Instantiate<SpoopBalloon>(this.balloon);
		spoopBalloon.transform.position = this.player.transform.position + a * 50f;
		spoopBalloon.player = this.player.transform;
	}

	// Token: 0x0400075D RID: 1885
	public SpoopBalloon balloon;

	// Token: 0x0400075E RID: 1886
	public PlayerScript player;

	// Token: 0x0400075F RID: 1887
	public float initialTime;

	// Token: 0x04000760 RID: 1888
	public float inc;

	// Token: 0x04000761 RID: 1889
	public MeshRenderer[] renderers;

	// Token: 0x04000762 RID: 1890
	public Material DSCI_0000;

	// Token: 0x04000763 RID: 1891
	public GameObject thanks;

	// Token: 0x04000764 RID: 1892
	public GameControllerScript gc;

	// Token: 0x04000765 RID: 1893
	private bool activated;
}
