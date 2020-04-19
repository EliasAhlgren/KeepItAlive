using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotScript : MonoBehaviour
{

    public bool[] hits;

    public HitPointScript[] hitPointScripts;

    public int fires = 0;

    // Start is called before the first frame update
    void Start()
    {
        hitPointScripts = gameObject.GetComponentsInChildren<HitPointScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        
    

        if (other.gameObject.layer == 8)
        {
            other.gameObject.GetComponent<BuildingScript>().StartCoroutine("Collapse");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 1440f)
        {
            SceneManager.LoadScene(0);
        }

        if (hits[0] == true && hits[1] == true && hits[2] == true && hits[3] == true && hits[4] == true && hits[5] == true)
        {
            SceneManager.LoadScene(0);
        }

    }
}
