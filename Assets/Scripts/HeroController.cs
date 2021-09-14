using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroController : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 2;
    [SerializeField] private GameObject manager;
    [SerializeField] private Text instruct;
    [SerializeField] private GameObject music;
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
        if (Input.GetKeyDown(KeyCode.Space) && !falling)
        {
            instruct.GetComponent<Text>().enabled = false;
            falling = true;
            fallLeft = (-1) * fallLeft;
        }
    }
    void FixedUpdate()
    {
        var fallMultiplier = manager.GetComponent<GameManager>().GetScore() * 0.005f;
        if(falling)
        {
            heroPos.AddForce(new Vector2(fallLeft * (fallSpeed + fallMultiplier), 0), ForceMode2D.Impulse);
        }

        if (fallLeft == 1)
        {
            transform.rotation *= Quaternion.Euler(new Vector3(0, 0, 3f));
        }
        else
        {
            transform.rotation *= Quaternion.Euler(new Vector3(0, 0, -3f));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        falling = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Spike")
        {
            music.GetComponent<AudioSource>().mute = true;
            this.GetComponent<AudioSource>().Play();
            manager.GetComponent<GameManager>().EndGame();
            Debug.Log("YOU LOSE");
        }
        else if(collision.gameObject.tag == "Coin")
        {
            manager.GetComponent<GameManager>().CollectCoin();
            collision.gameObject.GetComponent<CoinScript>().DeleteThis();
        }
    }
}
