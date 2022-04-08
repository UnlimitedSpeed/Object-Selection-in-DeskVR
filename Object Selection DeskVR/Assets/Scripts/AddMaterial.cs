
using UnityEngine;

public class AddMaterial : MonoBehaviour
{
    public Material[] OutlineMaterials;

    Material[] materials;
    
    public void AddMat(GameObject gameObject, int outlineNumber)
    {
        materials = new Material[2];

        Renderer ren = gameObject.GetComponent<Renderer>();

        if (ren != null)
        {
            materials[0] = ren.material;

            switch (outlineNumber)
            {
                case 1: //White Outline
                    materials[1] = OutlineMaterials[0];
                    ren.materials = materials;

                    break;
                case 2: //Red outline

                    materials[1] = OutlineMaterials[1];
                    ren.materials = materials;

                    break;
                default: //No outline
                    materials = new Material[1];
                    materials[0] = ren.material;
                    ren.materials = materials;

                    break;
            }
        }
        else
        {
            Transform[] children = gameObject.GetComponentsInChildren<Transform>();
            for(int i = 1; i < children.Length; i++)
            {
                AddMat(children[i].gameObject, outlineNumber);
            }
        }
        
    }

    
}
