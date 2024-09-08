using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    [SerializeField]private Transform grabPoint;

    [SerializeField]private Transform rayPoint;

    [SerializeField]private float rayDistance;

    private GameObject grabbedObject;
    private int layerindex;

    private void Start()
    {
        layerindex=LayerMask.NameToLayer("Objects");
    }

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right * transform.localScale.x, 1f);
        if(hitInfo.collider!=null &&hitInfo.collider.tag=="Box")
        {
            if(Input.GetKeyDown(KeyCode.V) && grabbedObject==null)
            {
                grabbedObject=hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic=true;
                grabbedObject.transform.position=grabPoint.position;
                grabbedObject.transform.SetParent(transform);
            }
            else if(Input.GetKeyDown(KeyCode.V))
            {
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic=false;
                grabbedObject.transform.SetParent(null);
                grabbedObject=null;
            }
        }

        Debug.DrawRay(rayPoint.position,transform.right *rayDistance);
    }
}
