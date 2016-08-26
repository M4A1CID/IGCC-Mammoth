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
                RayXY = hitInfo.textureCoord;
                int randomSplat = Random.Range(0, SpriteTexture.Length - 1);
                MainTexture = computeBitmap.BitmapsAddMix(MainTexture, SpriteTexture[randomSplat], SpriteColor, RayXY.x, RayXY.y);
                PlaneObj.transform.GetComponent<Renderer>().material.mainTexture = MainTexture as Texture;
            }
            
            // If ray hits Size changer
            if (hitInfo.collider.gameObject.CompareTag("SizeChanger"))
            {
               SpriteTexture =  hitInfo.collider.gameObject.GetComponent<PaintSizeController>().GetSwitchSize();
            }


        }
    }
}
