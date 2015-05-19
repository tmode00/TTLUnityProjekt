using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour 
{
	public Vector3 PitchYawRoll;
	void Start () 	
    {	
        print("Initialisiere Rotator, Name: " + this.gameObject.name.ToString());
    }
	void Update () 
	{
		this.transform.Rotate (PitchYawRoll,Space.Self);
	}
}
