using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour
{
    public GameObject fireBall;

    int             speed;                  //스피드 
    float           jumpPower;              // 플레이어 캐릭터를 점프시켰을 때의 파워
    bool            isjump;
    bool            grounded;		        // 접지 확인
    Animator        marioAni;
    BoxCollider2D   marioBox;
    int             currentMarioState;
    public Vector2            currentDirection;      
    enum            MarioState { Small = 1, Big, Fire};
    public float key;
    // Use this for initialization
    void Start()
    {
        speed           = 5;
        jumpPower       = 800.0f;
        grounded        = false;
        isjump          = false;
        marioAni        = GetComponent<Animator>();
        marioBox        = GetComponent<BoxCollider2D>();
        currentMarioState = (int)MarioState.Small;
        currentDirection = new Vector2(1.0f, 0.0f);
    }
    // Update is called once per frame
    void Update()
    {
        key = Input.GetAxis("Horizontal");
        float amtMove = speed * Time.deltaTime;

        if(true==isjump)
        { 
            if(currentMarioState == (int)MarioState.Small)
                GetComponent<Animator>().SetInteger("state", 2);
            if (currentMarioState == (int)MarioState.Big)
                GetComponent<Animator>().SetInteger("state", 5);
            if (currentMarioState == (int)MarioState.Fire)
                GetComponent<Animator>().SetInteger("state", 8);
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

                    //if (currentMarioState == (int)MarioState.Small)
                    //    GetComponent<Animator>().SetInteger("state", 2);
                }
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentDirection = new Vector2(-1.0f, 0.0f);
            //왼쪽 이동
            GetComponent<SpriteRenderer>().flipX = true;        //좌우이동 반전.
            transform.Translate(Vector3.right * amtMove * key);
            if (grounded)
            {
                if(currentMarioState == (int)MarioState.Small)
                    GetComponent<Animator>().SetInteger("state", 1);
                if (currentMarioState == (int)MarioState.Big)
                    GetComponent<Animator>().SetInteger("state", 4);
                if (currentMarioState == (int)MarioState.Fire)
                    GetComponent<Animator>().SetInteger("state", 7);
            }
            else if (!grounded)
            {
                if (currentMarioState == (int)MarioState.Small)
                    GetComponent<Animator>().SetInteger("state", 2);
                if (currentMarioState == (int)MarioState.Big)
                    GetComponent<Animator>().SetInteger("state", 5);
                if (currentMarioState == (int)MarioState.Fire)
                    GetComponent<Animator>().SetInteger("state", 8);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            currentDirection = new Vector2(1.0f, 0.0f);
            //오른쪽이동
            GetComponent<SpriteRenderer>().flipX = false;       //좌우이동 반전.
            transform.Translate(Vector3.right * amtMove * key);
            if (grounded)
            {
                if (currentMarioState == (int)MarioState.Small)
                    GetComponent<Animator>().SetInteger("state", 1);
                if (currentMarioState == (int)MarioState.Big)
                    GetComponent<Animator>().SetInteger("state", 4);
                if (currentMarioState == (int)MarioState.Fire)
                    GetComponent<Animator>().SetInteger("state", 7);
            }
            else if (!grounded)
            {
                if (currentMarioState == (int)MarioState.Small)
                    GetComponent<Animator>().SetInteger("state", 2);
                if (currentMarioState == (int)MarioState.Big)
                    GetComponent<Animator>().SetInteger("state", 5);
                if (currentMarioState == (int)MarioState.Fire)
                    GetComponent<Animator>().SetInteger("state", 8);
            }

        }
        else
        {
            if (grounded)
            {
                if (currentMarioState == (int)MarioState.Small)
                    GetComponent<Animator>().SetInteger("state", 0);
                if (currentMarioState == (int)MarioState.Big)
                    GetComponent<Animator>().SetInteger("state", 3);
                if (currentMarioState == (int)MarioState.Fire)
                    GetComponent<Animator>().SetInteger("state", 6);
            }
            else if (!grounded)
            {
                if (currentMarioState == (int)MarioState.Small)
                    GetComponent<Animator>().SetInteger("state", 2);
                if (currentMarioState == (int)MarioState.Big)
                    GetComponent<Animator>().SetInteger("state", 5);
                if (currentMarioState == (int)MarioState.Fire)
                    GetComponent<Animator>().SetInteger("state", 8);
            }
        }
       
        if (currentMarioState == (int)MarioState.Fire)              //미사일 발사.
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Instantiate(fireBall, new Vector2(this.transform.position.x+currentDirection.x, this.transform.position.y + 1), Quaternion.identity);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {           
        if(coll.gameObject.tag == "Tile")           //작은 마리오 상태일대 상태 처리와 큰 마리오일때 상태처리 다 해주자
        {
            isjump = false;
            grounded = true;
            print("enter");
        }
        if(coll.gameObject.tag == "Fall")
        {
            grounded = false;

            marioAni.Play("dead");
            GetComponent<Rigidbody2D>().AddForce(transform.up*30,ForceMode2D.Impulse);
            Destroy(marioBox);
        }

        if(coll.gameObject.tag == "TouchDie")
        {
            grounded = false;

            marioAni.Play("dead");
            GetComponent<Rigidbody2D>().AddForce(transform.up * 25, ForceMode2D.Impulse);
            Destroy(marioBox);
        }

        if (coll.gameObject.tag == "Shell")
        {
            grounded = false;

            marioAni.Play("dead");
            GetComponent<Rigidbody2D>().AddForce(transform.up * 25, ForceMode2D.Impulse);
            Destroy(marioBox);
        }

        if (coll.gameObject.tag == "Mushroom")          //버섯 먹었을때
        {
            marioAni.Play("b_idle");
            currentMarioState = (int)MarioState.Big;
            marioBox.offset = new Vector2(0, 1);
            marioBox.size = new Vector2(0.5f, 2);
        }

        if(coll.gameObject.tag == "Flower")             //꽃 먹었을때. 
        {
            marioAni.Play("f_idle");
            currentMarioState = (int)MarioState.Fire;
            marioBox.offset = new Vector2(0, 1);
            marioBox.size = new Vector2(0.5f, 2);
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
