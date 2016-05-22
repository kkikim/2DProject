using UnityEngine;
using System.Collections;

public class CannonBall : MonoBehaviour {
    float velocity;
	// Use this for initialization
	void Start () {
        velocity = 6.0f;
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Time.deltaTime * velocity * new Vector2(-1.0f, 0.0f));
        Destroy(this.gameObject,15.0f);
	}
}
