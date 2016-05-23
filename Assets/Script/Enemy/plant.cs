using UnityEngine;
using System.Collections;

public class plant : MonoBehaviour {

    Vector2 firstPosition;
    float moveRange;
    float direction;
    float velocity;
	// Use this for initialization
	void Start () {
        firstPosition = this.transform.position;
        moveRange = 2.0f;
        direction = 1.0f;
        velocity = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y > firstPosition.y + moveRange)
            direction *= -1;
        if (transform.position.y < firstPosition.y - moveRange)
            direction *= -1;

        transform.Translate(Vector2.up * velocity * Time.deltaTime * direction);
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Fireball")
        {
            Destroy(this.gameObject);
        }
    }
}
