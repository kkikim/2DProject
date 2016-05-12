using UnityEngine;
using System.Collections;

public class RandomBox_flower : MonoBehaviour {

    public GameObject flower;
    int collisionNumber = 1;
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
            //버섯생성.
            //GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 500.0f));
            if (collisionNumber >= 1)
            {
                Instantiate(flower, new Vector2(this.transform.position.x, this.transform.position.y + 1), Quaternion.identity);
                collisionNumber -= 1;
                isMove = true;
                LeanTween.moveY(this.gameObject, transform.position.y + 0.1f, 0.2f).setEase(LeanTweenType.easeInOutSine).
                    setLoopPingPong(1).setOnComplete(Complete);

                Vector3 pos = this.transform.position;
                pos.y += 0.1f;
            }
            GetComponent<Animator>().SetInteger("state", 1);
        }
    }
    void Complete()
    {
        isMove = false;
    }
}
