﻿using UnityEngine;
using System.Collections;

public class RandomBox : MonoBehaviour {

    public GameObject mushroom;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.name == "Player")
        {
            //버섯생성.
           print("boxEnter");
          // GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 500.0f));
           Instantiate(mushroom,new Vector2(this.transform.position.x,this.transform.position.y+1), Quaternion.identity);
        }
    }


}
