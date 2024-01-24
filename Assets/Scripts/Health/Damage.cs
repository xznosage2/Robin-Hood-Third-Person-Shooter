using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Damage : MonoBehaviour, IDamagable
{

    [Header("Damage Amount")]
    [SerializeField] float damage = 1;

    [Header("Is Constant")]
    [SerializeField] bool oneTime = true;

	public void TakeDamage(float damage)
	{
		
	}

	private void OnTriggerEnter(Collider other)
    {
        if (oneTime && other.gameObject.TryGetComponent<IDamagable>(out IDamagable damagable))
        {
            damagable.TakeDamage(damage);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (!oneTime && other.gameObject.TryGetComponent<IDamagable>(out IDamagable damagable))
        {
            damagable.TakeDamage(damage * Time.deltaTime);
        }
    }
}


public interface IDamagable
{
    void TakeDamage(float damage);


}
