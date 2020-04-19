using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitPointScript : MonoBehaviour
{
    public float health = 50;
    public GameObject emitters;
    public GameObject slider;
    public GameObject flame;
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        health = 50;
        emitters.SetActive(false);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            emitters.SetActive(true);
        }
        else
        {
            emitters.SetActive(false);

        }

        if (health <= -50)
        {

            flame.SetActive(true);
            transform.root.GetComponent<RobotScript>().hits[index] = true;
        }
        else
        {
            flame.SetActive(false);
        }

       // slider.GetComponent<Slider>().value = health;

    }
}


