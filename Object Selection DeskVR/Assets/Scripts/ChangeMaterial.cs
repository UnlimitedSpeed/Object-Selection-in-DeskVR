using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material defaultMat;

    public void ChangeColor(GameObject gameObject, int outlineNumber)
    {
        Renderer ren = gameObject.GetComponent<Renderer>();

        if (ren != null)
        {
            switch (outlineNumber)
            {
                case 0:
                    ren.material.color = defaultMat.color;
                    break;
                case 1:
                    ren.material.color = new Color(0.4f, 0.4f, 0.0f);
                    break;
                case 2:
                    ren.material.color = new Color(1f, 1f, 0.6f);
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
