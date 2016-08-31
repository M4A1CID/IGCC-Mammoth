using UnityEngine;
using System.Collections;

public class CanvasScript : MonoBehaviour {

    private ComputeBitmap computeBitmap=new ComputeBitmap();
    public GameObject FinishPainting;
    public Texture2D MainTexture;
    
	// Use this for initialization
	void Start () {
        // Slap the outline onto the existing canvas
        FinishPainting.GetComponent<ChangePicture>().GetNewPainting();
        //this.transform.GetComponent<Renderer>().material.mainTexture = MainTexture as Texture;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
