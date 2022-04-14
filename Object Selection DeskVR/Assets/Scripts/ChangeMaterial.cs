
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public void ChangeColor(GameObject gameObject, int outlineNumber)
    {
        Renderer ren = gameObject.GetComponent<Renderer>();

        if (ren != null)
        {
            switch (outlineNumber)
            {
                case 1: //Green
                    ren.material.color = Color.green;

                    break;
                case 2: //Red
                    ren.material.color = Color.red;

                    break;
                default: //White
                    ren.material.color = Color.white;

                    break;
            }
        }
        else
        {
            Transform[] children = gameObject.GetComponentsInChildren<Transform>();
            for(int i = 1; i < children.Length; i++)
            {
                ChangeColor(children[i].gameObject, outlineNumber);
            }
        }
        
    }

    
}
