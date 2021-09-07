using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private GameObject manager;
    private Rigidbody2D body;
    private bool pass = false;

    // Movement on Spawn
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.AddForce(new Vector2(0, moveSpeed));
        manager = GameObject.Find("GameManager");
    }

    private void FixedUpdate()
    {
        body.AddForce(new Vector2(0, manager.GetComponent<GameManager>().GetScore() * 0.001f));
        if(this.transform.position.y > 3 && !pass)
        {
            manager.GetComponent<GameManager>().PassedSpike();
            pass = true;
        }
        
        if(this.transform.position.y > 7)
        {
            Destroy(this.gameObject);
        }
    }
}
