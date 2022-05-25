using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RayCursor : MonoBehaviour
{
    public GameObject Ray;
    public float sphereVelocity = 20f;
    public ChangeMaterial ChangeMaterial;
    public MethodControls mc;

    float sphereInput;
    bool hasStarted = false;

    InputMaster InputMaster;
    GameObject Clone;
    GameObject Sphere;

    GameObject currentObject;
    GameObject finalSelectedObject;


    //Highlight
    public bool isHighlight;

    //Timed Trial
    public TimeTrial TimeTrial;

    void Awake()
    {
        InputMaster = new InputMaster();

        InputMaster.RayCursor.CastRay.started += ctx => CastRay();
        InputMaster.RayCursor.CastRay.canceled += ctx => DeleteRay();

        InputMaster.RayCursor.MoveSphere.performed += ctx => MoveSphere(ctx.ReadValue<Vector2>());

        InputMaster.RayCursor.Confirm.performed += ctx => Comfirm();

        //InputMaster.RayCursor.ABC.started += _ => ABC();

    }

    void ABC()
    {
        print("ABC");
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
    }

    void Comfirm()
    {
        if (hasStarted)
        {
            Renderer r = currentObject.GetComponent<Renderer>();

            if (r.material.color == new Color(1f, 1f, 0.6f))
                finalSelectedObject = currentObject;
            else
                finalSelectedObject = null;

            if (finalSelectedObject != null)
            {
                Debug.Log("SELECTED OBJECT = " + finalSelectedObject.name);
                TimeTrial.StopCounting(finalSelectedObject.name);
            }
            else
            {
                Debug.Log("NO OBJECT SELECTED");
                TimeTrial.StopCounting(null);
            }
        }
    }

    void Update()
    {
        GameObject l = GameObject.Find("Line");
        if(l != null)
        {
            Destroy(l);
        }

        if (Sphere != null)
        {
            if (Sphere.transform.localPosition.z < 50 && sphereInput > 0 || Sphere.transform.localPosition.z > 0 && sphereInput < 50)
                Sphere.transform.localPosition += new Vector3(0, 0, sphereVelocity * sphereInput * Time.deltaTime);

        }

        if (hasStarted)
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Selectable");

            float min = Mathf.Infinity;

            foreach (GameObject obj in gameObjects)
            {
                float distance = Vector3.Distance(obj.transform.position, Sphere.transform.position);
                if (distance < min)
                {
                    min = distance;
                    currentObject = obj;
                }
            }

            foreach (GameObject obj in gameObjects)
            {
                if (obj.name == currentObject.name)
                {
                    ChangeMaterial.ChangeColor(obj, 2);
                }
                else
                {
                    ChangeMaterial.ChangeColor(obj, 0);
                }
            }

            if (isHighlight)
            {
                RenderLine();
            }
        }
    }

    void RenderLine()
    {
        LineRenderer lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;

        //For drawing line in the world space, provide the x,y,z values
        lineRenderer.SetPosition(0, Sphere.transform.position); //x,y and z position of the starting point of the line
        lineRenderer.SetPosition(1, currentObject.transform.position); //x,y and z position of the end point of the line
    }

    void OnEnable()
    {
        InputMaster.RayCursor.Enable();
    }

    void OnDisable()
    {
        InputMaster.RayCursor.Disable();
    }
}