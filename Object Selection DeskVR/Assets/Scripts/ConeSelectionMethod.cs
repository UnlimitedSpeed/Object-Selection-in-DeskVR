using System.Collections.Generic;
using UnityEngine;

public class ConeSelectionMethod : MonoBehaviour
{

    [SerializeField]
    GameObject cone;

    GameObject c;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            c = Instantiate(cone, transform.position, Quaternion.Euler(45,45,45));
            c.name = "SelectionCone";
            c.transform.rotation = transform.rotation;
            c.transform.Rotate(0, 180, 0);
            c.transform.SetParent(transform);
        }
        

        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            CheckObject co = c.GetComponent<CheckObject>();
            int numberOfObj = co.getNumberOfObj();
            List<string> names = co.getNamesOfObj();
            Destroy(c);
            Debug.Log("Selected " + numberOfObj + " objects:");
            for(int i = 0; i < names.Count; i++)
            {
                Debug.Log(names[i]);
            }
        }
    }
}
