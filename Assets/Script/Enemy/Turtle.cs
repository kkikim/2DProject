using UnityEngine;
using System.Collections;

public class Turtle : MonoBehaviour {

    float speed;
    float direction;
    public GameObject Shell;

    Vector2 firstPosition;
    Animator turtleAnimator;
    GameObject childBox;
    SpriteRenderer turtleSR;
    Transform turtleTrans;
    // Use this for initialization
    void Start()
    {
        speed = 1.5f;
        direction = 1;
        firstPosition = transform.position;
        turtleSR = GetComponent<SpriteRenderer>();
        turtleSR.flipX = true;
        turtleTrans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > firstPosition.x + 2.0f)
        {
            //transform.position.x = new Vector2();
            turtleSR.flipX = false;
            direction *= -1;
        }
        if (transform.position.x < firstPosition.x - 2.0f)
        {
            //turtleTrans.transform.position = new Vector2(turtleTrans.transform.position.x - 2.0f, 0.0f); 
            turtleSR.flipX = true;
            direction *= -1;
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime * direction);
     
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Instantiate(Shell, new Vector2(this.transform.position.x , this.transform.position.y), Quaternion.identity);
        }
    }

}
