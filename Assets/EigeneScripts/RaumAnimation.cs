using UnityEngine;
using System.Collections;

public class RaumAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		fliegeLos();
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKey (KeyCode.L)) 
		{

		}
	}


	void fliegeLos()
	{
		Hashtable hh = new Hashtable();
		hh.Add("path",iTweenPath.GetPath ("hans"));
		hh.Add ("time", 30);
		//hh.Add ("axis", "z");
		//hh.Add ("axis", "x");
		hh.Add ("axis", "y");
		hh.Add ("orienttopath", true);
		//hh.Add ("speed", 5);

		//hh.Add ("easetype", iTween.EaseType.easeInOutSine);
		//hh.Add("oncomplete","ruckreise");
		iTween.MoveTo (gameObject, hh);
	}
}
