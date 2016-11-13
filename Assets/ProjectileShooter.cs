using UnityEngine;
using System.Collections;
using VRTK;

public class ProjectileShooter : VRTK_InteractableObject
{

    public int projectileSpeed;
    public Rigidbody bullet;
    

    // Use this for initialization
    override protected void Start()
    {
        base.Start();
    }

    public override void StartUsing(GameObject currentUsingObject)
    {
        base.StartUsing(currentUsingObject);
        Rigidbody instantiatedProjectile = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
        instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, projectileSpeed));
    }
    public override void StopUsing(GameObject previousUsingObject)
    {
        base.StopUsing(previousUsingObject);
    }

    protected override void Update()
    {
        base.Update();
    }

}
