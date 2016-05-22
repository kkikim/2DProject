using UnityEngine;
using System.Collections;

public class ParaTroopa : MonoBehaviour {

    float speed;
    float shellSpeed;
    float direction;

    Vector2 firstPosition;
    Animator turtleAnimator;
    BoxCollider2D turtleBox;
    SpriteRenderer turtleSR;

    public bool MoveShell;
    public float direction2;           //등딱지 와리가리 속력;
    public bool dead;
    // Use this for initialization
    void Start()
    {
        speed = 1.5f;
        shellSpeed = 5.0f;
        direction = 1;
        direction2 = 1;
        firstPosition = transform.position;
        turtleAnimator = GetComponent<Animator>();
        dead = false;
        turtleBox = GetComponent<BoxCollider2D>();
        turtleSR = GetComponent<SpriteRenderer>();
        MoveShell = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            if (transform.position.y > firstPosition.y + 2.0f)
            {
                direction *= -1;
            }
            if (transform.position.y < firstPosition.y - 2.0f)
            {
                direction *= -1;
            }
            transform.Translate(Vector2.up * speed * Time.deltaTime * direction);
        }

        if (this.transform.position.y < -30)
            Destroy(this.gameObject);

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!dead)
        {
            if (coll.gameObject.name == "Player")
            {
                turtleAnimator.SetInteger("TurtleState", 1);
                LeanTween.moveY(this.gameObject, transform.position.y + 0.8f, 0.1f).setEase(LeanTweenType.easeInOutSine).
                    setLoopPingPong(1).setOnComplete(Complete);
                turtleBox.enabled = false;
                this.transform.Rotate(Vector3.forward, 180);
                GetComponent<Rigidbody2D>().gravityScale = 1.0f;
                Invoke("changeDeadState", 0.1f);

            }
        }
    }

    void Complete()
    {
        //isMove = false;
    }
    void changeDeadState()
    {
        dead = true;
    }
}
