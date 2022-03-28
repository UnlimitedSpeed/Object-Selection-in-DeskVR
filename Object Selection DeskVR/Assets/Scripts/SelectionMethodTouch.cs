using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectionMethodTouch : MonoBehaviour
{
    public float touchSensitivity = 50f;

    [SerializeField]
    GameObject cylinder;

    MethodControls mc;
    bool isSelection = true;

    GameObject cylinderClone;
    GameObject cylinderParent;
    float xRotation = 0f;
    float yRotation = 0f;
    List<string> names;
    List<float> distanceList = new List<float>();
    Dictionary<float, GameObject> distanceDictionary = new Dictionary<float, GameObject>();

    GameObject finalSelectedObject;
    int index = 0;


    void Start()
    {
        mc = transform.GetComponent<MethodControls>();
    }

    void Update()
    {
        if (isSelection)
            Selection();
        else
            Refinement();
    }

    void Selection()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            //The process begins when the user touches the touch pad
            if (touch.phase == TouchPhase.Began)
            {
                cylinderParent = new GameObject("cylinderParent");
                cylinderParent.transform.rotation = transform.rotation;
                cylinderParent.transform.localPosition = new Vector3(
                                        transform.position.x + transform.forward.x / 2,
                                        transform.position.y + transform.forward.y / 2 - 0.5f,
                                        transform.position.z + transform.forward.z / 2);

                cylinderClone = Instantiate(cylinder, transform.position, Quaternion.Euler(45f, 45f, 45f));
                cylinderClone.transform.SetParent(cylinderParent.transform);
                cylinderClone.transform.localPosition = new Vector3(0f, 0f, 25f);
                cylinderClone.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);

                xRotation = cylinderParent.transform.eulerAngles.x;
                yRotation = cylinderParent.transform.eulerAngles.y;
            }

            //The user can move ray by moving their finger across the touch pad
            if (touch.phase == TouchPhase.Moved)
            {                
                yRotation += touch.deltaPosition.x * touchSensitivity * Time.deltaTime;
                xRotation -= touch.deltaPosition.y * touchSensitivity * Time.deltaTime;

                cylinderParent.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
                
            }

            //Selection process ends when user lets go of the touch pad
            if (touch.phase == TouchPhase.Ended)
            {
                CheckObject co = cylinderClone.GetComponent<CheckObject>();
                names = co.getNamesOfObj();
                Destroy(cylinderParent);
                
                foreach (string s in names)
                {
                    GameObject go = GameObject.Find(s);
                    float d = Vector3.Distance(transform.position, go.transform.position);
                    distanceDictionary.Add(d, go);
                }
                
                distanceList = distanceDictionary.Keys.ToList();
                distanceList.Sort();

                if (mc.isFadeOutActive)
                {
                    mc.FadeOut(names);
                }

                //if no objects were selected end the process
                if (names.Count == 0)
                {
                    Debug.Log("NO OBJECT SELECTED");
                    distanceList.Clear();
                    distanceDictionary.Clear();
                }
                else
                {
                    //If only one object was selected then there is no need for the refinement step
                    if (names.Count == 1)
                    {
                        finalSelectedObject = distanceDictionary[distanceList[0]];
                        finalSelectedObject.GetComponent<Outline>().OutlineColor = Color.red;
                        Debug.Log("SELECTED OBJECT = " + finalSelectedObject.name);
                        distanceList.Clear();
                        distanceDictionary.Clear();
                    }
                    else
                    {
                        distanceDictionary[distanceList[0]].GetComponent<Outline>().OutlineColor = Color.red;

                        isSelection = false;
                    }
                }
            }
        }
        
    }

    void Refinement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                int newIndex = index;
                if (touch.deltaPosition.y > 0)
                {
                    newIndex++;
                }
                else if(touch.deltaPosition.y < 0)
                {
                    newIndex--;
                }
                
                if (newIndex < 0)
                    newIndex = names.Count - 1;
                if (newIndex >= names.Count)
                    newIndex = 0;

                distanceDictionary[distanceList[index]].GetComponent<Outline>().OutlineColor = Color.white;
                distanceDictionary[distanceList[newIndex]].GetComponent<Outline>().OutlineColor = Color.red;
               
                index = newIndex;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                finalSelectedObject = distanceDictionary[distanceList[index]];
                foreach (string s in names)
                {
                    if (s != finalSelectedObject.name)
                        Destroy(GameObject.Find(s).GetComponent<Outline>());
                }

                Debug.Log("SELECTED OBJECT = " + finalSelectedObject.name);
                index = 0;
                isSelection = true;
                distanceList.Clear();
                distanceDictionary.Clear();
            }
        }
    }
}
