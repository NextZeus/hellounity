using UnityEngine;
using System.Collections;

public class ExampleBehaviourScript: MonBehaviour
{
    void Update(){
        if(Input.GetKeyDown(KeyCode.R)){
            GetComponent<Render>().material.color = Color.red;
        }
        if(Input.GetKeyDown(KeyCode.G)){
            GetComponent<Render>().material.color = Color.green;
        }
        if(Input.GetKeyDown(KeyCode.B)){
            GetComponent<Render>().material.color = Color.blue;
        }
    }
}

public class VariableAndFunctions: MonBehaviour 
{
    int myInt = 5;
    void Start(){
        myInt = MultiplyByTwo(myInt);
        Debug.Log(myInt);
    }

    int MultiplyByTwo(int number)
    {
        int ret;
        ret = number * 2;
        return ret;
    }
}

public class BasicSyntax: MonBehaviour 
{
    void void Start()
    {
        Debug.Log(transform.position.y);
        if(transform.position.y <= 5f){
            Debug.Log('I`m about to hit the ground!');
        }
    }
}

public class CameraLookAt : MonoBehaviour
{
    public Transform target;
    
    void Update ()
    {
        transform.LookAt(target);
    }
}

// linearly interpolate 线性插值
// In this case, result = 4
float result = Mathf.Lerp (3f, 5f, 0.5f); //50%
Vector3 from = new Vector3 (1f, 2f, 3f);
Vector3 to = new Vector3 (5f, 6f, 7f);

// Here result = (4, 5, 6)
Vector3 result = Vector3.Lerp (from, to, 0.75f);

void Update ()
{
    light.intensity = Mathf.Lerp(light.intensity, 8f, 0.5f * Time.deltaTime);
}