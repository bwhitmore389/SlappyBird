using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject BulletPrefab;
    public GameObject Bird;

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            Instantiate(BulletPrefab, shootingPoint.position, transform.rotation);
            Bird.gameObject.transform.Rotate(new Vector3(0, 180, 0));
        }
        else if (Keyboard.current.leftArrowKey.wasReleasedThisFrame)
        {
            Bird.gameObject.transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}
