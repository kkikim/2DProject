using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour{
    float velocity;

    Vector2 moveDirection;
    PlayerCtrl Move;
	// Use this for initialization
	void Start () 
    {
        velocity = 10.0f;
        Move = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        moveDirection = Move.currentDirection;
 
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(moveDirection * Time.deltaTime * velocity);
        Destroy(this.gameObject, 3);
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Enemy" )
        {
            Destroy(this.gameObject);
        }
    }
}
