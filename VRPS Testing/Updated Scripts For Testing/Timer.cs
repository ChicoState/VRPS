using UnityEngine;
using System.Collections;
using UnityEngine.UI; // allow us to use text

// Written and modified by Fadi Yousif 
// attach to the timer's text 

public class Timer : MonoBehaviour
{
  public int MaxSec, MaxMin, MaxHour;

  public bool FreeClock = true; // if false then the timer will run in TimedClock Mode
  public bool ClockValueProvided = false;

  private float seconds; // float because time class is in units of float.
  private int minutes, hours;
  public Text Text_Box;

  public void Start()
  {
    seconds = 0.0f; minutes = 0; hours = 0;
    Text_Box = GetComponent<Text>(); // grants access to the Text box component of this object

    if (!FreeClock)// TimedClock, check to see if a value is provided by the user, otherwise display a warning msg
    {
      if (MaxHour > 0 || MaxMin > 0 || MaxSec > 0)
        ClockValueProvided = true;
    }//if
  }//start

  // Update is called once per frame
  public void Update()
  {
    seconds += Time.deltaTime; // update seconds every frame

    if (!FreeClock) // when not in free clock mode
      IssueWarning();

    //if ((ClockValueProvided && FreeClock) || (!ClockValueProvided && FreeClock) || (ClockValueProvided && !FreeClock))
    if (!(!ClockValueProvided && !FreeClock)) // if it is not Freeclock and time is not provided by the user then do not run the timer.
    {
      if (seconds > 59.0f)
      {
        seconds = 0.0f;
        minutes++;
        if (minutes > 59.0f)
        {
          minutes = 0;
          hours++;
          if (hours > 23.0f)
          {
            hours = 0;
          }// hours (if)
        } // minutes (if)
      }// seconds (if)

      //converts value to string text with no fractions(f0) and print the result.
      Text_Box.text = "Timer: " + hours.ToString("f0") + ":" + minutes.ToString("f0") + ":" + seconds.ToString("f0");
    }//if
  }// update

  private void IssueWarning()
  {
    // Find out whether current second is odd or even
    bool oddeven = Mathf.FloorToInt(Time.time) % 2 == 0;

    if (!ClockValueProvided) // the user didnt provide any value in the fields, aka the values are 00:00:00.
    {
      Text_Box.text = "No Time Provided";
      Text_Box.color = new Color(0F, 1F, 0F, 1F); // color Green
    }//if

    else if (MaxHour > hours)        // if proivded hour is bigger than the hours value then just return.
      return;

    else if (MaxHour == hours)       // if the hour values are matched then check the minutes value
    {
      if (MaxMin > minutes)
        return;
      else if (MaxMin == minutes) // if the minutes values are matched then check the seconds value
      {
        if (MaxSec > seconds)
          return;
        else
        {                       // issue the warning
          if (oddeven) Text_Box.color = new Color(1F, 0F, 0F, 1F); // color red
          else Text_Box.color = new Color(1F, 1F, 1F, 1F);         // color white
        }
      }
      else                        // if minutes > MaxMin
      {                           // issue the warning
        if (oddeven) Text_Box.color = new Color(1F, 0F, 0F, 1F); // color red
        else Text_Box.color = new Color(1F, 1F, 1F, 1F);         // color white
      }
    }// else if
    else                            // if hours > MaxHour 
    {                               // issue the warning
      if (oddeven) Text_Box.color = new Color(1F, 0F, 0F, 1F); // color red
      else Text_Box.color = new Color(1F, 1F, 1F, 1F);         // color white
    }
  }//IssueWarning

}//class
