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
    List<GameObject> intersectedObjects = new List<GameObject>();
    float yRotation = 0f;

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


    bool CheckSelectable(GameObject currentObject)
    {
        if (currentObject != null)
        {
            if (currentObject.tag == "Selectable")
            {
                intersectedObjects.Add(currentObject);
                return true;
            }
            else
            {
                GameObject parent = currentObject.transform.parent.gameObject;
                if (parent.tag != "Root")
                    return CheckSelectable(parent);
                else
                    return false;
            }

        }
        else
            return false;
    }

    void CheckGroup(GameObject gameObject)
    {
        if (gameObject.tag == "Group")
        {
            if (intersectedObjects.Contains(gameObject))
                intersectedObjects.Remove(gameObject);

            intersectedObjects.Add(gameObject);
        }

        GameObject parent = gameObject.transform.parent.gameObject;

        if (parent.tag != "Root")
            CheckGroup(parent);
    }

    void ReleaseTouch()
    {
        if (isSelection)
        {
            mc.ResetObjects();
            RaycastHit[] hits;
            Ray ray = new Ray(cylinderClone.transform.position, cylinderClone.transform.forward);
            hits = Physics.RaycastAll(ray);

            foreach (RaycastHit hit in hits)
            {
                GameObject go = hit.transform.gameObject;

                CheckSelectable(go);
                CheckGroup(go);
            }
            

            if (intersectedObjects.Count == 0)
            {
                Destroy(cylinderClone);
                TimeTrial.StopCounting(null);
                Debug.Log("NO OBJECT SELECTED");
                intersectedObjects.Clear();
            }
            else
            {

                if (intersectedObjects.Count == 1)
                {
                    Destroy(cylinderClone);

                    finalSelectedObject = intersectedObjects[0];

                    TimeTrial.StopCounting(finalSelectedObject.name);

                    ChangeMaterial.ChangeColor(finalSelectedObject, 2);

                    Debug.Log("SELECTED OBJECT = " + finalSelectedObject.name);
                    intersectedObjects.Clear();
                }
                else
                {

                    for (int i = 1; i < intersectedObjects.Count; i++)
                    {
                        GameObject o = intersectedObjects[i];

                        ChangeMaterial.ChangeColor(o, 1, true);    
                    }

                    ChangeMaterial.ChangeColor(intersectedObjects[0], 2);

                    isSelection = false;
                }
            }
        }
        else
        {
            Destroy(cylinderClone);
            finalSelectedObject = intersectedObjects[index];
            foreach (GameObject g in intersectedObjects)
            {
                ChangeMaterial.ChangeColor(g, 0);
            }
            ChangeMaterial.ChangeColor(finalSelectedObject, 2);
            TimeTrial.StopCounting(finalSelectedObject.name);

            Debug.Log("SELECTED OBJECT = " + finalSelectedObject.name);
            index = 0;
            intersectedObjects.Clear();
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
                newIndex = intersectedObjects.Count - 1;
            if (newIndex >= intersectedObjects.Count)
                newIndex = 0;

            ChangeMaterial.ChangeColor(intersectedObjects[index], 1, true);

            ChangeMaterial.ChangeColor(intersectedObjects[newIndex], 2);
            


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
