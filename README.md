# Hello Unity Script C#

## Accessing ComponentsScript 
```

void Start(){
	Rigibody rb = GetComponent<Rigibody>();
	rb.mass = 10f;
	rb.AddForce(Vector3.up * 10f);
}

```

## Accessing Other Objects
```

public class Enemy : MonoBehaviour{
	public GameObject player;
	
	void Start(){
		transform.position = player.position - Vector3.forward * 10f;
	}
}

```

## Finding Child Objects
```
using UnityEngine;

public class WAypointManager : MonoBehaviour{
	public Transform[] waypoints;

	void Start(){
		waypoints = new Transform[transform.chindCount];
		int i = 0;
		forEach(Transform t in transform){
			waypoints[i++] = t;
		}
		

		// locate a specific child by name 
		transform.Find('Gun');
		
		GameObject player = GameObject.Find('MainHeroCharacter');
		player = GameObject.FindWithTag('Player');
		GameObject[] enemies = GameObject.FindGameObjectsWithTag('Enemy');

	}
}	


```

