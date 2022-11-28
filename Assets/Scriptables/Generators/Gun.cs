using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class Gun : ScriptableObject
{
    [Header("Gun General Variable Fields")]
    public string gunName;
    public GameObject gunPrefab;

    [Header("Gun Stats")]
    public float damage;
    public float fireRate;
    public float reloadSpeed;
}
