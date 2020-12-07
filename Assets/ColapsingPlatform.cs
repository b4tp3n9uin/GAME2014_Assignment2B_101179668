using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColapsingPlatform : MonoBehaviour
{

    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("CollapsePlatform", 1.0f);
            Destroy(gameObject, 2.0f);
        }
    }

    void CollapsePlatform()
    {
        rigidbody.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
