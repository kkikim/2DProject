using UnityEngine;
using System.Collections;

public class Mushroom : MonoBehaviour {

    float mushRoomVelocity;
	// Use this for initialization
	void Start () {
        mushRoomVelocity = 3.0f;
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(Vector3.left*Time.deltaTime*mushRoomVelocity);
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
