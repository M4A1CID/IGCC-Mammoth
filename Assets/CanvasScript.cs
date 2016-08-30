using UnityEngine;
using System.Collections;

public class CanvasScript : MonoBehaviour {

    private ComputeBitmap computeBitmap=new ComputeBitmap();
    public Texture2D PaintByNumTexture;
    public Texture2D MainTexture;
    
	// Use this for initialization
	void Start () {
        // Slap the outline onto the existing canvas
        MainTexture = computeBitmap.BitmapsAddMix(MainTexture, PaintByNumTexture, 0.5f, 0.5f);
        this.transform.GetComponent<Renderer>().material.mainTexture = MainTexture as Texture;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
