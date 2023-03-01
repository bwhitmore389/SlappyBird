using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LogicScript logic;
    public float speed;
    private Rigidbody2D rb;
    public Rigidbody2D flyBody;
    public float deadZone = 32;

    void OnCollisionEnter2D()
    {
        Debug.Log("Bullet Deleted");
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void Update()
    {
        if (transform.position.x > deadZone)
        {
            Debug.Log("Bullet Deleted");
            Destroy(gameObject);
        }
    }
}
