using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x020000C8 RID: 200
public class GameOverScript : MonoBehaviour
{
	// Token: 0x0600099D RID: 2461 RVA: 0x000241DC File Offset: 0x000225DC
	private void Start()
	{
		this.image = base.GetComponent<Image>();
		this.audioDevice = base.GetComponent<AudioSource>();
		this.delay = 5f;
		this.chance = UnityEngine.Random.Range(1f, 99f);
		int num = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 4f));
		this.image.sprite = this.images[num];
	}

	// Token: 0x0600099E RID: 2462 RVA: 0x0002424C File Offset: 0x0002264C
	private void Update()
	{
		this.delay -= 1f * Time.deltaTime;
		if (this.delay <= 0f)
		{
			if (this.chance < 98f)
			{
				SceneManager.LoadScene("MainMenu");
			}
			else
			{
				this.image.transform.localScale = new Vector3(5f, 5f, 1f);
				this.image.color = Color.red;
				if (!this.audioDevice.isPlaying)
				{
					this.audioDevice.Play();
				}
				if (this.delay <= -5f)
				{
					Application.Quit();
				}
			}
		}
	}

	// Token: 0x04000677 RID: 1655
	private Image image;

	// Token: 0x04000678 RID: 1656
	private float delay;

	// Token: 0x04000679 RID: 1657
	public Sprite[] images = new Sprite[5];

	// Token: 0x0400067A RID: 1658
	public Sprite rare;

	// Token: 0x0400067B RID: 1659
	private float chance;

	// Token: 0x0400067C RID: 1660
	private AudioSource audioDevice;
}
