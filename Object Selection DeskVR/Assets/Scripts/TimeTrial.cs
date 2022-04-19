using UnityEngine;
using System;

public class TimeTrial : MonoBehaviour
{
    public GameObject wantedObject;

    bool isCounting = false;
    double time = 0;
    double finalTime;

    int numberOfAttempts = 0;


    public void StartCounting()
    {
        if (!isCounting)
        {
            isCounting = true;
            time = 0;
            numberOfAttempts = 0;
        }
    }
    
    public void StopCounting(string name)
    {
        numberOfAttempts++;

        if (name == wantedObject.name)
        {
            isCounting = false;
            finalTime = Math.Round(time, 2);
            double accuracy = Math.Round((double) 1 / numberOfAttempts, 2) * 100;
            Debug.Log("Final time: " + finalTime + "; Accuracy: " + accuracy + "%");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isCounting)
        {
            time += Time.deltaTime;
        }
    }
}
