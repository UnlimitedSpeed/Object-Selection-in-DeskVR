using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DepthRay : MonoBehaviour
{
    public GameObject Ray;
    public float sphereVelocity = 20f;
    public ChangeMaterial ChangeMaterial;
    public MethodControls mc;

    public bool isRightHand;

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

        if (isRightHand)
        {
            InputMaster.DepthRayRight.CastRay.started += ctx => CastRay();
            InputMaster.DepthRayRight.CastRay.canceled += ctx => DeleteRay();

            InputMaster.DepthRayRight.MoveSphere.performed += ctx => MoveSphere(ctx.ReadValue<Vector2>());

            InputMaster.DepthRayRight.Confirm.performed += ctx => Comfirm();
        }
        else
        {
            InputMaster.DepthRayLeft.CastRay.started += ctx => CastRay();
            InputMaster.DepthRayLeft.CastRay.canceled += ctx => DeleteRay();

            InputMaster.DepthRayLeft.MoveSphere.performed += ctx => MoveSphere(ctx.ReadValue<Vector2>());

            InputMaster.DepthRayLeft.Confirm.performed += ctx => Comfirm();
        }
        
        
    }

    void CastRay()
    {
        mc.ResetObjects();
        TimeTrial.StartCounting();
        hasStarted = true;
        Clone = Instantiate(Ray, transform);
        Sphere = GameObject.Find(transform.gameObject.name + "/" + Clone.name + "/Sphere");
    }

    void DeleteRay()
    {
        hasStarted = false;
        Destroy(Clone);
    }

    void MoveSphere(Vector2 vec)
    {
        sphereInput = (float)Math.Round(vec.y, 2);
        if (sphereInput >= -0.01f && sphereInput <= 0.01f)
            sphereInput = 0f;
    }

    void Comfirm()
    {
        if (hasStarted)
        {
            Renderer r = currentObject.GetComponent<Renderer>();

            string n = r.material.name.Split(' ')[0];

            if (n == "TopCandidateMaterial")
                finalSelectedObject = currentObject;
            else
                finalSelectedObject = null;

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
                
                TimeTrial.StopCounting(finalSelectedObject.name);
            }
            else
            {
                TimeTrial.StopCounting(null);
            }
        }
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
        if (isRightHand)
            InputMaster.DepthRayRight.Enable();
        else
            InputMaster.DepthRayLeft.Enable();
    }

    void OnDisable()
    {
        if (isRightHand)
            InputMaster.DepthRayRight.Disable();
        else
            InputMaster.DepthRayLeft.Disable();
    }
}
