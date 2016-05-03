﻿using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour
{
    int             speed;                  //스피드 
    float           jumpPower;              // 플레이어 캐릭터를 점프시켰을 때의 파워
    bool            isjump;
    bool            grounded;		        // 접지 확인

    // Use this for initialization
    void Start()
    {
        speed = 5;
        jumpPower = 450.0f;
        grounded = false;
        isjump = false;
    }
    // Update is called once per frame

    void Update()
    {
        float key = Input.GetAxis("Horizontal");
        float amtMove = speed * Time.deltaTime;

        //지면과의 충돌체크
        //Transform groundCheck = transform.Find("GroundCheck");
        //grounded = (Physics2D.OverlapPoint(groundCheck.position) != null) ? true : false;
        if(true==isjump)
        { 
            GetComponent<Animator>().SetInteger("state", 2);
        }
        if (grounded)
        {
            // 점프 버튼 확인
            if (Input.GetButtonDown("Jump"))
            {
                // 점프 처리
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpPower));         
                GetComponent<Animator>().SetInteger("state", 2);
                //GetComponent<Rigidbody2D>().AddForce(Vector2.up,ForceMode2D.Impulse);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //왼쪽 이동
            //anim.SetInteger("state",1);
            Vector3 scale = transform.localScale;
            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale;
            transform.Translate(Vector3.right * amtMove * key);
            if(grounded)
                GetComponent<Animator>().SetInteger("state", 1);
            else if (!grounded)
                GetComponent<Animator>().SetInteger("state", 2);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //오른쪽이동
            //anim.SetInteger("state", 1);
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;
            transform.Translate(Vector3.right * amtMove * key);
            //GetComponent<Animator>().SetTrigger("walk");
            if (grounded)
                GetComponent<Animator>().SetInteger("state", 1);
            else if (!grounded)
                GetComponent<Animator>().SetInteger("state", 2);
        }
        else
        {
            if(grounded)
                GetComponent<Animator>().SetInteger("state", 0);
            else if(!grounded)
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
            isjump = true;
            grounded = false;
            print("exit");
        }
    }

}
