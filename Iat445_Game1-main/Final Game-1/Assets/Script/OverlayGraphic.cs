using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayGraphic : MonoBehaviour
{
    [SerializeField] private Transform targetGraphic;
    [SerializeField] private Transform linkedHandPosition;
    [SerializeField] private LayerMask layersToHit;

    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(linkedHandPosition.position, linkedHandPosition.forward, out hit, 10f, layersToHit))
        {
            targetGraphic.position = hit.point + hit.normal * 0.001f;

            targetGraphic.rotation = Quaternion.LookRotation(hit.normal);

            if (!targetGraphic.gameObject.activeInHierarchy)
            {
                targetGraphic.gameObject.SetActive(true);
            }
        }
        else
        {
            if (targetGraphic.gameObject.activeInHierarchy)
            {
                targetGraphic.gameObject.SetActive(false);
            }

        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
