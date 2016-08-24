using UnityEngine;
using System.Collections;

public class ChildTrunk : MonoBehaviour {

    
    public GameObject OVRcamera;
    public float RotationSpeed;

    private Quaternion currentRotation;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = OVRcamera.transform.position + v3Offset;
        currentRotation = transform.rotation;
        //transform.rotation = Quaternion.Slerp(this.transform.rotation, OVRcamera.transform.rotation, RotationSpeed * Time.deltaTime);\
        transform.rotation = OVRcamera.transform.rotation;
	}
}
