using UnityEngine;
using System.Collections;

public class ForceToRemains : MonoBehaviour {


	void Start () {
	    foreach (Transform child in transform)
        {
            Rigidbody2D body = child.GetComponent<Rigidbody2D>();
            body.AddForce(new Vector2(Random.Range(-1000, 1000), Random.Range(-1000, 1000)), ForceMode2D.Force);

            StartCoroutine(remove(child.gameObject));
        }
        StartCoroutine(close());
	}

    IEnumerator remove(GameObject child)
    {
        yield return new WaitForSeconds(Random.Range(2f, 4f));
        Destroy(child);
    }

    IEnumerator close()
    {
        yield return new WaitForSeconds(4);
        Destroy(this.gameObject);
    }

}
