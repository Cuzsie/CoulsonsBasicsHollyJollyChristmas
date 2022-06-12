using System;
using System.Collections;
//using Rewired;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

// Token: 0x020000D8 RID: 216
public class PlayerScript : MonoBehaviour
{
	// Token: 0x060009F1 RID: 2545 RVA: 0x00026E88 File Offset: 0x00025288
	private void Start()
	{
		if (PlayerPrefs.GetInt("AnalogMove") == 1)
		{
			this.sensitivityActive = true;
		}
		this.height = base.transform.position.y;
		//this.player = ReInput.players.GetPlayer(0);
		this.stamina = this.maxStamina;
		this.playerRotation = base.transform.rotation;
		this.mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity");
		this.principalBugFixer = 1;
		this.flipaturn = 1f;
	}

	// Token: 0x060009F2 RID: 2546 RVA: 0x00026F18 File Offset: 0x00025318
	private void Update()
	{
		base.transform.position = new Vector3(base.transform.position.x, this.height, base.transform.position.z);
		this.MouseMove();
		this.PlayerMove();
		this.StaminaCheck();
		this.GuiltCheck();
		if (this.cc.velocity.magnitude > 0f)
		{
			this.gc.LockMouse();
		}
		if (this.jumpRope & (base.transform.position - this.frozenPosition).magnitude >= 1f)
		{
			this.DeactivateJumpRope();
		}
		if (this.sweepingFailsave > 0f)
		{
			this.sweepingFailsave -= Time.deltaTime;
		}
		else
		{
			this.sweeping = false;
			this.hugging = false;
		}
	}

	// Token: 0x060009F3 RID: 2547 RVA: 0x00027014 File Offset: 0x00025414
	private void MouseMove()
	{
		this.playerRotation.eulerAngles = new Vector3(this.playerRotation.eulerAngles.x, this.playerRotation.eulerAngles.y, this.fliparoo);
		this.playerRotation.eulerAngles = this.playerRotation.eulerAngles + Vector3.up * Input.GetAxis("Mouse X") * this.mouseSensitivity * Time.timeScale * this.flipaturn;
		base.transform.rotation = this.playerRotation;
	}

	// Token: 0x060009F4 RID: 2548 RVA: 0x000270C0 File Offset: 0x000254C0
	private void PlayerMove()
	{
		Vector3 vector = new Vector3(0f, 0f, 0f);
		Vector3 vector2 = new Vector3(0f, 0f, 0f);
		vector = base.transform.forward * Input.GetAxis("Forward");
		vector2 = base.transform.right * Input.GetAxis("Strafe");
		if (this.stamina > 0f)
		{
			if (Input.GetButton("Run"))
			{
				this.playerSpeed = this.runSpeed;
				this.sensitivity = 1f;
				if (this.cc.velocity.magnitude > 0.1f & !this.hugging & !this.sweeping)
				{
					this.ResetGuilt("running", 0.1f);
				}
			}
			else
			{
				this.playerSpeed = this.walkSpeed;
				if (this.sensitivityActive)
				{
					this.sensitivity = Mathf.Clamp((vector2 + vector).magnitude, 0f, 1f);
				}
				else
				{
					this.sensitivity = 1f;
				}
			}
		}
		else
		{
			this.playerSpeed = this.walkSpeed;
			if (this.sensitivityActive)
			{
				this.sensitivity = Mathf.Clamp((vector2 + vector).magnitude, 0f, 1f);
			}
			else
			{
				this.sensitivity = 1f;
			}
		}
		this.playerSpeed *= Time.deltaTime;
		this.moveDirection = (vector + vector2).normalized * this.playerSpeed * this.sensitivity;
		if (!(!this.jumpRope & !this.sweeping & !this.hugging))
		{
			if (this.sweeping && !this.bootsActive)
			{
				this.moveDirection = this.gottaSweep.velocity * Time.deltaTime + this.moveDirection * 0.3f;
			}
			else if (this.hugging && !this.bootsActive)
			{
				this.moveDirection = (this.firstPrize.velocity * 1.2f * Time.deltaTime + (new Vector3(this.firstPrizeTransform.position.x, this.height, this.firstPrizeTransform.position.z) + new Vector3((float)Mathf.RoundToInt(this.firstPrizeTransform.forward.x), 0f, (float)Mathf.RoundToInt(this.firstPrizeTransform.forward.z)) * 3f - base.transform.position)) * (float)this.principalBugFixer;
			}
			else if (this.jumpRope)
			{
				this.moveDirection = new Vector3(0f, 0f, 0f);
			}
		}
		this.cc.Move(this.moveDirection);
	}

