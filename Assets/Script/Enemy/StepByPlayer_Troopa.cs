using UnityEngine;
using System.Collections;

public class StepByPlayer : MonoBehaviour {
    public GameObject parent;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
    void OnCollisonEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {

        }

    }
        
}
