using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GunController))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 5;

    public GameObject bullet;
    public GameObject Gun;
    public float Bulletspeed = 40;

    public AudioClip ShootSound;
    private AudioSource audio;

    Camera viewCamera;
    PlayerController controller;
    GunController gunController;
    // Use this for initialization
    public void Start()
    {
        viewCamera = Camera.main;
        audio = GetComponent<AudioSource>();
        controller = GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        //Movement Input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);

        //Look input
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            // Debug.DrawLine(ray.origin, point, Color.red);
            controller.LookAt(point);
        }

        if (Input.GetMouseButtonDown(0))
        {
            audio.clip = ShootSound;
            audio.Play();

           // audio.PlayOneShot(ShootSound);
            Rigidbody intantiatiateShoot = Instantiate(bullet,
                    new Vector3(Gun.transform.position.x, Gun.transform.position.y, Gun.transform.position.z + 0.1f),
                    transform.rotation)
                .GetComponent<Rigidbody>();

            intantiatiateShoot.velocity = transform.TransformDirection(new Vector3(0, 0, Bulletspeed));
        }
        
    }
}
