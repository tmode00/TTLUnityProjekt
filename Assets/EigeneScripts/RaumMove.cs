using System;
using UnityEngine;
using System.Collections;

public class RaumMove : MonoBehaviour
{
	public static float AktuellerSpeed;
	public static float SteigSinkAktSpeed;
	public static float LeftRigtAktSpeed;
	public static float RotatationAktSpeed;
	public static bool darfbewegen;
	public bool InvertSteuerung = true;

	[Header("Aufsteigen W:")]
	public float MaxSteigSpeed = 30;//W
	public float SteigBeschlUm = 0.3f;
	public float BremskraftUp = 0.6f;

	[Header("Sinken S:")]
	public float MaxSinkSpeed = 30;//S
	public float SinkBeschlUm = 0.3f;
	public float BremskraftDown = 0.6f;

	[Header("Links A:")]
	public float MaxLeftSpeed = 30;//A
	public float LeftBeschlUm = 0.3f;
	public float BremskraftLeft = 0.6f;

	[Header("Rechts D:")]
	public float MaxRightSpeed = 30;//D
	public float RightBeschlUm = 0.3f;
	public float BremskraftRight = 0.6f;

	[Header("Rotieren Q:")]
	public float MaxRotLeftSpeed = 30;//Q
	public float RotLeftBeschlUm = 0.3f;
	public float BremskraftRotLeft = 0.6f;

	[Header("Rotieren E:")]
	public float MaxRotRightSpeed = 30;//E
	public float RotRightBeschlUm = 0.3f;
	public float BremskraftRotRight = 0.6f;

	//Beschleunigung vorwärts
	[Header("Beschl. Mouse 1:")]
	public float MaxGasSpeed = 150;//LEFTMOUSE
	public float BeschleunigeUm = 0.3f;
	public float BremskraftVor = 0.6f;

	//Beschleunigung Rückwärts
	[Header("Rueckw. Mouse 2:")]
	public float RMaxGasSpeed = 90;//LEFTMOUSE
	public float RBeschleunigeUm = 0.3f;
	public float BremskraftZurueck = 0.6f;
	
	//Maus Rundumgucken
	[Header("Rundumgucken:")]
	public float SensitivityX = 450;
	public float SensitivityY = 450;

	[Header("tastenzuweisung:")]
	public KeyCode upkey = KeyCode.W;
	public KeyCode downkey = KeyCode.S;
	public KeyCode rightkey = KeyCode.D;
	public KeyCode leftkey = KeyCode.A;
	public KeyCode leftrotkey = KeyCode.Q;
	public KeyCode rightrotkey = KeyCode.E;

	public static int AktLevelID;
	void Start () 
	{
		//Am anfng darf bewegen

		//Invert Steurung merken
		KeyCode tmp_left = leftkey;
		KeyCode tmp_right = rightkey;
		KeyCode tmp_rotleft = leftrotkey;
		KeyCode tmp_rotright = rightrotkey;
		
		if (InvertSteuerung == true) 
		{
			rightkey = tmp_left;
			leftkey = tmp_right;
			leftrotkey = tmp_rotright;
			rightrotkey = tmp_rotleft;
		}
	}

	void Awake() 
	{
        print("Setze Raumschiff auf DontDestroyOnLoad!");
		DontDestroyOnLoad(GameObject.FindWithTag("Player"));
	}
	void Update () 
	{	
		if (darfbewegen == true) 
		{
			UpdateTastenSteuerung();
			UpdateMausGasBremse();
			UpdateMausRundumschau();
		}
	}

	void UpdateMausGasBremse()
	{
		//Maussteuerung vorwärts:
		int maustaste_vor;
		int maustaste_zurueck;
		if (InvertSteuerung == true) { maustaste_vor = 1; maustaste_zurueck = 0; } else {maustaste_vor = 0; maustaste_zurueck = 1;  }

		//Vorwärts fahren:
		if (Input.GetMouseButton (maustaste_vor))
		{
			if (AktuellerSpeed < MaxGasSpeed)
			{
				AktuellerSpeed = AktuellerSpeed + BeschleunigeUm;
			}
		}	

		//Maussteuerung Rückwärts:
		else if (Input.GetMouseButton (maustaste_zurueck))
		{			
			if (AktuellerSpeed > -RMaxGasSpeed)
			{
				AktuellerSpeed = AktuellerSpeed - RBeschleunigeUm;
			}			
		}
		//Keine Maustaste gedrückt (Bremsen)
		else 
		{
				//Wenn das Raumschiff gerade nach vornb fliegt:
				if (AktuellerSpeed < 0)
				{
					//Bremsen
					AktuellerSpeed = AktuellerSpeed + BremskraftVor;				
				}
				//Wenn das Raumschiff gerade nach hinten fliegt:
				else if (AktuellerSpeed > 0)
				{
					//Bremsen
					AktuellerSpeed = AktuellerSpeed - BremskraftZurueck;				
				}		
		}
		this.transform.position += transform.forward * (AktuellerSpeed * Time.deltaTime);
	}

