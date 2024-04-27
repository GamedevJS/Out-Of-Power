using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionForTV : MonoBehaviour
{
    public GameObject doesntHaveControllerUI;
    public GameObject hasControllerUI;
    public GameObject startGameUI;



    public SpriteRenderer spriteRenderer;

    public Sprite TVWithController;


    private bool gotController;

    private bool isOnCollisionWithTV;

    private bool attachedController = false;

    float timer;

    private void Start()
    {
        PlayerPrefs.SetInt("Stage", 0);
    }
    private void Update()
    {
        if (isOnCollisionWithTV)
        {
            if (Input.GetKeyDown(KeyCode.E) && gotController)
            {
                if (FindObjectOfType<AudioManager>() != null)
                {
                    FindObjectOfType<AudioManager>().Play("Click");
                }
                spriteRenderer.sprite = TVWithController;
                hasControllerUI.SetActive(false);
                attachedController = true;
            }
            if (attachedController)
            {
                timer = timer + Time.deltaTime;
                if (timer > 0.2f)
                {
                    startGameUI.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (FindObjectOfType<AudioManager>() != null)
                        {
                            FindObjectOfType<AudioManager>().Play("Click");
                        }
                        GameObject.FindGameObjectWithTag("SceneTransition").GetComponent<SceneTransition>().StartScene("FlappyBird");
                    }
                }

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            if (!gotController)
            {
                doesntHaveControllerUI.SetActive(true);
            }
            if (gotController && spriteRenderer.sprite != TVWithController)
            {
                hasControllerUI.SetActive(true);
            }

            if (attachedController)
            {
                startGameUI.SetActive(true);
            }

            isOnCollisionWithTV = true;
        }
    }

    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            hasControllerUI.SetActive(false);
            doesntHaveControllerUI.SetActive(false);
            isOnCollisionWithTV = false;
            startGameUI.SetActive(false);

        }
    }


    public void GotController()
    {
        gotController = true;
    }
}
