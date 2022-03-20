using System.Collections.Generic;
using UnityEngine;

public class CheckObject : MonoBehaviour
{
    private List<string> namesOfObj = new List<string>();

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        GameObject parent = go.transform.parent.gameObject;

        if (go.tag == "Selectable")
        {
            if(go.GetComponent<Outline>() == null)
                go.AddComponent<Outline>();

            namesOfObj.Add(go.name);
        }
        else if(parent.tag == "Selectable")
        {
            if (parent.GetComponent<Outline>() == null)
                parent.AddComponent<Outline>();

            if(!namesOfObj.Contains(parent.name))
                namesOfObj.Add(parent.name);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject go = other.gameObject;
        GameObject parent = go.transform.parent.gameObject;

        if (go.tag == "Selectable")
        {
            if (go.GetComponent<Outline>() != null)
                Destroy(go.GetComponent<Outline>());

            namesOfObj.Remove(go.name);
        }
        else if(parent.tag == "Selectable")
        {
            if (parent.GetComponent<Outline>() != null)
                Destroy(parent.GetComponent<Outline>());

            if (namesOfObj.Contains(parent.name))
                namesOfObj.Remove(parent.name);
        }
    }

    public List<string> getNamesOfObj()
    {
        return namesOfObj;
    }

}
