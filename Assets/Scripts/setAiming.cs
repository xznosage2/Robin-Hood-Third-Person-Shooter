using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class setAiming : MonoBehaviour
{
    public KeyCode aim;
    public KeyCode fire;

    [Header("Aiming Settings")]
    RaycastHit hit;
    public LayerMask aimLayers;
    Ray ray;

    bool isAiming;
    bool canShoot;

    bool hitDetected;

    public Bow bowScript;
    public FollowCamRotate rotate;

    Animator animator;

    private Camera cam;

	private PlayerInput _input;

	// Start is called before the first frame update
	void Start()
    {
        animator = GetComponent<Animator>();
        cam = transform.parent.GetChild(2).GetComponent<Camera>();

		_input = transform.parent.GetComponent<PlayerInput>();

        _input.actions["Aim"].started += setBowAimingTrue;
        _input.actions["Aim"].canceled += setBowAimingFalse;

        _input.actions["Shoot"].started += setShootTrue;
        _input.actions["Shoot"].canceled += setShootFalse;
	}

    // Update is called once per frame
    void Update()
    {
        // input
        //bool isAiming = Input.GetKey(aim);
        //bool isAiming = false;
        if (bowScript.bowSettings.arrowCount < 1)
            isAiming = false;

        if (isAiming)
        {
            animator.SetBool("isAiming", true);
            Aim();

            RotateCharacterSpine();

            bowScript.EquipBow();
            if (bowScript.bowSettings.arrowCount > 0)
            {
                //animator.SetBool("pullString", Input.GetKey(fire));
                //if (Input.GetKey(fire))
                //    bowScript.PullString();
				animator.SetBool("pullString", canShoot);
				if (canShoot)
					bowScript.PullString();
			}

            //if (Input.GetKeyUp(fire))
            if (canShoot)
            {
                bowScript.ReleaseString();
                animator.SetTrigger("fire");
                if (hitDetected)
                {
                    bowScript.Fire(hit.point);
                }
                else
                {
                    bowScript.Fire(ray.GetPoint(300f));
                }
                canShoot = false;
            }
        }
        else
        {
            animator.SetBool("isAiming", false);
            bowScript.UnEquipBow();
            bowScript.RemoveCrosshair();
            bowScript.DisableArrow();
            bowScript.ReleaseString();
        }
    }

    private void setBowAimingTrue(InputAction.CallbackContext context)
    {
        isAiming = true;
    }
    private void setBowAimingFalse(InputAction.CallbackContext context)
    {
        isAiming = false;
    }

    private void setShootTrue(InputAction.CallbackContext context)
    {
        canShoot = true;
    }

    private void setShootFalse(InputAction.CallbackContext context)
    {
        canShoot = false;
    }
    
    void Aim()
    {
        Vector3 camPosition = cam.transform.position;
        Vector3 dir = cam.transform.forward;

        ray = new Ray(camPosition, dir);
        if (Physics.Raycast(ray, out hit, 500f, aimLayers))
        {
            hitDetected = true;
            Debug.DrawLine(ray.origin, hit.point, Color.green);
            bowScript.ShowCrosshair(hit.point);
        }
        else
        {
            hitDetected = false;
            bowScript.RemoveCrosshair();
        }
    }
    void RotateCharacterSpine()
    {
        rotate.RotateCharacterSpine(ray);
    }
}
