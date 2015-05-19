using UnityEngine;
using System.Collections;

public class TriggerLoadLevel : MonoBehaviour 
{
	public bool CollectVisible;
	public int LevelID;
	public Vector3 ZielKoords;
    public Vector3 ZielRotation;

	void Start () 
	{
		//Soll das trigger-Objekt sichtbar sein?
		if (CollectVisible == false) 
		{
			this.GetComponent<Renderer>().enabled = false;
		}
	}

	public void Collector()
	{	
		//Object ist eingesammelt, nicht mehr sichtbar:
		this.GetComponent<Collider>().enabled = false;
		this.GetComponent<Renderer>().enabled = false;

		//Raumschiff muss immer wissen, in welchem Level es gerade ist:
		RaumMove.AktLevelID = LevelID;

		//Beim Levelwechsel sofort Steuerung des Raumschiffes deaktivieren:
		RaumMove.darfbewegen = false;

		//Level laden
        print("Merke Koordinaten zum Resporn nach sterben");
        CollisionChecker.StartKoordinaten = ZielKoords;
        CollisionChecker.StartRotation = ZielRotation;

        
        
        RaumMove.darfbewegen = true;
        RaumMove.AktuellerSpeed = 0;
        RaumMove.RotatationAktSpeed = 0;
        RaumMove.SteigSinkAktSpeed = 0;
        

        //Alle Pfades stoppen
        iTween.Stop();
                
        print("Loading Level");
        Application.LoadLevel(LevelID);

        //Im neuenn Level Positionen des Spielers setzen:
        print("Setze Koordinaten im neuen Level");
        GameObject.FindWithTag("Player").transform.position = ZielKoords;
        GameObject.FindWithTag("Player").transform.localEulerAngles = ZielRotation;
       }

	void Update () 
	{
		
	}
}
