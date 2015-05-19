using UnityEngine;
using System.Collections;

public class TriggerOpenDoor : MonoBehaviour 
{
	public bool CollectVisible;
	public string TuerA = "TurR";
	public string TuerB = "turL";
	public float OpenRange = 8;
	public float OpenSpeed = 0.1f;
	public string Achse = "Z";

	private Vector3 StartposA;
	private Vector3 StartposB;
	void Start () 
	{
		//Soll das trigger-Objekt sichtbar sein?
		if (CollectVisible == false) 
		{
			this.GetComponent<Renderer>().enabled = false;
		}

		//Startpositionen der Türen merken
		StartposA = GameObject.Find(TuerA).transform.position;
		StartposB = GameObject.Find(TuerB).transform.position;
	}
	
	private bool startopendoor;
	void Update () 
	{
		if (startopendoor == true) 
		{
			//Tueren finden anhand des Namens
			if (Achse == "Z")
			{
				if (GameObject.Find(TuerA).transform.position.z < StartposA.z + OpenRange)
				{
                    GameObject.Find(TuerA).transform.Translate(new Vector3(0, 0, (OpenSpeed * Time.deltaTime)), Space.World);
				}
				else
				{
					startopendoor = false;
				}
				if (GameObject.Find(TuerB).transform.position.z > StartposB.z - OpenRange)
				{
                    GameObject.Find(TuerB).transform.Translate(new Vector3(0, 0, -(OpenSpeed * Time.deltaTime)), Space.World);
				}
				else
				{
					startopendoor = false;
				}
			}
			if (Achse == "Y")
			{
				if (GameObject.Find(TuerA).transform.position.y < StartposA.y + OpenRange)
				{
					GameObject.Find(TuerA).transform.Translate(new Vector3(0,(OpenSpeed * Time.deltaTime),0), Space.World);
				}
				else
				{
					startopendoor = false;
				}
				if (GameObject.Find(TuerB).transform.position.y > StartposB.y - OpenRange)
				{
					GameObject.Find(TuerB).transform.Translate(new Vector3(0,-(OpenSpeed * Time.deltaTime),0), Space.World);
				}
				else
				{
					startopendoor = false;
				}
			}
			
			if (Achse == "X")
			{
				if (GameObject.Find(TuerA).transform.position.x < StartposA.x + OpenRange)
				{
					GameObject.Find(TuerA).transform.Translate(new Vector3((OpenSpeed * Time.deltaTime),0,0), Space.World);
				}
				else
				{
					startopendoor = false;
				}
				if (GameObject.Find(TuerB).transform.position.x > StartposB.x - OpenRange)
				{
					GameObject.Find(TuerB).transform.Translate(new Vector3(-(OpenSpeed * Time.deltaTime),0,0), Space.World);
				}
				else
				{
					startopendoor = false;
				}
			}
		}
	}

	public void Collector()
	{	
		//Object ist eingesammelt, nicht mehr sichtbar:
		this.GetComponent<Collider>().enabled = false;
		this.GetComponent<Renderer>().enabled = false;

		//Wenn getriggert, Türen öffnen
		startopendoor = true;
	}
}
