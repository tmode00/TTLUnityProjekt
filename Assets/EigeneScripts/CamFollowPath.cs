using UnityEngine;
using System.Collections;

public class CamFollowPath : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		hinreise ();
	}

	void hinreise()
	{
		Hashtable hh = new Hashtable();
		hh.Add("path",iTweenPath.GetPath ("testpath"));
		hh.Add ("time", 10);
		hh.Add ("easetype", iTween.EaseType.easeInOutSine);
		hh.Add("oncomplete","ruckreise");
		iTween.MoveTo (gameObject, hh);
	}

	void ruckreise()
	{
		Hashtable hh = new Hashtable();
		hh.Add("path",iTweenPath.GetPath ("testpath2"));
		hh.Add ("time", 10);
		hh.Add ("easetype", iTween.EaseType.easeInOutSine);
		hh.Add("oncomplete","hinreise");
		iTween.MoveTo (gameObject, hh);
	}

	// Update is called once per frame
	void Update () 
	{
		//iTween.Stop(gameObject);
	}
}
