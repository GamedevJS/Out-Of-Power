using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public GameObject winingPipe;

    public GameObject ground;
    
    public float spawnRate = 1;
    private float timer = 0;
    public float heightOffset = 1000;

    private int whatNumberedPipeIsBeingSpawned =1;

    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }
    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset-0.5f;

        if (whatNumberedPipeIsBeingSpawned <= 11)
        {
            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        }
        if (whatNumberedPipeIsBeingSpawned == 12)
        {
            Instantiate(winingPipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        }
        whatNumberedPipeIsBeingSpawned++;
    }

}