	void UpdateTastenSteuerung()
	{
		//Bei drücken von W aufsteigen
		if (Input.GetKey (upkey)) 
		{
			if (SteigSinkAktSpeed < MaxSteigSpeed) { SteigSinkAktSpeed = SteigSinkAktSpeed + SteigBeschlUm;	}		 
		}
		//Bei drücken von S sinken
		else if (Input.GetKey (downkey)) 
		{
			if (SteigSinkAktSpeed > -MaxSinkSpeed) { SteigSinkAktSpeed = SteigSinkAktSpeed - SinkBeschlUm;	}
		}
		//Weder Steigen noch sinken gedrückt, bremsen (falls bremasen soll)
		else
		{
			//Wenn das Raumschiff gerade nach oben fliegt:
			if (SteigSinkAktSpeed < 0)
			{
				//Bremsen bis 0 (positiv) erreicht
				SteigSinkAktSpeed = SteigSinkAktSpeed + BremskraftUp;				
			}
			//Wenn das Raumschiff gerade nach unten fliegt:
			else if (SteigSinkAktSpeed > 0)
			{
				//Bremsen bis 0 (negativ) erreicht
				SteigSinkAktSpeed = SteigSinkAktSpeed - BremskraftDown;				
			}		
		}
		this.transform.position += transform.up * (SteigSinkAktSpeed * Time.deltaTime);
		////////////////////////////////////////////////////////////////////////////////////////////////////////

		////RECHTS FLIEGEN
		if (Input.GetKey (rightkey)) 
		{
			if (LeftRigtAktSpeed < MaxLeftSpeed) { LeftRigtAktSpeed = LeftRigtAktSpeed + LeftBeschlUm;	}		 
		}
		////LINKS fliegen
		else if (Input.GetKey (leftkey)) 
		{
			if (LeftRigtAktSpeed > -MaxRightSpeed) { LeftRigtAktSpeed = LeftRigtAktSpeed - RightBeschlUm;	}
		}
		else
		{
			//Wenn das Raumschiff gerade rechts fliegt:
			if (LeftRigtAktSpeed < 0)
			{
				//Bremsen bis 0 (positiv) erreicht
				LeftRigtAktSpeed = LeftRigtAktSpeed + BremskraftLeft;				
			}
			//Wenn das Raumschiff gerade nach links fliegt:
			else if (LeftRigtAktSpeed > 0)
			{
				//Bremsen bis 0 (negativ) erreicht
				LeftRigtAktSpeed = LeftRigtAktSpeed - BremskraftRight;				
			}		
		}
		this.transform.position += transform.right * (LeftRigtAktSpeed * Time.deltaTime);
		////////////////////////////////////////////////////////////////////////////////////////////////////////


		//Rotation Links
		if (Input.GetKey (leftrotkey)) 
		{
			if (RotatationAktSpeed < MaxRotLeftSpeed) { RotatationAktSpeed = RotatationAktSpeed + RotLeftBeschlUm;	}		 
		}
		//Rotation Rechts
		else if (Input.GetKey (rightrotkey)) 
		{
			if (RotatationAktSpeed > -MaxRightSpeed) { RotatationAktSpeed = RotatationAktSpeed - RotRightBeschlUm;	}
		}
		else
		{
			//Wenn das Raumschiff gerade nach links rotiert:
			if (RotatationAktSpeed < 0)
			{
				//Bremsen bis 0 (positiv) erreicht
				RotatationAktSpeed = RotatationAktSpeed + BremskraftRotLeft;				
			}
			//Wenn das Raumschiff gerade nach rechts rotiert:
			else if (RotatationAktSpeed > 0)
			{
				//Bremsen bis 0 (negativ) erreicht
				RotatationAktSpeed = RotatationAktSpeed - BremskraftRotRight;				
			}		
		}

		this.transform.Rotate (new Vector3(0,0,RotatationAktSpeed * Time.deltaTime),Space.Self);
		////////////////////////////////////////////////////////////////////////////////////////////////////////////
	}

	void UpdateMausRundumschau()
	{
		float yawbewegung;
		float pitchbewegung;

		//Maus nach recht bewegen, führt zur Berechnung Yaw-Achse 
		if (InvertSteuerung == false) 
		{
			yawbewegung = Input.GetAxis ("Mouse X") * SensitivityX;
			pitchbewegung = -Input.GetAxis ("Mouse Y") * SensitivityY;
			this.transform.Rotate (new Vector3 (0, yawbewegung * Time.deltaTime, 0), Space.Self);
			this.transform.Rotate (new Vector3 (pitchbewegung * Time.deltaTime, 0, 0), Space.Self);
		} 
		else 
		{
			yawbewegung = Input.GetAxis ("Mouse X")*SensitivityX;
			pitchbewegung = -Input.GetAxis ("Mouse Y")*SensitivityY;
			this.transform.Rotate (new Vector3(0,yawbewegung * Time.deltaTime,0),Space.Self);
			this.transform.Rotate (new Vector3(-pitchbewegung * Time.deltaTime,0,0),Space.Self);		
		}
	}   
}
