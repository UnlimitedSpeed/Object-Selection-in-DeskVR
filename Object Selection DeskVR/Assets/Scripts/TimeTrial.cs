using UnityEngine;
using System;
using System.IO;

public class TimeTrial : MonoBehaviour
{
    public string participant = "";
    public GameObject[] wantedObject;
    public ChangeMaterial ChangeMaterial;

    string filename;
    bool isCounting = false;
    double finalTime = 0;
    int currentIndex = 0;

    DateTime time;
    DateTime startTime;

    int numberOfAttempts = 0;
    int totalAttempts = 0;

    TextWriter tw;

    void Start()
    {
        if (wantedObject.Length != 0)
        {
            filename = Application.dataPath + "/Results/" + participant + ".csv";
            
            //tw.Close();
            currentIndex = 0;
            wantedObject[currentIndex].AddComponent<Outline>();
        }
    }


    void Update()
    {
        if (isCounting)
        {
            finalTime += Time.deltaTime;
        }
    }

    void WriteToCSV(string name, double time, int attempts)
    {
        tw = new StreamWriter(filename, true);
        tw.WriteLine( name + ", " + time + ", " + attempts);
        tw.Close();
    }

    public void StartCounting()
    {
        if (!isCounting && wantedObject.Length > 0)
        {
            tw = new StreamWriter(filename, true);
            tw.WriteLine("Name, finalTime, numberOfAttempts");
            tw.Close();
            print("Start");
            isCounting = true;
            time = DateTime.Now;
            startTime = DateTime.Now;
            numberOfAttempts = 0;
            finalTime = 0;
            totalAttempts = 0;
            currentIndex = 0;
        }
    }

    public void StopCounting(string name)
    {
        if (wantedObject.Length > 0)
        {
            numberOfAttempts++;
            totalAttempts++;

            if (name == wantedObject[currentIndex].name)
            {
                Destroy(wantedObject[currentIndex].GetComponent<Outline>());
                DateTime now = DateTime.Now;
                TimeSpan diff = now - time;

                WriteToCSV(name, diff.TotalMilliseconds, numberOfAttempts);
                numberOfAttempts = 0;

                if (currentIndex == wantedObject.Length - 1)
                {
                    isCounting = false;
                    diff = now - startTime;
                    WriteToCSV("Total", diff.TotalMilliseconds, totalAttempts);
                    
                }
                else
                {
                    currentIndex++;
                    wantedObject[currentIndex].AddComponent<Outline>();
                    time = DateTime.Now;
                }
            }
        }
    }


}
