using UnityEngine;
using System;
using System.Collections;

public class RayEmitter : MonoBehaviour {
	private RaycastHit rayHit;
	public static Vector2 RayXY;
	public Texture2D MainTexture;
	public Texture2D[] SpriteTexture;
    public Color SpriteColor;
	private ComputeBitmap computeBitmap=new ComputeBitmap();
	public GameObject PlaneObj;
    public GameObject PaintController;
    public GameObject ParticleEmitter;


    private int PaintAmount = 20;
    private int PaintSize;
    private float Last_Fired;

    private GameObject[] PaintBucketsString;

    public GameObject snout; //The source of the paint spray
    
    
	// Use this for initialization
	void Start () {
        PaintBucketsString = new GameObject[2];
        // Called once
        PaintSize = PaintController.GetComponent<PaintSizeController>().currentSize + 1;

        Last_Fired = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {

        if(Last_Fired <= 0.1f)
        {
            Last_Fired += Time.deltaTime;
        }


        //Raycast to paint targets
        RaycastHit hitInfo;
        Vector3 directionalVector = snout.transform.position - Camera.main.transform.position; //The direction that the paint will spray in
        bool hit = Physics.Raycast(snout.transform.position, directionalVector, out hitInfo, Mathf.Infinity); //Raycast to determine has the paint hit anything?
        Debug.DrawRay(snout.transform.position, directionalVector); //Draw the ray in the scene for testing

        if (Input.GetButton("Fire1") && Last_Fired > 0.1f)
        {
            Last_Fired = 0.0f; // Reset last fired
            if (hitInfo.collider != null) // Handle No Collider
            {
                // If ray hits the canvas
                if (hitInfo.collider.gameObject.CompareTag("Canvas"))
                {
                    // If there is enough paint
                    if (PaintAmount >= PaintSize)
                    {
                        RayXY = hitInfo.textureCoord;
                        int randomSplat = UnityEngine.Random.Range(0, SpriteTexture.Length - 1);
                        MainTexture = computeBitmap.BitmapsAddMix(MainTexture, SpriteTexture[randomSplat], SpriteColor, RayXY.x, RayXY.y);
                        PlaneObj.transform.GetComponent<Renderer>().material.mainTexture = MainTexture as Texture;



                        //SpendPaint
                        Debug.Log("PaintSize:" + PaintSize);
                        PaintAmount -= PaintSize;
                        Debug.Log("PaintAmount:" + PaintAmount);

                        // Shoot particles
                        ParticleEmitter.GetComponent<ParticleSystem>().Play();
                    }
                }

                // If ray hits Size changer
                else if (hitInfo.collider.gameObject.CompareTag("SizeChanger"))
                {
                    SpriteTexture = hitInfo.collider.gameObject.GetComponent<PaintSizeController>().GetSwitchSize();

                    // Call once
                    PaintSize = PaintController.GetComponent<PaintSizeController>().currentSize + 1;
                }

                // If ray hits paint can
                else if (hitInfo.collider.gameObject.CompareTag("Paint Can"))
                {
                    Debug.Log("Getting Paint from: " + hitInfo.collider.gameObject.name);
                    if (PaintBucketsString[0] == null) // If first slot is empty
                    {
                        PaintBucketsString[0] = hitInfo.collider.gameObject;
                        SpriteColor = this.gameObject.GetComponent<PaintMixer>().AddTwoColor(PaintBucketsString[0], null);
                    }
                    else
                    {
                        PaintBucketsString[1] = PaintBucketsString[0];// Push over old color to 2nd
                        PaintBucketsString[0] = hitInfo.collider.gameObject; // Get new 1st
                        SpriteColor = this.gameObject.GetComponent<PaintMixer>().AddTwoColor(PaintBucketsString[0], PaintBucketsString[1]);
                    }
                    // Change Trunk Color emission map
                    PaintAmount = 20;
                }
            }
           

        }
    }
}
