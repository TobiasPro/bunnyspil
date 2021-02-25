using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerUp : MonoBehaviour
{
    public float JumpPowerDuration = 3;
    public float JumpPowerAmount = 800;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerMovement>().JumpPowerUp(JumpPowerDuration, JumpPowerAmount);
            Destroy(gameObject);
        }
    }

}
