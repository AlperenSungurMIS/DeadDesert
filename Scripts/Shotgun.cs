using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public Transform spawmPoint;
    public float distance = 15f;

    public GameObject muzzle;
    public GameObject impact;

    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }
    private void Shoot()
    {
        RaycastHit hit;
        RaycastHit hit_1;
        RaycastHit hit_2;
        RaycastHit hit_3;

        GameObject muzzleInstance = Instantiate(muzzle, spawmPoint.position, spawmPoint.localRotation);
        muzzleInstance.transform.parent = spawmPoint;

        if(Physics.Raycast(cam.transform.position,cam.transform.forward,out hit,distance))
        {
            Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
        }
        if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(-.2f,0f,0f), out hit_1, distance))
        {
            Instantiate(impact, hit.point, Quaternion.LookRotation(hit_1.normal));
        }
        if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(0f, .1f, 0f), out hit_2, distance))
        {
            Instantiate(impact, hit.point, Quaternion.LookRotation(hit_2.normal));
        }
        if (Physics.Raycast(cam.transform.position, cam.transform.forward + new Vector3(0f, -.1f, 0f), out hit_3, distance))
        {
            Instantiate(impact, hit.point, Quaternion.LookRotation(hit_3.normal));
        }
    }
}
