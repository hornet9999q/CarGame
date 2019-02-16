using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour {

    const string STAGE_NAME = "stage";
    int last_stage_id_;

    //public GameObject obj;
    // Use this for initialization
    void Start(){
        
    }

    public void LoadStage(int stage_id){
        last_stage_id_ = stage_id;
        GameObject course = Resources.Load(STAGE_NAME + stage_id.ToString()) as GameObject;
        GameObject stage = Instantiate(course);
        Vector3 pos = new Vector3(0, 0, 0);
        stage.transform.position = pos;
        
    }

    public void RemoveStage(int stage_id){
        // stageを削除する処理を書く
        //if () {
            //Destroy(objects[i].gameObject);
        //}
    }

    public void NextStage(){
        RemoveStage(last_stage_id_);
        LoadStage(last_stage_id_ + 1);
    }
    
	
	// Update is called once per frame
	void Update () {
		
	}
}
