using System.Collections.Generic;
using UnityEngine;

public class CylinderSelectionMethod : MonoBehaviour
{
    public float mouseSensitivity = 50f;

    [SerializeField]
    GameObject cylinder;

    int state = 1;
    bool isSelection = true;

    GameObject cylinderClone;
    GameObject cylinderParent;
    float xRotation = 0f;
    float yRotation = 0f;
    MethodControls mc;
    List<string> names;

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
        if (state == 1)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                cylinderClone = Instantiate(cylinder, transform.position, Quaternion.Euler(45f, 45f, 45f));
                cylinderClone.transform.SetParent(transform);

                cylinderClone.transform.localPosition = new Vector3(0f, -0.5f, 25.5f);
                cylinderClone.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
            }
        }


        if (state == 2)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                yRotation += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
                xRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

                cylinderParent.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            state++;

            switch (state)
            {
                case 2:
                    cylinderParent = new GameObject("cylinderParent");
                    cylinderParent.transform.rotation = transform.rotation;
                    cylinderParent.transform.localPosition = new Vector3(
                                            transform.position.x + transform.forward.x,
                                            transform.position.y + transform.forward.y,
                                            transform.position.z + transform.forward.z);

                    cylinderClone.transform.SetParent(cylinderParent.transform);

                    xRotation = cylinderParent.transform.eulerAngles.x;
                    yRotation = cylinderParent.transform.eulerAngles.y;

                    // Only aplicable in Desktop
                    transform.gameObject.GetComponent<RotateCamera>().enabled = false;

                    break;

                case 3:
                    CheckObject co = cylinderClone.GetComponent<CheckObject>();
                    names = co.getNamesOfObj();
                    Destroy(cylinderParent);

                    Debug.Log(names.Count);
                    for (int i = 0; i < names.Count; i++)
                    {
                        Debug.Log(names[i]);
                    }

                    if (mc.isFadeOutActive)
                    {
                        mc.FadeOut(names);
                    }

                    GameObject.Find(names[index]).GetComponent<Outline>().OutlineColor = Color.red;
                    state = 1;
                    isSelection = false;

                    // Only aplicable in Desktop
                    transform.gameObject.GetComponent<RotateCamera>().enabled = true;

                    break;
            }
        }
    }

    void Refinement()
    {
        float scroll = Input.mouseScrollDelta.y;

        if(scroll != 0)
        {
            int newIndex = (index + (int)scroll) % names.Count;
            if (newIndex < 0)
                newIndex *= -1;

            GameObject.Find(names[index]).GetComponent<Outline>().OutlineColor = Color.white;

            GameObject.Find(names[newIndex]).GetComponent<Outline>().OutlineColor = Color.red;

            index = newIndex;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            string selected = names[index];
            Debug.Log("SELECTED OBJECT = " + selected);
            foreach(string s in names)
            {
                if(s != selected)
                    Destroy(GameObject.Find(s).GetComponent<Outline>());
            }
            index = 0;
            isSelection = true;
        }
    }
}
