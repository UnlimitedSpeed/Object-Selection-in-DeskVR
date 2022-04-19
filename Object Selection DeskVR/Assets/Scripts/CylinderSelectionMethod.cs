using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CylinderSelectionMethod : MonoBehaviour
{
    public float mouseSensitivity = 50f;
    public ChangeMaterial ChangeMaterial;

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


    //Timed Trial
    public TimeTrial TimeTrial;

    
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
        //The process begins when the user presses the Left Mouse Button
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            TimeTrial.StartCounting();

            Vector3 pos = new Vector3(
                                    transform.position.x + transform.forward.x / 2,
                                    transform.position.y + transform.forward.y / 2 - 0.5f,
                                    transform.position.z + transform.forward.z / 2);
            
            cylinderClone = Instantiate(cylinder, pos, transform.rotation);
            
            xRotation = cylinderClone.transform.eulerAngles.x;
            yRotation = cylinderClone.transform.eulerAngles.y;
        }

        //The user can move ray while holding the button down
        if (Input.GetKey(KeyCode.Mouse0))
        {
            yRotation += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            xRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            cylinderClone.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        }

        //Selection process ends when user lets go of the button
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            CheckObject co = cylinderClone.GetComponentInChildren<CheckObject>();
            names = co.getNamesOfObj();
            Destroy(cylinderClone);

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
                Debug.Log("NO OBJECT SELECTED");
                distanceList.Clear();
                distanceDictionary.Clear();
                TimeTrial.StopCounting(null);
            }
            else
            {
                if (mc.isFadeOutActive)
                {
                    mc.FadeOut(names);
                }

                if (names.Count == 1)
                {
                    finalSelectedObject = distanceDictionary[distanceList[0]];

                    ChangeMaterial.ChangeColor(finalSelectedObject, 2);

                    Debug.Log("SELECTED OBJECT = " + finalSelectedObject.name);
                    distanceList.Clear();
                    distanceDictionary.Clear();
                    TimeTrial.StopCounting(finalSelectedObject.name);
                }
                else
                {
                    ChangeMaterial.ChangeColor(distanceDictionary[distanceList[0]], 2);

                    isSelection = false;
                }
            }
        }
    }

    void Refinement()
    {
        float scroll = Input.mouseScrollDelta.y;

        if (scroll != 0)
        {
            int newIndex = index + (int)scroll;
            if (newIndex < 0)
                newIndex = names.Count - 1;
            if (newIndex >= names.Count)
                newIndex = 0;
            
            ChangeMaterial.ChangeColor(distanceDictionary[distanceList[index]], 1);


            ChangeMaterial.ChangeColor(distanceDictionary[distanceList[newIndex]], 2);

            index = newIndex;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            finalSelectedObject = distanceDictionary[distanceList[index]];
            foreach (string s in names)
            {
                if (s != finalSelectedObject.name)
                    ChangeMaterial.ChangeColor(GameObject.Find(s), 0);
            }

            Debug.Log("SELECTED OBJECT = " + finalSelectedObject.name);
            index = 0;
            isSelection = true;
            distanceList.Clear();
            distanceDictionary.Clear();

            TimeTrial.StopCounting(finalSelectedObject.name);
        }
    }
}
