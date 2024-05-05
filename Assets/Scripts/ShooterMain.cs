using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterMain : MonoBehaviour, IPlaceable
{

    [SerializeField] GameObject dart;
    public float shootSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootTime(shootSpeed));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Action()
    {
        Instantiate(dart, this.transform.position, Quaternion.identity);
    }

    private IEnumerator ShootTime(float shootTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(shootTime);
            Action();
        }
    }
}
