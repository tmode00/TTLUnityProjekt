using UnityEngine;
using System.Collections;

public class EinTriggerStarten : MonoBehaviour 
{
    public bool CollectVisible;

    void Start()
    {
        //Soll das trigger-Objekt sichtbar sein?
        if (CollectVisible == false)
        {
            this.GetComponent<Renderer>().enabled = false;
        }
    }

    private bool doLanden;
    private float rotationoffset;
    private float positionoffset;
    void Update() 
    {
        if (doLanden == true)
        { 
            //Prüfen ob die Distanz schon zurückgelegt wurde
            if (positionoffset < 42)
            {
                positionoffset = positionoffset + 1;
                //rotationoffset = rotationoffset - 11.5f;
            }
            else
            {
                doLanden = false;
            }

            //Bewegung ausführen
            GameObject.FindWithTag("Player").transform.position += transform.up * (positionoffset * Time.deltaTime);
           // GameObject.FindWithTag("Player").transform.Rotate(new Vector3(0, rotationoffset * Time.deltaTime, 0), Space.Self);
        }
    }

    public void Collector()
    {
        //Object ist eingesammelt, nicht mehr sichtbar:
        this.GetComponent<Collider>().enabled = false;
        this.GetComponent<Renderer>().enabled = false;

        //Wenn getriggert, Landen
        doLanden = true;
    }
}
