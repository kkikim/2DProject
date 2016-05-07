using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //GetComponent<Rigidbody2D>().AddForce(Vector3.up*15);
	}
	
	// Update is called once per frame
    void Update()
    {
        Invoke("Destroy", 0.55f);
    }
    void Destroy()
    {
        Destroy(this.gameObject);

    }
 
}
