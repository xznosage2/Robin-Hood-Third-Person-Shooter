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

    public int PlayerIndex = 1;

	public void TakeDamage(float damage)
	{
		
	}

    public void setDamage(int dmg)
    {
        damage = dmg;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            if (oneTime && other.gameObject.TryGetComponent<IDamagable>(out IDamagable damagable))
            {
                damagable.TakeDamage(damage);
                int player = GetComponent<Arrow>().getPlayerIndex();
                other.gameObject.GetComponent<Enemy>().setPlayerIndex(player);
                DestroyGameObject();
            }
        }
        if(other.gameObject.tag == "Player")
        {
			if (oneTime && other.gameObject.TryGetComponent<IDamagable>(out IDamagable damagable))
			{
				damagable.TakeDamage(damage);
			
				DestroyGameObject();
			}
		}
    }
    private void OnTriggerStay(Collider other)
    {
        if (!oneTime && other.gameObject.TryGetComponent<IDamagable>(out IDamagable damagable))
        {
            damagable.TakeDamage(damage * Time.deltaTime);
        }
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}


public interface IDamagable
{
    void TakeDamage(float damage);


}
