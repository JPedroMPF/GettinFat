using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;


public class GeneralSharing : MonoBehaviour {
	Texture2D myImage;
	byte[] bytes ;
	string path;
	

	#region UNITY_DEFAULT_CALLBACKS
	public void OnEnable ()
	{
		ScreenshotHandler.ScreenshotFinishedSaving += ScreenshotSaved;
	}
	
	void OnDisable ()
	{
		ScreenshotHandler.ScreenshotFinishedSaving -= ScreenshotSaved;
	}
	#endregion



	public IEnumerator TakeScreenShot()
	{
		yield return new WaitForEndOfFrame();


		int width = Screen.width;
		int height = Screen.height;
		Texture2D myImage = new Texture2D(width, height, TextureFormat.RGB24, false);
		
		// Read screen contents into the texture
		myImage.ReadPixels(new Rect(0, 0, width, height), 0, 0);
		myImage.Apply();
		
		// Encode texture into PNG
		byte[] bytes = myImage.EncodeToPNG();
		
		path = Application.persistentDataPath + "/MyImage.png";
		File.WriteAllBytes (path, bytes);

	
	

		Debug.Log ("ScreenTaken");

	}

	IEnumerator UploadPNG() {
		// We should only read the screen buffer after rendering is complete
		yield return new WaitForEndOfFrame();
		
		// Create a texture the size of the screen, RGB24 format
		int width = Screen.width;
		int height = Screen.height;
		Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
		
		// Read screen contents into the texture
		tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
		tex.Apply();
		
		// Encode texture into PNG
		byte[] bytes = tex.EncodeToPNG();
		
		string path = Application.persistentDataPath + "/MyImage.png";
		File.WriteAllBytes (path, bytes);
		string path_ = "MyImage.png";
		
		Debug.Log("SCRENSHOT TAKEN");


		#if UNITY_IPHONE || UNITY_IPAD
		StartCoroutine (ScreenshotHandler.Save (path_, "Media Share", true));
		
		#elif UNITY_ANDROID
		StartCoroutine(SaveAndShare());
		#endif


		
	}

	void TakeFinalScreenShot(){
		StartCoroutine("UploadPNG");
	}
	
	
	public void Share()
	{

		Invoke ("TakeFinalScreenShot", 1.5f);		
	}	

	
	IEnumerator SaveAndShare()
	{
		
		yield return new WaitForEndOfFrame();
		#if UNITY_ANDROID
		AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
		AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
		
		intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
		intentObject.Call<AndroidJavaObject>("setType", "image/*");
		intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), "Look how fat i was");
		intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TITLE"), "Look how fat i was ");
		intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "Look how fat i was");
		
		AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
		AndroidJavaClass fileClass = new AndroidJavaClass("java.io.File");
		
		
		
		
		AndroidJavaObject fileObject = new AndroidJavaObject("java.io.File", Application.persistentDataPath + "/MyImage.png");// Set Image Path Here
		
		AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("fromFile", fileObject);
		
		//			string uriPath =  uriObject.Call<string>("getPath");
		bool fileExist = fileObject.Call<bool>("exists");
		Debug.Log("File exist : " + fileExist);
		if (fileExist)
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
		
		AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
		currentActivity.Call("startActivity", intentObject);
		#endif
		
	}


	#region DELEGATE_EVENT_LISTENER
	void ScreenshotSaved ()
	{
		#if UNITY_IPHONE || UNITY_IPAD
		GeneralSharingiOSBridge.ShareTextWithImage (ScreenshotHandler.savedImagePath, "Hello !!! \n This image is from Gettinfat");
		#endif
	}
	#endregion

}
