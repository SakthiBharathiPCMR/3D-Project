using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private const float Body_Y_Offset = 0.35f;

    [SerializeField] private GameObject snakeBodyPrefab;
    [SerializeField] private Transform bodyParentTransform;

    private List<GameObject> snakeBodyList = new List<GameObject>();
    public List<Vector3> snakePositionList = new List<Vector3>();
    private Vector3 directionOfSnake;
    private float waitTime = 0.2f;


    private void Start()
    {
        directionOfSnake = Vector3.forward;

        GrowSnake(5);

        //   InvokeRepeating("MoveOneStep", 1, waitTime);
        StartCoroutine("HandleSnakeMovement");
    }

    private void Update()
    {
        HandleInput();

    }

    private IEnumerator HandleSnakeMovement()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            snakePositionList.Insert(0, transform.position);

            transform.position += directionOfSnake;

            transform.forward = directionOfSnake;

            MoveSnakeInPlaySpace();
            UpdateBodyPosition();

        }
    }

    private void MoveSnakeInPlaySpace()
    {

        int xRange = GameManager.instance.xRange;
        int zRange = GameManager.instance.zRange;

        float snakeXPos = transform.position.x;
        float snakeZPos = transform.position.z;

        if (snakeXPos > xRange)
        {
            transform.position = new Vector3(-xRange, 0, snakeZPos);
        }
        else if (snakeXPos < -xRange)
        {
            transform.position = new Vector3(xRange, 0, snakeZPos);
        }
        else if (snakeZPos > zRange)
        {
            transform.position = new Vector3(snakeXPos, 0, -zRange);
        }
        else if (snakeZPos < -zRange)
        {
            transform.position = new Vector3(snakeXPos, 0, zRange);
        }
    }




    private void UpdateBodyPosition()
    {

        for (int i = 0; i < snakeBodyList.Count; i++)
        {
            Vector3 point = snakePositionList[Mathf.Min(i, snakePositionList.Count - 1)];
            GameObject body = snakeBodyList[i];
            body.transform.position = new Vector3(point.x, Body_Y_Offset, point.z);

        }

        RemoveUsedPosition();

    }

    private void RemoveUsedPosition()
    {
        int maxListSize = snakeBodyList.Count;

        if (snakePositionList.Count > maxListSize)
        {
            snakePositionList.RemoveAt(snakePositionList.Count - 1);
        }
    }

    private void HandleInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");


        float verticalInput = Input.GetAxisRaw("Vertical");

        if (directionOfSnake != transform.forward) return;


        if (horizontalInput > 0 && directionOfSnake.x != -1)
        {
            directionOfSnake = Vector3.right;
        }
        else if (horizontalInput < 0 && directionOfSnake.x != +1)
        {
            directionOfSnake = Vector3.left;

        }
        else if (verticalInput > 0 && directionOfSnake.z != -1)
        {
            directionOfSnake = Vector3.forward;

        }
        else if (verticalInput < 0 && directionOfSnake.z != +1)
        {
            directionOfSnake = Vector3.back;
        }
    }

    public void GrowSnake(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject snakeBody = Instantiate(snakeBodyPrefab, bodyParentTransform);
            snakeBodyList.Add(snakeBody);

           /* if (snakeBodyList.Count > 0)
            {
                int index = snakeBodyList.Count - 1;
                snakeBody.transform.position = snakeBodyList[index].transform.position;
            }*/
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StopCoroutine("HandleSnakeMovement");
        }
    }



}
