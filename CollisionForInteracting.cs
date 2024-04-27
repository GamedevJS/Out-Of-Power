using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionForInteracting : MonoBehaviour
{
    public GameObject interactionUI1;
    public GameObject interactionUI2;


    public SpriteRenderer spriteRenderer;

    public Sprite stage1;
    public Sprite stage2;


    private int onWhatInteraction = 1;

    private bool isOnCollisionWithDrawer;

    private void Update()
    {
        if (isOnCollisionWithDrawer)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ChangeSprite();
            }
        }

        if (SceneManager.GetActiveScene().name == "Stage3")
        {
            if (PlayerPrefs.GetInt("LightsOn", 0) == 1)
            {
                spriteRenderer.sprite = stage2;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (PlayerPrefs.GetInt("HasKey", 0) == 0 || SceneManager.GetActiveScene().name == "Garage")
        {
            if (c.gameObject.tag == "Player")
            {
                if (onWhatInteraction == 1 && interactionUI1 != null)
                {
                    interactionUI1.SetActive(true);
                }
                if (onWhatInteraction == 2 && interactionUI2 != null)
                {
                    interactionUI2.SetActive(true);
                }
                isOnCollisionWithDrawer = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            interactionUI1.SetActive(false);
            interactionUI2.SetActive(false);
            isOnCollisionWithDrawer = false;
        }
    }

    void ChangeSprite()
    {
        if (PlayerPrefs.GetInt("HasKey", 0) == 0 || SceneManager.GetActiveScene().name == "Garage")
{
            if (onWhatInteraction == 1 && stage1 != null)
            {
                spriteRenderer.sprite = stage1;
                interactionUI1.SetActive(false);
                interactionUI2.SetActive(true);
            }
            if (onWhatInteraction == 2 && stage2 != null)
            {
                spriteRenderer.sprite = stage2;
                interactionUI2.SetActive(false);
                if (SceneManager.GetActiveScene().name == "Stage1")
                {
                    GameObject.FindGameObjectWithTag("TV").GetComponent<InteractionForTV>().GotController();
                }
                else if (SceneManager.GetActiveScene().name == "Garage")
                {
                    PlayerPrefs.SetInt("HasScrewdriver", 1);
                }
                else
                {
                    PlayerPrefs.SetInt("HasKey", 1);
                }


            }
            onWhatInteraction++;
        }
    }
}