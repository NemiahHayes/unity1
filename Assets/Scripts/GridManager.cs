using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    private GameObject[] grids;

    // Start is called before the first frame update
    void Start()
    {
        grids = GameObject.FindGameObjectsWithTag("Grid");
    }

    public GameObject[] GetGrids()
    {
        return grids;
    }
}
