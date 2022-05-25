using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectionMethodTouch : MonoBehaviour
{
    public float touchSensitivity = 50f;
    public ChangeMaterial ChangeMaterial;
    public MethodControls mc;

    [SerializeField]
    GameObject cylinder;
    
    bool isSelection = true;

    GameObject cylinderClone;

    float xRotation = 0f;
    float yRotation = 0f;
    List<string> names;
    List<float> distanceList = new List<float>();
    Dictionary<float, GameObject> distanceDictionary = new Dictionary<float, GameObject>();

    GameObject finalSelectedObject;
    int index = 0;

    float accumulator;

    //Timed Trial
    public TimeTrial TimeTrial;

    InputMaster InputMaster;

    void Awake()
    {
        isSelection = true;

        InputMaster = new InputMaster();

        InputMaster.TouchPad.Touch.started += _ => StartTouch();
        InputMaster.TouchPad.Touch.canceled += _ => ReleaseTouch();
        InputMaster.TouchPad.MoveTouch.performed += ctx => MoveTouch(ctx.ReadValue<Vector2>());

    }

    void StartTouch()
    {
        if (isSelection)
        {
            mc.ResetObjects();
            TimeTrial.StartCounting();

            Vector3 pos = new Vector3(
                                transform.position.x + transform.forward.x / 2,
                                transform.position.y + transform.forward.y / 2 - 0.5f,
                                transform.position.z + transform.forward.z / 2);

            cylinderClone = Instantiate(cylinder, pos, transform.rotation);

            xRotation = cylinderClone.transform.eulerAngles.x;
            yRotation = cylinderClone.transform.eulerAngles.y;
        }
        else
        {
            accumulator = 0;
        }
    }

    void ReleaseTouch()
    {
        if(isSelection)
        {
            CheckObject co = cylinderClone.GetComponentInChildren<CheckObject>();
            names = co.getNamesOfObj();

            foreach (string s in names)
            {
                GameObject go = GameObject.Find(s);
                float d = Vector3.Distance(transform.position, go.transform.position);
                distanceDictionary.Add(d, go);
            }

            distanceList = distanceDictionary.Keys.ToList();
            distanceList.Sort();

            if (names.Count == 0)
            {
                Destroy(cylinderClone);
                TimeTrial.StopCounting(null);
                //Debug.Log("NO OBJECT SELECTED");
                distanceList.Clear();
                distanceDictionary.Clear();
            }
            else
            {
                if (mc.isFadeOutActive)
                {
                    mc.FadeOut(names);
                }

                if (names.Count == 1)
                {
                    Destroy(cylinderClone);

                    finalSelectedObject = distanceDictionary[distanceList[0]];

                    TimeTrial.StopCounting(finalSelectedObject.name);

                    ChangeMaterial.ChangeColor(finalSelectedObject, 2);

                    //Debug.Log("SELECTED OBJECT = " + finalSelectedObject.name);
                    distanceList.Clear();
                    distanceDictionary.Clear();
                }
                else
                {
                    //Debug.Log(distanceDictionary[distanceList[0]]);
                    ChangeMaterial.ChangeColor(distanceDictionary[distanceList[0]], 2);

                    for (int i = 1; i < distanceList.Count; i++)
                    {
                        GameObject o = distanceDictionary[distanceList[i]];
                        
                        ChangeMaterial.ChangeColor(o, 1);
                        Color c = o.GetComponent<Renderer>().material.color;
                        c.a = 0.5f;
                        o.GetComponent<Renderer>().material.color = c;
                        
                    }

                    isSelection = false;
                }
            }
        }
        else
        {
            Destroy(cylinderClone);
            finalSelectedObject = distanceDictionary[distanceList[index]];
            foreach (string s in names)
            {
                if (s != finalSelectedObject.name)
                    ChangeMaterial.ChangeColor(GameObject.Find(s), 0);
            }
            TimeTrial.StopCounting(finalSelectedObject.name);

            //Debug.Log("SELECTED OBJECT = " + finalSelectedObject.name);
            index = 0;
            distanceList.Clear();
            distanceDictionary.Clear();
            isSelection = true;
        }
    }
    
    void MoveTouch(Vector2 touch)
    {
        if (isSelection)
        {
            float v = touch.magnitude / Time.deltaTime / 1000.0f;

            yRotation += touch.x * touchSensitivity * Time.deltaTime * v;
            xRotation -= touch.y * touchSensitivity * Time.deltaTime * v;

            cylinderClone.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        }
        else
        {
            accumulator += touch.y;

            int newIndex = index;
            if (accumulator > 100)
            {
                newIndex++;
                accumulator = 0;
            }
            else if (accumulator < -100)
            {
                newIndex--;
                accumulator = 0;
            }

            if (newIndex < 0)
                newIndex = names.Count - 1;
            if (newIndex >= names.Count)
                newIndex = 0;

            ChangeMaterial.ChangeColor(distanceDictionary[distanceList[index]], 1);

            ChangeMaterial.ChangeColor(distanceDictionary[distanceList[newIndex]], 2);
            
            for(int i = 0; i < distanceList.Count; i++)
            {
                GameObject o = distanceDictionary[distanceList[i]];
                
                if (i != newIndex)
                {
                    ChangeMaterial.ChangeColor(o, 1);
                    Color c = o.GetComponent<Renderer>().material.color;
                    c.a = 0.5f;
                    o.GetComponent<Renderer>().material.color = c;
                }
                else
                {
                    ChangeMaterial.ChangeColor(o, 2);
                    Color c = o.GetComponent<Renderer>().material.color;
                    c.a = 1.0f;
                    o.GetComponent<Renderer>().material.color = c;
                }
            }


            index = newIndex;
        }
    }

  


    void OnEnable()
    {
        InputMaster.TouchPad.Enable();
    }

    void OnDisable()
    {
        InputMaster.TouchPad.Disable();
    }
}
