using UnityEngine;
using System.Collections;

public class PaintMixer : MonoBehaviour {

    public GameObject LeftTusk;
    public GameObject RightTusk;
    public Material RED;
    public Material BLUE;
    public Material YELLOW;
    public Material GREEN;
    public Material PURPLE;
    public Material ORANGE;
    public Material DEFAULT_MAT;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Color AddTwoColor(GameObject PaintBucket_1, GameObject PaintBucket_2)
    {

        // First Color Red
        if (PaintBucket_1.GetComponent<PaintCan>().ColorName == "RED" )
        {
            // If Single Color only [R] or [Y] or [B]
            if (PaintBucket_2 == null || PaintBucket_2.GetComponent<PaintCan>().ColorName == "RED")
            {
                LeftTusk.gameObject.GetComponent<Renderer>().material = RED;
                RightTusk.gameObject.GetComponent<Renderer>().material = RED;
                return new Color(1.0f, 0.0f, 0.0f);
            }
            else
            {
                // Mix with Yellow
                if (PaintBucket_2.GetComponent<PaintCan>().ColorName == "YELLOW")
                {
                    LeftTusk.gameObject.GetComponent<Renderer>().material = ORANGE;
                    RightTusk.gameObject.GetComponent<Renderer>().material = ORANGE;
                    return new Color(1.0f, 0.647f, 0.0f);// Orange R 255, G 165, B 0
                }
                // Mix with Blue
                if (PaintBucket_2.GetComponent<PaintCan>().ColorName == "BLUE")
                {
                    LeftTusk.gameObject.GetComponent<Renderer>().material = PURPLE;
                    RightTusk.gameObject.GetComponent<Renderer>().material = PURPLE;
                    return new Color(0.50196f, 0.0f, 0.50196f); // Purple R 128, G 0, B 128
                }
            }
           
        }

        // First Color Yellow
        else if (PaintBucket_1.GetComponent<PaintCan>().ColorName == "YELLOW")
        {
            // If Single Color only [R] or [Y] or [B]
            if (PaintBucket_2 == null || PaintBucket_2.GetComponent<PaintCan>().ColorName == "YELLOW")
            {
                LeftTusk.gameObject.GetComponent<Renderer>().material = YELLOW;
                RightTusk.gameObject.GetComponent<Renderer>().material = YELLOW;
                return new Color(1.0f, 1.0f, 0.0f);
            }
            else
            {

                // Mix with Red
                if (PaintBucket_2.GetComponent<PaintCan>().ColorName == "RED")
                {

                    LeftTusk.gameObject.GetComponent<Renderer>().material = ORANGE;
                    RightTusk.gameObject.GetComponent<Renderer>().material = ORANGE;
                    return new Color(1.0f, 0.647f, 0.0f);// Orange R 255, G 165, B 0
                }

                // Mix with Blue
                if (PaintBucket_2.GetComponent<PaintCan>().ColorName == "BLUE")
                {

                    LeftTusk.gameObject.GetComponent<Renderer>().material = GREEN;
                    RightTusk.gameObject.GetComponent<Renderer>().material = GREEN;
                    return new Color(0.0f, 0.50196f, 0.0f);// Green R 0, G 128, B 0
                }
            }

        }

        // First Color Blue
        else if (PaintBucket_1.GetComponent<PaintCan>().ColorName == "BLUE")
        {
            // If Single Color only [R] or [Y] or [B]
            if (PaintBucket_2 == null || PaintBucket_2.GetComponent<PaintCan>().ColorName == "BLUE")
            {
                LeftTusk.gameObject.GetComponent<Renderer>().material = BLUE;
                RightTusk.gameObject.GetComponent<Renderer>().material = BLUE;
                return new Color(0.0f, 0.0f, 1.0f);
            }
            else
            {
                // Mix with Yellow
                if (PaintBucket_2.GetComponent<PaintCan>().ColorName == "YELLOW")
                {
                    LeftTusk.gameObject.GetComponent<Renderer>().material = GREEN;
                    RightTusk.gameObject.GetComponent<Renderer>().material = GREEN;
                    return new Color(0.0f, 0.50196f, 0.0f);// Green R 0, G 128, B 0
                }
                // Mix with Red
                if (PaintBucket_2.GetComponent<PaintCan>().ColorName == "RED")
                {
                    LeftTusk.gameObject.GetComponent<Renderer>().material = PURPLE;
                    RightTusk.gameObject.GetComponent<Renderer>().material = PURPLE;
                    return new Color(0.50196f, 0.0f, 0.50196f); // Purple R 128, G 0, B 128
                }
            }
          
        }

        LeftTusk.gameObject.GetComponent<Renderer>().material = DEFAULT_MAT;
        RightTusk.gameObject.GetComponent<Renderer>().material = DEFAULT_MAT;
        return Color.black;
    }

}
