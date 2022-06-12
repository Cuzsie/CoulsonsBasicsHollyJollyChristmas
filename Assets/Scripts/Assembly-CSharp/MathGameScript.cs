using System;
using System.Collections;
//using Rewired;
//using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x020000C9 RID: 201
public class MathGameScript : MonoBehaviour
{
	// Token: 0x060009A0 RID: 2464 RVA: 0x00024390 File Offset: 0x00022790
	private void Start()
	{
		this.gc.ActivateLearningGame();
		if (this.gc.notebooks == 1)
		{
			this.QueueAudio(this.bal_intro);
			this.QueueAudio(this.bal_howto);
		}
		this.NewProblem();
		if (this.gc.spoopMode)
		{
			this.baldiFeedTransform.position = new Vector3(-1000f, -1000f, 0f);
		}
		//if (ReInput.controllers.GetLastActiveControllerType() == ControllerType.Joystick)
		//{
			//this.joystickEnabled = true;
		//}
	}

	// Token: 0x060009A1 RID: 2465 RVA: 0x00024420 File Offset: 0x00022820
	private void Update()
	{
		if (!this.baldiAudio.isPlaying)
		{
			if (this.audioInQueue > 0 & !this.gc.spoopMode)
			{
				this.PlayQueue();
			}
			this.baldiFeed.SetBool("talking", false);
		}
		else
		{
			this.baldiFeed.SetBool("talking", true);
		}
		if ((Input.GetKeyDown("return") || Input.GetKeyDown("enter")) & this.questionInProgress)
		{
			this.questionInProgress = false;
			this.CheckAnswer();
		}
		if (this.problem > 3)
		{
			this.endDelay -= 1f * Time.unscaledDeltaTime;
			if (this.endDelay <= 0f)
			{
				GC.Collect();
				this.ExitGame();
			}
		}
	}

