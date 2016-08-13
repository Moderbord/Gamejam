using UnityEngine;
using System.Collections;

public class ProjectileOutOfRange : MonoBehaviour {

    public float aliveTime;

	// Use this for initialization
	void Awake () {
        Destroy(gameObject, aliveTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
