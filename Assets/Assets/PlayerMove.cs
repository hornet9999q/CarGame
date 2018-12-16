using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float speed = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(-1*speed*Time.deltaTime, 0f, 0f);
        if (Input.GetMouseButton(0)){
            transform.position += new Vector3(+1 * speed * Time.deltaTime, 0f,-1*speed*Time.deltaTime);


        }
	}
}
