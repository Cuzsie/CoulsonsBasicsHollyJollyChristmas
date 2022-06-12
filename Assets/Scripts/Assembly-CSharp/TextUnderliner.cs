using System;
//using TMPro;
using UnityEngine.UI;
using UnityEngine;

// Token: 0x020000E4 RID: 228
public class TextUnderliner : MonoBehaviour
{
	// Token: 0x06000A20 RID: 2592 RVA: 0x0002812F File Offset: 0x0002652F
	public void Underline()
	{
		this.text.fontStyle = FontStyle.Normal;
	}

	// Token: 0x06000A21 RID: 2593 RVA: 0x0002813D File Offset: 0x0002653D
	public void Ununderline()
	{
		this.text.fontStyle = FontStyle.Normal;
	}

	// Token: 0x04000775 RID: 1909
	public Text text;
}
