// GunController.cs
using System.Collections.Generic;
using UnityEngine;

public class TargetShooting : MonoBehaviour
{
    public Transform bulletRaycastOrigin;
    public float fireRate = 0.5f; // Adjust the fire rate as desired
    private float nextFireTime = 0f;

    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private List<GameObject> inactiveTargets = new List<GameObject>();
    [SerializeField] private uint amountOfActiveTargets;
    [SerializeField] private Material activeMat;
    [SerializeField] private Material inactiveMat;
    private List<GameObject> activeTargets = new List<GameObject>();

    public bool disableAutoSearch = false;

    private void Start()
    {
        Debug.Log(transform.childCount);
        
        if (!disableAutoSearch)
        {
            foreach (Transform t in transform)
            {
                Debug.Log(t.gameObject.name);

                if (t.GetComponent<Collider>() != null)
                {
                    inactiveTargets.Add(t.gameObject);
                    t.GetComponent<MeshRenderer>().material = inactiveMat;
                }
            }
        }

        else
        {
            foreach (GameObject target in inactiveTargets)
            {
                target.GetComponent<MeshRenderer>().material = inactiveMat;
            }
        }

        RollRandomTarget();
    }

    void Update()
    {
        if (activeTargets.Count < amountOfActiveTargets)
        {
            RollRandomTarget();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(bulletRaycastOrigin.position, bulletRaycastOrigin.forward, out RaycastHit hitData, Mathf.Infinity, targetLayer)) //Hitreg shot
            {
                Debug.Log("Raycast success!");

                Debug.DrawRay(bulletRaycastOrigin.position, bulletRaycastOrigin.forward * 100, Color.green, 0.5f);
                CheckHitTarget(hitData);
            }

            else
            {
                Debug.DrawRay(bulletRaycastOrigin.position, bulletRaycastOrigin.forward * 100, Color.red, 0.5f);
            }
        }
    }
    
    private void RollRandomTarget()
    {
        int randomIndex = Random.Range(0, inactiveTargets.Count);
        GameObject newTarget = inactiveTargets[randomIndex];

        activeTargets.Add(newTarget);
        inactiveTargets.Remove(newTarget);

        newTarget.GetComponent<MeshRenderer>().material = activeMat;
    }

    private void CheckHitTarget(RaycastHit hitData)
    {
        GameObject targetToRemove = null;
        
        foreach (GameObject target in activeTargets)
        {
            if (hitData.collider.gameObject.GetInstanceID() == target.GetInstanceID())
            {
                RollRandomTarget();
                inactiveTargets.Add(target);
                activeTargets.Remove(targetToRemove);

                target.GetComponent<MeshRenderer>().material = inactiveMat;
                return;
            }
        }
    }
}