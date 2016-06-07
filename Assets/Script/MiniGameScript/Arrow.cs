using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
	// Use this for initialization
    Vector2 firstPosition;
    float direction;
    public float moveRange;
    public float velocity = 5.0f;
    bool arrowMove;
    bool arrowSecondMove;
	void Start () 
    {
        firstPosition = transform.position;
        direction = 1;
        moveRange = 3.0f;
        arrowMove = true;
        arrowSecondMove = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (arrowMove)
        {
            if (transform.position.y >= firstPosition.y + moveRange)
            {
                direction *= -1;
                transform.position.Set(1.5f, firstPosition.y + moveRange, 0);
            }
            if (transform.position.y <= firstPosition.y - moveRange)
            {
                direction *= -1;
                transform.position.Set(1.5f, firstPosition.y - moveRange, 0);
            }

            transform.Translate(Vector2.up * velocity * Time.deltaTime * direction);
        }
        if(!arrowMove)
        {
            if(!arrowSecondMove)
                transform.Translate(Vector2.left * 3.0f * Time.deltaTime);
            else if (arrowSecondMove)
            {
                transform.Translate(Vector2.right * 1.0f * Time.deltaTime);
            }
        }
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        arrowSecondMove = true; //스테이지 전환이후 파일 입출력을 통해서 마리오 상태를 전달한다.
        print("collide");
        if (coll.gameObject.name == "big")
        {
            print("big");
        }
        if (coll.gameObject.name == "fire")
        {
            print("fire");
        }
        if (coll.gameObject.name == "small")
        {
            print("small");
        }
    }
    public void StopArrowMove()
    {
        arrowMove = false;
    }
}
