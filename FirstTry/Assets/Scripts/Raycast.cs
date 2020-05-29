using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    private GameObject raycastedObject;

    [SerializeField] private int rayLength = 10;
    [SerializeField] private LayerMask interact;

    [SerializeField] public GameObject interactionText;

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, interact.value))
        {
            if (hit.collider.CompareTag("Object"))
            {
                raycastedObject = hit.collider.gameObject;

                interactionText.SetActive(true);

                if (Input.GetKeyDown("e"))
                {
                    //Debug.Log(raycastedObject.name);
                    raycastedObject.GetComponent<Terminal>().Talk();
                }
            }
        }
        else
        {
            interactionText.SetActive(false);
        }
    }
}
