using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DepthRay : MonoBehaviour
{
    public GameObject Ray;
    public float sphereVelocity = 20f;
    public ChangeMaterial ChangeMaterial;

    float sphereInput;

    InputMaster InputMaster;
    GameObject Clone;
    GameObject Sphere;

    GameObject currentObject;
    GameObject newObject;
    GameObject finalSelectedObject;

    List<string> names;

    void Awake()
    {
        InputMaster = new InputMaster();

        InputMaster.DepthRay.CastRay.started += ctx => CastRay();
        InputMaster.DepthRay.CastRay.canceled += ctx => DeleteRay();

        InputMaster.DepthRay.MoveSphere.started += ctx => { sphereInput = ctx.ReadValue<float>(); };
        InputMaster.DepthRay.MoveSphere.canceled += ctx => { sphereInput = 0; };
    }

    void CastRay()
    {
        Debug.Log("Start");
        Clone = Instantiate(Ray, transform);
        Sphere = GameObject.Find(Clone.name + "/Sphere");
    }

    void DeleteRay()
    {
        Debug.Log("STOP");
        Destroy(Clone);
        finalSelectedObject = currentObject;

        if (finalSelectedObject != null)
        {
            foreach (string s in names)
            {
                if (s != finalSelectedObject.name)
                    ChangeMaterial.ChangeColor(GameObject.Find(s), 0);
            }


            Debug.Log("SELECTED OBJECT = " + finalSelectedObject.name);
        }
        else
        {
            Debug.Log("NO OBJECT SELECTED");
        }
    }
    
    void Update()
    {
        if (Sphere != null)
        {
            if (Sphere.transform.localPosition.z < 50 && Sphere.transform.localPosition.z > 0)
                Sphere.transform.localPosition += new Vector3(0, 0, sphereVelocity * sphereInput * Time.deltaTime);
        }

        if (Clone != null)
        {
            CheckObject co = Clone.GetComponentInChildren<CheckObject>();
            names = co.getNamesOfObj();

            float min = Mathf.Infinity;

            foreach (string n in names)
            {
                GameObject obj = GameObject.Find(n);
                float distance = Vector3.Distance(obj.transform.position, Sphere.transform.position);
                if (distance < min)
                {
                    min = distance;
                    currentObject = obj;
                }
            }

            foreach (string n in names)
            {
                GameObject obj = GameObject.Find(n);
                if (n == currentObject.name)
                {
                    Debug.Log(n);
                    ChangeMaterial.ChangeColor(obj, 2);
                }
                else
                {
                    ChangeMaterial.ChangeColor(obj, 1);
                }
            }
        }
    }

    void OnEnable()
    {
        InputMaster.DepthRay.Enable();
    }

    void OnDisable()
    {
        InputMaster.DepthRay.Disable();
    }
}
