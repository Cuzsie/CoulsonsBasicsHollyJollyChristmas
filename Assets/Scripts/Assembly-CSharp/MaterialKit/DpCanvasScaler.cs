using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MaterialKit
{
	// Token: 0x020000C3 RID: 195
	[RequireComponent(typeof(Canvas))]
	[ExecuteInEditMode]
	[AddComponentMenu("Layout/DP Canvas Scaler")]
	public class DpCanvasScaler : UIBehaviour
	{
		// Token: 0x06000962 RID: 2402 RVA: 0x00022118 File Offset: 0x00020518
		protected DpCanvasScaler()
		{
		}

		// Token: 0x17000397 RID: 919
		// (get) Token: 0x06000963 RID: 2403 RVA: 0x0002216D File Offset: 0x0002056D
		// (set) Token: 0x06000964 RID: 2404 RVA: 0x00022175 File Offset: 0x00020575
		public float referencePixelsPerUnit
		{
			get
			{
				return this.m_ReferencePixelsPerUnit;
			}
			set
			{
				this.m_ReferencePixelsPerUnit = value;
			}
		}

		// Token: 0x17000398 RID: 920
		// (get) Token: 0x06000965 RID: 2405 RVA: 0x0002217E File Offset: 0x0002057E
		// (set) Token: 0x06000966 RID: 2406 RVA: 0x00022186 File Offset: 0x00020586
		public float fallbackScreenDPI
		{
			get
			{
				return this.m_FallbackScreenDPI;
			}
			set
			{
				this.m_FallbackScreenDPI = value;
			}
		}

		// Token: 0x17000399 RID: 921
		// (get) Token: 0x06000967 RID: 2407 RVA: 0x0002218F File Offset: 0x0002058F
		// (set) Token: 0x06000968 RID: 2408 RVA: 0x00022197 File Offset: 0x00020597
		public float defaultSpriteDPI
		{
			get
			{
				return this.m_DefaultSpriteDPI;
			}
			set
			{
				this.m_DefaultSpriteDPI = value;
			}
		}

		// Token: 0x1700039A RID: 922
		// (get) Token: 0x06000969 RID: 2409 RVA: 0x000221A0 File Offset: 0x000205A0
		// (set) Token: 0x0600096A RID: 2410 RVA: 0x000221A8 File Offset: 0x000205A8
		public float dynamicPixelsPerUnit
		{
			get
			{
				return this.m_DynamicPixelsPerUnit;
			}
			set
			{
				this.m_DynamicPixelsPerUnit = value;
			}
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x000221B1 File Offset: 0x000205B1
		protected override void OnEnable()
		{
			base.OnEnable();
			this.m_Canvas = base.GetComponent<Canvas>();
			this.Handle();
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x000221CB File Offset: 0x000205CB
		protected override void OnDisable()
		{
			this.SetScaleFactor(1f);
			this.SetReferencePixelsPerUnit(100f);
			base.OnDisable();
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x000221E9 File Offset: 0x000205E9
		protected virtual void Update()
		{
			this.Handle();
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x000221F4 File Offset: 0x000205F4
		protected virtual void Handle()
		{
			if (this.m_Canvas == null || !this.m_Canvas.isRootCanvas)
			{
				return;
			}
			if (this.m_Canvas.renderMode == RenderMode.WorldSpace)
			{
				this.HandleWorldCanvas();
				return;
			}
			this.HandleConstantPhysicalSize();
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x00022241 File Offset: 0x00020641
		protected virtual void HandleWorldCanvas()
		{
			this.SetScaleFactor(this.m_DynamicPixelsPerUnit);
			this.SetReferencePixelsPerUnit(this.m_ReferencePixelsPerUnit);
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x0002225C File Offset: 0x0002065C
		protected virtual void HandleConstantPhysicalSize()
		{
			float dpi = Screen.dpi;
			float num = (dpi != 0f) ? dpi : this.m_FallbackScreenDPI;
			float num2 = 160f;
			this.SetScaleFactor(num / num2);
			this.SetReferencePixelsPerUnit(this.m_ReferencePixelsPerUnit * num2 / this.m_DefaultSpriteDPI);
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x000222AB File Offset: 0x000206AB
		protected void SetScaleFactor(float scaleFactor)
		{
			if (scaleFactor == this.m_PrevScaleFactor)
			{
				return;
			}
			this.m_Canvas.scaleFactor = scaleFactor;
			this.m_PrevScaleFactor = scaleFactor;
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x000222CD File Offset: 0x000206CD
		protected void SetReferencePixelsPerUnit(float referencePixelsPerUnit)
		{
			if (referencePixelsPerUnit == this.m_PrevReferencePixelsPerUnit)
			{
				return;
			}
			this.m_Canvas.referencePixelsPerUnit = referencePixelsPerUnit;
			this.m_PrevReferencePixelsPerUnit = referencePixelsPerUnit;
		}

		// Token: 0x04000614 RID: 1556
		[Tooltip("If a sprite has this 'Pixels Per Unit' setting, then one pixel in the sprite will cover one unit in the UI.")]
		[SerializeField]
		protected float m_ReferencePixelsPerUnit = 100f;

		// Token: 0x04000615 RID: 1557
		private const float kLogBase = 2f;

		// Token: 0x04000616 RID: 1558
		[Tooltip("The DPI to assume if the screen DPI is not known.")]
		[SerializeField]
		protected float m_FallbackScreenDPI = 96f;

		// Token: 0x04000617 RID: 1559
		[Tooltip("The pixels per inch to use for sprites that have a 'Pixels Per Unit' setting that matches the 'Reference Pixels Per Unit' setting.")]
		[SerializeField]
		protected float m_DefaultSpriteDPI = 96f;

		// Token: 0x04000618 RID: 1560
		[Tooltip("The amount of pixels per unit to use for dynamically created bitmaps in the UI, such as Text.")]
		[SerializeField]
		protected float m_DynamicPixelsPerUnit = 1f;

		// Token: 0x04000619 RID: 1561
		private Canvas m_Canvas;

		// Token: 0x0400061A RID: 1562
		[NonSerialized]
		private float m_PrevScaleFactor = 1f;

		// Token: 0x0400061B RID: 1563
		[NonSerialized]
		private float m_PrevReferencePixelsPerUnit = 100f;
	}
}
