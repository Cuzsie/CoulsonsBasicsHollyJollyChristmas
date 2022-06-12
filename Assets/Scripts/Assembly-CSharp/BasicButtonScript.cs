using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000006 RID: 6
public class BasicButtonScript : MonoBehaviour
{
	// Token: 0x06000010 RID: 16 RVA: 0x000022EA File Offset: 0x000006EA
	private void Start()
	{
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.OpenScreen));
	}

	// Token: 0x06000011 RID: 17 RVA: 0x00002314 File Offset: 0x00000714
	private void OpenScreen()
	{
		this.screen.SetActive(true);
	}

	// Token: 0x04000010 RID: 16
	private Button button;

	// Token: 0x04000011 RID: 17
	public GameObject screen;
}
