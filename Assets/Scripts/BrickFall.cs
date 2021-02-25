using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickFall : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        
    }

    // Hvis Player colider skal den invoke "DropPlatform" hvilket giver et halvt sekund til grunden falder. Efter 2 sekunder slettes den. Vi sætter Rigbody type tilbage til dynamic
    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag.Equals ("Player"))
        {
            Invoke ("DropPlatform", 0.5f);
            Destroy(gameObject, 2f);
        }
    }
    void DropPlatform()
    {
        rb.isKinematic = false;
    }
}

