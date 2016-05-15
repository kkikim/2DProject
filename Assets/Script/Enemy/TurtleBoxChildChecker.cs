using UnityEngine;
using System.Collections;

public class TurtleBoxChildChecker : MonoBehaviour {

    public Turtle parent;
    Vector2 collPosition;
    Vector2 currentPosition;
    Vector2 directVector;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (parent.dead == true)        //이후 기둥에 부딪히면 방향 바뀌게 한다.
        {
            //parent.direction2 *= -1;
            if (coll.gameObject.name == "Player")
            {
                currentPosition = this.transform.position;
                directVector = currentPosition - coll.contacts[0].point;
                if (directVector.x < 0)
                    parent.direction2 *= -1;
                else if (directVector.x > 0)
                    parent.direction2 *= 1;
               
                //parent.direction2 *= directVector.x;
                parent.MoveShell = true;
            }
       
        }
    }
}
