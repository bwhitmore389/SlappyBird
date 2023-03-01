using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingFlap : MonoBehaviour
{
    public Sprite Bird_flap;
    private SpriteRenderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _renderer= GetComponent<SpriteRenderer>();
        if ( _renderer==null)
        {
            Debug.LogError("Player Sprite is missing a renderer");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _renderer.flipY = true;
            
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            _renderer.flipY = false;
        }
    }
}
