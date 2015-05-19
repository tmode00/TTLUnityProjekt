using UnityEngine;
using System.Collections;

public class CollisionChecker : MonoBehaviour {


	public static Vector3 StartKoordinaten;
    public static Vector3 StartRotation;
	void Start () 
	{
        print("CollisionChecker: Merke StartPosition und Rotation für Tod!");
		//Startkoords merken
		StartKoordinaten = new Vector3 (this.transform.localPosition.x,this.transform.localPosition.y,this.transform.localPosition.z);
		StartRotation = new Vector3 (this.transform.localEulerAngles.x,this.transform.localEulerAngles.y,this.transform.localEulerAngles.z);
	}
	
	void Update () { }

    void sterben()
    {
        print ("Setze Spieler auf StartKoordinaten und Rotation zurück!");
        GameObject.FindWithTag("Player").transform.position = StartKoordinaten;
        GameObject.FindWithTag("Player").transform.localEulerAngles = StartRotation;
        print("Aktueller Speed, Rotatation = 0");
        RaumMove.AktuellerSpeed = 0;
        RaumMove.RotatationAktSpeed = 0;
        RaumMove.SteigSinkAktSpeed = 0;        
    }

	//Bei Kollision Warten und Game resten
	void OnTriggerEnter(Collider collisionInfo)
	{
		//if(collisionInfo.gameObject.GetComponent<TriggerLoadLevel>().CollectAble != null)
		if (collisionInfo.gameObject.tag.ToString() == "TriggerLoadLevel")
		{
			//Collector aufrufen
			collisionInfo.gameObject.GetComponent<TriggerLoadLevel>().Collector();
			print ("Trigger 'LoadLevel' gefunden! Führe Collector-Funktion aus!");
		}
		else if (collisionInfo.gameObject.tag.ToString() == "TriggerOpenDoor")
		{
			//Collector aufrufen
			collisionInfo.gameObject.GetComponent<TriggerOpenDoor>().Collector();
			print ("Trigger 'TriggerOpenDoor' gefunden! Führe Collector-Funktion aus!");
		}
		else if (collisionInfo.gameObject.tag.ToString() == "TriggerCloseDoor")
		{
			//Collector aufrufen
			collisionInfo.gameObject.GetComponent<TriggerCloseDoor>().Collector();
			print ("Trigger 'TriggerCloseDoor' gefunden! Führe Collector-Funktion aus!");
		}
		else if (collisionInfo.gameObject.tag.ToString() == "TriggerChangeCam")
		{
			//Collector aufrufen
			collisionInfo.gameObject.GetComponent<TriggerChangeCam>().Collector();
			print ("Trigger 'TriggerChangeCam' gefunden! Führe Collector-Funktion aus!");
		}
        else if (collisionInfo.gameObject.tag.ToString() == "TriggerFollowPath")
        {
            //Collector aufrufen
            collisionInfo.gameObject.GetComponent<TriggerFollowPath>().Collector();
            print("Trigger 'TriggerFollowPath' gefunden! Führe Collector-Funktion aus!");
        }
        else if (collisionInfo.gameObject.tag.ToString() == "TriggerScannerPath")
        {
            //Collector aufrufen
            collisionInfo.gameObject.GetComponent<TriggerScannerPath>().Collector(this.transform);
            print("Trigger 'TriggerScannerPath' gefunden! Führe Collector-Funktion aus!");
        }
        else if (collisionInfo.gameObject.tag.ToString() == "TriggerDeactivatePath")
        {
            //Collector aufrufen
            collisionInfo.gameObject.GetComponent<TriggerDeactivatePath>().Collector();
            print("Trigger 'TriggerDeactivatePath' gefunden! Führe Collector-Funktion aus!");
        }
        else if (collisionInfo.gameObject.tag.ToString() == "EinTriggerLanden")
        {
            //Collector aufrufen
            collisionInfo.gameObject.GetComponent<EinTriggerLanden>().Collector();
            print("Trigger 'EinTriggerLanden' gefunden! Führe Collector-Funktion aus!");
        }
        else if (collisionInfo.gameObject.tag.ToString() == "EinTriggerStarten")
        {
            //Collector aufrufen
            collisionInfo.gameObject.GetComponent<EinTriggerStarten>().Collector();
            print("Trigger 'EinTriggerStarten' gefunden! Führe Collector-Funktion aus!");
        }

            
            
		else
		{
			print ("Kein bekannte Aktion (TAG?), aber als Trigger gesetzt?! Mache nix...");
		}
	}

	//Kein Trigger??? normle Kollision abfragen
	void OnCollisionEnter(Collision collisionInfo)
	{
		//Ausfaden und sterben:
		print ("Normale Kollision mit NonTrigger Objekt! Sterbe!");
		
        //Bei Kollision Warten und Game resten
        sterben();
	}
		
	void OnCollisionStay(Collision collisionInfo)
	{
	}	
	void OnCollisionExit(Collision collisionInfo)
	{
	}

}
