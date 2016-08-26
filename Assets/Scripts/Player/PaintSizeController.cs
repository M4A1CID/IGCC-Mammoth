using UnityEngine;
using System.Collections;

public class PaintSizeController : MonoBehaviour {

    public GameObject SnoutGun;

    public int NumberOfArrays;
    public Texture2D[] SmallSplat;
    public Texture2D[] NormalSplat;
    public Texture2D[] BigSplat;
    
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
        currentSize += 1;
        // If switching causes the access of array to go out of scope
        if (currentSize >= NumberOfArrays)
        {
            // Reset back the size
            currentSize = 0;
        }

        // Do a switch statment based on current size
        switch(currentSize)
        {
            case 0:
                return SmallSplat;
            case 1:
                return NormalSplat;
            case 2:
                return BigSplat;
            default:
                return NormalSplat;

        }
    }




}
