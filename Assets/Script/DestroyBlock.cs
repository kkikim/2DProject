using UnityEngine;
using System.Collections;

public class DestroyBlock : MonoBehaviour {
    bool isMove;
    public GameObject destroyParitcle;
	// Use this for initialization
	void Start () {
        isMove = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.name == "Player")
        {
            LeanTween.moveY(this.gameObject, transform.position.y + 0.1f, 0.1f).setEase(LeanTweenType.easeInOutSine).
                    setLoopPingPong(1).setOnComplete(Complete);

            Vector3 pos = this.transform.position;
            pos.y += 0.1f;
            Invoke("destroy", 0.1f);
        }
    }

    void destroy()
    {
        Instantiate(destroyParitcle,this.transform.position,Quaternion.identity);
        Destroy(this.gameObject);
    }
    void Complete()
    {
        isMove = false;
    }
}
