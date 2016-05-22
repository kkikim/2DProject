using UnityEngine;
using System.Collections;

public class HammerBros : MonoBehaviour {
    float TimeLeft = 5.0f;
    float nextTime = 0.0f;
    float jumpPower = 250.0f;
    public GameObject hammer;
    BoxCollider2D brosBox;
	// Use this for initialization
	void Start () {
        brosBox = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Time.time > nextTime)
        {
            nextTime = Time.time + TimeLeft;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpPower));
            Instantiate(hammer, new Vector2(this.transform.position.x - 1, this.transform.position.y + 1), Quaternion.identity);
            
        }
	
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Shell")
        {
            Destroy(brosBox);
            Destroy(this.gameObject, 1);
            transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), 180.0f);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 5.0f), ForceMode2D.Impulse);

        }
        if (coll.gameObject.tag == "Fireball")// 미사일
        {
            Destroy(brosBox);
            Destroy(this.gameObject, 1);
            transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), 180.0f);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 5.0f), ForceMode2D.Impulse);
        }
    }
}
