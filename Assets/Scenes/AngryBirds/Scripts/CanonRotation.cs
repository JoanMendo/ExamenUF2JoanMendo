using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonRotation : MonoBehaviour
{
    public float _maxRotation;
    public float _minRotation;
    public Quaternion initialRotation;
    private float offset = -51.6f;
    public GameObject ShootPoint;
    public GameObject Bullet;
    public float ProjectileForce= 0;
    public float MaxSpeed;
    public float MinSpeed;
    public GameObject PotencyBar;
    private float initialScaleX;

    private void Awake()
    {
        initialScaleX = PotencyBar.transform.localScale.x;
        initialRotation = transform.rotation;
    }
    void Update()
    {
        //PISTA: mireu TOTES les variables i feu-les servir

        var mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        var dir = (mousePos - transform.position).normalized;
        var angle = (Mathf.Atan2(dir.y, dir.x) * 180f / Mathf.PI - 45);
        angle = Mathf.Clamp(angle,  _minRotation, _maxRotation);
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (Input.GetMouseButton(0))
        {
            ProjectileForce += 1f;
            Debug.Log(ProjectileForce);
            
        }
        if(Input.GetMouseButtonUp(0))
        {
            var projectile = Instantiate(Bullet, transform.position, Quaternion.identity);
            ProjectileForce = Mathf.Clamp(ProjectileForce, MinSpeed, MaxSpeed);
            projectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(dir.x, dir.y) * ProjectileForce);
            ProjectileForce = 0f; //reset despr�s del tret
        }
        CalculateBarScale();

    }
    public void CalculateBarScale()
    {
        PotencyBar.transform.localScale = new Vector3(Mathf.Lerp(0, initialScaleX, ProjectileForce / MaxSpeed),
            PotencyBar.transform.localScale.y,
            PotencyBar.transform.localScale.z);
    }
}
