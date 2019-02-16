using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour {
    public GameObject player;
    public Vector3 offset;
    private Animator animator;
    bool isGoal = false;
    [SerializeField] GameObject container;


    public delegate void OnAnimationCompleteDelegete();
    public OnAnimationCompleteDelegete OnAnimationCmplete;

    // Use this for initialization
    void Start () {
        offset = container.transform.position - player.transform.position;
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!isGoal){
            container.transform.position = player.transform.position + offset;
        }
    }

    public void Goal(){
        isGoal = true;
        animator.SetBool("Goal",true);
    }
}
