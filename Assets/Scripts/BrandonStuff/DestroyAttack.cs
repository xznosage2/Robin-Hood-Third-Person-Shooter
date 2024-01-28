using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAttack : MonoBehaviour
{
    public float Timer = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(poofAttack), Timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void poofAttack()
	{
		Destroy(gameObject);
	}
}
