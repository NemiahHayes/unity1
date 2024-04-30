using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public float dropDistance;

    //Private Variables
    bool drag;
    Vector3 offset;
    Vector3 spawn;
    GameObject master;

    //Grid Management
    GameObject[] grids;

    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master");
        grids = master.GetComponent<GridManager>().GetGrids();
        spawn = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (drag)
        {
            this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    private void OnMouseDown()
    {
        offset = this.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        drag = true;
    }

    private void OnMouseUp()
    {
        drag = false;

        GameObject nearestObject = findNearestObject();
        if (nearestObject != null && Vector2.Distance(this.transform.position, nearestObject.transform.position) < dropDistance)
        {
            this.transform.position = nearestObject.transform.position;
        } else
        {
            transform.position = spawn;
        }
        
    }

    private GameObject findNearestObject()
    {
        GameObject nearestObject;
        if (grids != null)
        {
            nearestObject = grids[0];
            float nearestDistance = Vector3.Distance(this.transform.position, grids[0].transform.position);

            if (grids.Length > 0)
            {
                for (int i = 1; i < grids.Length; i++)
                {
                    float distance = Vector3.Distance(this.transform.position, grids[i].transform.position);

                    if (distance < nearestDistance)
                    {
                        nearestObject = grids[i];
                    }
                }
            }

            return nearestObject;
        }

        return null;
    }
}
