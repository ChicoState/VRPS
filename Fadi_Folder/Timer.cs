using UnityEngine;
using System.Collections;
using UnityEngine.UI; // allow us to use text

public class Timer : MonoBehaviour
{
    private float seconds,minutes,hours; // float variables to hold the time value
    private Text Text_Box;

    void Start()
    {
        seconds = 0.0f;
        minutes = 0.0f;
        hours = 0.0f;

        Text_Box = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime; // update seconds every frame

        if (seconds > 59.0f)
        {
            minutes += 1.0f;
            seconds = 0.0f;
        }
        else if (minutes > 59.0f)
        {
            hours += 1.0f;
            minutes = 0.0f;
        }
        else if (hours > 23.0f)
        {
            hours = 0.0f;
            minutes = 0.0f;
            seconds = 0.0f;
        }

        //converts value to string text with no fractions(f0) and print the result.
        Text_Box.text = "Timer: " + hours.ToString("f0") + ":" + minutes.ToString("f0") +":" + seconds.ToString("f0");
    }
}
