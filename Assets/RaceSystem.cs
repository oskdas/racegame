using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceSystem : MonoBehaviour
{

    public Text timeText;

    private int count;
    private bool congoal, goalnow = false, StartGoalLine = false;
    private float seconds, minutes;

    void Update()
    {
        timer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CheckPoint")
        {
            Destroy(other.gameObject);
            count += 1;
        }
        if (other.gameObject.tag == "Line")
        {
            if (count == 6)
            {
                Debug.Log("GOAL!");
                StartGoalLine = false;
                goalnow = true;
            }
            else
            {
                StartGoalLine = true;
            }
        }
    }

    void timer()
    {
        if (StartGoalLine)
        {
            seconds += Time.deltaTime;
        }

        if (seconds >= 60)
        {
            minutes++;
            seconds -= 60;
        }

        if (!goalnow)
        {

            timeText.text = "Time" + minutes.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        else
        {

            timeText.text = "ÉSÅ[ÉãÉ^ÉCÉÄÇÕ  " + minutes.ToString("00") +":"+((int)seconds).ToString("00");
        }
    }
}
