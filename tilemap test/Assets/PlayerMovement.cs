using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D ribo;

    // Start is called before the first frame update
    private void Start()
    {
        ribo = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        ribo.velocity = new Vector2(dirX * 4f, ribo.velocity.y);
        if (Input.GetKeyDown("space"))
        {
            ribo.velocity = new Vector2(ribo.velocity.x, 5f);
        }
    }
}