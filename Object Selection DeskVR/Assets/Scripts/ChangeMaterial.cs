using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material transparentMaterial;
    public Material topCandidateMaterial;
    public Material candidateMaterial;



    Dictionary<string, Material> colorDictionary = new Dictionary<string, Material>();

    public void ChangeColor(GameObject gameObject, int outlineNumber, bool isTransparent)
    {
        string name = gameObject.name;

        if (gameObject.TryGetComponent(out Renderer ren))
        {

            if (!colorDictionary.ContainsKey(name))
            {
                Material m = ren.material;

                colorDictionary.Add(name, m);
            }

            if (!isTransparent)
            {
                switch (outlineNumber)
                {
                    case 0:
                        Material material;
                        colorDictionary.TryGetValue(name, out material);
                        ren.material = material;
                        break;
                    case 1:
                        ren.material = candidateMaterial;
                        break;
                    case 2:
                        ren.material = topCandidateMaterial;
                        break;
                }
            }
            else
            {
                ren.material = transparentMaterial;
            }
            

            
            
        }
        else
        {
            Transform[] children = gameObject.GetComponentsInChildren<Transform>();
            for (int i = 1; i < children.Length; i++)
            {
                ChangeColor(children[i].gameObject, outlineNumber, isTransparent);
            }
        }
    }

    public void ChangeColor(GameObject gameObject, int outlineNumber)
    {
        ChangeColor(gameObject, outlineNumber, false);
    }
}
