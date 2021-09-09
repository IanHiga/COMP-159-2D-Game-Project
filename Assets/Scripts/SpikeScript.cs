using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    [SerializeField] private float startSpeed;
    [SerializeField] private float speedMultiplier;
    private float speedUp;
    private GameObject manager;
    private Rigidbody2D body;
    private bool pass = false;

    // Movement on Spawn
    private void Start()
    {
        speedMultiplier *= 0.0001f;
        body = GetComponent<Rigidbody2D>();
        manager = GameObject.Find("GameManager");
    }

    private void FixedUpdate()
    {
        speedUp = manager.GetComponent<GameManager>().GetScore() * speedMultiplier;
        body.velocity = new Vector2(0, startSpeed + speedUp);
        Debug.Log(startSpeed + speedUp);
        if(this.transform.position.y > 3 && !pass)
        {
            manager.GetComponent<GameManager>().PassedSpike();
            pass = true;
        }
        
        if(this.transform.position.y > 10)
        {
            Destroy(this.gameObject);
        }
    }
}
