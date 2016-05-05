using UnityEngine;
using System.Collections;

public class RandomBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
           print("boxEnter");
           GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 500.0f));
        }
    }


}
