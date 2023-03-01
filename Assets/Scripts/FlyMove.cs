using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FlyMove : MonoBehaviour
{
    public GameObject flysplat;
    public float moveSpeed = 5;
    public float deadZone = -45;
    private Animator anim;
    private Rigidbody2D rb;
    private Collider2D col;
    public LogicScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    
    void Update()
    {
        if (transform.position.x < deadZone)
        {
            Debug.Log("Fly Deleted");
            Destroy(gameObject);
        }

    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.x -= moveSpeed * Time.fixedDeltaTime;

        transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            logic.addScore(1);
            Death();
            Shot();
        }
    }

    public void Shot()
    {
        Instantiate(flysplat, transform.position, Quaternion.identity);
    }

    private void Death()
    {
        Destroy(this.gameObject);
    }
}
