using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Coin : MonoBehaviour
{
    private float _flySpeed;
    [Inject]
    private Transform _flyPoint;

    private void Start()
    {
        _flySpeed = 20f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boy") || other.gameObject.CompareTag("Girl"))
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;

            StartCoroutine(Fly());
        }
    }
    private IEnumerator Fly()
    {
        while(transform.position != _flyPoint.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, _flyPoint.position, _flySpeed * Time.deltaTime);
            yield return null;
        }
        Destroy(gameObject);
    }
}
