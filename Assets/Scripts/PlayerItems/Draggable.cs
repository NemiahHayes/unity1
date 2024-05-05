using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    [SerializeField] GameObject placedItem;
    public float dropDistance;

    //Private Variables
    bool active;
    bool placed;
    GameObject master;
    SpriteRenderer spriteRenderer;

    //Grid Management
    GameObject[] grids;

    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master");
        grids = master.GetComponent<GridManager>().GetGrids();
        spriteRenderer = GetComponent<SpriteRenderer>();

        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (active)
        {
            this.transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
            PlayerInput();
        }

    }

    private void PlayerInput()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Left Click");
            active = false;

            GameObject nearestObject = FindNearestObject();
            if (nearestObject != null && Vector2.Distance(this.transform.position, nearestObject.transform.position) < dropDistance)
            {
                Instantiate(placedItem, nearestObject.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    private GameObject FindNearestObject()
    {
        GameObject nearestObject = null;
        float nearestDistance = dropDistance + 1;

        if (grids != null)
        {
                for (int i = 0; i < grids.Length; i++)
                {
                    float distance = Vector2.Distance(this.transform.position, grids[i].transform.position);

                    if (distance < nearestDistance)
                    {
                        nearestDistance = distance;
                        nearestObject = grids[i];
                    }
                }
        }

        Debug.Log("Nearest Distance: " + nearestDistance + "Nearest Object" + nearestObject);
        return nearestObject;
    }

}
