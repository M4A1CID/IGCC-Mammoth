using UnityEngine;
using System.Collections;

public class TrunkControlled : MonoBehaviour {
    
    private Vector3 newPosition;
    private Vector3 currentPosition;
    private float ytranslation;
    private float xtranslation;

    public float Sensivity;
    public float MinMaxY;
    public float MinMaxX;

    public GameObject Game_Settings;

	// Use this for initialization
	void Start () {
        Input.GetJoystickNames();
	}
	
	// Update is called once per frame
	void Update () {


        if (Game_Settings.GetComponent<GameSettings>().JoystickInput)
        {
            Debug.Log("JOYSTICK Length: " + Input.GetJoystickNames().Length);
            ytranslation = Input.GetAxis("Vertical") * Sensivity;
            xtranslation = Input.GetAxis("Horizontal") * Sensivity;
        }
        else
        {
            Debug.Log("NO JOYSTICK");
            ytranslation = Input.GetAxis("Mouse Y") * Sensivity;
            xtranslation = Input.GetAxis("Mouse X") * Sensivity;
        }
        

        //Debug.Log(translation);
        //this.transform.position.Set(transform.position.x, transform.position.y + translation, transform.position.z);
       
        // Handle out of Right
        if (xtranslation + transform.localPosition.z > MinMaxX)
        {
            xtranslation = 0.0f;
        }

        // Handle out of left
        if (xtranslation + transform.localPosition.z < -MinMaxX)
        {
            xtranslation = 0.0f;
        }

        // Handle out of Top
        if (ytranslation + transform.localPosition.y > MinMaxY)
        {
            ytranslation = 0.0f;
        }

        // Handle out of Bottom
        if (ytranslation + transform.localPosition.y < 0.0)
        {
            ytranslation = 0.0f;
        }
        newPosition.Set(0.0f, ytranslation, xtranslation);

        currentPosition = this.transform.localPosition + newPosition;
        this.transform.localPosition = currentPosition;
	}
}
