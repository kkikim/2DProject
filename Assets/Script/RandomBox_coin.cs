using UnityEngine;
using System.Collections;

public class RandomBox_coin : MonoBehaviour {

    public GameObject coin;
    int collisionNumber = 5;
    bool isMove;
    // Use this for initialization
    void Start()
    {
        isMove = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            //동전생성
            //GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 500.0f));
            if (collisionNumber >= 1)
            {
                Instantiate(coin, new Vector2(this.transform.position.x, this.transform.position.y + 2), Quaternion.identity);
                collisionNumber -= 1;
                isMove = true;
                LeanTween.moveY(this.gameObject, transform.position.y + 0.1f, 0.2f).setEase(LeanTweenType.easeInOutSine).
                    setLoopPingPong(1).setOnComplete(Complete);

                Vector3 pos = this.transform.position;
                pos.y += 0.1f;
            }
           
            if(collisionNumber==0)
                GetComponent<Animator>().SetInteger("state", 1);
            if (collisionNumber >= 1)
            {
                collisionNumber -= 1;
            }
        }
    }

    void Complete()
    {
        isMove = false;
    }
}
