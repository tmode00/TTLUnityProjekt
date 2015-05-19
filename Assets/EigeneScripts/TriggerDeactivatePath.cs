using UnityEngine;
using System.Collections;

public class TriggerDeactivatePath : MonoBehaviour {
    public bool CollectVisible;

	// Use this for initialization
	void Start () 
    {
        //Soll das trigger-Objekt sichtbar sein?
        if (CollectVisible == false)
        {
            this.GetComponent<Renderer>().enabled = false;
        }
	}
	
	void Update () {}

    public void Collector()
    {
        //Object ist eingesammelt, nicht mehr sichtbar:
        this.GetComponent<Collider>().enabled = false;
        this.GetComponent<Renderer>().enabled = false;

        //Wenn getriggert, alle Paths deaktivieren
        iTween.Stop();
    }


}
