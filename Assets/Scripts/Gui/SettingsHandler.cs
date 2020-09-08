using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour {
    

	//STATIC VARIABLES
	public static bool BABY_MODE = false;

	//UI DEPENDENT
	public GameObject chupeta;

	//TOOGLE BUTTONS
	public Toggle musicToggle;
	public Toggle effectsToggle;
	public Toggle babymodeToggle;
	public Toggle notificationsToggle;

	//EVENTS
	public delegate void GUIEvents(string action);
	public static event GUIEvents guiEvent;
	public const string MUSIC_EVENT = "MusicEvent";
	public const string SOUND_EFFECTS_EVENT = "SoundEffectsEvent";
	public const string BABY_EVENT = "BabyEvent";

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("MusicOn") == true || PlayerPrefs.HasKey ("EffectsOn") == true || PlayerPrefs.HasKey ("BabyMode") == true || PlayerPrefs.HasKey ("Notifications") == true) {
			CheckSavedSettings ();
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CheckSavedSettings ()
	{
		
		if (PlayerPrefs.GetInt ("MusicOn") == 1) {
			musicToggle.isOn = true;
		} else { 
			musicToggle.isOn = false;
		}
		
		if (guiEvent != null) {
			guiEvent(MUSIC_EVENT);
		}
		
		if (PlayerPrefs.GetInt ("EffectsOn") == 1) {
			effectsToggle.isOn = true;
		} else {
			effectsToggle.isOn = false;
		}
		
		if (guiEvent != null) {
			guiEvent(SOUND_EFFECTS_EVENT);
		}	
		
		if (PlayerPrefs.GetInt ("BabyMode") == 1) {
			babymodeToggle.isOn = true;
			chupeta.SetActive(true);
			BABY_MODE = true;
		} else {
			babymodeToggle.isOn = false;
			BABY_MODE = false;
			chupeta.SetActive(false);
		}
		
		if (guiEvent != null) {
			guiEvent(BABY_EVENT);
		}	
		
		if (PlayerPrefs.GetInt ("Notifications") == 1) {
			notificationsToggle.isOn = true;
			LocalNotification.SendRepeatingNotification(1, 172800, 172800, "Message from Spidy:", "I could really eat one bug or two", new Color32(0xff, 0xe1, 0x1b, 255), false, false, true, "app_icon");
			
			
		} else {
			notificationsToggle.isOn = false;
			LocalNotification.CancelNotification(1);
		}
		
	}

	public void ChangeSettings(string setting){
		switch (setting) {
			
		case "Music":
			
			if (musicToggle.isOn ) {
				PlayerPrefs.SetInt ("MusicOn",1);
			} else { 
				PlayerPrefs.SetInt ("MusicOn",0);
			}
			if (guiEvent != null) {
				guiEvent(MUSIC_EVENT);
			}	
			break;
			
		case "Effects":
			if (effectsToggle.isOn ) {
				PlayerPrefs.SetInt ("EffectsOn",1);
			} else { 
				PlayerPrefs.SetInt ("EffectsOn",0);
			}
			
			if (guiEvent != null) {
				guiEvent(SOUND_EFFECTS_EVENT);
			}	
			break;
			
		case "BabyMode":
			if (babymodeToggle.isOn ) {
				PlayerPrefs.SetInt ("BabyMode",1);
				chupeta.SetActive(true);
				BABY_MODE = true;
			} else { 
				PlayerPrefs.SetInt ("BabyMode",0);
				BABY_MODE = false;
				chupeta.SetActive(false);
			}
			
			if (guiEvent != null) {
				guiEvent(BABY_EVENT);
			}	
			break;
			
		case "Notifications":
			if (notificationsToggle.isOn ) {
				PlayerPrefs.SetInt ("Notifications",1);
				LocalNotification.SendRepeatingNotification(1, 172800, 172800, "Message from Spidy:", "I could really eat one bug or two", new Color32(0xff, 0xe1, 0x1b, 255), false, false, true, "app_icon");
				
			} else { 
				PlayerPrefs.SetInt ("Notifications",0);
				LocalNotification.CancelNotification(1);
			}
			
			break;
			
		}
		
	}


}
