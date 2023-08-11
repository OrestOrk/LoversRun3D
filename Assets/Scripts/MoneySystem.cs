using UnityEngine;
using System.Collections;
using Zenject;

public class MoneySystem : MonoBehaviour
{
    public float saveInterval;
    public int startMoney;

    private UIController _uiController;
    private int money;

    [Inject]
    public void Construct(UIController uIController)
    {
        _uiController = uIController;
    }
    void Start()
    {
        if (!PlayerPrefs.HasKey("MoneySaved"))
        {
            AddMoney(startMoney);
        }
        else
        {
            AddMoney(PlayerPrefs.GetInt("MoneySaved", 0));
        }

        StartCoroutine("SaveMoney");

        _uiController.UpdateMoneyText(money);
    }


    //while reality exists, save money every saveInterval.
    public IEnumerator SaveMoney()
    {
        while (true)
        {
            yield return new WaitForSeconds(saveInterval);
            PlayerPrefs.SetInt("MoneySave",money);
        }
    }

    //Checks if you have enough money to buy item with cost, if you do buy it and return true. Otherwise, return false.
    public bool BuyItem(int cost)
    {
        if (money - cost >= 0)
        {
            money -= cost;
            PlayerPrefs.SetInt("MoneySaved",money);

            _uiController.UpdateMoneyText(money);
            return true;
        }
        else
        {
            return false;
        }
    }

    //Simply return the balance
    public  int GetMoney()
    {
        return money;
    }

    //Add some money to the balance.
    public void AddMoney(int amount)
    {
        money += amount;
        PlayerPrefs.SetInt("MoneySaved", money);

        _uiController.UpdateMoneyText(money);
    }
}