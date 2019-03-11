using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LillypadBound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D colliderRB = collision.collider.GetComponent<Rigidbody2D>();
        colliderRB.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
    }
}
