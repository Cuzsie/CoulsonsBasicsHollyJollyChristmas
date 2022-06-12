using System;
using System.Collections;
//using Rewired;
//using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x020000C7 RID: 199
public class GameControllerScript : MonoBehaviour
{
	// Token: 0x0600097A RID: 2426 RVA: 0x00022400 File Offset: 0x00020800
	public GameControllerScript()
	{
		int[] array = new int[3];
		array[0] = -80;
		array[1] = -40;
		this.itemSelectOffset = array;
		//base..ctor();
	}

	// Token: 0x0600097B RID: 2427 RVA: 0x000224CC File Offset: 0x000208CC
	private void Start()
	{
		//this.playerInput = ReInput.players.GetPlayer(0);
		this.cullingMask = this.camera.cullingMask;
		this.audioDevice = base.GetComponent<AudioSource>();
		this.mode = PlayerPrefs.GetString("CurrentMode");
		if (this.mode == "endless")
		{
			this.baldiScrpt.endless = true;
		}
		this.schoolMusic.Play();
		this.LockMouse();
		this.UpdateNotebookCount();
		this.itemSelected = 0;
		this.gameOverDelay = 0.5f;
	}

	// Token: 0x0600097C RID: 2428 RVA: 0x00022564 File Offset: 0x00020964
	private void Update()
	{
		if (!this.learningActive)
		{
			if (Input.GetButtonDown("Pause"))
			{
				if (!this.gamePaused)
				{
					this.PauseGame();
				}
				else
				{
					this.UnpauseGame();
				}
			}
			if (Input.GetKeyDown(KeyCode.Y) & this.gamePaused)
			{
				this.ExitGame();
			}
			else if (Input.GetKeyDown(KeyCode.N) & this.gamePaused)
			{
				this.UnpauseGame();
			}
			if (!this.gamePaused & Time.timeScale != 1f)
			{
				Time.timeScale = 1f;
			}
			if (Input.GetMouseButtonDown(1) && Time.timeScale != 0f)
			{
				this.UseItem();
			}
			if (Input.GetAxis("Mouse ScrollWheel") > 0f & Time.timeScale != 0f)
			{
				this.DecreaseItemSelection();
			}
			else if (Input.GetAxis("Mouse ScrollWheel") < 0f & Time.timeScale != 0f)
			{
				this.IncreaseItemSelection();
			}
			if (Time.timeScale != 0f)
			{
				if (Input.GetKeyDown(KeyCode.Alpha1))
				{
					this.itemSelected = 0;
					this.UpdateItemSelection();
				}
				else if (Input.GetKeyDown(KeyCode.Alpha2))
				{
					this.itemSelected = 1;
					this.UpdateItemSelection();
				}
				else if (Input.GetKeyDown(KeyCode.Alpha3))
				{
					this.itemSelected = 2;
					this.UpdateItemSelection();
				}
			}
		}
		else
		{
			if (Time.timeScale != 0f)
			{
				Time.timeScale = 0f;
			}
			//if (ReInput.controllers.GetLastActiveControllerType() == ControllerType.Joystick)
			//{
				//this.cursorController.LockCursor();
			//}
			//else
			//{
				//this.cursorController.UnlockCursor();
			//}
		}
		if (this.player.stamina < 0f & !this.warning.activeSelf)
		{
			this.warning.SetActive(true);
		}
		else if (this.player.stamina > 0f & this.warning.activeSelf)
		{
			this.warning.SetActive(false);
		}
		if (this.player.gameOver)
		{
			if (this.mode == "endless" && this.notebooks > PlayerPrefs.GetInt("HighBooks") && !this.highScoreText.activeSelf)
			{
				this.highScoreText.SetActive(true);
			}
			Time.timeScale = 0f;
			this.gameOverDelay -= Time.unscaledDeltaTime * 0.5f;
			this.camera.farClipPlane = this.gameOverDelay * 400f;
			this.audioDevice.PlayOneShot(this.aud_buzz);
			if (PlayerPrefs.GetInt("Rumble") == 1)
			{
				//this.playerInput.SetVibration(0, 1f, 0.5f);
				//this.playerInput.SetVibration(1, 1f, 0.5f);
			}
			if (this.gameOverDelay <= 0f)
			{
				if (this.mode == "endless")
				{
					if (this.notebooks > PlayerPrefs.GetInt("HighBooks"))
					{
						PlayerPrefs.SetInt("HighBooks", this.notebooks);
					}
					PlayerPrefs.SetInt("CurrentBooks", this.notebooks);
				}
				Time.timeScale = 1f;
				SceneManager.LoadScene("GameOver");
			}
		}
		if (this.finaleMode && !this.audioDevice.isPlaying && this.exitsReached == 3)
		{
			this.audioDevice.clip = this.aud_MachineLoop;
			this.audioDevice.loop = true;
			this.audioDevice.Play();
		}
	}

