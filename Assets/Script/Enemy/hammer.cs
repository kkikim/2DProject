using UnityEngine;
using System.Collections;

public class hammer : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-10.0f, 0.0f), ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Tile")
            Destroy(this.gameObject);
        if (coll.gameObject.tag == "Player")
            Destroy(this.gameObject);
    }
    
}
