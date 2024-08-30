using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    public int routine;
    public float chronometer;
    public Animator animation;
    public Quaternion angle;
    public float grade;

    public GameObject target;

    public bool attack;
    void Start()
    {
        animation = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    public void Behaviour()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 5)
        {
            animation.SetBool("Run", false);
            chronometer += 1 * Time.deltaTime;
            if (chronometer >= 4)
            {
                routine = Random.Range(0, 2);
                chronometer = 0;
            }
            switch (routine)
            {
                case 0:
                    animation.SetBool("Walk", false);
                    break;
                case 1:
                    grade = Random.Range(0, 360);
                    angle = Quaternion.Euler(0, grade, 0);
                    routine++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    animation.SetBool("Walk", true);
                    break;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 1 && !attack)
            {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                animation.SetBool("Walk", false);

                animation.SetBool("Run", true);
                transform.Translate(Vector3.forward * 4 * Time.deltaTime);

                animation.SetBool("Attack", false);
            }
            else
            {
                animation.SetBool("Walk", false);
                animation.SetBool("Run", false);

                animation.SetBool("Attack", true);
                attack = true;
            }
        }
    }

    public void finalAnimation()
    {
        animation.SetBool("Attack", false);
        attack = false;
    }
    void Update()
    {
        Behaviour();
    }
}
