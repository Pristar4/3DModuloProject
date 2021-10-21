using UnityEngine;

namespace _3DProject.Scripts
{
    public class PlayerWeaponToHand : MonoBehaviour
    {
        [SerializeField] private GameObject leftWeaponOrigin;

        [SerializeField] private GameObject itemIndex;


        private void Awake()
        {
            SetTransform();
        }

        private void SetTransform()
        {
            itemIndex.transform.position = leftWeaponOrigin.transform.position;
            itemIndex.transform.parent = leftWeaponOrigin.transform;
        }
    }
}