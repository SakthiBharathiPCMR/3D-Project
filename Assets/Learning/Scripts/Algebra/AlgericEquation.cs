using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AlgericEquation : MonoBehaviour
{



    void Start()
    {
        //Debug.Log(SumOfNumber());
        //Scaling();
        //Debug.Log(Distance());
        //Debug.Log(Lerp());
        //Modulo();
        //Grid();

        for (int i = 0; i < 40; i++)
        {
            Debug.Log(i + "Mod 3 is:" + i % 10);
        }
    }





    public void Grid()
    {
        int cols = 5; // Number of columns
        int rows = 4; // Number of rows

        for (int i = 0; i < cols * rows; i++)
        {
            int x = i % cols;    // Column
            int y = i / cols;    // Row
            Debug.Log($"Position: ({x}, {y})");
        }
    }
    public void Modulo()
    {
        int[] items = { 10, 20, 30, 40 };
        int currentIndex = 0;

        for (int i = 0; i < 10; i++) // Simulate cycling through indices
        {
            currentIndex = (currentIndex + 1) % items.Length;
            Debug.Log("curINd" + currentIndex); // Wrap around
            Debug.Log(items[currentIndex]);
        }
    }

    public float startPoint = 5;
    public float endPoint = 15;

    public float t = 0.5f;

    public float Lerp()
    {
        return startPoint + (endPoint - startPoint) * t;
    }



    public Vector2 pointA = new Vector2(1, 1);
    public Vector2 pointB = new Vector2(4, 5);

    public float Distance()
    {
        float num1 = pointA.x - pointB.x;
        float num2 = pointA.y - pointB.y;
        float result = Mathf.Sqrt((num1 * num1) + (num2 * num2));
        return result;
    }

    public float a = 1;      // Initial scale
    public float r = 1.2f;   // Growth ratio
    public int n = 5;        // Total objects


    public void Scaling()
    {
        for (int i = 0; i < n; i++)
        {
            float scale = a * Mathf.Pow(r, i); // Calculate scale
            Debug.Log(scale);
        }
    }

    public int totalNum;
    public int startNum;
    public int endNum;


    public int SumOfNumber()
    {
        return totalNum * (startNum + endNum) / 2;
    }



}
