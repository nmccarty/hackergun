using UnityEngine;
using System.Collections;
using VRTK;

public class LaserShooter : VRTK_InteractableObject
{

    public int laserStrength;
    public int pulseDuration;

    LineRenderer line;
    bool laser;
    int count;

    // Use this for initialization
    override protected void Start()
    {
        base.Start();
        laser = false;
        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = false;
        count = 0;
    }

    public override void StartUsing(GameObject currentUsingObject)
    {
        base.StartUsing(currentUsingObject);
        laser = true;
        count = 0;
    }
    public override void StopUsing(GameObject previousUsingObject)
    {
        base.StopUsing(previousUsingObject);
        laser = false;
        line.enabled = false;
    }

    protected override void Update()
    {
        base.Update();
        if (laser && count<pulseDuration)
        {
            count++;
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            line.SetPosition(0, ray.origin);
            line.enabled = true;

            if (Physics.Raycast(ray, out hit, 100))
            {
                line.SetPosition(1, hit.point);
                if (hit.rigidbody)
                {
                    hit.rigidbody.AddForceAtPosition(transform.forward * laserStrength, hit.point);
                }
            }
            else
                line.SetPosition(1, ray.GetPoint(100));
        } else
        {
            line.enabled = false;
            laser = false;
        }

    }



}
