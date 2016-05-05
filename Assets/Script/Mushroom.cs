using UnityEngine;
using System.Collections;

public class Mushroom : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        print("mushroom");
        if(coll.gameObject.name == "Player")
        {
            print("mushroom2");
            Destroy(this.gameObject);
        }
    }
}
