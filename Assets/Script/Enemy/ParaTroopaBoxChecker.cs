using UnityEngine;
using System.Collections;

public class ParaTroopaBoxChecker : MonoBehaviour {
    public ParaTroopa parent;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (parent.dead)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
	}
    void OnCollisionEnter2D (Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            print("아니왜");
        }
    }

}
