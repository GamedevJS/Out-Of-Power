using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugScript : MonoBehaviour
{
    bool playerIsNear;

    public GameObject UI;

    bool pluggedIn = false;


    void Update()
    {
        if (pluggedIn)
        {
            GameObject.FindGameObjectWithTag("TV").GetComponent<InterctionForTV3>().PluggedIn();
        }


        if (playerIsNear)
        {
            if (!pluggedIn)
            {
                UI.SetActive(true);
            }
            else
            {
                UI.SetActive(false);
            }


            if (Input.GetKeyDown(KeyCode.E))
            {
                pluggedIn = true;
            }
        }
        else
        {
            UI.SetActive(false);
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



