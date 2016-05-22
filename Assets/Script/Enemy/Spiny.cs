using UnityEngine;
using System.Collections;

public class Spiny : MonoBehaviour {

    float autoMove;
    float speed;
    float direction;
    public float moveRange;
    Vector2 firstPosition;
    BoxCollider2D spinyBox;
    GameObject childBox;
    BoxCollider2D childBoxcollider;
    SpriteRenderer spr;
    // Use this for initialization
    void Start()
    {
        moveRange = 2.0f;
        autoMove = 0;
        speed = 3;
        direction = 1;
        firstPosition = transform.position;
        spinyBox = GetComponent<BoxCollider2D>();
        spr = GetComponent<SpriteRenderer>();
        spr.flipX = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > firstPosition.x + moveRange)
        {
            direction *= -1;
            spr.flipX = false;
        }
        if (transform.position.x < firstPosition.x - moveRange)
        {
            direction *= -1;
            spr.flipX = true;
        }


        transform.Translate(Vector2.right * speed * Time.deltaTime * direction);

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Shell")
        {
            Destroy(spinyBox);
            Destroy(this.gameObject, 1);
            transform.Rotate(new Vector3(0.0f,0.0f,1.0f),180.0f);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f,5.0f),ForceMode2D.Impulse);
            
        }
        if (coll.gameObject.tag == "Fireball")// 미사일
        {
            Destroy(spinyBox);
            Destroy(this.gameObject, 1);
            transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), 180.0f);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 5.0f), ForceMode2D.Impulse);
        }
    }
 
}
