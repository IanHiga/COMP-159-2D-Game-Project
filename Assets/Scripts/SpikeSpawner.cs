using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spike;
    [SerializeField] private GameObject wallLeft;
    [SerializeField] private GameObject wallRight;
    [SerializeField] private GameObject manager;
    [SerializeField] private float minRate;
    private float tick;

    // Start is called before the first frame update
    void Start()
    {
        tick = minRate;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var rand = Random.Range(0, 2);
        Debug.Log("Rand: " + rand);
        if ((rand == 1) && (tick <= 0))
        {
            SpawnSpike();
            tick = minRate;
        }
        else if(tick <= 0)
        {
            tick = minRate;
        }
        else
        {
            tick -= 1;
        }
    }

    void SpawnSpike()
    {
        var rand = Random.Range(0, 3);
        Debug.Log("Rand: " + rand);
        if (rand == 0)
        {
            // SPAWN LEFT
            var position = new Vector3(-4, -9, 0);
            Instantiate(spike, position, Quaternion.identity);
        }
        else if (rand == 1)
        {
            //SPAWN RIGHT
            var position = new Vector3(4, -9, 0);
            Instantiate(spike, position, Quaternion.identity);
        }
        else
        {
            //SPAWN MID
            var position = new Vector3(0, -9, 0);
            rand = Random.Range(0, 2);
            if (rand == 1)
            {
                Instantiate(wallLeft, position, Quaternion.identity);

            }
            else
            {
                Instantiate(wallRight, position, Quaternion.identity);

            }
        }
    }
}
