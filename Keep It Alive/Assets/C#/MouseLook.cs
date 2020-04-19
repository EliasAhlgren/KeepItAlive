using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    public GameObject sparkles;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    

    void Start()
    {
        sparkles.SetActive(false);
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;

        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5f);
            if (hit.collider != null && hit.collider.gameObject.tag == "Robot")
            {
                sparkles.SetActive(true);
                sparkles.transform.position = hit.point;

                Debug.DrawLine(Camera.main.transform.position, hit.point);
                Debug.Log("lol " + hit.collider.gameObject);

                hit.collider.gameObject.GetComponent<HitPointScript>().health++;
            }
            else
            {
                sparkles.SetActive(false);
            }
        }

    }
}
