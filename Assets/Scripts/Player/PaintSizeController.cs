using UnityEngine;
using System.Collections;

public class PaintSizeController : MonoBehaviour {

    public GameObject SnoutGun;


    public Texture2D[] Splat;
    public int Size;
    
    // 0 for S, 1 for M, 2 for L
    public int currentSize;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Texture2D[] GetSwitchSize()
    {
        //currentSize += 1;
        currentSize = Size;

        return Splat;
    }

}