	// Token: 0x060009F5 RID: 2549 RVA: 0x00027424 File Offset: 0x00025824
	private void StaminaCheck()
	{
		if (this.cc.velocity.magnitude > 0.1f)
		{
			if (Input.GetButton("Run") & this.stamina > 0f)
			{
				this.stamina -= this.staminaRate * Time.deltaTime;
			}
			if (this.stamina < 0f & this.stamina > -5f)
			{
				this.stamina = -5f;
			}
		}
		else if (this.stamina < this.maxStamina)
		{
			this.stamina += this.staminaRate * Time.deltaTime;
		}
		this.staminaBar.value = this.stamina / this.maxStamina * 100f;
	}

	// Token: 0x060009F6 RID: 2550 RVA: 0x00027504 File Offset: 0x00025904
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.name == "Baldi" & !this.gc.debugMode)
		{
			this.gameOver = true;
			RenderSettings.skybox = this.blackSky;
			base.StartCoroutine(this.KeepTheHudOff());
		}
		else if (other.transform.name == "Playtime" & !this.jumpRope & this.playtime.playCool <= 0f)
		{
			this.ActivateJumpRope();
		}
	}

	// Token: 0x060009F7 RID: 2551 RVA: 0x000275A0 File Offset: 0x000259A0
	public IEnumerator KeepTheHudOff()
	{
		while (this.gameOver)
		{
			this.hud.enabled = false;
			this.mobile1.enabled = false;
			this.mobile2.enabled = false;
			this.jumpRopeScreen.SetActive(false);
			yield return new WaitForEndOfFrame();
		}
		yield break;
	}

	// Token: 0x060009F8 RID: 2552 RVA: 0x000275BC File Offset: 0x000259BC
	private void OnTriggerStay(Collider other)
	{
		if (other.transform.name == "Gotta Sweep")
		{
			this.sweeping = true;
			this.sweepingFailsave = 1f;
		}
		else if (other.transform.name == "1st Prize" & this.firstPrize.velocity.magnitude > 5f)
		{
			this.hugging = true;
			this.sweepingFailsave = 1f;
		}
	}

	// Token: 0x060009F9 RID: 2553 RVA: 0x00027644 File Offset: 0x00025A44
	private void OnTriggerExit(Collider other)
	{
		if (other.transform.name == "Office Trigger")
		{
			this.ResetGuilt("escape", this.door.lockTime);
		}
		else if (other.transform.name == "Gotta Sweep")
		{
			this.sweeping = false;
		}
		else if (other.transform.name == "1st Prize")
		{
			this.hugging = false;
		}
	}

	// Token: 0x060009FA RID: 2554 RVA: 0x000276CD File Offset: 0x00025ACD
	public void ResetGuilt(string type, float amount)
	{
		if (amount >= this.guilt)
		{
			this.guilt = amount;
			this.guiltType = type;
		}
	}

	// Token: 0x060009FB RID: 2555 RVA: 0x000276E9 File Offset: 0x00025AE9
	private void GuiltCheck()
	{
		if (this.guilt > 0f)
		{
			this.guilt -= Time.deltaTime;
		}
	}

	// Token: 0x060009FC RID: 2556 RVA: 0x0002770D File Offset: 0x00025B0D
	public void ActivateJumpRope()
	{
		this.jumpRopeScreen.SetActive(true);
		this.jumpRope = true;
		this.frozenPosition = base.transform.position;
	}

	// Token: 0x060009FD RID: 2557 RVA: 0x00027733 File Offset: 0x00025B33
	public void DeactivateJumpRope()
	{
		this.jumpRopeScreen.SetActive(false);
		this.jumpRope = false;
	}

	// Token: 0x060009FE RID: 2558 RVA: 0x00027748 File Offset: 0x00025B48
	public void ActivateBoots()
	{
		this.bootsActive = true;
		base.StartCoroutine(this.BootTimer());
	}

	// Token: 0x060009FF RID: 2559 RVA: 0x00027760 File Offset: 0x00025B60
	private IEnumerator BootTimer()
	{
		float time = 15f;
		while (time > 0f)
		{
			time -= Time.deltaTime;
			yield return null;
		}
		this.bootsActive = false;
		yield break;
	}

	// Token: 0x04000726 RID: 1830
	public GameControllerScript gc;

	// Token: 0x04000727 RID: 1831
	public BaldiScript baldi;

	// Token: 0x04000728 RID: 1832
	public DoorScript door;

	// Token: 0x04000729 RID: 1833
	public PlaytimeScript playtime;

	// Token: 0x0400072A RID: 1834
	public bool gameOver;

	// Token: 0x0400072B RID: 1835
	public bool jumpRope;

	// Token: 0x0400072C RID: 1836
	public bool sweeping;

	// Token: 0x0400072D RID: 1837
	public bool hugging;

	// Token: 0x0400072E RID: 1838
	public bool bootsActive;

	// Token: 0x0400072F RID: 1839
	public int principalBugFixer;

	// Token: 0x04000730 RID: 1840
	public float sweepingFailsave;

	// Token: 0x04000731 RID: 1841
	public float fliparoo;

	// Token: 0x04000732 RID: 1842
	public float flipaturn;

	// Token: 0x04000733 RID: 1843
	private Quaternion playerRotation;

	// Token: 0x04000734 RID: 1844
	public Vector3 frozenPosition;

	// Token: 0x04000735 RID: 1845
	private bool sensitivityActive;

	// Token: 0x04000736 RID: 1846
	private float sensitivity;

	// Token: 0x04000737 RID: 1847
	public float mouseSensitivity;

	// Token: 0x04000738 RID: 1848
	public float walkSpeed;

	// Token: 0x04000739 RID: 1849
	public float runSpeed;

	// Token: 0x0400073A RID: 1850
	public float slowSpeed;

	// Token: 0x0400073B RID: 1851
	public float maxStamina;

	// Token: 0x0400073C RID: 1852
	public float staminaRate;

	// Token: 0x0400073D RID: 1853
	public float guilt;

	// Token: 0x0400073E RID: 1854
	public float initGuilt;

	// Token: 0x0400073F RID: 1855
	private float moveX;

	// Token: 0x04000740 RID: 1856
	private float moveZ;

	// Token: 0x04000741 RID: 1857
	private Vector3 moveDirection;

	// Token: 0x04000742 RID: 1858
	private float playerSpeed;

	// Token: 0x04000743 RID: 1859
	public float stamina;

	// Token: 0x04000744 RID: 1860
	public CharacterController cc;

	// Token: 0x04000745 RID: 1861
	public NavMeshAgent gottaSweep;

	// Token: 0x04000746 RID: 1862
	public NavMeshAgent firstPrize;

	// Token: 0x04000747 RID: 1863
	public Transform firstPrizeTransform;

	// Token: 0x04000748 RID: 1864
	public Slider staminaBar;

	// Token: 0x04000749 RID: 1865
	public float db;

	// Token: 0x0400074A RID: 1866
	public string guiltType;

	// Token: 0x0400074B RID: 1867
	public GameObject jumpRopeScreen;

	// Token: 0x0400074C RID: 1868
	//private Player player;

	// Token: 0x0400074D RID: 1869
	public float height;

	// Token: 0x0400074E RID: 1870
	public Material blackSky;

	// Token: 0x0400074F RID: 1871
	public Canvas hud;

	// Token: 0x04000750 RID: 1872
	public Canvas mobile1;

	// Token: 0x04000751 RID: 1873
	public Canvas mobile2;
}
