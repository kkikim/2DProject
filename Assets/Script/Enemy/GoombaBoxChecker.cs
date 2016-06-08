using UnityEngine;
using System.Collections;

public class GoombaBoxChecker : MonoBehaviour {
    Animator goombaAnimator;
    BoxCollider2D thisBox;
    public Goomba parent;
	// Use this for initialization
	void Start () {
        goombaAnimator = GetComponentInParent<Animator>();
        //goombaBox = GetComponentInParent<BoxCollider2D>();
        thisBox = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Fireball")
        {
            goombaAnimator.Play("GoombaDead");
            parent.goombaBox.enabled = false;
            //Destroy(goombaBox);
            Destroy(this.gameObject, 1);
            parent.dead = true;
            thisBox.enabled = false;
            //Destroy(childOfGoomba);
        }
    }
}
