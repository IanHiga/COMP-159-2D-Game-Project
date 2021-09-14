using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField] GameObject hero;
    // Start is called before the first frame update
    [SerializeField] private float startSpeed;
    [SerializeField] private float speedMultiplier;
    private float speedUp;
    private GameObject manager;
    private Rigidbody2D body;

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
        if (this.transform.position.y > 10)
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        transform.rotation *= Quaternion.Euler(new Vector3(0, 0.1f, 0));
    }

    public void DeleteThis()
    {
        Destroy(this.gameObject);
    }
}
