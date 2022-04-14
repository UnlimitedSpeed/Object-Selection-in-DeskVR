using System.Collections.Generic;
using UnityEngine;

public class MethodControls : MonoBehaviour
{
    public bool isFadeOutActive = false;
    public ChangeMaterial ChangeMaterial;
    
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
        GameObject root = GameObject.FindGameObjectWithTag("Root");

        Renderer[] childrenRenderer = root.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in childrenRenderer)
        {
            r.material.color = Color.white;
            ChangeMaterial.ChangeColor(r.gameObject, 0);
        }
    }

    public void FadeOut(List<string> names)
    {
        GameObject root = GameObject.FindGameObjectWithTag("Root");
        Renderer[] mockupChildren = root.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in mockupChildren)
        {
            r.material.color = Color.gray;
        }

        for (int i = 0; i < names.Count; i++)
        {
            GameObject selectedObj = GameObject.Find(names[i]);
            ChangeMaterial.ChangeColor(selectedObj, 0);
        }
    }


}
