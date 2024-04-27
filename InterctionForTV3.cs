using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterctionForTV3 : MonoBehaviour
{
    bool playerIsNear;

    public GameObject powerOffUI;
    public GameObject powerOnUI;

    bool pluggedIn = false;


    public SpriteRenderer spriteRenderer;

    public Sprite TVPluggedIn;

    void Update()
    {


        if (playerIsNear)
        {
            if (!pluggedIn)
            {
                powerOffUI.SetActive(true);

            }
            else
            {
                powerOffUI.SetActive(false);
                powerOnUI.SetActive(true);
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
        else
        {
            powerOffUI.SetActive(false);
            powerOnUI.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            playerIsNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            playerIsNear = false;
        }
    }


    public void PluggedIn()
    {
        pluggedIn = true;
        spriteRenderer.sprite = TVPluggedIn;
    }
}

