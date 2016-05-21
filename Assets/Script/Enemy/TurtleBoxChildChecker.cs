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
    void OnCollisionEnter2D(Collision2D coll2)
    {
    }
}
