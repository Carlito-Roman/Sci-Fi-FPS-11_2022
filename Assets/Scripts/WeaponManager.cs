using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Player Weapon Array")]
    [SerializeField] private Gun[] loadout;

    [Header("Weapon General Variable Fields")]
    [SerializeField] private Transform weaponParent;

    private GameObject currentEquipment;

    // Start is called before the first frame update
    void Start()
    {
       if(loadout[0] != null) {
            Equip(0);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Equip(int equipmentIndex) {

        if(currentEquipment != null) {
            Destroy(currentEquipment);
        }

        GameObject newEquipment = Instantiate(loadout[equipmentIndex].gunPrefab, weaponParent.position, weaponParent.rotation, weaponParent) as GameObject;
        newEquipment.transform.localPosition = Vector3.zero;
        newEquipment.transform.localEulerAngles = Vector3.zero;

        currentEquipment = newEquipment;
    }
}
