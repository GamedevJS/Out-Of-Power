using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
    public GameObject UpperOrOnlyDoor;
    public GameObject LowerDoor;

    void Awake()
    {
        if (LowerDoor == null) 
        {
            LowerDoor = this.gameObject;
        }

        if (PlayerPrefs.GetInt("WhichDoor", 0)  == 1)
        {
            transform.position = UpperOrOnlyDoor.transform.position;
        }

        if (PlayerPrefs.GetInt("WhichDoor", 0) == 2)
        {
            transform.position = LowerDoor.transform.position;
        }

    }

}