	// Token: 0x0600097D RID: 2429 RVA: 0x00022994 File Offset: 0x00020D94
	private void UpdateNotebookCount()
	{
		if (this.mode == "story")
		{
			if (this.notebooks <= 7)
			{
				this.notebookCount.text = this.notebooks.ToString() + "/7 Notebooks";
			}
			else if (this.notebooks == 8)
			{
				this.notebookCount.text = this.notebooks.ToString() + "/8 Notebooks";
			}
			else
			{
				this.notebookCount.text = this.notebooks.ToString() + "/9 Notebooks";
			}
		}
		else
		{
			this.notebookCount.text = this.notebooks.ToString() + " Notebooks";
		}
		if (this.notebooks == 7 & this.mode == "story")
		{
			this.ActivateFinaleMode();
		}
	}

	// Token: 0x0600097E RID: 2430 RVA: 0x00022A9A File Offset: 0x00020E9A
	public void CollectNotebook()
	{
		this.notebooks++;
		this.UpdateNotebookCount();
	}

	// Token: 0x0600097F RID: 2431 RVA: 0x00022AB0 File Offset: 0x00020EB0
	public void LockMouse()
	{
		if (!this.learningActive)
		{
			this.cursorController.LockCursor();
			this.mouseLocked = true;
			this.reticle.SetActive(true);
		}
	}

	// Token: 0x06000980 RID: 2432 RVA: 0x00022ADB File Offset: 0x00020EDB
	public void UnlockMouse()
	{
		this.cursorController.UnlockCursor();
		this.mouseLocked = false;
		this.reticle.SetActive(false);
	}

	// Token: 0x06000981 RID: 2433 RVA: 0x00022AFB File Offset: 0x00020EFB
	public void PauseGame()
	{
		if (!this.learningActive)
		{
			this.UnlockMouse();
			Time.timeScale = 0f;
			this.gamePaused = true;
			this.pauseMenu.SetActive(true);
		}
	}

	// Token: 0x06000982 RID: 2434 RVA: 0x00022B3B File Offset: 0x00020F3B
	public void ExitGame()
	{
		SceneManager.LoadScene("MainMenu");
	}

	// Token: 0x06000983 RID: 2435 RVA: 0x00022B47 File Offset: 0x00020F47
	public void UnpauseGame()
	{
		Time.timeScale = 1f;
		this.gamePaused = false;
		this.pauseMenu.SetActive(false);
		this.LockMouse();
	}

	// Token: 0x06000984 RID: 2436 RVA: 0x00022B6C File Offset: 0x00020F6C
	public void ActivateSpoopMode()
	{
		this.spoopMode = true;
		this.entrance_0.Lower();
		this.entrance_1.Lower();
		this.entrance_2.Lower();
		this.entrance_3.Lower();
		this.baldiTutor.SetActive(false);
		this.baldi.SetActive(true);
		this.principal.SetActive(true);
		this.crafters.SetActive(true);
		this.playtime.SetActive(true);
		this.gottaSweep.SetActive(true);
		this.bully.SetActive(true);
		this.firstPrize.SetActive(true);
		this.audioDevice.PlayOneShot(this.aud_Hang);
		this.learnMusic.Stop();
		this.schoolMusic.Stop();
	}

	// Token: 0x06000985 RID: 2437 RVA: 0x00022C33 File Offset: 0x00021033
	public void GlitchBook()
	{
		if (this.glitchActive)
		{
			this.learnMusic.loop = false;
			base.StartCoroutine(this.PlayGlitchEnd());
		}
	}

