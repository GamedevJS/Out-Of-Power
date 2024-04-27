using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCheckIfLocked : MonoBehaviour
{
    public GameObject door;

    public GameObject doesntHaveeyUI;
    public GameObject hasKeyUI;

    bool isOnCollision;

    public GameObject darkFilter;

    public GameObject wallBlocade;

    private void Start()
    {
        if (PlayerPrefs.GetInt("AlreadyUnlocked", 0) == 1)
        {
            door.SetActive(true);
            wallBlocade.SetActive(false);
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



        if (!door.activeSelf)
        {
            if (isOnCollision)
            {
                if (PlayerPrefs.GetInt("HasKey", 0) == 0)
                {
                    doesntHaveeyUI.SetActive(true);
                }
                else
                {
                    doesntHaveeyUI.SetActive(false);
                    hasKeyUI.SetActive(true);
                }
            }
            else
            {
                doesntHaveeyUI.SetActive(false);
                hasKeyUI.SetActive(false);
            }

            if (hasKeyUI.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (FindObjectOfType<AudioManager>() != null)
                    {
                        FindObjectOfType<AudioManager>().Play("Door");
                    }
                    PlayerPrefs.SetInt("AlreadyUnlocked", 1);
                    door.SetActive(true);
                    wallBlocade.SetActive(false);
                    hasKeyUI.SetActive(false);
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
