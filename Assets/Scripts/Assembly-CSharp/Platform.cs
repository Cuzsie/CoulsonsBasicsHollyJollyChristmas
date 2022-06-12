using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000023 RID: 35
public class Platform : MonoBehaviour
{
	// Token: 0x0600007B RID: 123 RVA: 0x00004078 File Offset: 0x00002478
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.name == "Player" && this.gc.surpriseActive && !this.activated)
		{
			this.offset = this.ps.transform.position.y - base.transform.position.y;
			this.ps.transform.position = base.transform.position + Vector3.up * this.offset;
			this.playerController.enabled = false;
			this.audioDevice.clip = this.motor;
			this.audioDevice.Play();
			this.audioDevice.loop = true;
			this.activated = true;
			base.StartCoroutine(this.Lift());
			this.wall.enabled = false;
		}
	}

	// Token: 0x0600007C RID: 124 RVA: 0x00004170 File Offset: 0x00002570
	private IEnumerator Lift()
	{
		while (base.transform.position.y < this.height)
		{
			base.transform.position = base.transform.position + Vector3.up * (this.speed * Time.deltaTime);
			this.ps.height = base.transform.position.y + this.offset;
			yield return null;
		}
		Transform transform = base.transform;
		Vector3 position = new Vector3(base.transform.position.x, this.height, base.transform.position.z);
		base.transform.position = position;
		transform.position = position;
		this.ps.height = this.height + this.offset;
		this.audioDevice.Stop();
		yield break;
	}

	// Token: 0x04000092 RID: 146
	[SerializeField]
	private GameControllerScript gc;

	// Token: 0x04000093 RID: 147
	[SerializeField]
	private PlayerScript ps;

	// Token: 0x04000094 RID: 148
	[SerializeField]
	private CharacterController playerController;

	// Token: 0x04000095 RID: 149
	[SerializeField]
	private AudioSource audioDevice;

	// Token: 0x04000096 RID: 150
	[SerializeField]
	private Collider wall;

	// Token: 0x04000097 RID: 151
	public AudioClip motor;

	// Token: 0x04000098 RID: 152
	public float height;

	// Token: 0x04000099 RID: 153
	public float speed;

	// Token: 0x0400009A RID: 154
	public float offset;

	// Token: 0x0400009B RID: 155
	private bool activated;
}
