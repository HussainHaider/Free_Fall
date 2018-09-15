using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour {


    public TextMesh potential_energy;
    public TextMesh kinetic_energy;

    private Rigidbody rb;
    private float mass;
    private float velocity;
    private float height;

    private float KE;
    private float PE;
    private float PE_max;
    private float PE_min;
    private float PE_avg;
    private float gravitinal_force;

    public GameObject[] PE_Cubes;
    public GameObject[] KE_Cubes;

    float time = 5.00f;
    bool flag = false;
    float value = 0.005f;
    float YValue;
    Vector3 previous;
    int count1 = 5;
    int count2 = 0;
    float[] arr;

    void Start () {

        YValue = 0;
        arr = new float[6];

        rb = GetComponent<Rigidbody>();
        mass = rb.mass;

        kinetic_energy.text = "Kinetic Energy =";
        potential_energy.text = "Potential Energy = ";
        gravitinal_force = 9.8f;
        for (int i = 0; i < PE_Cubes.Length; i++)
        {
            PE_Cubes[i].GetComponent<Renderer>().material.color = Color.green;
        }
        for (int i = 0; i < KE_Cubes.Length; i++)
        {
            KE_Cubes[i].GetComponent<Renderer>().material.color = Color.white;
        }

        PE_max = this.transform.localPosition.y;
        
        float pvalue = PE_max / 6;

        for (int i = 0; i < 6; i++)
        {
            arr[i] = (i + 1) * pvalue;
            //Debug.Log("arr: "+"i= " + arr[i]);
        }



        PE_avg = (PE_max + PE_min) / 2;
    }

    int determineCount(float YValue)
    {
        int count = 0;
        for (int i = 0; i < 6; i++)
        {
            if (YValue >= arr[i])
            {
                count = i;
            }
        }
        return count;
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
                //Debug.Log("x = " + this.transform.localPosition.x + " y = " + this.transform.localPosition.y + " z = " + this.transform.localPosition.z);
                YValue = this.transform.localPosition.y - value;
                this.transform.localPosition = new Vector3(0, YValue, 0);
                count1 = determineCount(YValue);


                for (int i = KE_Cubes.Length - 1; i > count1; i--)
                {
                    KE_Cubes[i].GetComponent<Renderer>().material.color = Color.green;
                }
                for (int i = 0; i < (PE_Cubes.Length - count1) - 1; i++)
                {
                    PE_Cubes[i].GetComponent<Renderer>().material.color = Color.white;
                }
            }
            if (flag == true)
            {
                // Debug.Log("x = " + this.transform.localPosition.x + " y = " + this.transform.localPosition.y + " z = " + this.transform.localPosition.z);
                YValue = this.transform.localPosition.y + value;
                this.transform.localPosition = new Vector3(0, YValue, 0);

                count2 = determineCount(YValue);

                Debug.Log("count = " + count2);


                for (int i = PE_Cubes.Length-1; i >= (PE_Cubes.Length - count2)-1 ; i--)
                {
                    Debug.Log("hello: " + i);
                    PE_Cubes[i].GetComponent<Renderer>().material.color = Color.green;
                }
                for (int i = 0; i < count2; i++)
                {
                    KE_Cubes[i].GetComponent<Renderer>().material.color = Color.white;
                }

                if (this.transform.localPosition.y >= 0.7f)
                {

                    for (int i = 0; i < PE_Cubes.Length; i++)
                    {
                        PE_Cubes[i].GetComponent<Renderer>().material.color = Color.green;
                    }
                    for (int i = 0; i < KE_Cubes.Length; i++)
                    {
                        KE_Cubes[i].GetComponent<Renderer>().material.color = Color.white;
                    }
                    flag = false;
                }
            }
        }


        velocity = ((transform.position - previous).magnitude) / Time.deltaTime;
        previous = transform.position;

        height = this.transform.localPosition.y;




       
        KE = (0.2f) * (mass) * (velocity);
        PE = mass * (gravitinal_force) * height;



        kinetic_energy.text = "Kinetic Energy = " + KE.ToString("F2");
        potential_energy.text = "Potential Energy = " + PE.ToString("F2");
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("---Collision---");
        gravitinal_force = -9.8f;
        for(int i = 0; i < KE_Cubes.Length; i++)
        {
            KE_Cubes[i].GetComponent<Renderer>().material.color  = Color.green;
        }
        for (int i = 0; i < PE_Cubes.Length; i++)
        {
            PE_Cubes[i].GetComponent<Renderer>().material.color = Color.white;
        }
        count2 = 0;
        flag = true;
    }
    

}
