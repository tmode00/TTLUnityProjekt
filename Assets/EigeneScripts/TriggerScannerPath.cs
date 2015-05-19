using UnityEngine;
using System.Collections;

public class TriggerScannerPath : MonoBehaviour 
{
	public bool CollectVisible;

    public string pathname = "hans";
    public int pathtime = 30;
    public bool isactiveonstart = false;
    public static Transform Zielobjekt;
    
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
    
	public void Collector(Transform collisionfrom)
	{	
		//Object ist eingesammelt, nicht mehr sichtbar:
		this.GetComponent<Collider>().enabled = false;
		this.GetComponent<Renderer>().enabled = false;

        Zielobjekt = collisionfrom;
                    
		//Wenn getriggert, Path folgen
    	ActivatePath(pathname);
	}
}
