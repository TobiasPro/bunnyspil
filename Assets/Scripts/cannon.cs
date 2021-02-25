using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{

    public GameObject SpawnPoint;
    public GameObject BulletPrefab;

// her laver vi en public for farten
    public float Speed = 10;
// her laver vi en public med hvor lang tid der skal gå mellem skud. Vi laver 2 en min og max for at udvikle en random værdi
    public float ShootIntervalMin;
    public float ShootIntervalMax;

    // En IEnumerator kan også være start i stedet for void hvilket gør at koden bliver kørt i starten af spillet
    IEnumerator Start()
    {               // Instantiate betyder at klone, så lav klon af bullet som skal være typen GameObject
        GameObject spawn = Instantiate(BulletPrefab) as GameObject;
        spawn.transform.position = SpawnPoint.transform.position;
        // Her ændre vi på bullet volicity så den ikke bare falder når den bliver spawnet. SpawnPoint.transform.right; får bullets til at komme ud af den røde streg af cannon. Denne vektor er meget langsom derfor * vi med speed floaten som vi lavede tidligere
        spawn.GetComponent<Rigidbody2D>().velocity = SpawnPoint.transform.right*Speed;
        
        
        
        // Her sørger vi for at bullet ødelægger sig selv efter 3 sekunder
        Destroy(spawn,3);
// Her bruger vi igen Random.Rage til at gøre størrelsen af bullet forskellig. Random.Range er god når man skal random generate noget.
        spawn.transform.localScale *= Random.Range(1, 3);

    // Her får vi den til at vente imellem skud. Vi laver også en random generate imellem min og max. Vi skal dog huske at med denne metode hvis 10 er max vil den kun kan ramme 9. Hvis det havde været en float med 10 max vil den kan ramme 9,999
        yield return new WaitForSeconds(Random.Range(ShootIntervalMin, ShootIntervalMax));
    // Efter den har ventet vil den så starte igen
        StartCoroutine(Start());
    }

}
