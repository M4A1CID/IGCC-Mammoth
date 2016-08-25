using UnityEngine;
using System.Collections;

public class PlaneProcess : MonoBehaviour {
	public Texture2D MainTexture;
	public Texture2D SpriteTexture;
	private ComputeBitmap computeBitmap=new ComputeBitmap();
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//transform.renderer.material.mainTexture = computeBitmap.BitmapsAddMix (MainTexture, SpriteTexture) as Texture;
	}
}
