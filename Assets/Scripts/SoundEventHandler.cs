using UnityEngine;
using System.Collections;

public class SoundEventHandler : MonoBehaviour {


	void OnEnable(){
		SettingsHandler.guiEvent += GUIEventHandler;

		
	}
	
	void OnDisable(){
		SettingsHandler.guiEvent -= GUIEventHandler;
	
	}

	void GUIEventHandler (string action)
	{

		switch (action) {
		case SettingsHandler.MUSIC_EVENT:
			if(transform.name == "Main Camera"){
				if (PlayerPrefs.GetInt ("MusicOn") == 1) {
					transform.GetComponent<AudioSource>().enabled = true;
				} else { 
					transform.GetComponent<AudioSource>().enabled = false;
				}
			}
			break;

		case SettingsHandler.SOUND_EFFECTS_EVENT:
			if(transform.name != "Main Camera"){
				if (PlayerPrefs.GetInt ("EffectsOn") == 1) {
					transform.GetComponent<AudioSource>().enabled = true;
				} else { 
					transform.GetComponent<AudioSource>().enabled = false;
				}
			}
			break;

		}
	}
}