	// Token: 0x06000986 RID: 2438 RVA: 0x00022C5C File Offset: 0x0002105C
	private IEnumerator PlayGlitchEnd()
	{
		while (this.learnMusic.isPlaying)
		{
			yield return null;
		}
		this.learnMusic.clip = this.glitchMusicEnd;
		this.learnMusic.Play();
		yield break;
	}

	// Token: 0x06000987 RID: 2439 RVA: 0x00022C77 File Offset: 0x00021077
	private void ActivateFinaleMode()
	{
		this.finaleMode = true;
		this.entrance_0.Raise();
		this.entrance_1.Raise();
		this.entrance_3.Raise();
	}

	// Token: 0x06000988 RID: 2440 RVA: 0x00022CA1 File Offset: 0x000210A1
	public void GetAngry(float value)
	{
		if (!this.spoopMode)
		{
			this.ActivateSpoopMode();
		}
		this.baldiScrpt.GetAngry(value);
	}

	// Token: 0x06000989 RID: 2441 RVA: 0x00022CC0 File Offset: 0x000210C0
	public void ActivateLearningGame()
	{
		this.camera.cullingMask = 0;
		this.learningActive = true;
		//if (ReInput.controllers.GetLastActiveControllerType() != ControllerType.Joystick)
		//{
			this.UnlockMouse();
		//}
		this.tutorBaldi.Stop();
		this.learnMusic.loop = true;
		if (!this.spoopMode)
		{
			this.schoolMusic.Stop();
			this.learnMusic.Play();
		}
		if (this.glitchActive)
		{
			this.learnMusic.clip = this.glitchMusic;
			this.learnMusic.Play();
		}
	}

	// Token: 0x0600098A RID: 2442 RVA: 0x00022D58 File Offset: 0x00021158
	public void DeactivateLearningGame(GameObject subject)
	{
		this.camera.cullingMask = this.cullingMask;
		this.learningActive = false;
		UnityEngine.Object.Destroy(subject);
		this.LockMouse();
		if (this.player.stamina < 100f)
		{
			this.player.stamina = 100f;
		}
		if (!this.spoopMode)
		{
			this.schoolMusic.Play();
			this.learnMusic.Stop();
		}
		if (this.notebooks == 1 & !this.spoopMode)
		{
			PickupScript pickupScript = UnityEngine.Object.Instantiate<PickupScript>(this.giftItems[WeightedSelection<int>.RandomSelection(this.baldiItems)]);
			pickupScript.gc = this;
			pickupScript.player = this.player.transform;
			pickupScript.transform.position = this.quarter.transform.position;
			pickupScript.transform.name = pickupScript.transform.name.Replace("(Clone)", string.Empty);
			this.tutorBaldi.PlayOneShot(this.aud_Prize);
		}
		else if (this.notebooks == 7 & this.mode == "story")
		{
			this.audioDevice.PlayOneShot(this.aud_AllNotebooks, 0.8f);
		}
	}

	// Token: 0x0600098B RID: 2443 RVA: 0x00022EA4 File Offset: 0x000212A4
	private void IncreaseItemSelection()
	{
		this.itemSelected++;
		if (this.itemSelected > 2)
		{
			this.itemSelected = 0;
		}
		this.itemSelect.anchoredPosition = new Vector3((float)this.itemSelectOffset[this.itemSelected], 0f, 0f);
		this.UpdateItemName();
	}

	// Token: 0x0600098C RID: 2444 RVA: 0x00022F08 File Offset: 0x00021308
	private void DecreaseItemSelection()
	{
		this.itemSelected--;
		if (this.itemSelected < 0)
		{
			this.itemSelected = 2;
		}
		this.itemSelect.anchoredPosition = new Vector3((float)this.itemSelectOffset[this.itemSelected], 0f, 0f);
		this.UpdateItemName();
	}

	// Token: 0x0600098D RID: 2445 RVA: 0x00022F69 File Offset: 0x00021369
	private void UpdateItemSelection()
	{
		this.itemSelect.anchoredPosition = new Vector3((float)this.itemSelectOffset[this.itemSelected], 0f, 0f);
		this.UpdateItemName();
	}

