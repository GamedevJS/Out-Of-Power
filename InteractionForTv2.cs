using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionForTv2 : MonoBehaviour
{
    bool playerIsNear;

    public GameObject darkFilter;

    public GameObject powerOffUI;
    public GameObject powerOnUI;


    void Update()
    {
        if (PlayerPrefs.GetInt("LightsOn", 0) == 1)
        {
            if (darkFilter != null)
            {
                darkFilter.SetActive(false);
            }
        }

        if (playerIsNear)
        {
            if (PlayerPrefs.GetInt("LightsOn", 0) == 1)
            {
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
            else
            {
                powerOffUI.SetActive(true);
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
}

