using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    public PlayerMove player_;
    public Goal goal_;
    public CameraControler camera_controller_;
    public Stage stage_;
    
    // Use this for initialization
    void Start () {
        goal_.OnGoal += GoalAction;
        camera_controller_.OnAnimationCmplete += CameraAnimationCompleteAction;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoalAction(){
        player_.Goal();
        StartCoroutine("WaitGoalAction");
    }

    private IEnumerator WaitGoalAction(){
        Debug.Log("WaitGoalAction");
        // 1秒待つ  
        yield return new WaitForSeconds(1.0f);
        
        camera_controller_.Goal();  
    }

    public void CameraAnimationCompleteAction(){
        stage_.NextStage();
    }
}
