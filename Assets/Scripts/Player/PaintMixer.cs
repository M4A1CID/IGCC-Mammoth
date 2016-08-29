using UnityEngine;
using System.Collections;

public class PaintMixer : MonoBehaviour {

    public string[] ArrayOfColor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Color AddTwoColor(GameObject PaintBucket_1, GameObject PaintBucket_2)
    {
        // First Color Red
        if (PaintBucket_1.GetComponent<PaintCan>().ColorName == "RED")
        {
            // Mix with Yellow
            

            // Mix with Blue
        }

        // First Color Yellow
        else if (PaintBucket_1.GetComponent<PaintCan>().ColorName == "YELLOW")
        {
            // Mix with Yellow

            // Mix with Blue
        }

        // First Color Blue
        else if (PaintBucket_1.GetComponent<PaintCan>().ColorName == "BLUE")
        {
            // Mix with Yellow

            // Mix with Blue
        }

        
        return Color.black;
    }

}
