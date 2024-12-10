using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private const float yOffset = 0.35f;

    [SerializeField] private GameObject snakeBodyPrefab;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float repeateRate = 0.3f;

    private List<GameObject> snakeBodyList = new List<GameObject>();
    private List<Vector3> snakePositionList = new List<Vector3>();
    private Vector3Int directionOfSnake;
    private Vector3 bodyoffset;

    private void Start()
    {
        directionOfSnake = Vector3Int.forward;
        bodyoffset = Vector3.up * yOffset;

        for (int i = 0; i < 5; i++)
        {
            GameObject snakeBody = Instantiate(snakeBodyPrefab);
            snakeBodyList.Add(snakeBody);
        }
        InvokeRepeating("MoveOneStep", 1, repeateRate);
    }

    private void Update()
    {
        HandleInput();
        MoveSnake();

        snakePositionList.Insert(0, (transform.position - bodyoffset));


    }

    private void MoveSnake()
    {
        transform.forward = directionOfSnake;

        //transform.Translate(directionOfSnake * Time.deltaTime * moveSpeed, Space.World);

    }


    private void MoveOneStep()
    {
        transform.position += directionOfSnake;
        for (int i = 0; i < snakeBodyList.Count; i++)
        {
            Vector3 point = snakePositionList[Mathf.Min(i, snakePositionList.Count - 1)];
            GameObject body = snakeBodyList[i];
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection;
        }

    }

    private void HandleInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");


        float verticalInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput > 0 && directionOfSnake.x != -1)
        {
            directionOfSnake = Vector3Int.right;
        }
        else if (horizontalInput < 0 && directionOfSnake.x != +1)
        {
            directionOfSnake = Vector3Int.left;

        }
        else if (verticalInput > 0 && directionOfSnake.z != -1)
        {
            directionOfSnake = Vector3Int.forward;

        }
        else if (verticalInput < 0 && directionOfSnake.z != +1)
        {
            directionOfSnake = Vector3Int.back;

        }
    }




}
