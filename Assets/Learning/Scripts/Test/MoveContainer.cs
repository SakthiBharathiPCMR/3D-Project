using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveContainer : MonoBehaviour
{
    public static MoveContainer instance;
    public Train trainObj;
    public float amplitude;
    public float frequency;
    public float stepDis;
    public float moveSpeed;
    public float followSpeed;
    internal Vector3 startPos;
    public List<Train> trains;
    internal List<Train> inActiveTrains;

    private void Awake()
    {
        instance = this;
        inActiveTrains = new List<Train>();
    }

    internal void AddToTrains(Train train)
    {
        train.gameObject.SetActive(false);
        inActiveTrains.Add(train);
    }

    private void Start()
    {
        startPos = Camera.main.ViewportToWorldPoint(new Vector3(-0.2f, 0.5f, 20f));
    }
    private void Update()
    {
      
    }

    private void SpawnTrain()
    {
        Train train;
        if (inActiveTrains.Count > 0)
        {
            train = inActiveTrains[0];
            inActiveTrains.RemoveAt(0);
        }
        else
        {
            train = Instantiate(trainObj);
            train.FillColor();
        }
        train.transform.position = startPos;
        train.gameObject.SetActive(true);
    }

    public void RemoveTrain(Train train)
    {
        train.gameObject.SetActive(false);
        trains.Remove(train);
    }
}

