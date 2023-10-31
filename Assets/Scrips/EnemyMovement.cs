using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Speed = 10;
    public bool IsMovingRight = true;

    public float LeftBoundry;
    public float RightBoundry;

    private void Start()
    {
        LeftBoundry = transform.position.x + LeftBoundry;
        RightBoundry = transform.position.x + RightBoundry;
    }

    void Update()
    {
        if (IsMovingRight)
        {
            transform.position += new Vector3(Speed, 0, 0) * Time.deltaTime;
        }
        else
        {
            transform.position -= new Vector3(Speed, 0, 0) * Time.deltaTime; //If we want to move left.
        }

        if(transform.position.x >= RightBoundry) //If it's past the right boundry it will move left.
        {
            IsMovingRight = false;
        }

        if(transform.position.x <= LeftBoundry) //If it's past the left boundry it will move right.
        {
            IsMovingRight = true;
        }
    }
}
