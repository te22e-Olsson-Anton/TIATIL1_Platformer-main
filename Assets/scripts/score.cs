using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;

    public static float elapsedTime;

    public static float bestTime;

    void Update()
    {
        elapsedTime += Time.deltaTime * 1000; 

        
        timerText.text = FormatTime(elapsedTime);
    }

    
    private string FormatTime(float time)
    {
        int minutes = (int)(time / 60000);
        int seconds = (int)((time / 1000) % 60);
        int milliseconds = (int)(time % 1000);

        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}
