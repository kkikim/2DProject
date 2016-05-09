using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour
{
    int             speed;                  //스피드 
    float           jumpPower;              // 플레이어 캐릭터를 점프시켰을 때의 파워
    bool            isjump;
    bool            grounded;		        // 접지 확인
    Animator        marioAni;
    BoxCollider2D   marioBox;
    // Use this for initialization
    void Start()
    {
        speed           = 5;
        jumpPower       = 800.0f;
        grounded        = false;
        isjump          = false;
        marioAni = GetComponent<Animator>();
        marioBox = GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        float key = Input.GetAxis("Horizontal");
        float amtMove = speed * Time.deltaTime;

        //지면과의 충돌체크
        //Transform groundCheck = transform.Find("GroundCheck");
        //grounded = (Physics2D.OverlapPoint(groundCheck.position) != null) ? true : false;z
        if(true==isjump)
        { 
            GetComponent<Animator>().SetInteger("state", 2);
        }
        if (grounded)
        {
            // 점프 버튼 확인
            if (Input.GetButtonDown("Jump"))
            {
                if (grounded == true&&isjump == false)
                {// 점프 처리
                    isjump = true;
                    grounded = false;
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpPower));
                    GetComponent<Animator>().SetInteger("state", 2);
                    //GetComponent<Rigidbody2D>().AddForce(Vector2.up,ForceMode2D.Impulse);
                }
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //왼쪽 이동
            GetComponent<SpriteRenderer>().flipX = true;        //좌우이동 반전.
            transform.Translate(Vector3.right * amtMove * key);
            if(grounded)
                GetComponent<Animator>().SetInteger("state", 1);
            else if (!grounded)
                GetComponent<Animator>().SetInteger("state", 2);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //오른쪽이동
            GetComponent<SpriteRenderer>().flipX = false;       //좌우이동 반전.
            transform.Translate(Vector3.right * amtMove * key);
            if (grounded)
                GetComponent<Animator>().SetInteger("state", 1);
            else if (!grounded)
                GetComponent<Animator>().SetInteger("state", 2);

        }
        else
        {
            if (grounded)
                GetComponent<Animator>().SetInteger("state", 0);
            else if (!grounded)
                GetComponent<Animator>().SetInteger("state", 2);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Tile")
        {
            isjump = false;
            grounded = true;
            print("enter");
        }
        if(coll.gameObject.tag == "Fall")
        {
            grounded = false;

            marioAni.Play("dead");
            GetComponent<Rigidbody2D>().AddForce(transform.up*35,ForceMode2D.Impulse);
            Destroy(marioBox);

        }
    }
    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Tile")
        {
            print("stay");
        }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Tile")
        {
            print("exit");
        }
    }

}
