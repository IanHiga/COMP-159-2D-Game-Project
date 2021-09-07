using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 2;
    [SerializeField] private GameObject manager;
    private float fallLeft; // Pos = yes, neg = no
    private bool falling;
    private Rigidbody2D heroPos;

    // Start is called before the first frame update
    void Start()
    {
        falling = true;
        fallLeft = 1;
        heroPos = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && !falling)
        {
            falling = true;
            fallLeft = (-1) * fallLeft;
        }
    }
    void FixedUpdate()
    {
        if(falling)
        {
            heroPos.AddForce(new Vector2(fallLeft * fallSpeed, 0));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        falling = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        manager.GetComponent<GameManager>().EndGame();
        Debug.Log("YOU LOSE");
    }
}
