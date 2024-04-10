using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score2 : MonoBehaviour
{

    public TMP_Text highscore;


    // Start is called before the first frame update
    void Start()
    {
        

        highscore.text = highscore.text.Replace("New Text", "Ditt highscore är " + (Timer.elapsedTime / 1000) + " sek");

        if(Timer.bestTime < Timer.elapsedTime)
        {
            Timer.elapsedTime = Timer.bestTime;
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
}
