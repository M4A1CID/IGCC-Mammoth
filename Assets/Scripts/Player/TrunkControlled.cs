using UnityEngine;
using System.Collections;

public class TrunkControlled : MonoBehaviour {
    
    private Vector3 newPosition;
    private Vector3 currentPosition;
    private Vector3 startingPosition;
    private float ytranslation;
    private float xtranslation;

    public float Sensivity;
    public float GearVRMaxSpeed;
    public float MinMaxY;
    public float MinMaxX;

    public GameObject Game_Settings;

	// Use this for initialization
	void Start () {
        Input.GetJoystickNames();
        startingPosition = this.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {


        if (Game_Settings.GetComponent<GameSettings>().JoystickInput)
        {
            //Debug.Log("JOYSTICK Length: " + Input.GetJoystickNames().Length);
            ytranslation = Input.GetAxis("Vertical") * Sensivity;
            xtranslation = Input.GetAxis("Horizontal") * Sensivity;
        }
        else
        {
            //Debug.Log("NO JOYSTICK");
            ytranslation = Input.GetAxis("Mouse Y") * Sensivity;
            xtranslation = Input.GetAxis("Mouse X") * Sensivity;
        }
        

        //Debug.Log(translation);
        //this.transform.position.Set(transform.position.x, transform.position.y + translation, transform.position.z);
       
        // Handle out of Right
        if (xtranslation + transform.localPosition.x <=  -MinMaxX)
        {
            Debug.Log("RIGHT LIMIT HIT");
            xtranslation = -0.01f;
        }

        // Handle out of left
        if (xtranslation + transform.localPosition.x >=  MinMaxX)
        {
            Debug.Log("LEFT LIMIT HIT");
            xtranslation = 0.01f;
        }

        // Handle out of Top
        if (ytranslation + transform.localPosition.y >= startingPosition.y + MinMaxY)
        {
            ytranslation = 0.0f;
        }

        // Handle out of Bottom
        if (ytranslation + transform.localPosition.y <= startingPosition.y + -MinMaxY)
        {
            ytranslation = 0.0f;
        }

        // Limit the speed of the Gear VR to prevent teleportation of snout
        if (xtranslation > GearVRMaxSpeed)
            xtranslation = GearVRMaxSpeed;

        if (xtranslation < -GearVRMaxSpeed)
            xtranslation = -GearVRMaxSpeed;

        if (ytranslation > GearVRMaxSpeed)
            ytranslation = GearVRMaxSpeed;

        if (ytranslation < -GearVRMaxSpeed)
            ytranslation = -GearVRMaxSpeed;

        newPosition.Set(-xtranslation, ytranslation, 0.0f);

        currentPosition = this.transform.localPosition + newPosition;
        this.transform.localPosition = currentPosition;
	}
}
