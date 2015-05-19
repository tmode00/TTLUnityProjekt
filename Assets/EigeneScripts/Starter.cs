using UnityEngine;
using System.Collections;

public class Starter : MonoBehaviour {
	public int LevelID;
	
    // Use this for initialization
	void Start () 
	{

		//testraum
		if (LevelID == 1) 
		{
            print("Starter: Level1");
            print("Starter: Diasbling rabdcam");
			GameObject.Find("randcam").GetComponent<Camera>().enabled = false;
            print("Starter: Diasbling 3rdPersonCam");
			GameObject.Find("3rdPersonCam").GetComponent<Camera>().enabled = false;
            print("Starter: Darfbewegen = false");
            RaumMove.darfbewegen = false;
		}

		//testlvl
		if (LevelID == 2) 
		{
            print("Starter: Level2");
            print("Starter: Attaching LookAt (bluedockincam) at " + GameObject.FindWithTag("Player").name.ToString());
            GameObject.Find("bluedockincam").GetComponent<LookAt>().target = GameObject.FindWithTag("Player").transform;
            print("Starter: Diasbling bluedockincam");
            GameObject.Find("bluedockincam").GetComponent<Camera>().enabled = false;
            print("Starter: Enabling 3rdPersonCam");
			GameObject.Find("3rdPersonCam").GetComponent<Camera>().enabled = true;
            print("Starter: Darfbewegen = true");
			RaumMove.darfbewegen = true;
		}

        //HangarBlau
        if (LevelID == 3)
        {
            print("Starter: Level3");
            print("Starter: Enabling RandKamera");
            GameObject.Find("RandKamera").GetComponent<Camera>().enabled = true;
            print("Starter: Diasbling 3rdPersonCam");
            GameObject.Find("3rdPersonCam").GetComponent<Camera>().enabled = false;
            print("Starter: Attaching LookAt (RandKamera) at " + GameObject.FindWithTag("Player").name.ToString());
            GameObject.Find("RandKamera").GetComponent<LookAt>().target = GameObject.FindWithTag("Player").transform;
            print("Starter: Darfbewegen = false");
            RaumMove.darfbewegen = false;
            print("Starter: Disabling abdockpfad Collider!");
            GameObject.Find("abdockpfad").GetComponent<Collider>().enabled = false;
            print("Starter: Disabling abdockbefehlsplatte Collider!");
            GameObject.Find("abdockbefehlsplatte").GetComponent<Collider>().enabled = false;

        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Hagerblau Spezial events
        if (LevelID == 3)
        {
            if (Input.GetKey(KeyCode.L))
            {
                print("Starter: Enabling abdockpfad Collider!");
                GameObject.Find("abdockpfad").GetComponent<Collider>().enabled = true;
                print("Starter: Enabling abdockbefehlsplatte Collider!");
                GameObject.Find("abdockbefehlsplatte").GetComponent<Collider>().enabled = true;
            
            }
                
        }
	}



}
