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
    double time = 0;
    double finalTime = 0;
    int currentIndex = 0;

    int numberOfAttempts = 0;
    int totalAttempts = 0;

    void Start()
    {
        filename = Application.dataPath + "/Results/" + participant + ".csv";
        TextWriter tw = new StreamWriter(filename, false);
        tw.WriteLine("Name, finalTime, numberOfAttempts");
        tw.Close();
        currentIndex = 0;
        wantedObject[currentIndex].AddComponent<Outline>();
    }


    void Update()
    {
        if (isCounting)
        {
            time += Time.deltaTime;
            finalTime += Time.deltaTime;
        }
    }

    void WriteToCSV(int index, double time, int attempts)
    {
        TextWriter tw = new StreamWriter(filename, true);
        tw.WriteLine( index + ", " + time + ", " + attempts);
        tw.Close();
    }

    public void StartCounting()
    {
        if (!isCounting)
        {
            isCounting = true;
            time = 0;
            numberOfAttempts = 0;
            finalTime = 0;
            totalAttempts = 0;
            currentIndex = 0;
        }
    }

    public void StopCounting(string name)
    {
        numberOfAttempts++;
        totalAttempts++;

        if (name == wantedObject[currentIndex].name)
        {
            Destroy(wantedObject[currentIndex].GetComponent<Outline>());
            double t = Math.Round(time, 2);
            int tempNumb = currentIndex + 1;
            WriteToCSV(tempNumb, t, numberOfAttempts);
            time = 0;
            numberOfAttempts = 0;
            
            if(currentIndex == wantedObject.Length - 1)
            {
                isCounting = false;
                Debug.Log("Final time: " + Math.Round(finalTime, 2) + "; Attempts: " + totalAttempts);
            }
            else
            {                
                currentIndex++;
                wantedObject[currentIndex].AddComponent<Outline>();
            }
        }
    }


}
