using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeFall : MonoBehaviour
{

    public float FallDelay;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void DropPlatform()
    {
        rb.isKinematic = false;
        Destroy(gameObject, 2f);
    }
}
