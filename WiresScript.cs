using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiresScript : MonoBehaviour
{
    public GameObject exposedWires;

    public GameObject doesntHavScrewdriverUI;
    public GameObject hasScrewdriverUI;

    bool isOnCollision;

    public GameObject darkFilter;


    private void Start()
    {
        if (PlayerPrefs.GetInt("AlreadyFixedWires", 0) == 1)
        {
            exposedWires.SetActive(false);
        }
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("LightsOn", 0) == 1)
        {
            darkFilter.SetActive(false);
        }
        else
        {
            darkFilter.SetActive(true);
        }

        if (exposedWires.activeSelf)
        {
            if (isOnCollision)
            {
                if (PlayerPrefs.GetInt("HasScrewdriver", 0) == 0)
                {
                    doesntHavScrewdriverUI.SetActive(true);
                }
                else
                {
                    doesntHavScrewdriverUI.SetActive(false);
                    hasScrewdriverUI.SetActive(true);
                }
            }
            else
            {
                doesntHavScrewdriverUI.SetActive(false);
                hasScrewdriverUI.SetActive(false);
            }

            if (hasScrewdriverUI.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (FindObjectOfType<AudioManager>() != null)
                    {
                        FindObjectOfType<AudioManager>().Play("Swich");
                    }
                    PlayerPrefs.SetInt("LightsOn", 1);
                    PlayerPrefs.SetInt("AlreadyFixedWires", 1);
                    exposedWires.SetActive(false);
                    hasScrewdriverUI.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            isOnCollision = true;
        }
    }
    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            isOnCollision = false;
        }
    }
}
