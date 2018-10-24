using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class graph : MonoBehaviour
{

    // Use this for initialization
    public GameObject textObj;

    Vector3 position;
    Vector3 position_KE;
    Vector3 position_PE;


    int index = 1;

    Vector3 scale = Vector3.one / 7f;

    float delaypoints = 0.2f;
    Boolean flag = false;


    float gravForce = Ball.gravitinal_force;
    float heightBall =2;
    float massBall = Ball.mass;
    int j = 0;



    void Start()
    {

        position.x = -4.9f;
        position.y = 0.0f;
        //Debug.Log("---massBall is ---:" + massBall);
        //Debug.Log("---gravForce is ---:" + gravForce);
        //Debug.Log("---heightBall is ---:" + heightBall);
        position.z = massBall * gravForce * heightBall * 0.01f;

        if (position.z == 0.00)
        {
            //Debug.Log("---Z is zero ---:");
            position.z = -4.5f;
        }
        else if (position.z > 0.00)
        {
            //Debug.Log("---Z is greater zero ---:");
            position.z = -4.5f + position.z * 20f;
        }
        //Debug.Log("---Position Z is ---:" + position.z);



        for (int i = 0; position.x <= 4.8; i++)
        {
            GameObject test = Instantiate(textObj);
            test.GetComponent<Renderer>().material.color = Color.black;
            position.x += 0.1f;

            test.transform.localPosition = position;
            test.transform.localScale = scale;
            test.transform.SetParent(transform, false);
        }

        position_PE.z = position.z;
        position_PE.x = -4.9f;
        position_PE.y = 0.0f;


        position_KE.z = -4.4f;
        position_KE.x = -4.9f;
        position_KE.y = 0.0f;


    }


    //Update is called once per frame
    void Update()
    {
        if (j == 3)
        {
            return;
        }
        if (flag == false)
        {
            for (int i = 0; position_PE.z > -4.3f; i++)
            {
                GameObject test_PE = Instantiate(textObj);
                test_PE.GetComponent<Renderer>().material.color = Color.blue;
                position_PE.x += 0.1f;

                position_PE.z -= (float)Math.Log(0.01f * massBall * i * i * i * gravForce + 1, 1000000);


                test_PE.transform.localPosition = position_PE;
                test_PE.transform.localScale = scale;
                test_PE.transform.SetParent(transform, false);
            }

            GameObject test_PE_1 = Instantiate(textObj);
            test_PE_1.GetComponent<Renderer>().material.color = Color.blue;
            position_PE.x += 0.2f;

            position_PE.z -= 0.2f;

            test_PE_1.transform.localPosition = position_PE;
            test_PE_1.transform.localScale = scale;
            test_PE_1.transform.SetParent(transform, false);


            for (int i = 0; position_KE.z < position.z; i++)
            {
                GameObject test_KE = Instantiate(textObj);
                test_KE.GetComponent<Renderer>().material.color = Color.red;
                position_KE.x += 0.1f;

                position_KE.z += (float)Math.Log(0.01f * massBall * i * i * i * gravForce + 1, 1000000);
                Debug.Log("---Position Z is ---:" + position_KE.z);

                test_KE.transform.localPosition = position_KE;
                test_KE.transform.localScale = scale;
                test_KE.transform.SetParent(transform, false);
            }

            flag = true;
        }
        else
        {
            for (int i = 0; position_PE.z < position.z; i++)
            {
                GameObject test_PE = Instantiate(textObj);
                test_PE.GetComponent<Renderer>().material.color = Color.blue;
                position_PE.x += 0.1f;

                position_PE.z += (float)Math.Log(0.01f * massBall * i * i * i * gravForce + 1, 1000000);
                Debug.Log("---Position Z is ---:" + position_PE.z);

                test_PE.transform.localPosition = position_PE;
                test_PE.transform.localScale = scale;
                test_PE.transform.SetParent(transform, false);
            }

            for (int i = 0; position_KE.z > -4.3f; i++)
            {
                GameObject test_KE = Instantiate(textObj);
                test_KE.GetComponent<Renderer>().material.color = Color.red;
                position_KE.x += 0.1f;

                position_KE.z -= (float)Math.Log(0.01f * massBall * i * i * i * gravForce + 1, 1000000);

                test_KE.transform.localPosition = position_KE;
                test_KE.transform.localScale = scale;
                test_KE.transform.SetParent(transform, false);
            }

            GameObject test_KE_1 = Instantiate(textObj);
            test_KE_1.GetComponent<Renderer>().material.color = Color.red;
            position_KE.x += 0.2f;

            position_KE.z -= 0.2f;

            test_KE_1.transform.localPosition = position_KE;
            test_KE_1.transform.localScale = scale;
            test_KE_1.transform.SetParent(transform, false);



            flag = false;
        }
        j++;
    }
}
