﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumHeight = 4f;
    private bool isGrounder;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.Play("player");
            gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
            //xoay mat
            if (gameObject.transform.localScale.x > 0)
            {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1,
                    gameObject.transform.localScale.y);
            }
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.Play("player");
            gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
            //xoay mat
            if (gameObject.transform.localScale.x < 0)
            {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1,
                    gameObject.transform.localScale.y);
            }
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity =
                new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, jumHeight);
        }
        else
        {
            anim.Play("ido");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounder = true;
        }
    }
}