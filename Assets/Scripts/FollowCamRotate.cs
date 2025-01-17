using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamRotate : MonoBehaviour
{
    [Header("Spine Settings")]
    public Transform spine;
    public Vector3 spineOffset;

    [Header("Camera & Character Syncing")]
    public float lookDistance = 5;
    public float lookSpeed = 5;

    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = transform.GetChild(2).GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void RotateCharacterSpine(Ray ray)
    {
        RotateToCamView();
        spine.LookAt(ray.GetPoint(50));
        spine.Rotate(spineOffset);
    }
    void RotateToCamView()
    {
        Vector3 camCenterPos = cam.transform.position;

        Vector3 lookPoint = camCenterPos + (cam.transform.forward * lookDistance);
        Vector3 direction = lookPoint - transform.position;

        Quaternion lookRotation = Quaternion.LookRotation(-direction);
        lookRotation.x = 0;
        lookRotation.z = 0;

        Quaternion finalRotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed);
        transform.rotation = finalRotation;
    }
}
