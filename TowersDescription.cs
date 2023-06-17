using UnityEngine;
using UnityEngine.UI;

public class TowersDescription : MonoBehaviour
{
    public void Start()
    {
        // Send data for each tower to text fields
        foreach (Transform tower in transform)
        {
            switch (tower.name)
            {
                case "BowTower":
                    BowTower bowTower = new BowTower();
                    bowTower.AssignTextFields(tower.GetComponentsInChildren(typeof(Transform)));
                    bowTower.SetValues();
                    break;
                case "CannonTower":
                    CannonTower cannonTower = new CannonTower();
                    cannonTower.AssignTextFields(tower.GetComponentsInChildren(typeof(Transform)));
                    cannonTower.SetValues();
                    break;
                case "FreezeTower":
                    FreezeTower freezeTower = new FreezeTower();
                    freezeTower.AssignTextFields(tower.GetComponentsInChildren(typeof(Transform)));
                    freezeTower.SetValues();
                    break;
            }
        }
    }
}

public abstract class Tower
{
    public GameObject TextDamage;
    public GameObject TextRadius;
    public GameObject TextCost;
    public int ValueDamage;
    public int ValueRadius;
    public int ValueCost;

    public void SetValues()
    {
        TextDamage.GetComponent<Text>().text = ValueDamage.ToString();
        TextRadius.GetComponent<Text>().text = ValueRadius.ToString();
        TextCost.GetComponent<Text>().text = ValueCost.ToString();
    }

    // Each tower has a personal block of parameters
    public void AssignTextFields(Component[] parameters)
    {
        foreach (Component parameter in parameters)
        {
            switch (parameter.name)
            {
                case "Damage":
                    TextDamage = parameter.gameObject;
                    break;
                case "Radius":
                    TextRadius = parameter.gameObject;
                    break;
                case "Cost":
                    TextCost = parameter.gameObject;
                    break;
            }
        }
    }
}

public class BowTower : Tower
{
    public BowTower()
    {
        ValueDamage = PlayerPrefs.GetInt("BowTowerDamage");
        ValueRadius = PlayerPrefs.GetInt("BowTowerRadius");
        ValueCost = PlayerPrefs.GetInt("BowTowerCost");
    }
}

public class CannonTower : Tower
{
    public CannonTower()
    {
        ValueDamage = PlayerPrefs.GetInt("CannonTowerDamage");
        ValueRadius = PlayerPrefs.GetInt("CannonTowerRadius");
        ValueCost = PlayerPrefs.GetInt("CannonTowerCost");
    }
}

public class FreezeTower : Tower
{
    public FreezeTower()
    {
        ValueDamage = PlayerPrefs.GetInt("FreezeTowerDamage");
        ValueRadius = PlayerPrefs.GetInt("FreezeTowerRadius");
        ValueCost = PlayerPrefs.GetInt("FreezeTowerCost");
    }
}
