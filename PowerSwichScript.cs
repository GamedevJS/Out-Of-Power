using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSwichScript : MonoBehaviour
{

    bool playerIsNear;

    public SpriteRenderer spriteRenderer;

    public Sprite swichUp;

    public GameObject darkFilter;

    public GameObject UI;

    private void Update()
    {
        if (playerIsNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                spriteRenderer.sprite = swichUp;
                PlayerPrefs.SetInt("LightsOn", 1);
                if (FindObjectOfType<AudioManager>() != null)
                {
                FindObjectOfType<AudioManager>().Play("Swich");
                }
            }

            if (PlayerPrefs.GetInt("LightsOn", 0) == 0)
            {
                UI.SetActive(true);
            }
            else
            {
                UI.SetActive(false);
            }
        }
        else
        {
            UI.SetActive(false);
        }

        if (PlayerPrefs.GetInt("LightsOn", 0) == 1)
        {
            if (darkFilter != null) 
            {
                darkFilter.SetActive(false);
            }
            spriteRenderer.sprite = swichUp;
            playerIsNear = false;
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
