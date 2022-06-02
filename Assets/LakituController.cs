using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakituController : MonoBehaviour
{
    public GameObject player;
    Vector3 targetPosition;
    bool isMove = false;
    public Transform point;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 100);
            if (transform.position.y > 19)
            {
                //isMove = false;
                targetPosition = point.position;
                targetPosition.y = 20;
                if (transform.position.x == targetPosition.x && transform.position.z == targetPosition.z)
                {

                    player.transform.parent = null;
                    isMove = false;
                    player.GetComponent<Rigidbody>().useGravity = true;
                    player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                }
            }

        }
    }
    public void MovePosition()
    {
        this.transform.position = player.transform.position + new Vector3(0, 10, 0);
        player.transform.parent = this.transform;
        targetPosition = this.transform.position;
        targetPosition.y = 20;
        isMove = true;
    }
}
