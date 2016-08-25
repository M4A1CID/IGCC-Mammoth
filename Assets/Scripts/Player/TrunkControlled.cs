using UnityEngine;
using System.Collections;

public class TrunkControlled : MonoBehaviour {
    
    private Vector3 newPosition;
    private Vector3 currentPosition;

    public float Sensivity;
    public float MinMaxY;
    public float MinMaxX;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        float ytranslation = Input.GetAxis("Vertical") * Sensivity;
        float xtranslation = Input.GetAxis("Horizontal") * Sensivity;

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
