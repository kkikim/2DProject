using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour
{
    public GameObject cannonBall;
    float TimeLeft = 3.0f;
    float nextTime = 0.0f;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextTime)
        {
            nextTime = Time.time + TimeLeft;
            Instantiate(cannonBall, new Vector2(this.transform.position.x - 1, this.transform.position.y + 1), Quaternion.identity);
        }

    }

}