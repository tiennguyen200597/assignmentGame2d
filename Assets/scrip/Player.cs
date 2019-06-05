using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumHeight = 4f;
    private bool isGrounder;

    private Animator anim;
    //
    int score = 0;
    public Text textScore;
    //

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        textScore = GameObject.Find("txtTextScore").GetComponent<Text>();

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounder = true;
        }
        if (collision.gameObject.tag == "Coin")
        {
            score++;
            Destroy(collision.gameObject);
            textScore.text = "Score:" + score.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.Play("Running");
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
            anim.Play("Running");
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
            anim.Play("Idle");
        }
    }

}