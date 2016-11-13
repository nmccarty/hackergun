using UnityEngine;
using System.Collections;

public class GravityToggle : MonoBehaviour {

    public GameObject contained;

	// Use this for initialization
	void Start () {
        contained = null;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody && other.tag.Contains("Gun")) {
            other.attachedRigidbody.useGravity = false;
            other.attachedRigidbody.drag = 200;
            other.attachedRigidbody.angularDrag = 200;
            contained = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody && other.tag.Contains("Gun")) {
            other.attachedRigidbody.useGravity = true;
            other.attachedRigidbody.drag = 0;
            other.attachedRigidbody.angularDrag = 0.05F;
            contained = null;
        }

    }

    public void increasePower()
    {
        if (contained != null)
        {
            LaserShooter laser = contained.GetComponent<LaserShooter>();
            ProjectileShooter project = contained.GetComponent<ProjectileShooter>();
            if (laser != null && laser.enabled)
            {
                laser.laserStrength += 10;
                Debug.Log("Increased Laser.");
            } else if(project != null && laser.enabled)
            {
                project.projectileSpeed += 10;
                Debug.Log("Increased bullet.");
            }
        } else
        {
            Debug.Log("No Gun.");
        }

    }

    public void decreasePower()
    {
        if (contained != null)
        {
            LaserShooter laser = contained.GetComponent<LaserShooter>();
            ProjectileShooter project = contained.GetComponent<ProjectileShooter>();
            if (laser != null && laser.enabled)
            {
                laser.laserStrength -= 10;
                Debug.Log("Decreased Laser.");
            }
            else if (project != null && laser.enabled)
            {
                project.projectileSpeed -= 10;
                Debug.Log("Decreased bullet.");
            }
        }
        else
        {
            Debug.Log("No Gun.");
        }

    }

    public void mkLaser()
    {
        LaserShooter laser = contained.GetComponent<LaserShooter>();
        ProjectileShooter project = contained.GetComponent<ProjectileShooter>();
        if (laser != null && !laser.enabled)
        {
            laser.enabled = true;
        }
        if (project != null && laser.enabled)
        {
            project.enabled = false;
        }
    }

    public void mkProjectile()
    {
        LaserShooter laser = contained.GetComponent<LaserShooter>();
        ProjectileShooter project = contained.GetComponent<ProjectileShooter>();
        if (laser != null && laser.enabled)
        {
            laser.enabled = false;
        }
        if (project != null && !laser.enabled)
        {
            project.enabled = true;
        }
    }
}
