using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DepthRay : MonoBehaviour
{
    public GameObject Ray;
    public float sphereVelocity = 20f;
    public ChangeMaterial ChangeMaterial;

    float sphereInput;
    bool hasStarted = false;

    InputMaster InputMaster;
    GameObject Clone;
    GameObject Sphere;

    GameObject currentObject;
    GameObject newObject;
    GameObject finalSelectedObject;

    List<string> names;

    //Timed Trial
    public TimeTrial TimeTrial;

    void Awake()
    {
        InputMaster = new InputMaster();
        
        InputMaster.DepthRay.CastRay.started += ctx => CastRay();
        InputMaster.DepthRay.CastRay.canceled += ctx => DeleteRay();

        InputMaster.DepthRay.MoveSphere.started += ctx => MoveSphere(ctx.ReadValue<Vector2>().y);
        InputMaster.DepthRay.MoveSphere.canceled += ctx => MoveSphere(0);
        
    }

    void CastRay()
    {
        TimeTrial.StartCounting();
        hasStarted = true;
        Clone = Instantiate(Ray, transform);
        Sphere = GameObject.Find(transform.gameObject.name + "/" + Clone.name + "/Sphere");
    }

    void DeleteRay()
    {
        hasStarted = false;
        Destroy(Clone);
        finalSelectedObject = currentObject;

        if (finalSelectedObject != null)
        {
            foreach (string s in names)
            {
                if (s != finalSelectedObject.name)
                {
                    GameObject obj = GameObject.Find(s);
                    ChangeMaterial.ChangeColor(obj, 0);
                }
            }

            Debug.Log("SELECTED OBJECT = " + finalSelectedObject.name);
            TimeTrial.StopCounting(finalSelectedObject.name);
        }
        else
        {
            Debug.Log("NO OBJECT SELECTED");
            TimeTrial.StopCounting(null);
        }
    }
    
    void MoveSphere(float y)
    {
        if (y > 0)
            sphereInput = 0.5f;
        else if (y < 0)
            sphereInput = -0.5f;
        else
            sphereInput = 0f;
    }

    void Update()
    {
        if (Sphere != null)
        {
            if (Sphere.transform.localPosition.z < 50 && sphereInput > 0 || Sphere.transform.localPosition.z > 0 && sphereInput < 50)
                Sphere.transform.localPosition += new Vector3(0, 0, sphereVelocity * sphereInput * Time.deltaTime);

        }

        if (hasStarted)
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
