using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FlySpawner : MonoBehaviour
{
    public GameObject fly;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 10;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        spawnFly();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnFly();
            timer = 0;
        }
    }

    void spawnFly()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(fly, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
