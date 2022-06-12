using System;
using UnityEngine;

// Token: 0x0200000E RID: 14
public class CursorControllerScript : MonoBehaviour
{
	// Token: 0x06000030 RID: 48 RVA: 0x00002E0B File Offset: 0x0000120B
	private void Update()
	{
	}

	// Token: 0x06000031 RID: 49 RVA: 0x00002E0D File Offset: 0x0000120D
	public void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	// Token: 0x06000032 RID: 50 RVA: 0x00002E1B File Offset: 0x0000121B
	public void UnlockCursor()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
}
