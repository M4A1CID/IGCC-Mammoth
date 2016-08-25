using UnityEngine;
using System.Collections;

public class Shageki_Shooting : MonoBehaviour {


    // bullet prefab
    public GameObject projectile;

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
            GameObject bullets = GameObject.Instantiate(projectile) as GameObject;

			bullets.transform.position = hoshin.position;



			Vector3 force;

			force = hoshin.transform.forward * speed;

			bullets.GetComponent<Rigidbody>().AddForce(force);

			
			/*
            Vector3 force;
            force = this.transform.forward * speed;
			//force = hoshin.transform.forward * speed;
            // Rigidbodyに力を加えて発射
            bullets.GetComponent<Rigidbody>().AddForce(force);
            // 弾丸の位置を調整
			*/

			print("Snout Position: " + hoshin.position + " Bullet Position: " + bullets.transform.position);

            
        }



    }
}
