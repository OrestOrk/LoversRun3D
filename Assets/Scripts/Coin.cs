using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Coin : MonoBehaviour
{
    private float _flySpeed;

    private Transform _flyPoint;
    private MoneySystem _moneySystem;

    [Inject]
    public void Construct(Transform flyPoint,MoneySystem moneySystem)
    {
        _flyPoint = flyPoint;
        _moneySystem = moneySystem;
    }
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

            if(Vector3.Distance(transform.position,_flyPoint.position) < 2f)
            {
                _moneySystem.AddMoney(1);
                Debug.Log("CoinsAdInCoins");
                Destroy(gameObject);
                yield break;
            }
            yield return null;
        }
        _moneySystem.AddMoney(1);
        Debug.Log("CoinsAdInCoins");
        Destroy(gameObject);
    }
}
