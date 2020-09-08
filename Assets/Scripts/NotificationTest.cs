using UnityEngine;
using System.Collections;

public class NotificationTest : MonoBehaviour {

	
	void OnGUI () {
        //Color is supported only in Android >= 5.0

		if (GUILayout.Button("5 SECONDS", GUILayout.Height(Screen.height * 0.2f)))
			LocalNotification.SendNotification(1, 5, "Message from Spidy:", "I could really eat one bug or two", new Color32(0xff, 0x44, 0x44, 255));

        if (GUILayout.Button("5 SECONDS BIG ICON", GUILayout.Height(Screen.height * 0.2f)))
			LocalNotification.SendNotification(2, 5, "Message from Spidy:", "I could really eat one bug or two", new Color32(0xff, 0x44, 0x44, 255), true, true, true, "app_icon");

        if (GUILayout.Button("EVERY 5 SECONDS", GUILayout.Height(Screen.height * 0.2f)))
			LocalNotification.SendRepeatingNotification(1, 5, 5, "Message from Spidy:", "I could really eat one bug or two", new Color32(0xff, 0x44, 0x44, 255), true, false, true, "app_icon");
			
		if (GUILayout.Button("STOP",GUILayout.Height(Screen.height * 0.2f)))
			LocalNotification.CancelNotification(1);
	}
}
