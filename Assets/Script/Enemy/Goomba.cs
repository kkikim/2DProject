using UnityEngine;
using System.Collections;

public class Goomba : MonoBehaviour {

    float               autoMove;
    float               speed;
    float               direction;
    public float        moveRange;
    Vector2             firstPosition;
    Animator            goombaAnimator;
    BoxCollider2D       goombaBox;
    GameObject          childBox;
    BoxCollider2D       childBoxcollider;
    bool                dead;
	// Use this for initialization
	void Start () 
    {
        moveRange = 2.0f;
        autoMove    = 0;
        speed       = 3;
        direction   = 1;
        firstPosition = transform.position;
        goombaAnimator = GetComponent<Animator>();
        dead = false;
        goombaBox = GetComponent<BoxCollider2D>();
        childBox = transform.Find("GoombaBoxChecker").gameObject;
        childBoxcollider = childBox.GetComponent<BoxCollider2D>();

	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!dead)
        {
            if (transform.position.x > firstPosition.x + moveRange)
                direction *= -1;
            if (transform.position.x < firstPosition.x - moveRange)
                direction *= -1;


            transform.Translate(Vector2.right * speed * Time.deltaTime * direction);
        }

        
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
       if(coll.gameObject.name == "Player")
       {
           goombaAnimator.Play("GoombaDead");
           Destroy(goombaBox);
           Destroy(childBoxcollider);
           Destroy(this.gameObject, 1);
           dead = true;
           //Destroy(childOfGoomba);
       }
       if (coll.gameObject.tag=="Shell")
       {
           goombaAnimator.Play("GoombaDead");
           Destroy(goombaBox);
           Destroy(childBoxcollider);
           Destroy(this.gameObject, 1);
           dead = true;
           //Destroy(childOfGoomba);
       }
    }
 
}
