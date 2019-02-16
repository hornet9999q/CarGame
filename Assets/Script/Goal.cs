using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
    public delegate void OnGoalDelegate();
    public OnGoalDelegate OnGoal;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision coll){
        if (coll.gameObject.name=="Player"){
            //Debug.Log("GOAL!!");
            if (OnGoal != null){
                OnGoal();
                
            }
        }
    }

}