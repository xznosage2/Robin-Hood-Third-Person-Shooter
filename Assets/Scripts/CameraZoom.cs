using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{
    CinemachineFreeLook vcam;
    public KeyCode aim;
    public float originalFieldofView = 70;
    public float zoomFieldofView = 20;
    public float zoomSpeed = 5;
    public Transform LookAtZoom;
    public Transform LookAt;

    public PlayerMovement move;
    public PlayerInput _input;
    private bool isAiming = false;

	private void Awake()
	{
		_input = transform.parent.GetComponent<PlayerInput>();

        _input.actions["Aim"].performed += setAimingTrue;
        _input.actions["Aim"].canceled += setAimingFalse;
	}

	// Start is called before the first frame update
	void Start()
    {
        vcam = GetComponent<CinemachineFreeLook>();
        vcam.m_CommonLens = true;
        vcam.m_Lens.FieldOfView = 20;
    }

    // Update is called once per frame
    void Update()
    {
        // input
        //if (Input.GetKey(aim))
        if (isAiming)
        {
            vcam.LookAt = LookAtZoom;
            ZoomCameraIn();
            move.rotateToCam();
        }
        else
        {
            vcam.LookAt = LookAt;
            ZoomCameraOut();
        }
    }

    private void setAimingTrue(InputAction.CallbackContext context)
    {
        isAiming = true;
    }

    private void setAimingFalse(InputAction.CallbackContext context)
    {
        isAiming = false;
    }

    void ZoomCameraIn()
    {
        vcam.m_Lens.FieldOfView = Mathf.Lerp(vcam.m_Lens.FieldOfView, zoomFieldofView, zoomSpeed * Time.deltaTime);
    }
    void ZoomCameraOut()
    {
        vcam.m_Lens.FieldOfView = Mathf.Lerp(vcam.m_Lens.FieldOfView, originalFieldofView, zoomSpeed * Time.deltaTime);
    }
}