	// Token: 0x0600098E RID: 2446 RVA: 0x00022FA0 File Offset: 0x000213A0
	public void CollectItem(int item_ID)
	{
		if (this.item[0] == 0)
		{
			this.item[0] = item_ID;
			this.itemSlot[0].texture = this.itemTextures[item_ID];
		}
		else if (this.item[1] == 0)
		{
			this.item[1] = item_ID;
			this.itemSlot[1].texture = this.itemTextures[item_ID];
		}
		else if (this.item[2] == 0)
		{
			this.item[2] = item_ID;
			this.itemSlot[2].texture = this.itemTextures[item_ID];
		}
		else
		{
			this.item[this.itemSelected] = item_ID;
			this.itemSlot[this.itemSelected].texture = this.itemTextures[item_ID];
		}
		this.UpdateItemName();
	}

	// Token: 0x0600098F RID: 2447 RVA: 0x0002306C File Offset: 0x0002146C
	private void UseItem()
	{
		if (this.item[this.itemSelected] != 0)
		{
			if (this.item[this.itemSelected] == 1)
			{
				this.player.stamina = this.player.maxStamina * 2f;
				this.ResetItem();
			}
			else if (this.item[this.itemSelected] == 2)
			{
				Ray ray = Camera.main.ScreenPointToRay(new Vector3((float)(Screen.width / 2), (float)(Screen.height / 2), 0f));
				RaycastHit raycastHit;
				if (Physics.Raycast(ray, out raycastHit) && (raycastHit.collider.tag == "SwingingDoor" & Vector3.Distance(this.playerTransform.position, raycastHit.transform.position) <= 10f))
				{
					raycastHit.collider.gameObject.GetComponent<SwingingDoorScript>().LockDoor(15f);
					this.ResetItem();
				}
			}
			else if (this.item[this.itemSelected] == 3)
			{
				Ray ray2 = Camera.main.ScreenPointToRay(new Vector3((float)(Screen.width / 2), (float)(Screen.height / 2), 0f));
				RaycastHit raycastHit2;
				if (Physics.Raycast(ray2, out raycastHit2) && (raycastHit2.collider.tag == "Door" & Vector3.Distance(this.playerTransform.position, raycastHit2.transform.position) <= 10f))
				{
					DoorScript component = raycastHit2.collider.gameObject.GetComponent<DoorScript>();
					if (component.DoorLocked)
					{
						component.UnlockDoor();
						component.OpenDoor();
						this.ResetItem();
					}
				}
			}
			else if (this.item[this.itemSelected] == 4)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.bsodaSpray, this.playerTransform.position, this.cameraTransform.rotation);
				this.ResetItem();
				this.player.ResetGuilt("drink", 1f);
				this.audioDevice.PlayOneShot(this.aud_Soda);
			}
			else if (this.item[this.itemSelected] == 5)
			{
				Ray ray3 = Camera.main.ScreenPointToRay(new Vector3((float)(Screen.width / 2), (float)(Screen.height / 2), 0f));
				RaycastHit raycastHit3;
				if (Physics.Raycast(ray3, out raycastHit3))
				{
					if ((raycastHit3.collider.name == "BSODAMachine" || raycastHit3.collider.name == "ZestyMachine") & Vector3.Distance(this.playerTransform.position, raycastHit3.transform.position) <= 10f)
					{
						this.ResetItem();
						this.CollectItem(WeightedSelection<int>.RandomSelection(this.machineItems));
					}
					else if (raycastHit3.collider.name == "PayPhone" & Vector3.Distance(this.playerTransform.position, raycastHit3.transform.position) <= 10f)
					{
						raycastHit3.collider.gameObject.GetComponent<TapePlayerScript>().Play();
						this.ResetItem();
					}
				}
			}
			else if (this.item[this.itemSelected] == 6)
			{
				Ray ray4 = Camera.main.ScreenPointToRay(new Vector3((float)(Screen.width / 2), (float)(Screen.height / 2), 0f));
				RaycastHit raycastHit4;
				if (Physics.Raycast(ray4, out raycastHit4) && (raycastHit4.collider.name == "TapePlayer" & Vector3.Distance(this.playerTransform.position, raycastHit4.transform.position) <= 10f))
				{
					raycastHit4.collider.gameObject.GetComponent<TapePlayerScript>().Play();
					this.ResetItem();
				}
			}
			else if (this.item[this.itemSelected] == 7)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.alarmClock, this.playerTransform.position, this.cameraTransform.rotation);
				gameObject.GetComponent<AlarmClockScript>().baldi = this.baldiScrpt;
				this.ResetItem();
			}
			else if (this.item[this.itemSelected] == 8)
			{
				Ray ray5 = Camera.main.ScreenPointToRay(new Vector3((float)(Screen.width / 2), (float)(Screen.height / 2), 0f));
				RaycastHit raycastHit5;
				if (Physics.Raycast(ray5, out raycastHit5) && (raycastHit5.collider.tag == "Door" & Vector3.Distance(this.playerTransform.position, raycastHit5.transform.position) <= 10f))
				{
					raycastHit5.collider.gameObject.GetComponent<DoorScript>().SilenceDoor();
					this.ResetItem();
					this.audioDevice.PlayOneShot(this.aud_Spray);
				}
			}
			else if (this.item[this.itemSelected] == 9)
			{
				Ray ray6 = Camera.main.ScreenPointToRay(new Vector3((float)(Screen.width / 2), (float)(Screen.height / 2), 0f));
				RaycastHit raycastHit6;
				if (this.player.jumpRope)
				{
					this.player.DeactivateJumpRope();
					this.playtimeScript.Disappoint();
					this.ResetItem();
				}
				else if (Physics.Raycast(ray6, out raycastHit6) && raycastHit6.collider.name == "1st Prize")
				{
					this.firstPrizeScript.GoCrazy();
					this.ResetItem();
				}
			}
			else if (this.item[this.itemSelected] == 10)
			{
				this.player.ActivateBoots();
				base.StartCoroutine(this.BootAnimation());
				this.ResetItem();
			}
			else if (this.item[this.itemSelected] == 11)
			{
				base.StartCoroutine(this.Teleporter());
				this.ResetItem();
			}
		}
	}

	// Token: 0x06000990 RID: 2448 RVA: 0x00023684 File Offset: 0x00021A84
	private IEnumerator BootAnimation()
	{
		float time = 15f;
		float height = 375f;
		Vector3 position = default(Vector3);
		this.boots.gameObject.SetActive(true);
		while (height > -375f)
		{
			height -= 375f * Time.deltaTime;
			time -= Time.deltaTime;
			position = this.boots.localPosition;
			position.y = height;
			this.boots.localPosition = position;
			yield return null;
		}
		position = this.boots.localPosition;
		position.y = -375f;
		this.boots.localPosition = position;
		this.boots.gameObject.SetActive(false);
		while (time > 0f)
		{
			time -= Time.deltaTime;
			yield return null;
		}
		this.boots.gameObject.SetActive(true);
		while (height < 375f)
		{
			height += 375f * Time.deltaTime;
			position = this.boots.localPosition;
			position.y = height;
			this.boots.localPosition = position;
			yield return null;
		}
		position = this.boots.localPosition;
		position.y = 375f;
		this.boots.localPosition = position;
		this.boots.gameObject.SetActive(false);
		yield break;
	}

	// Token: 0x06000991 RID: 2449 RVA: 0x000236A0 File Offset: 0x00021AA0
	private IEnumerator Teleporter()
	{
		this.playerCharacter.enabled = false;
		this.playerCollider.enabled = false;
		int teleports = UnityEngine.Random.Range(12, 16);
		int teleportCount = 0;
		float baseTime = 0.2f;
		float currentTime = baseTime;
		float increaseFactor = 1.1f;
		while (teleportCount < teleports)
		{
			currentTime -= Time.deltaTime;
			if (currentTime < 0f)
			{
				this.Teleport();
				teleportCount++;
				baseTime *= increaseFactor;
				currentTime = baseTime;
			}
			if (this.flipped)
			{
				this.player.height = 6f;
			}
			else
			{
				this.player.height = 4f;
			}
			yield return null;
		}
		this.playerCharacter.enabled = true;
		this.playerCollider.enabled = true;
		yield break;
	}

	// Token: 0x06000992 RID: 2450 RVA: 0x000236BC File Offset: 0x00021ABC
	private void Teleport()
	{
		this.AILocationSelector.GetNewTarget();
		this.player.transform.position = this.AILocationSelector.transform.position + Vector3.up * this.player.height;
		this.audioDevice.PlayOneShot(this.aud_Teleport);
	}

	// Token: 0x06000993 RID: 2451 RVA: 0x0002371F File Offset: 0x00021B1F
	private void ResetItem()
	{
		this.item[this.itemSelected] = 0;
		this.itemSlot[this.itemSelected].texture = this.itemTextures[0];
		this.UpdateItemName();
	}

	// Token: 0x06000994 RID: 2452 RVA: 0x0002374F File Offset: 0x00021B4F
	public void LoseItem(int id)
	{
		this.item[id] = 0;
		this.itemSlot[id].texture = this.itemTextures[0];
		this.UpdateItemName();
	}

	// Token: 0x06000995 RID: 2453 RVA: 0x00023775 File Offset: 0x00021B75
	private void UpdateItemName()
	{
		this.itemText.text = this.itemNames[this.item[this.itemSelected]];
	}

	// Token: 0x06000996 RID: 2454 RVA: 0x00023798 File Offset: 0x00021B98
	public void ExitReached()
	{
		this.exitsReached++;
		if (this.exitsReached == 1)
		{
			RenderSettings.ambientLight = Color.red;
			RenderSettings.fog = true;
			this.audioDevice.PlayOneShot(this.aud_Switch, 0.8f);
			this.audioDevice.clip = this.aud_MachineQuiet;
			this.audioDevice.loop = true;
			this.audioDevice.Play();
		}
		if (this.exitsReached == 2)
		{
			this.audioDevice.volume = 0.8f;
			this.audioDevice.clip = this.aud_MachineStart;
			this.audioDevice.loop = true;
			this.audioDevice.Play();
		}
		if (this.exitsReached == 3)
		{
			this.entrance_2.Raise();
			this.audioDevice.clip = this.aud_MachineRev;
			this.audioDevice.loop = false;
			this.audioDevice.Play();
		}
	}

	// Token: 0x06000997 RID: 2455 RVA: 0x00023890 File Offset: 0x00021C90
	public void Surprise()
	{
		this.finaleMode = false;
		this.surpriseActive = true;
		this.baldi.SetActive(false);
		this.principal.SetActive(false);
		this.crafters.SetActive(false);
		this.playtime.SetActive(false);
		this.gottaSweep.SetActive(false);
		this.bully.SetActive(false);
		this.firstPrize.SetActive(false);
		this.audioDevice.Stop();
		this.audioDevice.PlayOneShot(this.aud_Switch);
		RenderSettings.ambientLight = Color.white;
		RenderSettings.fog = false;
		foreach (GameObject gameObject in this.surprises)
		{
			gameObject.SetActive(true);
		}
	}

	// Token: 0x06000998 RID: 2456 RVA: 0x00023954 File Offset: 0x00021D54
	public void Glitch()
	{
		this.environment2.SetActive(true);
		this.audioDevice.PlayOneShot(this.aud_Blow);
		this.glitchActive = true;
		this.playerCharacter.enabled = true;
		RenderSettings.ambientLight = Color.gray;
		this.audioDevice.clip = this.aud_GlitchLoop;
		this.audioDevice.loop = true;
		this.audioDevice.Play();
		base.StartCoroutine(this.FloatCharacters());
		this.filename2.SetActive(true);
		this.balloons.SetActive(false);
		RenderSettings.skybox = this.blackSky;
	}

	// Token: 0x06000999 RID: 2457 RVA: 0x000239F4 File Offset: 0x00021DF4
	private IEnumerator FloatCharacters()
	{
		foreach (GameObject gameObject in this.surprises)
		{
			gameObject.transform.position = new Vector3(UnityEngine.Random.Range(-100f, 25f), 0f, UnityEngine.Random.Range(250f, 340f));
		}
		float height = 0f;
		float speed = 20f;
		Vector3 _position = default(Vector3);
		while (height < 40f)
		{
			height += speed * Time.deltaTime;
			foreach (GameObject gameObject2 in this.surprises)
			{
				_position = gameObject2.transform.position;
				_position.y = height;
				gameObject2.transform.position = _position;
			}
			yield return null;
		}
		this.surprises[7].gameObject.SetActive(false);
		this.surprises[8].gameObject.SetActive(false);
		yield break;
	}

	// Token: 0x0600099A RID: 2458 RVA: 0x00023A0F File Offset: 0x00021E0F
	public void DespawnCrafters()
	{
		this.crafters.SetActive(false);
	}

	// Token: 0x0600099B RID: 2459 RVA: 0x00023A20 File Offset: 0x00021E20
	public void Fliparoo()
	{
		this.flipped = true;
		this.player.height = 6f;
		this.player.fliparoo = 180f;
		this.player.flipaturn = -1f;
		Camera.main.GetComponent<CameraScript>().offset = new Vector3(0f, -1f, 0f);
	}

	// Token: 0x04000620 RID: 1568
	public CursorControllerScript cursorController;

	// Token: 0x04000621 RID: 1569
	public PlayerScript player;

	// Token: 0x04000622 RID: 1570
	public Transform playerTransform;

	// Token: 0x04000623 RID: 1571
	public CharacterController playerCharacter;

	// Token: 0x04000624 RID: 1572
	public Collider playerCollider;

	// Token: 0x04000625 RID: 1573
	public AILocationSelectorScript AILocationSelector;

	// Token: 0x04000626 RID: 1574
	public Transform cameraTransform;

	// Token: 0x04000627 RID: 1575
	public Camera camera;

	// Token: 0x04000628 RID: 1576
	private int cullingMask;

	// Token: 0x04000629 RID: 1577
	public EntranceScript entrance_0;

	// Token: 0x0400062A RID: 1578
	public EntranceScript entrance_1;

	// Token: 0x0400062B RID: 1579
	public EntranceScript entrance_2;

	// Token: 0x0400062C RID: 1580
	public EntranceScript entrance_3;

	// Token: 0x0400062D RID: 1581
	public GameObject baldiTutor;

	// Token: 0x0400062E RID: 1582
	public GameObject baldi;

	// Token: 0x0400062F RID: 1583
	public GameObject environment2;

	// Token: 0x04000630 RID: 1584
	public BaldiScript baldiScrpt;

	// Token: 0x04000631 RID: 1585
	public AudioClip aud_Prize;

	// Token: 0x04000632 RID: 1586
	public AudioClip aud_PrizeMobile;

	// Token: 0x04000633 RID: 1587
	public AudioClip aud_AllNotebooks;

	// Token: 0x04000634 RID: 1588
	public AudioClip aud_Teleport;

	// Token: 0x04000635 RID: 1589
	private bool flipped;

	// Token: 0x04000636 RID: 1590
	public GameObject principal;

	// Token: 0x04000637 RID: 1591
	public GameObject filename2;

	// Token: 0x04000638 RID: 1592
	public GameObject balloons;

	// Token: 0x04000639 RID: 1593
	public GameObject crafters;

	// Token: 0x0400063A RID: 1594
	public GameObject playtime;

	// Token: 0x0400063B RID: 1595
	public PlaytimeScript playtimeScript;

	// Token: 0x0400063C RID: 1596
	public GameObject gottaSweep;

	// Token: 0x0400063D RID: 1597
	public GameObject bully;

	// Token: 0x0400063E RID: 1598
	public GameObject firstPrize;

	// Token: 0x0400063F RID: 1599
	public FirstPrizeScript firstPrizeScript;

	// Token: 0x04000640 RID: 1600
	public GameObject quarter;

	// Token: 0x04000641 RID: 1601
	public AudioSource tutorBaldi;

	// Token: 0x04000642 RID: 1602
	public RectTransform boots;

	// Token: 0x04000643 RID: 1603
	public string mode;

	// Token: 0x04000644 RID: 1604
	public int notebooks;

	// Token: 0x04000645 RID: 1605
	public GameObject[] notebookPickups;

	// Token: 0x04000646 RID: 1606
	public int failedNotebooks;

	// Token: 0x04000647 RID: 1607
	public bool spoopMode;

	// Token: 0x04000648 RID: 1608
	public bool finaleMode;

	// Token: 0x04000649 RID: 1609
	public bool debugMode;

	// Token: 0x0400064A RID: 1610
	public bool mouseLocked;

	// Token: 0x0400064B RID: 1611
	public int exitsReached;

	// Token: 0x0400064C RID: 1612
	public int itemSelected;

	// Token: 0x0400064D RID: 1613
	public int[] item = new int[3];

	// Token: 0x0400064E RID: 1614
	public RawImage[] itemSlot = new RawImage[3];

	// Token: 0x0400064F RID: 1615
	private string[] itemNames = new string[]
	{
		"Nothing",
		"Carrot",
		"Yellow Door Lock",
		"Emilees Keys",
		"Seltzer",
		"Coulson Coin",
		"Dog Whistle",
		"Bird",
		"No Sound Door Spray",
		"Safety Scissors",
		"Big Ol' Boots",
		"Coulsons Teleportation Machine"
	};

	// Token: 0x04000650 RID: 1616
	public Text itemText;

	// Token: 0x04000651 RID: 1617
	public UnityEngine.Object[] items = new UnityEngine.Object[10];

	// Token: 0x04000652 RID: 1618
	public Texture[] itemTextures = new Texture[10];

	// Token: 0x04000653 RID: 1619
	public GameObject bsodaSpray;

	// Token: 0x04000654 RID: 1620
	public GameObject alarmClock;

	// Token: 0x04000655 RID: 1621
	public WeightedItem[] baldiItems;

	// Token: 0x04000656 RID: 1622
	public WeightedItem[] machineItems;

	// Token: 0x04000657 RID: 1623
	public PickupScript[] giftItems;

	// Token: 0x04000658 RID: 1624
	public Text notebookCount;

	// Token: 0x04000659 RID: 1625
	public GameObject pauseMenu;

	// Token: 0x0400065A RID: 1626
	public GameObject highScoreText;

	// Token: 0x0400065B RID: 1627
	public GameObject warning;

	// Token: 0x0400065C RID: 1628
	public GameObject reticle;

	// Token: 0x0400065D RID: 1629
	public RectTransform itemSelect;

	// Token: 0x0400065E RID: 1630
	private int[] itemSelectOffset;

	// Token: 0x0400065F RID: 1631
	private bool gamePaused;

	// Token: 0x04000660 RID: 1632
	private bool learningActive;

	// Token: 0x04000661 RID: 1633
	private float gameOverDelay;

	// Token: 0x04000662 RID: 1634
	public bool surpriseActive;

	// Token: 0x04000663 RID: 1635
	public bool glitchActive;

	// Token: 0x04000664 RID: 1636
	private AudioSource audioDevice;

	// Token: 0x04000665 RID: 1637
	public AudioClip aud_Soda;

	// Token: 0x04000666 RID: 1638
	public AudioClip aud_Spray;

	// Token: 0x04000667 RID: 1639
	public AudioClip aud_buzz;

	// Token: 0x04000668 RID: 1640
	public AudioClip aud_Hang;

	// Token: 0x04000669 RID: 1641
	public AudioClip aud_MachineQuiet;

	// Token: 0x0400066A RID: 1642
	public AudioClip aud_MachineStart;

	// Token: 0x0400066B RID: 1643
	public AudioClip aud_MachineRev;

	// Token: 0x0400066C RID: 1644
	public AudioClip aud_MachineLoop;

	// Token: 0x0400066D RID: 1645
	public AudioClip aud_Switch;

	// Token: 0x0400066E RID: 1646
	public AudioClip aud_GlitchLoop;

	// Token: 0x0400066F RID: 1647
	public AudioClip aud_Blow;

	// Token: 0x04000670 RID: 1648
	public AudioClip glitchMusic;

	// Token: 0x04000671 RID: 1649
	public AudioClip glitchMusicEnd;

	// Token: 0x04000672 RID: 1650
	public AudioSource schoolMusic;

	// Token: 0x04000673 RID: 1651
	public AudioSource learnMusic;

	// Token: 0x04000674 RID: 1652
	//private Player playerInput;

	// Token: 0x04000675 RID: 1653
	public GameObject[] surprises;

	// Token: 0x04000676 RID: 1654
	public Material blackSky;
}
