using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTrigger : MonoBehaviour
{
    public List<GameObject> Targets;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            for (int i = 0; i < Targets.Count; i++)
            {
                Targets[i].GetComponent<SpikeFall>().DropPlatform();
            }
        }
    }
}
