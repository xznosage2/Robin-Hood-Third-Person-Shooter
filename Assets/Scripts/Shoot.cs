using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera cam;
    public GameObject arrowPrefab;
    public Transform arrowSpawn;
    public float shootForce = 20f;
    public int playerIndex;


    public void Start()
    {
        playerIndex = GetComponent<charaterManager>().GetPlayerIndex();
    }

    // Update is called once per frame
    void Update()
    {
        // input
        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = Instantiate(arrowPrefab, arrowSpawn.position, Quaternion.identity);
            go.AddComponent<Arrow>();
            go.GetComponent<Arrow>().setplayerIndex(playerIndex);
            
            Rigidbody rb = go.GetComponent<Rigidbody>();
            rb.velocity = cam.transform.forward * shootForce;
            
        }
    }
}
