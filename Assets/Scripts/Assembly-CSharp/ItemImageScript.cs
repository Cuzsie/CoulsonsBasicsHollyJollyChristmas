using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000019 RID: 25
public class ItemImageScript : MonoBehaviour
{
	// Token: 0x06000059 RID: 89 RVA: 0x0000399C File Offset: 0x00001D9C
	private void Update()
	{
		if (this.gs != null)
		{
			Texture texture = this.gs.itemSlot[this.gs.itemSelected].texture;
			if (texture == this.blankSprite)
			{
				this.sprite.texture = this.noItemSprite;
			}
			else
			{
				this.sprite.texture = texture;
			}
		}
		else
		{
			this.sprite.texture = this.noItemSprite;
		}
	}

	// Token: 0x04000072 RID: 114
	public RawImage sprite;

	// Token: 0x04000073 RID: 115
	[SerializeField]
	private Texture noItemSprite;

	// Token: 0x04000074 RID: 116
	[SerializeField]
	private Texture blankSprite;

	// Token: 0x04000075 RID: 117
	public GameControllerScript gs;
}
