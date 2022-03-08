using System.Collections.Generic;
using UnityEngine;

public class CheckObject : MonoBehaviour
{
    int numberOfObj = 0;

    private List<string> namesOfObj = new List<string>();

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Outline>().enabled = true;
        numberOfObj++;
        namesOfObj.Add(other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Outline>().enabled = false;
        numberOfObj--;
        namesOfObj.Remove(other.gameObject.name);
    }

    public int getNumberOfObj()
    {
        return numberOfObj;
    }

    public List<string> getNamesOfObj()
    {
        return namesOfObj;
    }

}
