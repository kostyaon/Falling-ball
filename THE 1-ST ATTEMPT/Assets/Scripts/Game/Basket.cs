using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public Scores obj;
    public Rigidbody2D rb_bask
    {
        get
        {
            return rb;
        }
    }
    private Rigidbody2D rb;
    private float value;
    private GameObject ball;

    private void Awake()
    {
        ball = GameObject.FindGameObjectWithTag("Player");
        obj = ball.GetComponent<Scores>();
    }
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, obj.speed);
        FindObjectOfType<ParticleSystem>().Stop();
    }

    void Update()
    {
        value = ball.transform.position.y - rb.transform.position.y;

        if (transform.position.y > 6.7f)
        {
            Destroy(this.gameObject);
        }
        
        if (value < -0.89f && value > -0.934f && obj.objCheck == false)
        {
            obj.checkHealth(Scores.health);
        }

    }

}
