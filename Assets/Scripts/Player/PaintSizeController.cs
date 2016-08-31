using UnityEngine;
using System.Collections;

public class PaintSizeController : MonoBehaviour {

    public GameObject SnoutGun;
    public float MinScale;
    public float MaxScale;

    public bool Expand;
    private Vector3 currentScale;

    public Texture2D[] Splat;

    // 0 for S, 1 for M, 2 for L
    public int Size;
    public int currentSize;

	// Use this for initialization
	void Start () {
        currentScale = transform.localScale;
	}
	
	// Update is called once per frame
    void Update()
    {
        if(Expand)
        {
            ExpandScale();
        }
        else
        {
            ShrinkScale();
        }
	}

    public void ExpandScale()
    {
        if (transform.localScale.x < MaxScale)
            this.transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
    }
    public void ShrinkScale()
    {
        if (transform.localScale.x > MinScale)
            this.transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
    }

    public Texture2D[] GetSwitchSize()
    {
        //Get Size
        currentSize = Size;
        Debug.Log("currentSize:" + currentSize);
        return Splat;
    }

}
