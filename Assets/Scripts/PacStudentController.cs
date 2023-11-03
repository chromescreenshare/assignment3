using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    [SerializeField] private GameObject pacStudent;
    private Tweener pacTweener;
    private KeyCode lastInput;
    private KeyCode currentInput;
    [SerializeField] private Animator pacAnimator;

    private int[,] maze;
    private int[] mazeFlag = { 1, 2, 3, 4, 7 };

    private int lastMovementCalcX;
    private int lastMovementCalcY;

    private int currentMovementCalcX;
    private int currentMovementCalcY;

    // Start is called before the first frame update
    void Start()
    {
        pacTweener = GetComponent<Tweener>();
        maze = new int[,]
        {
            {1,2,2,2,2,2,2,2,2,2,2,2,2,7,7,2,2,2,2,2,2,2,2,2,2,2,2,1 },
            {2,5,5,5,5,5,5,5,5,5,5,5,5,4,4,5,5,5,5,5,5,5,5,5,5,5,5,2 },
            {2,5,3,4,4,3,5,3,4,4,4,3,5,4,4,5,3,4,4,4,3,5,3,4,4,3,5,2 },
            {2,6,4,0,0,4,5,4,0,0,0,4,5,4,4,5,4,0,0,0,4,5,4,0,0,4,6,2 },
            {2,5,3,4,4,3,5,3,4,4,4,3,5,3,3,5,3,4,4,4,3,5,3,4,4,3,5,2 },
            {2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2 },
            {2,5,3,4,4,3,5,3,3,5,3,4,4,4,4,4,4,3,5,3,3,5,3,4,4,3,5,2 },
            {2,5,3,4,4,3,5,4,4,5,3,4,4,3,3,4,4,3,5,4,4,5,3,4,4,3,5,2 },
            {2,5,5,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,5,5,2 },
            {1,2,2,2,2,1,5,4,3,4,4,3,0,4,4,0,3,4,4,3,4,5,1,2,2,2,2,1 },
            {0,0,0,0,0,2,5,4,3,4,4,3,0,3,3,0,3,4,4,3,4,5,2,0,0,0,0,0 },
            {0,0,0,0,0,2,5,4,4,0,0,0,0,0,0,0,0,0,0,4,4,5,2,0,0,0,0,0 },
            {0,0,0,0,0,2,5,4,4,0,3,4,4,0,0,4,4,3,0,4,4,5,2,0,0,0,0,0 },
            {2,2,2,2,2,1,5,3,3,0,4,0,0,0,0,0,0,4,0,3,3,5,1,2,2,2,2,2 },
            {0,0,0,0,0,0,5,0,0,0,4,0,0,0,0,0,0,4,0,0,0,5,0,0,0,0,0,0 },
            {2,2,2,2,2,1,5,3,3,0,4,0,0,0,0,0,0,4,0,3,3,5,1,2,2,2,2,2 },
            {0,0,0,0,0,2,5,4,4,0,3,4,4,0,0,4,4,3,0,4,4,5,2,0,0,0,0,0 },
            {0,0,0,0,0,2,5,4,4,0,0,0,0,0,0,0,0,0,0,4,4,5,2,0,0,0,0,0 },
            {0,0,0,0,0,2,5,4,3,4,4,3,0,3,3,0,3,4,4,3,4,5,2,0,0,0,0,0 },
            {1,2,2,2,2,1,5,4,3,4,4,3,0,4,4,0,3,4,4,3,4,5,1,2,2,2,2,1 },
            {2,5,5,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,5,5,2 },
            {2,5,3,4,4,3,5,4,4,5,3,4,4,3,3,4,4,3,5,4,4,5,3,4,4,3,5,2 },
            {2,5,3,4,4,3,5,3,3,5,3,4,4,4,4,4,4,3,5,3,3,5,3,4,4,3,5,2 },
            {2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2 },
            {2,5,3,4,4,3,5,3,4,4,4,3,5,3,3,5,3,4,4,4,3,5,3,4,4,3,5,2 },
            {2,6,4,0,0,4,5,4,0,0,0,4,5,4,4,5,4,0,0,0,4,5,4,0,0,4,6,2 },
            {2,5,3,4,4,3,5,3,4,4,4,3,5,4,4,5,3,4,4,4,3,5,3,4,4,3,5,2 },
            {2,5,5,5,5,5,5,5,5,5,5,5,5,4,4,5,5,5,5,5,5,5,5,5,5,5,5,2 },
            {1,2,2,2,2,2,2,2,2,2,2,2,2,7,7,2,2,2,2,2,2,2,2,2,2,2,2,1 }
        };

        lastMovementCalcX = -1;
        lastMovementCalcY = -1;

        currentMovementCalcX = -1;
        currentMovementCalcY = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            lastMovementCalcX = 0;
            lastMovementCalcY = 0;

            lastMovementCalcY = 1;
            lastInput = KeyCode.W;
            
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            lastMovementCalcX = 0;
            lastMovementCalcY = 0;

            lastMovementCalcY = -1;
            lastInput = KeyCode.S;
            
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            lastMovementCalcX = 0;
            lastMovementCalcY = 0;

            lastMovementCalcX = 1;
            lastInput = KeyCode.D;
            
        }



        else if (Input.GetKeyDown(KeyCode.A))
        {
            lastMovementCalcX = 0;
            lastMovementCalcY = 0;

            lastMovementCalcX = -1;
            lastInput = KeyCode.A;
            
        }

        if (lastBarrierCheck() == false)
        {
            pacAnimator.SetFloat("speed", 1.0f);
            Vector2 endPos = new Vector2(pacStudent.transform.position.x + lastMovementCalcX, pacStudent.transform.position.y + lastMovementCalcY);
            float duration = 1.0f;
            if (pacTweener.AddTween(pacStudent.transform, pacStudent.transform.position, endPos, duration))
            {
                currentInput = lastInput;
                currentMovementCalcX = lastMovementCalcX;
                currentMovementCalcY = lastMovementCalcY;
                pacAnimator.SetInteger("x", currentMovementCalcX);
                pacAnimator.SetInteger("y", currentMovementCalcY);
                pacAnimator.SetFloat("speed", 1.0f);
                if (currentMovementCalcX == -1)
                {
                    pacAnimator.SetTrigger("left");
                }

                else if (currentMovementCalcX == 1)
                {
                    pacAnimator.SetTrigger("right");
                }

                else if (currentMovementCalcY == -1)
                {
                    pacAnimator.SetTrigger("down");
                }

                else if (currentMovementCalcY == 1)
                {
                    pacAnimator.SetTrigger("up");
                }
            }

        }

        else if (currentBarrierCheck() == false)
        {
            pacAnimator.SetFloat("speed", 1.0f);
            Vector2 endPos = new Vector2(pacStudent.transform.position.x + currentMovementCalcX, pacStudent.transform.position.y + currentMovementCalcY);
            float duration = 1.0f;
            pacTweener.AddTween(pacStudent.transform, pacStudent.transform.position, endPos, duration);
        }
        else
        {
            pacAnimator.SetFloat("speed", 0.0f);
        }
    }

    bool lastBarrierCheck()
    {
        for (int i = 0; i < mazeFlag.Length; i++)
        {
            if (maze[Mathf.RoundToInt((29 - pacStudent.transform.position.y) - lastMovementCalcY), Mathf.RoundToInt(pacStudent.transform.position.x + lastMovementCalcX)] == mazeFlag[i])
            {
                return true;
            }
        }
        return false;
    }

    bool currentBarrierCheck()
    {
        for (int i = 0; i < mazeFlag.Length; i++)
        {
            if (maze[Mathf.RoundToInt((29 - pacStudent.transform.position.y) - currentMovementCalcY), Mathf.RoundToInt(pacStudent.transform.position.x + currentMovementCalcX)] == mazeFlag[i])
            {
                return true;
            }
        }
        return false;
    }
}
