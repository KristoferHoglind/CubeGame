using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Covfefe : MonoBehaviour
{
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();

        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", new Color(62f/255f, 10f/255f, 10f/255f, 0.75f));

        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", new Color(1f, 1f, 1f, 0.8f));
    }
}
