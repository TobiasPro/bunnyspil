using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject Target; 
   
    private Vector3 Offset;

    // Start is called before the first frame update
    void Start() {

        // Camera posistion - Target(Player) position
        Offset = transform.position - Target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Target != null)
        {
    transform.position = Target.transform.position+Offset;
        }
        // Her giver man camera samme position som spiller og tilføjere offsettet for at camera ikke skal være inde i player
        
        
    }
}
