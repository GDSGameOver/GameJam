using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CradleDetector : MonoBehaviour
{
    [SerializeField] private Enemy _parent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Cradle cradle))
        {
            _parent.CradleTakeDamage(cradle);
        }
    }
}
