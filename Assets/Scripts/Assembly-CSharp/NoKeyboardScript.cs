using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000CD RID: 205
public class NoKeyboardScript : InputField
{
	// Token: 0x060009B5 RID: 2485 RVA: 0x000254C2 File Offset: 0x000238C2
	protected override void Start()
	{
		base.keyboardType = (TouchScreenKeyboardType)(-1);
		base.Start();
	}
}
