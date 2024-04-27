using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            if (PlayerPrefs.GetInt("BirdIsAlive", 0) == 1)
            {
                GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>().AddScore();
                FindObjectOfType<AudioManager>().Play("Point");

                if (gameObject.tag == "WiningPipe")
                {
                    GameObject.FindGameObjectWithTag("SceneTransition").GetComponent<SceneTransition>().StartScene("Win");
                }
            }
        }
    }
}
