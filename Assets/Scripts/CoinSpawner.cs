using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject manager;
    [SerializeField] private float minRate;
    private float tick;
    private float pos;

    // Start is called before the first frame update
    void Start()
    {
        tick = minRate;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var rand = Random.Range(0, 2);
        // Debug.Log("Rand: " + rand);
        if ((rand == 1) && (tick <= 0))
        {
            SpawnCoin();
            tick = minRate;
        }
        else if (tick <= 0)
        {
            tick = minRate;
        }
        else
        {
            tick -= 1;
        }
    }

    void SpawnCoin()
    {
        var rand = Random.Range(0, 3);
        var rand2 = Random.Range(0, 3);
        if(rand2 == 1)
        {
            pos = -1;
        }
        else if(rand2 == 2)
        {
            pos = 1;
        }
        else
        {
            pos = 0;
        }
        // Debug.Log("Rand: " + rand);

        if (rand == 0)
        {
            // SPAWN SINGLE
            Instantiate(coin, new Vector3(pos * 3.5f, -9, 0), Quaternion.identity);
        }
        else if (rand == 1)
        {
            //SPAWN DOUBLE
            Instantiate(coin, new Vector3(pos * 3.5f, -9, 0), Quaternion.identity);
            Instantiate(coin, new Vector3(pos * 3.5f, -11, 0), Quaternion.identity);
        }
        else
        {
            //SPAWN TRIPLE
            Instantiate(coin, new Vector3(pos * 3.5f, -9, 0), Quaternion.identity);
            Instantiate(coin, new Vector3(pos * 3.5f, -11, 0), Quaternion.identity);
            Instantiate(coin, new Vector3(pos * 3.5f, -13, 0), Quaternion.identity);
        }
    }
}
