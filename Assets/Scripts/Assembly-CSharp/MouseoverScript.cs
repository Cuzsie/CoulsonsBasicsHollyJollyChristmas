using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

// Token: 0x0200001E RID: 30
public class MouseoverScript : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x0600006C RID: 108 RVA: 0x00003E4C File Offset: 0x0000224C
	public void OnSelect(BaseEventData eventData)
	{
		this.mouseOver.Invoke();
	}

	// Token: 0x0600006D RID: 109 RVA: 0x00003E59 File Offset: 0x00002259
	public void OnPointerEnter(PointerEventData eventData)
	{
		this.mouseOver.Invoke();
	}

	// Token: 0x0600006E RID: 110 RVA: 0x00003E66 File Offset: 0x00002266
	public void OnDeselect(BaseEventData eventData)
	{
		this.mouseLeave.Invoke();
	}

	// Token: 0x0600006F RID: 111 RVA: 0x00003E73 File Offset: 0x00002273
	public void OnPointerExit(PointerEventData eventData)
	{
		this.mouseLeave.Invoke();
	}

	// Token: 0x0400008B RID: 139
	public UnityEvent mouseOver;

	// Token: 0x0400008C RID: 140
	public UnityEvent mouseLeave;
}
