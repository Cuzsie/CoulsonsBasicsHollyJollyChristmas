using System;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x02000020 RID: 32
public class OnAwakeTrigger : MonoBehaviour
{
	// Token: 0x06000074 RID: 116 RVA: 0x00003EC3 File Offset: 0x000022C3
	private void OnEnable()
	{
		this.OnEnableEvent.Invoke();
	}

	// Token: 0x0400008D RID: 141
	public UnityEvent OnEnableEvent;
}
