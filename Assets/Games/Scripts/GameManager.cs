using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const float FOOD_Y_OFFSET = 0.4f;
    public int xRange { get; } = 15;
    public int zRange { get; } = 8;

    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private Snake snake;
    [SerializeField] private Transform foodParentTransform;

    public static GameManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        SpawnFoodAtStart();
    }

    private void SpawnFoodAtStart()
    {
        Invoke("SpawnFoodInRandomPos", 1f);
    }


    public void FoodCollected()
    {
        snake.GrowSnake(3);
        SpawnFoodInRandomPos();
    }


    private void SpawnFoodInRandomPos()
    {
        GameObject food = Instantiate(foodPrefab, foodParentTransform);

        food.transform.position = GetFreeLocation();
    }

    private Vector3 GetFreeLocation()
    {
        Vector3 randomPos;
        do
        {
            randomPos = new Vector3(Random.Range(-xRange, xRange), FOOD_Y_OFFSET, Random.Range(-zRange, zRange));
        }
        while (snake.snakePositionList.Contains(randomPos));

        return randomPos;

    }

}
