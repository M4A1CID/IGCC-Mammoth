using UnityEngine;
using System.Collections;

public class Shageki_Shooting : MonoBehaviour {


    // bullet prefab
    public GameObject projrctile;

    // 弾丸発射点
    public Transform hoshin;

    // 弾丸の速度
    public float speed = 1000;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      // MouseLeftButton or JoyPadButton[0]( XboxControllerButton[A])された時
        if (Input.GetButtonDown("Fire1"))
        {
            // 弾丸の複製
            GameObject bullets = GameObject.Instantiate(projrctile) as GameObject;
            
            Vector3 force;
            force = this.transform.forward * -speed;
            // Rigidbodyに力を加えて発射
            bullets.GetComponent<Rigidbody>().AddForce(force);
            // 弾丸の位置を調整
            bullets.transform.position = hoshin.position;
        }



    }
}
