using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceScript : MonoBehaviour
{
    public GameObject[] robot;
    public bool canShoot = true;
    public float shootDelay;
    public GameObject chosenRobot;
    public GameObject muzzleFlash;

    // Start is called before the first frame update
    void Start()
    {
        robot = GameObject.FindGameObjectsWithTag("Robot");
        chosenRobot = robot[Random.Range(0, robot.Length)];
        canShoot = true;
        muzzleFlash.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(chosenRobot.transform);
        RaycastHit raycastHit;
        if (Physics.Raycast(transform.position,transform.forward, out raycastHit, Mathf.Infinity))
        {
            if (raycastHit.collider.gameObject.tag == "Robot" && canShoot)
            {
                StartCoroutine(Shoot());
            }
        }

    }

    IEnumerator Shoot()
    {
       
        canShoot = false;
        chosenRobot.GetComponent<HitPointScript>().health--;
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        muzzleFlash.SetActive(false);
        if (chosenRobot.GetComponent<HitPointScript>().health <= -50)
        {
            chosenRobot = robot[Random.Range(0, robot.Length)];
        }
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }

}
