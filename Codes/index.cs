using UnityEngine;
using System.Collections;

public class ExampleBehaviourScript: MonoBehaviour
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

public class VariableAndFunctions: MonoBehaviour 
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

public class BasicSyntax: MonoBehaviour 
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

// Destroy

Destroy(gameObject, delayTime);

public class DualAxisExample: MonoBehaviour
{
    public float range;
    public GUIText textOutput;

    void /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        float h = Input.GetAxis('Horizontal');
        float v = Input.GetAxis('Vertical');

        float xpos = h * range;
        float ypos = v * range;
        transform.position = new Vector3(xpos, ypos, 0);
        textOutput.text = "Horizontal Value Returned: "+h.ToString("F2")+"\nVertical Value Returned: "+v.ToString("F2"); 
    }
}

public class MouseClick: MonoBehaviour
{
    void OnMouseDown()
    {
        // 给某个物体一个作用力 踢开
        rigibody.AddForce(-transform.forward * 500f);
        rigibody.useGravity = true;
    }
}

public class UsingInstantiate: MonoBehaviour
{
    public Rigibody rocketPrefab;
    public Transform barrelEnd;

    void Update()
    {
        if(Input.GetButtonDown('Fire1'))
        {
            Rigibody rocketInstance;
            rocketInstance = Instantiate(rocketPrefab, barrelEnd.position, barrelEnd.rotation) as Rigibody;
            rocketInstance.AddForce(barrelEnd.forward * 5000f);
        }
    }
}

public class InvokeScript: MonoBehaviour
{
    public GameObject target;

    void Start(){
        Invoke('SpawnObject',2); //call SpawnObject function after 2s
    }
    void SpawnObject()
    {
        Instantiate(target, new Vector3(0,2,0), Quaternion.identity);
    }
}

public class InvokeRepeating : MonoBehaviour 
{
    public GameObject target;
    
    
    void Start()
    {
        InvokeRepeating("SpawnObject", 2, 1);
    }
    
    void SpawnObject()
    {
        float x = Random.Range(-2.0f, 2.0f);
        float z = Random.Range(-2.0f, 2.0f);
        Instantiate(target, new Vector3(x, 2, z), Quaternion.identity);
    }
}
