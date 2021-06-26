using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private float sensitivity = 150f;

    private Transform player;

    private float yRotation = 0;

    void Start()
    {
        player = transform.parent;
        Cursor.visible = false;
    }

    void Update()
    {
        if (DialogManager.main.IsDialogOpen) return;
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivity;

        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(yRotation, 0, 0);
        player.Rotate(Vector3.up * mouseX);
    }

    private void FixedUpdate()
    {

        // Bit shift the index of the layer (6) to get a bit mask
        int layerMask = 1 << 6;

        // This would cast rays only against colliders in layer 6.
        // But instead we want to collide against everything except layer 6. The ~ operator does this, it inverts a bitmask.
        // layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            GameObject hitTarget = hit.collider.gameObject;

            if (hitTarget != null && hitTarget.tag == "Object")
            {
                //Debug.Log("Did Hit");
                InteractiveObject obj = hitTarget.GetComponent<InteractiveObject>();
                if (obj != null)
                {
                    obj.Hilight();
                }
            }
        }
    }
}
