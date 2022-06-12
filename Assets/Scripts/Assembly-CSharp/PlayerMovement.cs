using System;
//using Rewired;
using UnityEngine;

// Token: 0x020000D7 RID: 215
public class PlayerMovement : MonoBehaviour
{
	// Token: 0x060009EA RID: 2538 RVA: 0x00026C4A File Offset: 0x0002504A
	private void Awake()
	{
		this.mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity");
		//this.reInput = ReInput.players.GetPlayer(0);
	}

	// Token: 0x060009EB RID: 2539 RVA: 0x00026C6D File Offset: 0x0002506D
	private void Start()
	{
		this.stamina = this.staminaMax;
		Time.timeScale = 1f;
	}

	// Token: 0x060009EC RID: 2540 RVA: 0x00026C85 File Offset: 0x00025085
	private void Update()
	{
		this.running = Input.GetButton("Run");
		this.MouseMove();
		this.PlayerMove();
		this.StaminaUpdate();
	}

	// Token: 0x060009ED RID: 2541 RVA: 0x00026CB0 File Offset: 0x000250B0
	private void MouseMove()
	{
		Quaternion rotation = base.transform.rotation;
		rotation.eulerAngles += new Vector3(0f, Input.GetAxis("Mouse X") * this.mouseSensitivity * Time.deltaTime * Time.timeScale, 0f);
		base.transform.rotation = rotation;
	}

	// Token: 0x060009EE RID: 2542 RVA: 0x00026D1C File Offset: 0x0002511C
	private void PlayerMove()
	{
		float d = this.walkSpeed;
		if (this.stamina > 0f & this.running)
		{
			d = this.runSpeed;
		}
		Vector3 a = base.transform.right * Input.GetAxis("Strafe");
		Vector3 b = base.transform.forward * Input.GetAxis("Forward");
		this.sensitivity = Mathf.Clamp((a + b).magnitude, 0f, 1f);
		this.cc.Move((a + b).normalized * d * this.sensitivity * Time.deltaTime);
	}

	// Token: 0x060009EF RID: 2543 RVA: 0x00026DF0 File Offset: 0x000251F0
	public void StaminaUpdate()
	{
		if (this.cc.velocity.magnitude > this.cc.minMoveDistance)
		{
			if (this.running)
			{
				this.stamina = Mathf.Max(this.stamina - this.staminaDrop * Time.deltaTime, 0f);
			}
		}
		else if (this.stamina < this.staminaMax)
		{
			this.stamina += this.staminaRise * Time.deltaTime;
		}
	}

	// Token: 0x0400071B RID: 1819
	//private Player reInput;

	// Token: 0x0400071C RID: 1820
	public CharacterController cc;

	// Token: 0x0400071D RID: 1821
	public float walkSpeed;

	// Token: 0x0400071E RID: 1822
	public float runSpeed;

	// Token: 0x0400071F RID: 1823
	public float stamina;

	// Token: 0x04000720 RID: 1824
	public float staminaDrop;

	// Token: 0x04000721 RID: 1825
	public float staminaRise;

	// Token: 0x04000722 RID: 1826
	public float staminaMax;

	// Token: 0x04000723 RID: 1827
	private float sensitivity;

	// Token: 0x04000724 RID: 1828
	private float mouseSensitivity;

	// Token: 0x04000725 RID: 1829
	private bool running;
}
