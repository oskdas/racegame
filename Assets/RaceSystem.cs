using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceSystem : MonoBehaviour
{

    public Text timeText;

    public int count;
    private bool congoal, goalnow = false, StartGoalLine = false;
    private float time;
    private float seconds, minutes;
    private GameObject[] checkPoint;
    public int countRound = 0;
    public float[] roundTimes;
    public GameObject goalpanel;
    public float best=Mathf.Infinity;
    public Text bt;

    private void Start()
    {
        checkPoint = GameObject.FindGameObjectsWithTag("CheckPoint");
        goalpanel.SetActive(false);
    }

    void Update()
    {
        timer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CheckPoint")
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            count += 1;
        }
        if (other.gameObject.tag == "Line")
        {
            StartGoalLine = true;
            if (count == 7)
            {
                Debug.Log("GOAL!");

                foreach (GameObject point in checkPoint)
                {
                    point.SetActive(true);
                }
                goalnow = true;
            }
        }
    }

    void timer()
    {
        if (StartGoalLine)
        {
            time += Time.deltaTime;
            minutes = time / 60f;
            seconds = time % 60f;
        }


        if (!goalnow)
        {

            timeText.text = "Time" + ((int)minutes).ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        else
        {

            roundTimes[countRound] = time;
            if (time < best)
            {
                best = time;
            }
            countRound++;
            time = 0;
            count = 0;
            goalnow = false;
            if (countRound == roundTimes.Length)
            {
                StartGoalLine = false;
                goalpanel.SetActive(true);
                minutes = best / 60f;
                seconds = best % 60f;
                bt.text= ((int)minutes).ToString("00") + ":" + ((int)seconds).ToString("00");
            }
        }
    }
}
