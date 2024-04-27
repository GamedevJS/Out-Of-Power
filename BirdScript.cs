using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdscript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStreinght;
    public LogicScript logic;
    public bool birdIsAlive = true;

    private Animator animator;

    private float timer;

    public GameObject spaceToJump;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        GetComponent<Rigidbody2D>().gravityScale = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive )
        {
            if (timer < 3)
            {
                GetComponent<Rigidbody2D>().gravityScale = 1.5f;
                spaceToJump.SetActive(false);
            }

            myRigidbody.velocity = Vector2.up * 4.5f;
            animator.SetTrigger("Flap");
            FindObjectOfType<AudioManager>().Play("Flap");
        }


        if (timer < 1.6f)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            if (timer < 5f)
            {
                timer += Time.timeScale;
                GetComponent<Rigidbody2D>().gravityScale = 1.5f;
                spaceToJump.SetActive(false);
            }
        }
    }

    private void FixedUpdate()
    {
        animator.ResetTrigger("Flap");

        if (birdIsAlive)
        {
            transform.rotation = Quaternion.Euler(0,0, GetComponent<Rigidbody2D>().velocity.y* 6);
            PlayerPrefs.SetInt("BirdIsAlive", 1);
        }
        else
        {
            PlayerPrefs.SetInt("BirdIsAlive", 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.GameOver();
        birdIsAlive = false;
        GetComponent<CircleCollider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().AddTorque(360, ForceMode2D.Impulse);
        GetComponent<Rigidbody2D>().AddForce(transform.up * 100);
        FindObjectOfType<AudioManager>().Play("Smash");
        FindObjectOfType<AudioManager>().Play("Die");

    }
}
