using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{

    public TextMeshProUGUI TextTid;
    public TextMeshProUGUI TextHighscore;

// Dette bruger vi til styre hvilke level vi er i
    private string _currentLevelName;

    private float _timeInLevel;
    // Man har brug for bool for at kunne stoppe tiden
    private bool _runTimer = true;


    // Start is called before the first frame update
    void Start()
    {
        // Her får vi navnet på den nuværende bane. Det gør vi så vi kan gemme en highscoren ved hver enkelt level
        _currentLevelName = SceneManager.GetActiveScene().name;

        // Her gemmer vi Highscore i en string som vi gemte som en float i playerprefs. _currentlevelname gør at den kun holder øje med det nuværende level så man får en forskellige score ved hver level
        string score = "Highscore: "+PlayerPrefs.GetFloat(_currentLevelName).ToString("F1");
        // Denne linje sætter så score som vi har gemt til at være TextHighscore
        TextHighscore.text = score;
    }

    // Update is called once per frame
    void Update()
    {
        // Hvis _runTimer er true forsætter den med at tælde op
        if(_runTimer == true)
        {
        // Her får den _timeInLevel til langsomt gå op i sekunder med deltatime
        _timeInLevel += Time.deltaTime;
        }
        // .text betyder vi går ind i selve teksten og ændre den ToString "F1" styre hvor mange decimaler man har i sin tid tager
        TextTid.text = "Tid: " + _timeInLevel.ToString("F1");
    }

    public void StopAndSaveScore()
    {
        // Når tiden skal stoppe skal _runTimer være false
        _runTimer = false;

        // Her sørger vi får at hvis last score er mindre end den nuværende highscore gemmer den ikke. _currentlevelname gør at den kun holder øje med det nuværende level
        float lastScore = PlayerPrefs.GetFloat(_currentLevelName);
      // || betyder eller og både score som vi har som playerprefs så lang tid at vores tid er hurtigere end den og hvis last score er 0 må der gerne skrives en score. Så hvis scoren er 0 til starte får man lov til at skrive en score.
        if(lastScore > _timeInLevel || lastScore == 0)
        {
// Den her funktion sørger for at tiden bliver gemt næste step er så at sætte den på highscoren
        PlayerPrefs.SetFloat("Highscore", _timeInLevel);
        }
        
    }
}
