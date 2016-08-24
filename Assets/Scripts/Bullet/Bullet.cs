using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public GameObject paint;
    private GameObject canvas;

    // Use this for initialization
    void Start()
    {
        canvas = GameObject.Find("Canvas");

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        // DeleteBullet
        if (collision.gameObject.CompareTag("Canvas"))
        {
            Destroy(this.gameObject);

            // Draw
            GameObject paints = GameObject.Instantiate(paint) as GameObject;
            paints.transform.position = gameObject.transform.position;

            // SetParentObject
            paints.transform.parent = canvas.transform;
        }
    }
}
