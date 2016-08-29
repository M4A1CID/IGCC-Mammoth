using UnityEngine;
using System.Collections;

public class PaintCan : MonoBehaviour {

    public Color PaintColor;
    public string ColorName;

	// Use this for initialization
	void Start () {
        // Convert to Uppercase
        ColorName = ColorName.ToUpper();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Color GetPaintBucketColor()
    {
        
        return PaintColor;
    }
}
