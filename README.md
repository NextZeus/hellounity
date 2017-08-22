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

## 2D 图形

	Sprites Sprite Editor
	Texture Type:	Sprite(2D and UI)

# Graphics [图像]
	lighting: intensity[强度] direction[方向] color[颜色]
	some lights may diminish ［减弱］ with distance from the source
	lighting technique
		Realtime lighting
			By default, lights in Unity - directional, spot and point, are realtime
		Backed[烘培] lightmaps
		Precomputed realtime global illumination

	With baked lighting, these lightmaps cannot change during gameplay and so are referred to as ‘static’. Realtime lights can be overlaid and used additively on top of a lightmapped scene but cannot interactively change the lightmaps themselves.



geometry 几何结构
illumination 照明
lightmap 光线映射
bounce 弹 跳
albedo 反射率
lit 照亮的 environments 
deliver 实现 effects 
simultaneously 同时地