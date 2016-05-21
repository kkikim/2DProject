using UnityEngine;
using System.Collections;

public class CollideWithEnemy : MonoBehaviour {

    bool isMove;
	// Use this for initialization
	void Start () {
        isMove = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag=="Enemy")
        {
            isMove = true;
            LeanTween.moveY(this.gameObject, transform.position.y + 1.5f, 0.2f).setEase(LeanTweenType.easeInOutSine).
                setLoopPingPong(1).setOnComplete(Complete);
          
            Vector3 pos = this.transform.position;
            pos.y += 0.1f;
        }
    }
    void Complete()
    {
        isMove = false;
    }
}
