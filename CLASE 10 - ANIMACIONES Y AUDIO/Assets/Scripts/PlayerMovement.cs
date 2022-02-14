using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 2f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject shootPoint;
    [SerializeField] float cooldown = 2f;
    [SerializeField] private bool canShoot = true;
    [SerializeField] private float timePass = 0;

    [SerializeField] private float speedJump = 1f;
    private bool canJump;

    private GameObject parentBullets;
    float cameraAxisX = 0f;

    void Start()
    {
        parentBullets = GameObject.Find("DinamycBullets");
    }
    void Update()
    {
        MovePlayer();
        RotatePlaye();
        ShootPlayer();
        JumpPlayer();

    }

    private void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            transform.Translate(Vector3.up * speedJump);
        }
    }

    public void SetJumpStatus(bool status){
        canJump = status;
    }

    private void ShootPlayer()
    {
        if (Input.GetKeyDown(KeyCode.E) && canShoot)
        {
            GameObject newBullet = Instantiate(bulletPrefab, shootPoint.transform.position, transform.rotation);// PROYECTILES
            newBullet.transform.parent = parentBullets.transform;
            canShoot = false;
        }

        if (!canShoot)
        {
            timePass += Time.deltaTime;
        } 

        if (timePass > cooldown)
        {
            timePass = 0;
            canShoot = true;
        }
    }

    private void MovePlayer()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MovePlayer(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            MovePlayer(Vector3.back);
        }
    }

    private void MovePlayer(Vector3 directionEnemy)
    {
        transform.Translate(speed * Time.deltaTime * directionEnemy);
    }

    private void RotatePlaye()
    {
        //1 UN VALOR PARA ROTAR EN Y
        cameraAxisX += Input.GetAxis("Horizontal");
        //2 UN ANGULO A CALCULAR EN FUNCION DEL VALOR DEL PRIMER PASO
        Quaternion angulo = Quaternion.Euler(0f, cameraAxisX * 0.5f, 0f);
        //3 ROTAR
        transform.localRotation = angulo;
    }
}
