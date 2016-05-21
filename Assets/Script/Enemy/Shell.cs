using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour {
    float velocity;
    bool move;
    Vector2 currentPosition;
    Vector2 directVector;
    Vector2 direction;
	// Use this for initialization
	void Start () 
    {
        velocity = 10.0f;
        move = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(move)
        {
            transform.Translate(direction*Time.deltaTime*velocity);
        }
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "colum")
        {
            direction *= -1;
        }

        if (coll.gameObject.tag == "Player")
        {
            if (!move)
            {
                currentPosition = this.transform.position;
                directVector = currentPosition - coll.contacts[0].point;
                if (directVector.x < 0)
                    direction = new Vector2(-1.0f, 0.0f);
                else if (directVector.x > 0)
                    direction = new Vector2(1.0f, 0.0f);
                move = true;
                Invoke("ChangeTag", 0.2f);
            }
        }
    }
    void ChangeTag()
    {
        this.gameObject.tag = "Shell";
    }

}
