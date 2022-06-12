using System;
using UnityEngine;

// Token: 0x020000BA RID: 186
public class Billboard : MonoBehaviour
{
	// Token: 0x0600093E RID: 2366 RVA: 0x000215D5 File Offset: 0x0001F9D5
	private void Start()
	{
		this.m_Camera = Camera.main;
	}

	// Token: 0x0600093F RID: 2367 RVA: 0x000215E2 File Offset: 0x0001F9E2
	private void LateUpdate()
	{
		base.transform.LookAt(base.transform.position + this.m_Camera.transform.rotation * Vector3.forward);
	}

	// Token: 0x040005D5 RID: 1493
	private Camera m_Camera;
}
