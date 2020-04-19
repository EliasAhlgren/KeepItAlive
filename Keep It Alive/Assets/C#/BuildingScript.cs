using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    bool canMove = false;

    IEnumerator Collapse()
    {
        canMove = true;
        yield return new WaitForSeconds(1.4f); 
        GameObject.Destroy(gameObject);
    }

    private void Update()
    {
        if (canMove)
        {
          transform.Translate(Vector3.down * 100 * Time.deltaTime, Space.World);
        }
      

    }

}
