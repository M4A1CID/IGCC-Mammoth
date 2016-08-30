using UnityEngine;
using System.Collections;

public class ChangePicture : MonoBehaviour {

    public GameObject PaintableCanvas;
    public GameObject PaintingModel;

    public Texture2D[] PaintByNumTexture;
    public Mesh[] Models;

    private int Prev;


	// Use this for initialization
	void Start () {
        Prev = -1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GetNewPainting()
    {
       
        bool changed = false;
        
        while(changed != true)
        {
            int rand = Random.Range(0, PaintByNumTexture.Length - 1);
            if (rand != Prev)// If it's not the same painting as last time
            {
                PaintableCanvas.GetComponent<Renderer>().material.mainTexture = PaintByNumTexture[rand];
                Prev = rand;
                changed = true;
            }
            
        }

       
        
        
    }
}
