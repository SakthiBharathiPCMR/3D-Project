using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Learning : MonoBehaviour
{
    void Start()
    {
        List<Worker> workers = new List<Worker>();

        for (int i = 0; i < 10; i++)
        {
            Worker worker = new Worker();
            worker.id = 9 - i;
            worker.name = "" + (char)(65 + i);
            workers.Add(worker);
        }

        workers.ForEach(x => Debug.Log(x.id + " " + x.name));

        workers = workers.OrderBy(x => x.id).ToList();

        workers.ForEach(x => Debug.Log(x.id + " " + x.name));
    }

}


public class Worker
{
    public int id;
    public string name;
}