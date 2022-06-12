using System;
//using Rewired;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x0200001C RID: 28
public class PauseMenuScript : MonoBehaviour
{
	// Token: 0x06000064 RID: 100 RVA: 0x000038D0 File Offset: 0x00001CD0
	private void Update()
	{
		//if (ReInput.controllers.GetLastActiveControllerType() == ControllerType.Joystick & EventSystem.current.currentSelectedGameObject == null)
		//{
			//if (!this.gc.mouseLocked)
			//{
				//this.gc.LockMouse();
			//}
		//}
		//else if (ReInput.controllers.GetLastActiveControllerType() != ControllerType.Joystick && this.gc.mouseLocked)
		//{
			//this.gc.UnlockMouse();
		//}
	}

	// Token: 0x04000072 RID: 114
	public GameControllerScript gc;
}
