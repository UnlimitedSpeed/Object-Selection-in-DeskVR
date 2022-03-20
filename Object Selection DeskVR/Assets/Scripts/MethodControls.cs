using System.Collections.Generic;
using UnityEngine;

public class MethodControls : MonoBehaviour
{
    
    public bool isFadeOutActive = false;
    [SerializeField]
    MonoBehaviour[] methods;

    int activeMethod = 0;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            isFadeOutActive = !isFadeOutActive;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetObjects();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            methods[activeMethod].enabled = false;
            methods[0].enabled = true;
            activeMethod = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            methods[activeMethod].enabled = false;
            methods[1].enabled = true;
            activeMethod = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            methods[activeMethod].enabled = false;
            methods[2].enabled = true;
            activeMethod = 0;
        }
        /*
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            methods[activeMethod].enabled = false;
            methods[0].enabled = true;
            activeMethod = 0;
        }*/
    }

    void ResetObjects()
    {
        Debug.Log("Reset");
        GameObject mockup = GameObject.Find("mockup");

        Renderer[] childrenRenderer = mockup.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in childrenRenderer)
        {
            r.material.color = Color.white;
        }
        Outline[] childrenOutlines = mockup.GetComponentsInChildren<Outline>();
        foreach (Outline o in childrenOutlines)
        {
            Debug.Log(o.transform.gameObject.name);
            Destroy(o);
        }
    }

    public void FadeOut(List<string> names)
    {
        GameObject mockup = GameObject.Find("mockup");
        Renderer[] mockupChildren = mockup.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in mockupChildren)
        {
            r.material.color = Color.gray;
        }

        for (int i = 0; i < names.Count; i++)
        {
            GameObject selectedObj = GameObject.Find(names[i]);
            if (selectedObj.GetComponent<Renderer>() != null)
            {
                Renderer r = selectedObj.GetComponent<Renderer>();
                r.material.color = Color.white;
            }
            else
            {
                Renderer[] selectedObjChildren = selectedObj.GetComponentsInChildren<Renderer>();
                foreach (Renderer rc in selectedObjChildren)
                {
                    rc.material.color = Color.white;
                }
            }
        }
    }


}
