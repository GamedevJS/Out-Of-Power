using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorChangeScene : MonoBehaviour
{
    public string sceneName;

    public bool goingTroughUpperDoorInNextRoomOrIsOnlyDoorThere;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("SceneTransition").GetComponent<SceneTransition>().StartScene(sceneName);

            if (goingTroughUpperDoorInNextRoomOrIsOnlyDoorThere)
            {
                PlayerPrefs.SetInt("WhichDoor", 1);
            }
            else
            {
                PlayerPrefs.SetInt("WhichDoor", 2);
            }
        }
    }
}
