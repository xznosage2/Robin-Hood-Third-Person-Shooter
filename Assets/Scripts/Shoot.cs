using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public Camera cam;
    public GameObject arrowPrefab;
    public Transform arrowSpawn;
    public float shootForce = 20f;
    public int playerIndex;
    int arrowLevel;

    private PlayerInput _input;

    public void Start()
    {
        playerIndex = GetComponent<charaterManager>().GetPlayerIndex();

        _input.actions["Shoot"].started += shootArrow;

        
    }

    // Update is called once per frame
    void Update()
    {
		Debug.Log(transform.parent.name);
		// input
		//if (Input.GetMouseButtonDown(0))
		//{
		//    GameObject go = Instantiate(arrowPrefab, arrowSpawn.position, Quaternion.identity);
		//    go.AddComponent<Arrow>();
		//    go.GetComponent<Arrow>().setPlayerIndex(playerIndex);

		//    Rigidbody rb = go.GetComponent<Rigidbody>();
		//    rb.velocity = cam.transform.forward * shootForce;

		//}
	}

    private void shootArrow(InputAction.CallbackContext context)
    {
		GameObject go = Instantiate(arrowPrefab, arrowSpawn.position, Quaternion.identity);
		go.AddComponent<Damage>();
		
        go.AddComponent<Arrow>();
        go.AddComponent<Arrow>().dmg = 2 * arrowLevel;
		go.GetComponent<Arrow>().setPlayerIndex(playerIndex);

		Rigidbody rb = go.GetComponent<Rigidbody>();
		rb.velocity = cam.transform.forward * shootForce;

	}

    public void UpgradeArrow()
    {
        arrowLevel += 1;
    }
}
