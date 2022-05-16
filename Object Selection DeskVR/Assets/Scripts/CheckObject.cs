using System.Collections.Generic;
using UnityEngine;

public class CheckObject : MonoBehaviour
{
    ChangeMaterial ChangeMaterial;
    
    List<string> namesOfObj = new List<string>();
    
    private void Awake()
    {
        ChangeMaterial = GameObject.Find("Manager").GetComponent<ChangeMaterial>();
    }
    
    bool CheckSelectable(GameObject currentObject, bool isEnter)
    {
        if (currentObject.tag == "Selectable")
        {
            if (isEnter && !namesOfObj.Contains(currentObject.name))
            {
                namesOfObj.Add(currentObject.name);
                
                ChangeMaterial.ChangeColor(currentObject, 1);
            }
            else if (!isEnter && namesOfObj.Contains(currentObject.name))
            {
                namesOfObj.Remove(currentObject.name);
                
                ChangeMaterial.ChangeColor(currentObject, 0);
            }
            return true;
        }
        else
        {
            GameObject parent = currentObject.transform.parent.gameObject;

            if (parent.tag != "Root")
                return CheckSelectable(parent, isEnter);
            else
                return false;
        }
    }

    void CheckGroup(GameObject currentObject, bool isEnter)
    {
        if (currentObject.tag == "Group")
        {
            if (isEnter && !namesOfObj.Contains(currentObject.name))
            {
                namesOfObj.Add(currentObject.name);
            }
            else if (!isEnter && namesOfObj.Contains(currentObject.name))
            {
                namesOfObj.Remove(currentObject.name);
            }
        }

        GameObject parent = currentObject.transform.parent.gameObject;
        if (parent.tag != "Root")
        {
            CheckGroup(parent, isEnter);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(CheckSelectable(other.gameObject, true))
            CheckGroup(other.gameObject, true);
    }

    void OnTriggerExit(Collider other)
    {
        if (CheckSelectable(other.gameObject, false))
            CheckGroup(other.gameObject, false);
    }
    
    public List<string> getNamesOfObj()
    {
        return namesOfObj;
    }

}