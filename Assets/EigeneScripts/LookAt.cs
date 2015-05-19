using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {
	public Transform target;

    void Start ()
    {
        print ("Attaching LookAt Target: " + target.gameObject.name.ToString());
    }
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(target);
	}
}