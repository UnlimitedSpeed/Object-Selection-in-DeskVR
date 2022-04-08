using System.Collections.Generic;
using UnityEngine;

public class CheckObject : MonoBehaviour
{
    AddMaterial AddMaterial;
    
    List<string> namesOfObj = new List<string>();


    private void Awake()
    {
        AddMaterial = GameObject.Find("AddMaterial").GetComponent<AddMaterial>();
    }


    bool CheckSelectable(GameObject currentObject, bool isEnter)
    {
        if (currentObject.tag == "Selectable")
        {
            Debug.Log(currentObject.name);
            if (isEnter && !namesOfObj.Contains(currentObject.name))
            {
                namesOfObj.Add(currentObject.name);
                AddMaterial.AddMat(currentObject, 1);
            }
            else if (!isEnter && namesOfObj.Contains(currentObject.name))
            {
                namesOfObj.Remove(currentObject.name);
                AddMaterial.AddMat(currentObject, 0);
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (string name in namesOfObj)
                Debug.Log(name);
        }
    }

    public List<string> getNamesOfObj()
    {
        return namesOfObj;
    }

}