using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;

    public bool CreateTower(Tower tower, Transform position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null)
        {
            return false;
        }

        if (bank.CurrentBalance >= cost)
        {
            Instantiate(tower.gameObject, position);
            bank.Withdraw(cost);
            return true;
        }

        return false;
    }
}
