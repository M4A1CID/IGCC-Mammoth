using UnityEngine;
using System.Collections;

public class PaintCan : MonoBehaviour {

    public Color PaintColor;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Color GetPaintBucketColor()
    {
        Debug.Log("Getting Paint from: " + gameObject.name);
        return PaintColor;
    }
}
