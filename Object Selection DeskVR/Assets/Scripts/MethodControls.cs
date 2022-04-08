using System.Collections.Generic;
using UnityEngine;

public class MethodControls : MonoBehaviour
{
    public bool isFadeOutActive = false;
    public AddMaterial AddMaterial;
    
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
    }

    void ResetObjects()
    {
        Debug.Log("Reset");
        GameObject mockup = GameObject.Find("mockup");

        Renderer[] childrenRenderer = mockup.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in childrenRenderer)
        {
            r.material.color = Color.white;
            AddMaterial.AddMat(r.gameObject, 0);
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
