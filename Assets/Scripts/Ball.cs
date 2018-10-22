using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
    {


    public TextMesh potential_energy;
    public TextMesh kinetic_energy;



    private Rigidbody rb;
    public static float mass = 1;


    public float velocity;
    public static float height =1;

    private float KE;
    private float PE;
    public static float gravitinal_force = 9.8f;


    float time = 5.00f;
    bool flag = false;
    float value = 0.005f;
    float YValue;
    Vector3 previous;

    float ballheightupto;

    void Awake()
    {

        YValue = 0;

        rb = GetComponent<Rigidbody>();
        mass = rb.mass;
        //Debug.Log("---Mass is ---:" + mass);

        //kinetic_energy.text = "Kinetic Energy =";
        //potential_energy.text = "Potential Energy = ";

        ballheightupto = this.transform.localPosition.y;

    }


    void FixedUpdate()
        {
            if (time >= 0)
            {
                time -= Time.deltaTime;
                return;
            }
            else
            {

                if (flag == false)
                {
                    YValue = this.transform.localPosition.y - value;
                    this.transform.localPosition = new Vector3(0.14f, YValue, 0);


                }
                else if (flag == true)
                {
                    YValue = this.transform.localPosition.y + value;
                    this.transform.localPosition = new Vector3(0.14f, YValue, 0);

                    if (this.transform.localPosition.y >= ballheightupto)
                    {
                        flag = false;
                    }
                }
            }


            velocity = ((transform.position - previous).magnitude) / Time.deltaTime;
            previous = transform.position;


            if (this.transform.localPosition.y <= 0.065)
            {
               // Debug.Log("OHHHH");
                height = 0;
            }
            else
            {
               // Debug.Log("height:" + height);
                height = this.transform.localPosition.y;
            }

            





            KE = (0.5f) * (mass) * (velocity);
            PE = mass * (gravitinal_force) * height;

           // Debug.Log("---PE---:" + PE);



            //kinetic_energy.text = "Kinetic Energy = " + KE.ToString("F2");
            //potential_energy.text = "Potential Energy = " + PE.ToString("F2");
        }
        void OnCollisionEnter(Collision collision)
        {
           // Debug.Log("---Collision---:" + height);
            flag = true;
        }


    
}