using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Speed;
    public float JumpPower;

    private Rigidbody2D RB;

    // Dette bruges til at lave en layer mask så vores raycast ikke dector Player
    public LayerMask Mask;

    public Animator PlayerAnimator;
    public SpriteRenderer SR;

    private float _startJumpPower;
    private float _startSpeed;
    // Denne bliver brugt til at gøre så man ikke kan uendeligt hoppe i luften
    private bool _isGrounded;

    // Start is called before the first frame update
    void Start() {
        RB = GetComponent<Rigidbody2D>();
        _startJumpPower = JumpPower;
        _startSpeed = Speed;
    }

    // Update is called once per frame
    void Update()  {
        // Dette styrer movement a og d på spilleren 
        Vector2 movement = new Vector2(0, RB.velocity.y);

        // Her finder vi midten af kaniens y og tager den nederste
        float DistanceToGround = GetComponent<Collider2D>().bounds.extents.y;

// Her bruges Mask til at sørge for at raycast ikke rammer Player
    _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, DistanceToGround + 0.5f, Mask);




        if (Input.GetKey(KeyCode.A))
        {
            movement.x = -Speed;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            movement.x = Speed;
        }

// Her kan sørger man får characteren kan hoppe
      
      // && _isGrounded == true gør at jeg ikke kan hoppe når jeg er i luften. Koden er true fordi jeg skal være på jorden og trykke space for at hoppe.
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == true)
        {
            RB.AddForce(new Vector2(0, JumpPower));
            _isGrounded = false;
        }

        // != betyder ikke = 0 
        if(movement.x != 0)
        {
            // Her refferer vi til den bool vom vi lavede inde i unity kaldet IsMoving
            PlayerAnimator.SetBool("IsMoving", true);
        }
        else
        {
            // Hvis X ikke bevæger sig må animation ikke afspilles
            PlayerAnimator.SetBool("IsMoving", false);
        }

// Her sørger vi for at når x-aksen går i en positiv retning skal player gå mod højre. Når X-aksen går i negativ skal animation gå mod venstre
        if(movement.x >= 0)
        {
            SR.flipX = false;
        }
        else{
            SR.flipX = true;
        }

        RB.velocity = movement;
    }



    // Her sætter vi en timer for poweruppen så den ikke varer forevigt. Så istedet for at ændre JumpPowerUp tal får vi den nu til at kører dette kode
    public void JumpPowerUp(float seconds, float Power)
    {
        StartCoroutine(RunJumpPowerup(seconds, Power));
    }
                                                                 // Her nde er Coroutine
                                                                 // Kan stoppe koden i noget tid og så komme tilbage og ændre noget andet kode unden at skulle lave en timeout
                                                                  // Det koden gør et at skifte spillerens jumpower ud med den nuværende og så venter den 3 sekunder før den går videre til næste linje hvor den så skal gå tilbage til start JumpPower
    IEnumerator RunJumpPowerup(float seconds, float Power)
    {
        JumpPower = Power; 
        yield return new WaitForSeconds(seconds);
        JumpPower = _startJumpPower;

    }

    public void SpeedPowerup(float sec, float sPower)
    {
        StartCoroutine(RunSpeedBoost(sec, sPower));
    }

    IEnumerator RunSpeedBoost(float seconds, float speedPower)
    {
        Speed = speedPower;
        yield return new WaitForSeconds(seconds);
        Speed = _startSpeed;
    }

}
