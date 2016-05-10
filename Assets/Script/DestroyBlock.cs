using UnityEngine;
using System.Collections;

public class DestroyBlock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.name == "Player")
        {
            print("11");
            Destroy(this.gameObject);
        }
    }
}
