using UnityEngine;
using System.Collections;

public class SceneFadeInOut : MonoBehaviour
{
	public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.
	
	
	private bool sceneStarting = true;      // Whether or not the scene is still fading in.
	
	private bool StartEndScene;
	void Awake ()
	{
		// Set the texture so that it is the the size of the screen and covers it.
		GetComponent<GUITexture>().pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
	}
	
	
	void Update ()
	{
		// If the scene is starting...
		if (sceneStarting) 
		{
			StartScene();
		}

		if (StartEndScene == true) {	EndScene ();	}
					
	}
	
	
	void FadeToClear ()
	{
		// Lerp the colour of the texture between itself and transparent.
		GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.clear, fadeSpeed * Time.deltaTime);
	}
	
	
	void FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.black, fadeSpeed * Time.deltaTime);
	}
	
	
	void StartScene ()
	{
		// Fade the texture to clear.
		FadeToClear();
		
		// If the texture is almost clear...
		if(GetComponent<GUITexture>().color.a <= 0.05f)
		{
			// ... set the colour to clear and disable the GUITexture.
			GetComponent<GUITexture>().color = Color.clear;
			GetComponent<GUITexture>().enabled = false;
			
			// The scene is no longer starting.
			sceneStarting = false;
		}
	}

	private int LevelID; 
	private Vector3 ZKoords;
	public void DoFadeOutAndLoadLevel(int lid, Vector3 ZielKoords)
	{
		LevelID = lid;
		ZKoords = ZielKoords;
		StartEndScene = true;
		SetKoords = true;
	}

	private bool SetKoords;
	public void DoFadeOutAndReset()
	{
		LevelID = RaumMove.AktLevelID;
		StartEndScene = true;
		SetKoords = false;
	}

	private void EndScene ()
	{
		// Make sure the texture is enabled.
		GetComponent<GUITexture>().enabled = true;
		
		// Start fading towards black.
		FadeToBlack();
		
		// If the screen is almost black...
		if(GetComponent<GUITexture>().color.a >= 0.95f)
		// ... reload the level.
		print ("Loading Level");
	

		Application.LoadLevel(LevelID);

        //SetKoords wenn Aufruf über LevelLoadTriggerPlatte
        if (SetKoords == true)
        {
            print("Merke Koordinaten zum Resporn nach sterben");
            CollisionChecker.StartKoordinaten = ZKoords;
            print("Setze Koordinaten im neuen Level");
            GameObject.FindWithTag("Player").transform.position = ZKoords;
            RaumMove.darfbewegen = true;
            RaumMove.AktuellerSpeed = 0;
            RaumMove.RotatationAktSpeed = 0;
            RaumMove.SteigSinkAktSpeed = 0;

            iTween.Stop(GameObject.FindWithTag("Player").GetComponent<RaumAnimation>().gameObject);
            Destroy(GameObject.FindWithTag("Player").GetComponent<iTweenPath>());
        }
        //Aufruf über normale Kollision (sterben)
        else
        {
            GameObject.FindWithTag("Player").transform.localPosition = CollisionChecker.StartKoordinaten;
        }
	}



}