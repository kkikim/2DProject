using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
    public GameObject Player;
    Vector3 CameraPosition;
    public float x = 0.25f;
    public float y = 0.1f;
    public float z = -10.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        CameraPosition.x = Player.transform.position.x;
        CameraPosition.y = y;
        CameraPosition.z = Player.transform.position.z + z;

        transform.position = CameraPosition;
	
	}
}
