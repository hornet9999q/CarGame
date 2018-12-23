using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class PlayerMove : MonoBehaviour {
    public float speed = 0;
    private float SPEED_ADD = 0.05f; // 加速度
    private float SPEED_MAX = 8; // 最高速度
    private float SPEED_FRI = 0.9f; // 摩擦係数(0.0～1.0)
    private float friction = 0.95f; // 摩擦係数(0.0～1.0)
    private float speed_z = 0f;
                         // Use this for initialization
    void Start () {
		
	}

    private bool flg = false;
	
	// Update is called once per frame
	void Update () {
        speed += SPEED_ADD;

        // 速度を摩擦係数で乗算する
        //speed *= friction;

        if (speed > SPEED_MAX) speed = SPEED_MAX;

        // 速度を座標に加算する
        
        transform.position += new Vector3(-1*speed*Time.deltaTime, 0f, -1 * speed_z * Time.deltaTime);
        if (Input.GetMouseButton(0)){
            if (!flg) touchBegan();
            speed_z += SPEED_ADD;
            speed *= friction;
            if (speed_z > SPEED_MAX) speed_z = SPEED_MAX;
            transform.position += new Vector3(-1 * speed * Time.deltaTime, 0f,-1* speed_z * Time.deltaTime);
        } else
        {
            flg = false;
            speed_z *= friction;
        }
	}

    void touchBegan()
    {
        flg = true;
        //speed_z = 0;
    }
}
