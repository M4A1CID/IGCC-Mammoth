using UnityEngine;
using System.Collections;

public class RayEmitter : MonoBehaviour {
	private RaycastHit rayHit;
	public static Vector2 RayXY;
	public Texture2D MainTexture;
	public Texture2D[] SpriteTexture;
    public Color SpriteColor;
	private ComputeBitmap computeBitmap=new ComputeBitmap();
	public GameObject PlaneObj;
    private int PaintAmount = 20;
    private int PaintSize;
    

    public GameObject snout; //The source of the paint spray
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //Raycast to paint targets
        RaycastHit hitInfo;
        Vector3 directionalVector = snout.transform.position - Camera.main.transform.position; //The direction that the paint will spray in
        bool hit = Physics.Raycast(snout.transform.position, directionalVector, out hitInfo, Mathf.Infinity); //Raycast to determine has the paint hit anything?
        Debug.DrawRay(snout.transform.position, directionalVector); //Draw the ray in the scene for testing

        if (Input.GetButtonDown("Fire1"))
        {
                // If ray hits the canvas
            if (hitInfo.collider.gameObject.CompareTag("Canvas"))
            {
                // GetPaintSize
                PaintSize = GameObject.Find("Paint Size Controller").GetComponent<PaintSizeController>().currentSize + 1;
                // If there is enough paint
                if (PaintAmount >= PaintSize)
                {
                    RayXY = hitInfo.textureCoord;
                    int randomSplat = Random.Range(0, SpriteTexture.Length - 1);
                    MainTexture = computeBitmap.BitmapsAddMix(MainTexture, SpriteTexture[randomSplat], SpriteColor, RayXY.x, RayXY.y);
                    PlaneObj.transform.GetComponent<Renderer>().material.mainTexture = MainTexture as Texture;

                    //SpendPaint
                    PaintAmount -= PaintSize;
                    Debug.Log("PaintAmount:" + PaintAmount);
                }
            }
            
            // If ray hits Size changer
            if (hitInfo.collider.gameObject.CompareTag("SizeChanger"))
            {
               SpriteTexture =  hitInfo.collider.gameObject.GetComponent<PaintSizeController>().GetSwitchSize();
            }

            // If ray hits paint can
            if (hitInfo.collider.gameObject.CompareTag("Paint Can"))
            {
                SpriteColor = hitInfo.collider.gameObject.GetComponent<PaintCan>().GetPaintBucketColor();
                PaintAmount = 20;
            }

        }
    }
}
