using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    // Refference til TimeManager
    public TimeManager TM;

    public int NextLevel;
    public float TimeUntilNextLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            TM.StopAndSaveScore();

            StartCoroutine(WaitAndChangeLevel());
        }
    }


    IEnumerator WaitAndChangeLevel()
    {
        yield return new WaitForSeconds(TimeUntilNextLevel);
        SceneManager.LoadScene(NextLevel);
    }

}