	// Token: 0x060009A2 RID: 2466 RVA: 0x00024500 File Offset: 0x00022900
	private void NewProblem()
	{
		this.playerAnswer.text = string.Empty;
		this.problem++;
		this.playerAnswer.ActivateInputField();
		if (this.problem <= 3)
		{
			this.QueueAudio(this.bal_problems[this.problem - 1]);
			if ((this.gc.mode == "story" & (this.problem <= 2 || this.gc.notebooks <= 1)) || (this.gc.mode == "endless" & (this.problem <= 2 || this.gc.notebooks != 2)))
			{
				this.num1 = (float)Mathf.RoundToInt(UnityEngine.Random.Range(0f, 9f));
				this.num2 = (float)Mathf.RoundToInt(UnityEngine.Random.Range(0f, 9f));
				this.sign = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 1f));
				this.QueueAudio(this.bal_numbers[Mathf.RoundToInt(this.num1)]);
				if (this.sign == 0)
				{
					this.solution = this.num1 + this.num2;
					this.questionText.text = string.Concat(new object[]
					{
						"SOLVE MATH Q",
						this.problem,
						": \n \n",
						this.num1,
						"+",
						this.num2,
						"="
					});
					this.QueueAudio(this.bal_plus);
				}
				else if (this.sign == 1)
				{
					this.solution = this.num1 - this.num2;
					this.questionText.text = string.Concat(new object[]
					{
						"SOLVE MATH Q",
						this.problem,
						": \n \n",
						this.num1,
						"-",
						this.num2,
						"="
					});
					this.QueueAudio(this.bal_minus);
				}
				this.QueueAudio(this.bal_numbers[Mathf.RoundToInt(this.num2)]);
				this.QueueAudio(this.bal_equals);
			}
			else
			{
				this.impossibleMode = true;
				this.num1 = UnityEngine.Random.Range(1f, 9999f);
				this.num2 = UnityEngine.Random.Range(1f, 9999f);
				this.num3 = UnityEngine.Random.Range(1f, 9999f);
				this.sign = Mathf.RoundToInt((float)UnityEngine.Random.Range(0, 1));
				this.QueueAudio(this.bal_screech);
				if (this.sign == 0)
				{
					this.questionText.text = string.Concat(new object[]
					{
						"SOLVE MATH Q",
						this.problem,
						": \n",
						this.num1,
						"+(",
						this.num2,
						"X",
						this.num3,
						"="
					});
					this.QueueAudio(this.bal_plus);
					this.QueueAudio(this.bal_screech);
					this.QueueAudio(this.bal_times);
					this.QueueAudio(this.bal_screech);
				}
				else if (this.sign == 1)
				{
					this.questionText.text = string.Concat(new object[]
					{
						"SOLVE MATH Q",
						this.problem,
						": \n (",
						this.num1,
						"/",
						this.num2,
						")+",
						this.num3,
						"="
					});
					this.QueueAudio(this.bal_divided);
					this.QueueAudio(this.bal_screech);
					this.QueueAudio(this.bal_plus);
					this.QueueAudio(this.bal_screech);
				}
				this.num1 = UnityEngine.Random.Range(1f, 9999f);
				this.num2 = UnityEngine.Random.Range(1f, 9999f);
				this.num3 = UnityEngine.Random.Range(1f, 9999f);
				this.sign = Mathf.RoundToInt((float)UnityEngine.Random.Range(0, 1));
				if (this.sign == 0)
				{
					this.questionText2.text = string.Concat(new object[]
					{
						"SOLVE MATH Q",
						this.problem,
						": \n",
						this.num1,
						"+(",
						this.num2,
						"X",
						this.num3,
						"="
					});
				}
				else if (this.sign == 1)
				{
					this.questionText2.text = string.Concat(new object[]
					{
						"SOLVE MATH Q",
						this.problem,
						": \n (",
						this.num1,
						"/",
						this.num2,
						")+",
						this.num3,
						"="
					});
				}
				this.num1 = UnityEngine.Random.Range(1f, 9999f);
				this.num2 = UnityEngine.Random.Range(1f, 9999f);
				this.num3 = UnityEngine.Random.Range(1f, 9999f);
				this.sign = Mathf.RoundToInt((float)UnityEngine.Random.Range(0, 1));
				if (this.sign == 0)
				{
					this.questionText3.text = string.Concat(new object[]
					{
						"SOLVE MATH Q",
						this.problem,
						": \n",
						this.num1,
						"+(",
						this.num2,
						"X",
						this.num3,
						"="
					});
				}
				else if (this.sign == 1)
				{
					this.questionText3.text = string.Concat(new object[]
					{
						"SOLVE MATH Q",
						this.problem,
						": \n (",
						this.num1,
						"/",
						this.num2,
						")+",
						this.num3,
						"="
					});
				}
				this.QueueAudio(this.bal_equals);
			}
			this.questionInProgress = true;
		}
		else
		{
			this.endDelay = 5f;
			if (!this.gc.spoopMode)
			{
				this.questionText.text = "WOW! YOU CAN BARK!";
			}
			else if (this.gc.mode == "endless" & this.problemsWrong <= 0)
			{
				int num = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 1f));
				this.questionText.text = this.endlessHintText[num];
			}
			else if (this.gc.mode == "story" & this.problemsWrong >= 3)
			{
				this.questionText.text = "I HEAR MATH THAT BAD";
				this.questionText2.text = string.Empty;
				this.questionText3.text = string.Empty;
				this.baldiScript.Hear(this.playerPosition, 7f);
				this.gc.failedNotebooks++;
			}
			else
			{
				int num2 = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 1f));
				this.questionText.text = this.hintText[num2];
				this.questionText2.text = string.Empty;
				this.questionText3.text = string.Empty;
			}
		}
	}

	// Token: 0x060009A3 RID: 2467 RVA: 0x00024D68 File Offset: 0x00023168
	public void OKButton()
	{
		this.CheckAnswer();
	}

	// Token: 0x060009A4 RID: 2468 RVA: 0x00024D70 File Offset: 0x00023170
	public void CheckAnswer()
	{
		if (this.playerAnswer.text == "122520")
		{
			base.StartCoroutine(this.CheatText("Jingle And Mingle!"));
			SceneManager.LoadSceneAsync("TestRoom");
		}
		else if (this.playerAnswer.text == "53045009")
		{
			base.StartCoroutine(this.CheatText("USE THESE TO STICK TO THE CEILING!"));
			this.gc.Fliparoo();
		}
		if (this.problem <= 3)
		{
			if (this.playerAnswer.text == this.solution.ToString() & !this.impossibleMode)
			{
				this.results[this.problem - 1].texture = this.correct;
				this.baldiAudio.Stop();
				this.ClearAudioQueue();
				int num = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 4f));
				this.QueueAudio(this.bal_praises[num]);
				this.NewProblem();
			}
			else
			{
				this.problemsWrong++;
				this.results[this.problem - 1].texture = this.incorrect;
				this.gc.GlitchBook();
				if (!this.gc.spoopMode)
				{
					this.baldiFeed.SetTrigger("angry");
					this.gc.ActivateSpoopMode();
				}
				if (this.gc.mode == "story")
				{
					if (this.problem == 3)
					{
						this.baldiScript.GetAngry(1f);
					}
					else
					{
						this.baldiScript.GetTempAngry(0.25f);
					}
				}
				else
				{
					this.baldiScript.GetAngry(1f);
				}
				this.ClearAudioQueue();
				this.baldiAudio.Stop();
				this.NewProblem();
			}
		}
	}

	// Token: 0x060009A5 RID: 2469 RVA: 0x00024F5A File Offset: 0x0002335A
	private void QueueAudio(AudioClip sound)
	{
		this.audioQueue[this.audioInQueue] = sound;
		this.audioInQueue++;
	}

	// Token: 0x060009A6 RID: 2470 RVA: 0x00024F78 File Offset: 0x00023378
	private void PlayQueue()
	{
		this.baldiAudio.PlayOneShot(this.audioQueue[0]);
		this.UnqueueAudio();
	}

	// Token: 0x060009A7 RID: 2471 RVA: 0x00024F94 File Offset: 0x00023394
	private void UnqueueAudio()
	{
		for (int i = 1; i < this.audioInQueue; i++)
		{
			this.audioQueue[i - 1] = this.audioQueue[i];
		}
		this.audioInQueue--;
	}

	// Token: 0x060009A8 RID: 2472 RVA: 0x00024FD8 File Offset: 0x000233D8
	private void ClearAudioQueue()
	{
		this.audioInQueue = 0;
	}

	// Token: 0x060009A9 RID: 2473 RVA: 0x00024FE4 File Offset: 0x000233E4
	private void ExitGame()
	{
		if (this.problemsWrong <= 0 & this.gc.mode == "endless")
		{
			this.baldiScript.GetAngry(-1f);
		}
		this.gc.DeactivateLearningGame(base.gameObject);
	}

	// Token: 0x060009AA RID: 2474 RVA: 0x0002503C File Offset: 0x0002343C
	public void ButtonPress(int value)
	{
		if (value >= 0 & value <= 9)
		{
			this.playerAnswer.text = this.playerAnswer.text + value;
		}
		else if (value == -1)
		{
			this.playerAnswer.text = this.playerAnswer.text + "-";
		}
		else
		{
			this.playerAnswer.text = string.Empty;
		}
	}

	// Token: 0x060009AB RID: 2475 RVA: 0x000250C0 File Offset: 0x000234C0
	private IEnumerator CheatText(string text)
	{
		for (;;)
		{
			this.questionText.text = text;
			this.questionText2.text = string.Empty;
			this.questionText3.text = string.Empty;
			yield return new WaitForEndOfFrame();
		}
		yield break;
	}

	// Token: 0x0400067D RID: 1661
	public GameControllerScript gc;

	// Token: 0x0400067E RID: 1662
	public BaldiScript baldiScript;

	// Token: 0x0400067F RID: 1663
	public Vector3 playerPosition;

	// Token: 0x04000680 RID: 1664
	public GameObject mathGame;

	// Token: 0x04000681 RID: 1665
	public RawImage[] results = new RawImage[3];

	// Token: 0x04000682 RID: 1666
	public Texture correct;

	// Token: 0x04000683 RID: 1667
	public Texture incorrect;

	// Token: 0x04000684 RID: 1668
	public InputField playerAnswer;

	// Token: 0x04000685 RID: 1669
	public Text questionText;

	// Token: 0x04000686 RID: 1670
	public Text questionText2;

	// Token: 0x04000687 RID: 1671
	public Text questionText3;

	// Token: 0x04000688 RID: 1672
	public Animator baldiFeed;

	// Token: 0x04000689 RID: 1673
	public Transform baldiFeedTransform;

	// Token: 0x0400068A RID: 1674
	public AudioClip bal_plus;

	// Token: 0x0400068B RID: 1675
	public AudioClip bal_minus;

	// Token: 0x0400068C RID: 1676
	public AudioClip bal_times;

	// Token: 0x0400068D RID: 1677
	public AudioClip bal_divided;

	// Token: 0x0400068E RID: 1678
	public AudioClip bal_equals;

	// Token: 0x0400068F RID: 1679
	public AudioClip bal_howto;

	// Token: 0x04000690 RID: 1680
	public AudioClip bal_intro;

	// Token: 0x04000691 RID: 1681
	public AudioClip bal_screech;

	// Token: 0x04000692 RID: 1682
	public AudioClip[] bal_numbers = new AudioClip[10];

	// Token: 0x04000693 RID: 1683
	public AudioClip[] bal_praises = new AudioClip[5];

	// Token: 0x04000694 RID: 1684
	public AudioClip[] bal_problems = new AudioClip[3];

	// Token: 0x04000695 RID: 1685
	public Button firstButton;

	// Token: 0x04000696 RID: 1686
	private float endDelay;

	// Token: 0x04000697 RID: 1687
	private int problem;

	// Token: 0x04000698 RID: 1688
	private int audioInQueue;

	// Token: 0x04000699 RID: 1689
	private float num1;

	// Token: 0x0400069A RID: 1690
	private float num2;

	// Token: 0x0400069B RID: 1691
	private float num3;

	// Token: 0x0400069C RID: 1692
	private int sign;

	// Token: 0x0400069D RID: 1693
	private float solution;

	// Token: 0x0400069E RID: 1694
	private string[] hintText = new string[]
	{
		"I GET ANGRIER FOR EVERY PROBLEM YOU GET WRONG",
		"I HEAR EVERY DOOR YOU OPEN"
	};

	// Token: 0x0400069F RID: 1695
	private string[] endlessHintText = new string[]
	{
		"That's more like it...",
		"Keep up the good work or see me after class..."
	};

	// Token: 0x040006A0 RID: 1696
	private bool questionInProgress;

	// Token: 0x040006A1 RID: 1697
	private bool impossibleMode;

	// Token: 0x040006A2 RID: 1698
	private bool joystickEnabled;

	// Token: 0x040006A3 RID: 1699
	private int problemsWrong;

	// Token: 0x040006A4 RID: 1700
	private AudioClip[] audioQueue = new AudioClip[20];

	// Token: 0x040006A5 RID: 1701
	public AudioSource baldiAudio;
}
