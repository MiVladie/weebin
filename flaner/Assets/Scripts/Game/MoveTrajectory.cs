using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrajectory : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool rotate = true;
    [SerializeField] bool moveOnCollision = false;
    [SerializeField] bool oneWay = false;
    [SerializeField] Vector3[] pathPoints;

    private int nextPosIndex;
    private bool isHolding;
    private bool endReached = false;

    private Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = pathPoints[0];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool canMove = true;

        if(moveOnCollision)
        {
            if(!isHolding)
            {
                canMove = false;
            }
        }
        
        if(oneWay)
        {
            if(endReached)
            {
                canMove = false;
            }
        }

        if(canMove)
            Move();
    }

    void Move()
    {
        if (transform.localPosition == nextPos)
        {
            nextPosIndex++;

            if (nextPosIndex >= pathPoints.Length)
            {   
                if(oneWay) {
                    endReached = true;
                    
                    return;
                }
                else
                {
                    nextPosIndex = 0;
                }
            }

            nextPos = pathPoints[nextPosIndex];

            if(rotate) {
                transform.LookAt(nextPos);
            }
        }
        else
        {
            GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime));
        }
    }
    
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            isHolding = true;
        }
    }
    
    private void OnCollisionExit(Collision col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            isHolding = false;
        }
    }

}
