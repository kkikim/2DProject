using UnityEngine;
using System.Collections;

public class Blooper : MonoBehaviour {

    float autoMove;
    public float speed;
    float direction;
    public float moveRange;
    Vector2 firstPosition;
    bool dead;
    BoxCollider2D cheepBox;
    // Use this for initialization
    int moveState = 1;
    float changeTime;
    void Start()
    {
        moveRange = 2.0f;
        autoMove = 0;
        speed = 1.0f;
        cheepBox = GetComponent<BoxCollider2D>();
        direction = 1;
        firstPosition = transform.position;
        dead = false;
        changeTime = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            if (0 == moveState)
            {
                transform.Translate(speed * Time.deltaTime, speed * Time.deltaTime, 0);
            }
            if(1==moveState)
            {
                transform.Translate(-speed * Time.deltaTime, speed * Time.deltaTime, 0);
            }
            if(2==moveState)
            {
                transform.Translate(-speed * Time.deltaTime, -speed * Time.deltaTime, 0);
            }
            if(3==moveState)
            {
                transform.Translate(speed*Time.deltaTime,-speed*Time.deltaTime,0);
            }
        }
        changeTime += Time.deltaTime;
        if(changeTime>2.0f)
        {
            changeTime = 0;
            moveState = Random.Range(0, 3);
        }

        if (dead)
        {
            transform.Translate(Vector2.up * 5 * Time.deltaTime);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Fireball")
        {
            this.transform.Rotate(Vector3.forward, 180);
            Destroy(cheepBox);
            Destroy(this.gameObject, 1);
            dead = true;
            //Destroy(childOfGoomba);
        }
    }
}
