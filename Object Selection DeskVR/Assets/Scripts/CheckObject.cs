using System.Collections.Generic;
using UnityEngine;

public class CheckObject : MonoBehaviour
{
    int numberOfObj = 0;

    private List<string> namesOfObj = new List<string>();

    private void OnTriggerEnter(Collider other)
    {
        //other.gameObject.GetComponent<Outline>().enabled = true;
        GameObject go = other.gameObject;
        go.AddComponent<Outline>();
        numberOfObj++;
        namesOfObj.Add(go.name);
    }

    private void OnTriggerExit(Collider other)
    {
        //other.gameObject.GetComponent<Outline>().enabled = false;
        GameObject go = other.gameObject;
        Destroy(go.GetComponent<Outline>());
        numberOfObj--;
        namesOfObj.Remove(go.name);
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
