using UnityEngine;
using System.Collections;

public class RayEmitter : MonoBehaviour {
	private RaycastHit rayHit;
	public static Vector2 RayXY;
	public Texture2D MainTexture;
	public Texture2D SpriteTexture;
	private ComputeBitmap computeBitmap=new ComputeBitmap();
	public GameObject PlaneObj;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		var hit = Physics.Raycast (transform.position, transform.up * (-1), out rayHit, 10f);
		if(Input.GetKey(KeyCode.Space)){
			if (hit)
						RayXY = rayHit.textureCoord;
			MainTexture=computeBitmap.BitmapsAddMix (MainTexture, SpriteTexture,RayXY.x,RayXY.y);
			PlaneObj.transform.GetComponent<Renderer>().material.mainTexture =MainTexture as Texture;

			}
		}
}
