using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x020000D1 RID: 209
public class CraftersScript : MonoBehaviour
{
	// Token: 0x060009CC RID: 2508 RVA: 0x00025BF9 File Offset: 0x00023FF9
	private void Start()
	{
		this.agent = base.GetComponent<NavMeshAgent>();
		this.audioDevice = base.GetComponent<AudioSource>();
		this.sprite.SetActive(false);
	}

	// Token: 0x060009CD RID: 2509 RVA: 0x00025C20 File Offset: 0x00024020
	private void Update()
	{
		if (this.forceShowTime > 0f)
		{
			this.forceShowTime -= Time.deltaTime;
		}
		if (this.gettingAngry)
		{
			this.anger += Time.deltaTime;
			if (this.anger >= 1f & !this.angry)
			{
				this.angry = true;
				this.audioDevice.PlayOneShot(this.aud_Intro);
				this.spriteImage.sprite = this.angrySprite;
			}
		}
		else if (this.anger > 0f)
		{
			this.anger -= Time.deltaTime;
		}
		if (!this.angry)
		{
			if (((base.transform.position - this.agent.destination).magnitude <= 20f & (base.transform.position - this.player.position).magnitude >= 60f) || this.forceShowTime > 0f)
			{
				this.sprite.SetActive(true);
			}
			else
			{
				this.sprite.SetActive(false);
			}
		}
		else
		{
			this.agent.speed = this.agent.speed + 60f * Time.deltaTime;
			this.TargetPlayer();
			if (!this.audioDevice.isPlaying)
			{
				this.audioDevice.PlayOneShot(this.aud_Loop);
			}
		}
	}

	// Token: 0x060009CE RID: 2510 RVA: 0x00025DC4 File Offset: 0x000241C4
	private void FixedUpdate()
	{
		if (this.gc.notebooks >= 7)
		{
			Vector3 direction = this.player.position - base.transform.position;
			RaycastHit raycastHit;
			if (Physics.Raycast(base.transform.position + Vector3.up * 2f, direction, out raycastHit, float.PositiveInfinity, 769, QueryTriggerInteraction.Ignore) && (raycastHit.transform.tag == "Player" & this.craftersRenderer.isVisible & this.sprite.activeSelf))
			{
				this.gettingAngry = true;
			}
			else
			{
				this.gettingAngry = false;
			}
		}
	}

	// Token: 0x060009CF RID: 2511 RVA: 0x00025E81 File Offset: 0x00024281
	public void GiveLocation(Vector3 location, bool flee)
	{
		if (!this.angry)
		{
			this.agent.SetDestination(location);
			if (flee)
			{
				this.forceShowTime = 3f;
			}
		}
	}

	// Token: 0x060009D0 RID: 2512 RVA: 0x00025EAC File Offset: 0x000242AC
	private void TargetPlayer()
	{
		this.agent.SetDestination(this.player.position);
	}

	// Token: 0x060009D1 RID: 2513 RVA: 0x00025EC8 File Offset: 0x000242C8
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" & this.angry)
		{
			this.cc.enabled = false;
			this.player.position = new Vector3(5f, this.player.position.y, 80f);
			this.baldiAgent.Warp(new Vector3(5f, this.baldi.position.y, 125f));
			this.player.LookAt(new Vector3(this.baldi.position.x, this.player.position.y, this.baldi.position.z));
			this.cc.enabled = true;
			this.gc.DespawnCrafters();
		}
	}

	// Token: 0x040006DA RID: 1754
	public bool db;

	// Token: 0x040006DB RID: 1755
	public bool angry;

	// Token: 0x040006DC RID: 1756
	public bool gettingAngry;

	// Token: 0x040006DD RID: 1757
	public float anger;

	// Token: 0x040006DE RID: 1758
	private float forceShowTime;

	// Token: 0x040006DF RID: 1759
	public Transform player;

	public CharacterController cc;

	// Token: 0x040006E0 RID: 1760
	public Transform playerCamera;

	// Token: 0x040006E1 RID: 1761
	public Transform baldi;

	// Token: 0x040006E2 RID: 1762
	public NavMeshAgent baldiAgent;

	// Token: 0x040006E3 RID: 1763
	public GameObject sprite;

	// Token: 0x040006E4 RID: 1764
	public GameControllerScript gc;

	// Token: 0x040006E5 RID: 1765
	private NavMeshAgent agent;

	// Token: 0x040006E6 RID: 1766
	public Renderer craftersRenderer;

	// Token: 0x040006E7 RID: 1767
	public SpriteRenderer spriteImage;

	// Token: 0x040006E8 RID: 1768
	public Sprite angrySprite;

	// Token: 0x040006E9 RID: 1769
	private AudioSource audioDevice;

	// Token: 0x040006EA RID: 1770
	public AudioClip aud_Intro;

	// Token: 0x040006EB RID: 1771
	public AudioClip aud_Loop;
}
