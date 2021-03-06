﻿using UnityEngine;
using System;
using System.Collections;

public class RayEmitter : MonoBehaviour {
	private RaycastHit rayHit;
	public static Vector2 RayXY;
    
	private Texture2D MainTexture;
    private Texture2D PlaneTexture;
	public Texture2D[] SpriteTexture;
    public Color SpriteColor;
    private ComputeBitmap computeBitmap = new ComputeBitmap();
	public GameObject PlaneObj;
    public GameObject PaintController;
    public GameObject ParticleEmitter;
    public GameObject[] SizeChangers;

    private int PaintAmount = 20;
    private int PaintSize;
    private float Last_Fired;

    private AudioSource MammothExhale;
    private AudioSource MammothInhale;

    private GameObject[] PaintBucketsString;

    public GameObject snout; //The source of the paint spray
    
    
	// Use this for initialization
	void Start () {
        PaintBucketsString = new GameObject[2];
        // Called once
        PaintSize = PaintController.GetComponent<PaintSizeController>().currentSize + 1;

        Last_Fired = 0.0f;

        MammothExhale = GetComponent<AudioSource>();
        MammothInhale = GetComponent<AudioSource>();

        
	}
	
	// Update is called once per frame
    void Update()
    {

        if (Last_Fired <= 0.1f)
        {
            Last_Fired += Time.deltaTime;
        }


        //Raycast to paint targets
        RaycastHit hitInfo;
        Vector3 directionalVector = snout.transform.position - Camera.main.transform.position; //The direction that the paint will spray in
        bool hit = Physics.Raycast(snout.transform.position, directionalVector, out hitInfo, Mathf.Infinity); //Raycast to determine has the paint hit anything?
        Debug.DrawRay(snout.transform.position, directionalVector); //Draw the ray in the scene for testing

        // Expand and Shrink size changers
        

        if (hit)
        {

            for (int i = 0; i < SizeChangers.Length; ++i)
            {
                if (hitInfo.collider.gameObject == SizeChangers[i])
                {
                    SizeChangers[i].GetComponent<PaintSizeController>().Expand = true;
                }
                else
                {
                    SizeChangers[i].GetComponent<PaintSizeController>().Expand = false;
                }
            }

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
                            PlaneTexture = PlaneObj.transform.GetComponent<Renderer>().material.mainTexture as Texture2D;
                            MainTexture = computeBitmap.BitmapsAddMix(PlaneTexture, SpriteTexture[randomSplat], SpriteColor, RayXY.x, RayXY.y);
                            PlaneObj.transform.GetComponent<Renderer>().material.mainTexture = MainTexture as Texture;

                            //SpendPaint
                            Debug.Log("PaintSize:" + PaintSize);
                            PaintAmount -= PaintSize;
                            Debug.Log("PaintAmount:" + PaintAmount);

                            // Shoot particles
                            ParticleEmitter.GetComponent<ParticleSystem>().Play();

                            // PlayExhaleSound
                            MammothExhale.PlayOneShot(MammothExhale.clip);
                        }
                    }

                    // If ray hits Size changer
                    else if (hitInfo.collider.gameObject.CompareTag("SizeChanger"))
                    {
                        SpriteTexture = hitInfo.collider.gameObject.GetComponent<PaintSizeController>().GetSwitchSize();

                        // Call once
                        PaintSize = PaintController.GetComponent<PaintSizeController>().currentSize + 1;
                    }


                }
                if (Input.GetButtonDown("Fire1"))
                {
                    // If ray hits paint can
                    if (hitInfo.collider.gameObject.CompareTag("Paint Can"))
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

                        // PlayInhaleSound
                        MammothInhale.PlayOneShot(MammothInhale.clip);
                    }

                    else if (hitInfo.collider.gameObject.CompareTag("FinishFrame"))
                    {
                        hitInfo.collider.gameObject.GetComponent<ChangePicture>().GetNewPainting();
                    }
                }

            }
        }
        else
        {
            for (int i = 0; i < SizeChangers.Length; ++i)
            {
                SizeChangers[i].GetComponent<PaintSizeController>().Expand = false;
            }
        }
    }
}
