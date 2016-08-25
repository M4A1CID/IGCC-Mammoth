using UnityEngine;
using System.Collections;

public class RaycastPaint : MonoBehaviour {

	public GameObject paint; //The prefab to be instantiated as paint
	public GameObject snout; //The source of the paint spray
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1")){ //While the button is held down
			RaycastToPaintTarget ();
		}
	}

	public void RaycastToPaintTarget () {
		//Raycast to paint targets
		RaycastHit hitInfo; 
		Vector3 directionalVector = snout.transform.position - Camera.main.transform.position; //The direction that the paint will spray in
		bool hit = Physics.Raycast(snout.transform.position, directionalVector,  out hitInfo, Mathf.Infinity); //Raycast to determine has the paint hit anything?
		//Debug.DrawRay(snout.transform.position, directionalVector); //Draw the ray in the scene for testing

		if(hit){ //If the raycast hits a target, paint it
			print("Painting At: " + hitInfo.point); //Print the location that the paint will appear
			//Instantiate a new paint splat
			GameObject paintSplat = GameObject.Instantiate(paint) as GameObject; //Instantiate a new paint splat 
			paintSplat.transform.position = hitInfo.point; //Position the paint splat at the raycast hit
		}

	}
}
