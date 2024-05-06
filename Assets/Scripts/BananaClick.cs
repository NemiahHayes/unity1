using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaClick : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseOver()
    {
        Debug.Log($"{Input.mousePosition}");
        Destroy(this.gameObject);
    }
}
