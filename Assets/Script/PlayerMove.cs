using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class PlayerMove : MonoBehaviour {
    public float speed = 0;
    private float SPEED_ADD = 0.05f; // 加速度
    private float SPEED_MAX = 8; // 最高速度
    private float friction = 0.95f; // 摩擦係数(0.0～1.0)
    private float speed_z = 0f;
    private float default_rotation = 270;
    private float left_rotation = 180;
    private float curve_friction = 5;

    private bool is_goal_ = false;
                         // Use this for initialization
    void Start () {
		
	}

    private bool flg = false;
	
	// Update is called once per frame
	void Update () {

        //if (is_goal_) return;

        if (!is_goal_)
        {
            speed += SPEED_ADD;

        } else
        {
            speed *= friction;
            speed_z *= friction;
            transform.position += new Vector3(-1 * speed * Time.deltaTime, 0f, -1 * speed_z * Time.deltaTime);
            return;
        }

        // 速度を摩擦係数で乗算する
        //speed *= friction;

        if (speed > SPEED_MAX) speed = SPEED_MAX;

        // 速度を座標に加算する
        
        transform.position += new Vector3(-1*speed*Time.deltaTime, 0f, -1 * speed_z * Time.deltaTime);
        transform.Rotate(0, 0, 0);
        if (Input.GetMouseButton(0)){
            if (!flg) touchBegan();
            speed_z += SPEED_ADD;
            speed *= friction;
            if (speed_z > SPEED_MAX) speed_z = SPEED_MAX;
            transform.position += new Vector3(-1 * speed * Time.deltaTime, 0f,-1* speed_z * Time.deltaTime);
        }
        float y;
        if (Input.GetMouseButton(0)){
            //Debug.Log("mouse down");
            // だんだんとかえたいとき
            // 実際の値 += (目標の値 - 実際の値) / 係数;
            y = ((left_rotation - transform.localRotation.eulerAngles.y) / curve_friction) + transform.localRotation.eulerAngles.y;
            
            transform.localRotation = Quaternion.Euler(0, y, 0);
        }
        else{
            
            flg = false;
            speed_z *= friction;

            y = ((default_rotation - transform.localRotation.eulerAngles.y) / curve_friction) + transform.localRotation.eulerAngles.y;
            
            //Debug.Log("mouse up");
            transform.localRotation = Quaternion.Euler(0, y, 0);

           

        }

    }
    
    public void Goal()
    {
        is_goal_ = true;
    }

    void touchBegan()
    {
        flg = true;
        //speed_z = 0;
    }
}
