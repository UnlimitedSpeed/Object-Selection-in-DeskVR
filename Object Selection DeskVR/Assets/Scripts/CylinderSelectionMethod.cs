using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CylinderSelectionMethod : MonoBehaviour
{
    public float mouseSensitivity = 50f;

    [SerializeField]
    GameObject cylinder;

    bool isSelection = true;

    GameObject cylinderClone;
    GameObject cylinderParent;
    float xRotation = 0f;
    float yRotation = 0f;
    MethodControls mc;
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
        //The process begins when the user presses the Left Mouse Button
        if (Input.GetKeyDown(KeyCode.Mouse0))
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

        //The user can move ray while holding the button down
        if (Input.GetKey(KeyCode.Mouse0))
        {
            yRotation += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            xRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            cylinderParent.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        }

        //Selection process ends when user lets go of the button
        if (Input.GetKeyUp(KeyCode.Mouse0))
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

            if (names.Count == 0)
            {
                Debug.Log("NO OBJECT SELECTED");
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

    void Refinement()
    {
        float scroll = Input.mouseScrollDelta.y;

        if (scroll != 0)
        {
            int newIndex = (index + (int)scroll) % names.Count;
            if (newIndex < 0)
                newIndex = names.Count - 1;
            if (newIndex >= names.Count)
                newIndex = 0;

            distanceDictionary[distanceList[index]].GetComponent<Outline>().OutlineColor = Color.white;
            distanceDictionary[distanceList[newIndex]].GetComponent<Outline>().OutlineColor = Color.red;

            index = newIndex;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
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
