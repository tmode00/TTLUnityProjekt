using UnityEngine;
using System.Collections;

public class TriggerCloseDoor : MonoBehaviour 
{
	public bool CollectVisible;
	public string TuerA = "TurR";
	public string TuerB = "turL";
	public float CloseRange = 8;
	public float CloseSpeed = 0.1f;
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
	
	private bool startclosedoor;
	void Update () 
	{
		if (startclosedoor == true) 
		{
			//Tueren finden anhand des Namens
			if (Achse == "Z")
			{
				if (GameObject.Find(TuerA).transform.position.z > StartposA.z)
				{                                     
					GameObject.Find(TuerA).transform.Translate(new Vector3(0,0,-(CloseSpeed * Time.deltaTime)), Space.World);
				}
				else
				{
					startclosedoor = false;
				}
				if (GameObject.Find(TuerB).transform.position.z < StartposB.z)
				{
					GameObject.Find(TuerB).transform.Translate(new Vector3(0,0,(CloseSpeed * Time.deltaTime)), Space.World);
				}
				else
				{
					startclosedoor = false;
				}
			}
			if (Achse == "Y")
			{
				if (GameObject.Find(TuerA).transform.position.y > StartposA.y)
				{
					GameObject.Find(TuerA).transform.Translate(new Vector3(0,-(CloseSpeed * Time.deltaTime),0), Space.World);
				}
				else
				{
					startclosedoor = false;
				}
				if (GameObject.Find(TuerB).transform.position.y < StartposB.y)
				{
					GameObject.Find(TuerB).transform.Translate(new Vector3(0,(CloseSpeed * Time.deltaTime),0), Space.World);
				}
				else
				{
					startclosedoor = false;
				}
			}
			
			if (Achse == "X")
			{
				if (GameObject.Find(TuerA).transform.position.x > StartposA.x)
				{
					GameObject.Find(TuerA).transform.Translate(new Vector3(-(CloseSpeed * Time.deltaTime),0,0), Space.World);
				}
				else
				{
					startclosedoor = false;
				}
				if (GameObject.Find(TuerB).transform.position.x < StartposB.x)
				{
					GameObject.Find(TuerB).transform.Translate(new Vector3((CloseSpeed * Time.deltaTime),0,0), Space.World);
				}
				else
				{
					startclosedoor = false;
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
		startclosedoor = true;
	}
}
