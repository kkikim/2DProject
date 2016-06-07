using UnityEngine;
using System.Collections;

public class MakeClearBox : MonoBehaviour {
    public GameObject clearBox;
    bool makeTrue;
	// Use this for initialization
	void Start () {
        makeTrue = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            if(!makeTrue)
            {
                makeTrue = true;
                Instantiate(clearBox, new Vector2(this.transform.position.x - 1.28f, this.transform.position.y + 2), Quaternion.identity);
                Instantiate(clearBox, new Vector2(this.transform.position.x -0.64f, this.transform.position.y + 2), Quaternion.identity);
                Instantiate(clearBox, new Vector2(this.transform.position.x + 0, this.transform.position.y + 2), Quaternion.identity);
                Instantiate(clearBox, new Vector2(this.transform.position.x + 0.64f, this.transform.position.y + 2), Quaternion.identity);
                Instantiate(clearBox, new Vector2(this.transform.position.x + 1.28f, this.transform.position.y + 2), Quaternion.identity);
                Instantiate(clearBox, new Vector2(this.transform.position.x + 1.92f, this.transform.position.y + 2), Quaternion.identity);
                Instantiate(clearBox, new Vector2(this.transform.position.x + 2.56f, this.transform.position.y + 2), Quaternion.identity);
            }

        }
    }
}
