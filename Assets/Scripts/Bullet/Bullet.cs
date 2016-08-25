using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public GameObject paint;
    public float canvasOffset;
    public float paintOffset;
    public float fowardRayDistance;

    //一生
    public float LifeTime;

    //合計時間生きています
    private float totalTimeAlive;

    private GameObject canvas;
    private bool callOnce;


    // Use this for initialization
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        callOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        //デルタ時間を追加します。
        totalTimeAlive += Time.deltaTime;
        //生きて費やされる時間は、許可された寿命よりも大きい場合
        if(totalTimeAlive > LifeTime)
        {
            //破壊する
            GameObject.Destroy(this.gameObject);
            
        }

        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, fowardRayDistance))
        {
            if (hit.collider.gameObject.CompareTag("Paint") && !callOnce)
            {
                Debug.Log("Bullet Hit Paint");
                HitPaintTarget(hit);
                callOnce = true;
            }
        }
    }

    

    void OnCollisionEnter(Collision collision)
    {
        // DeleteBullet
        if (collision.gameObject.CompareTag("Canvas") && !callOnce)
        {
            Debug.Log("Bullet Hit Canvas");
            HitCanvasTarget();
            callOnce = true;
        }
        if (collision.gameObject.CompareTag("Paint") && !callOnce)
        {
            Debug.Log("Bullet Hit Paint");
            HitPaintTarget(collision);
            callOnce = true;
        }
    }

    //ターゲットと衝突
    void HitCanvasTarget()
    {
        Destroy(this.gameObject);

        // Draw
        GameObject paints = GameObject.Instantiate(paint) as GameObject;

        Vector3 newPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, canvas.transform.position.z + canvasOffset);

        paints.transform.position = newPosition;
        // SetParentObject
        paints.transform.parent = canvas.transform;
    }

    void HitPaintTarget(Collision collision)
    {
        Destroy(this.gameObject);

        // Draw
        GameObject paints = GameObject.Instantiate(paint) as GameObject;

        Vector3 newPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, collision.transform.position.z + paintOffset);

        paints.transform.position = newPosition;
        // SetParentObject
        paints.transform.parent = canvas.transform;
    }

    void HitPaintTarget(RaycastHit collision)
    {
        Destroy(this.gameObject);

        // Draw
        GameObject paints = GameObject.Instantiate(paint) as GameObject;

        Vector3 newPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, collision.transform.position.z + paintOffset);

        paints.transform.position = newPosition;
        // SetParentObject
        paints.transform.parent = canvas.transform;

    }
    
}
