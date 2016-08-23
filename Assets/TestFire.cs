using UnityEngine;
using System.Collections;

public class TestFire : MonoBehaviour {

    private bool tick;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire1 button pressed");
           
            if (tick){
                GetComponent<MeshRenderer>().material.color = new Color(1f, 0f, 0f);
                tick = false;
            } else {
                GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f);
                tick = true;
            }
           }
	}
}
