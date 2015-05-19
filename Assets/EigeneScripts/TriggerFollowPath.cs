using UnityEngine;
using System.Collections;

public class TriggerFollowPath : MonoBehaviour 
{
	public bool CollectVisible;

    public string pathname = "hans";
    public int pathtime = 30;
    public bool isactiveonstart = false;
    public Transform Zielobjekt;
    //public Transform OnCompleteObjekt;
    //public string OnCompleteFunction = "DarfbewegenToogler";


	void Start () 
	{
		//Soll das trigger-Objekt sichtbar sein?
		if (CollectVisible == false) 
		{
			this.GetComponent<Renderer>().enabled = false;
		}

        if (isactiveonstart == true)
        {
            ActivatePath(pathname);
        }
        		
	}
	
	
	void Update () { }
    
    public void ActivatePath(string paname)
    {
        //Darfbewegen abschalten
        RaumMove.darfbewegen = false;
                
        Hashtable hh = new Hashtable();
        hh.Add("path", iTweenPath.GetPath(paname));
        hh.Add("time", pathtime);

        //hh.Add("axis", "y");
        hh.Add("orienttopath", true);
        //hh.Add ("speed", 5);
        //hh.Add ("easetype", iTween.EaseType.easeInOutSine);

        //hh.Add("onCompleteTarget", OnCompleteObjekt.gameObject);
        //hh.Add("oncomplete", OnCompleteFunction);
        iTween.MoveTo(Zielobjekt.gameObject, hh);
    }
    
	public void Collector()
	{	
		//Object ist eingesammelt, nicht mehr sichtbar:
		this.GetComponent<Collider>().enabled = false;
		this.GetComponent<Renderer>().enabled = false;

		//Wenn getriggert, Path folgen
    	ActivatePath(pathname);
	}
}
