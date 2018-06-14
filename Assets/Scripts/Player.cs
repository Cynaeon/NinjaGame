using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    public float strength = 1;
    public float dexterity = 1;
    public float defence = 1;

    public float dexGrowth = 3;

    public float baseAttackSpeed = 9;
    public float baseMovementSpeed;

    public float dash_speed;
    public float dash_duration;
    public float dash_cooldown;

    public ParticleSystem p_levelUp;

    private float attackSpeed;

    private float c_dashTime;
    private float c_attackTime;
    private Vector3 movement;
    private bool strikeAgain;

    private Camera playerCamera;
    private CharacterController characterController;
    private Collider dashCollider;
    private ParticleSystem ps_trail;
    private Animator anim;

    private enum State
    {
        Standing,
        Attacking,
        Dashing
    }

    private State state;

    void Start () {
        ps_trail = transform.Find("DashTrail").GetComponent<ParticleSystem>();
        dashCollider = transform.Find("DashCollider").GetComponent<Collider>();
        playerCamera = FindObjectOfType<Camera>();
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
	}
	
	void Update () {
        UpdateStats();
        switch (state)
        {
            case State.Standing:
                movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                movement *= movementSpeed;
                anim.SetFloat("Speed", movement.magnitude);
                if (movement.magnitude > 0)
                    transform.rotation = Quaternion.LookRotation(movement);
                movement.y -= gravity;

                if (Input.GetButtonDown("Fire1"))
                {
                    state = State.Attacking;
                    anim.SetTrigger("Attack");
                    GetComponentInChildren<Sword>().Swing(attackSpeed);
                    break;
                }
                else if (Input.GetButtonDown("Fire2"))
                {
                    state = State.Dashing;
                    break;
                }

                characterController.Move(movement * Time.deltaTime);
                break;

            case State.Attacking:
                if (Input.GetButtonDown("Fire1"))
                    strikeAgain = true;
                if (!GetComponentInChildren<Sword>().striking)
                {
                    if (strikeAgain)
                    {
                        GetComponentInChildren<Sword>().Swing(attackSpeed);
                        strikeAgain = false;
                    }
                    else
                    {
                        state = State.Standing;
                    }
                }
                break;

            case State.Dashing:
                anim.SetBool("Dash", true);
                dashCollider.enabled = true;
                ps_trail.Emit(10);
                c_dashTime += Time.deltaTime;
                characterController.Move(transform.forward * dash_speed * Time.deltaTime);
                if (c_dashTime >= dash_duration)
                {
                    c_dashTime = 0;
                    dashCollider.enabled = false;
                    anim.SetBool("Dash", false);
                    state = State.Standing;
                }
                break;
        }

        float cameraZoom = Input.GetAxis("RightVertical");
        playerCamera.Zoom(cameraZoom);
    }

    public void UpdateStats()
    {
        dexterity = 1 + (dexGrowth * (ExpSystem.level - 1));
        movementSpeed = baseMovementSpeed + dexterity / 2;
        attackSpeed = baseAttackSpeed + dexterity;
    }

    public void LevelUp()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Instantiate(p_levelUp, pos, Quaternion.identity, transform);
    }

    public void FootDown()
    {
        transform.Find("FootSteps").GetComponent<ParticleSystem>().Emit(1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {

        }
    }
}
