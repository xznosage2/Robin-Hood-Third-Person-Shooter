using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Heal : MonoBehaviour
{


    [Header("Heal Amount")]
    [SerializeField] float heal = 1;

    [Header("Is Constant")]
    [SerializeField] bool oneTime = true;




    private void OnTriggerEnter(Collider other)
    {
        if (oneTime && other.gameObject.TryGetComponent<IHealiable>(out IHealiable healiable))
        {
            healiable.restoreHealth(heal);
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (!oneTime && other.gameObject.TryGetComponent<IHealiable>(out IHealiable healiable))
        {
            healiable.restoreHealth(heal);
        }
    }
}

public interface IHealiable
{
    void restoreHealth(float health);

}

