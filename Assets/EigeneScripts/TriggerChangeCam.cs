using UnityEngine;
using System.Collections;

public class TriggerChangeCam : MonoBehaviour 
{
	public bool CollectVisible;
	public string camdeactivate;
	public string camactivate;

	void Start () 
	{	
		//Soll das trigger-Objekt sichtbar sein?
		if (CollectVisible == false) 
		{
			this.GetComponent<Renderer>().enabled = false;
		}
	}
	void Update () { }

	public void change_camera(string deactivate_cam, string activate_cam)
	{
		GameObject.Find(deactivate_cam).GetComponent<Camera>().enabled = false;
		GameObject.Find(activate_cam).GetComponent<Camera>().enabled = true;
	}

	public void Collector()
	{	
		//Object ist eingesammelt, nicht mehr sichtbar:
		this.GetComponent<Collider>().enabled = false;
		this.GetComponent<Renderer>().enabled = false;
		
		//Kamera wie angegeben wechseln:
        print("Kamera_Deaktivate:" + camdeactivate + " | Kameraactivate:" + camactivate);
		change_camera (camdeactivate, camactivate);
	}
}








