using System.Collections.Generic;
using UnityEngine;

public class CheckObject : MonoBehaviour
{
    List<string> namesOfObj = new List<string>();

    void CheckSelectable(GameObject currentObject, bool isEnter)
    {
        if(currentObject.tag == "Selectable")
        {
            if (isEnter && !namesOfObj.Contains(currentObject.name))
            {
                namesOfObj.Add(currentObject.name);
                //add outline
            }
            else if (!isEnter && namesOfObj.Contains(currentObject.name))
            {
                namesOfObj.Remove(currentObject.name);
                //remove outline
            }
        }
        else
        {
            GameObject parent = currentObject.transform.parent.gameObject;

            if (parent.tag != "Root")
                CheckSelectable(parent, isEnter);
            else
                return;
        }
    }

    void CheckGroup(GameObject currentObject, bool isEnter)
    {
        if(currentObject.tag == "Group")
        {
            if (isEnter && !namesOfObj.Contains(currentObject.name))
            {
                namesOfObj.Add(currentObject.name);
                //add outline
            }
            else if (!isEnter && namesOfObj.Contains(currentObject.name))
            {
                namesOfObj.Remove(currentObject.name);
                //remove outline
            }
        }

        GameObject parent = currentObject.transform.parent.gameObject;
        if(parent.tag != "Root")
        {
            CheckGroup(parent, isEnter);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        CheckSelectable(other.gameObject, true);

        CheckGroup(other.gameObject, true);
    }

    void OnTriggerExit(Collider other)
    {
        CheckSelectable(other.gameObject, false);

        CheckGroup(other.gameObject, false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
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
