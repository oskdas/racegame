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
    public GameObject player;
    Transform point;
    public GameObject startposition;
    public LakituController lakitu;

    private void Start()
    {
        checkPoint = GameObject.FindGameObjectsWithTag("CheckPoint");
        goalpanel.SetActive(false);
        point = startposition.transform;
    }

    void Update()
    {
        timer();
    }

    //ontriggerenterÇÕìñÇΩÇËîªíËÇ≈Ç‘Ç¬Ç©Ç¡ÇΩêlÇÕotherÇ…ì¸ÇÈ
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CheckPoint")
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            count += 1;
            point = other.gameObject.transform;
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
        if (other.gameObject.tag == "Bonnet")
        {
            lakitu.MovePosition();
            //player.transform.position = point.position;
            player.transform.localEulerAngles = point.localEulerAngles;
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            player.GetComponent<Rigidbody>().useGravity = false;
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            lakitu.point = point;
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
