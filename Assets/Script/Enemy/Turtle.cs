using UnityEngine;
using System.Collections;

public class Turtle : MonoBehaviour {

    float speed;
    float shellSpeed;
    float direction;
    
    Vector2 firstPosition;
    Animator turtleAnimator;
    BoxCollider2D turtleBox;
    BoxCollider2D childBoxcollider;
    GameObject childBox;
    SpriteRenderer turtleSR;

    public bool MoveShell;
    public float direction2;           //등딱지 와리가리 속력;
    public bool dead;
    // Use this for initialization
    void Start()
    {
        speed = 1.5f;
        shellSpeed =  5.0f;
        direction = 1;
        direction2 = 1;
        firstPosition = transform.position;
        turtleAnimator = GetComponent<Animator>();
        dead = false;
        turtleBox = GetComponent<BoxCollider2D>();
        childBox = transform.Find("TurtleBoxChecker").gameObject;
        childBoxcollider = childBox.GetComponent<BoxCollider2D>();
        turtleSR = GetComponent<SpriteRenderer>();
        turtleSR.flipX = true;
        MoveShell = false;
    }

    // Update is called once per frame
    void Update()
    {
        print(MoveShell);
        if (!dead)
        {
            if (transform.position.x > firstPosition.x + 2.0f)
            {
                turtleSR.flipX = false;
                direction *= -1;
            }
            if (transform.position.x < firstPosition.x - 2.0f)
            {
                turtleSR.flipX = true;
                direction *= -1;
            }

            transform.Translate(Vector2.right * speed * Time.deltaTime * direction);
        }
        else if(dead)
        {
            if(!MoveShell)
                Invoke("AwakeTurtle", 15.0f);
            else if (MoveShell)
            {
                CancelInvoke("AwakeTurtle");
                transform.Translate(Vector2.right * shellSpeed * Time.deltaTime * direction2);
            }
        }
    }
    void AwakeTurtle()
    {
        turtleAnimator.SetInteger("TurtleState", 2);
        Invoke("RisenTurtle", 3.0f);
    }

    void RisenTurtle()
    {
        dead = false;
        turtleBox.enabled = true;
        turtleAnimator.Play("TurtleMove");
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!dead)
        {
            if (coll.gameObject.name == "Player")
            {
                //turtleAnimator.Play("TurtleDead");
                turtleAnimator.SetInteger("TurtleState", 1);
                //Destroy(turtleBox);
                turtleBox.enabled = false;
                //Destroy(childBoxcollider);
                //Destroy(this.gameObject, 1);
                Invoke("changeDeadState",0.1f);
                //Destroy(childOfGoomba);
            }
        }
    }
    void changeDeadState()
    {
        dead = true;
    }
}
