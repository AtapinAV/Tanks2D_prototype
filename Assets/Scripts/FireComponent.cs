using System.Collections;
using UnityEngine;

namespace Tanks
{
    public class FireComponent : MonoBehaviour
    {
        private bool _canFire = true;

        [SerializeField, Range(0.1f, 1f)]
        private float _delatFire = 0.25f;
        [SerializeField]
        private Projectille _prefab;
        [SerializeField]
        private SideType _side;

        public SideType GetSide => _side;
        
        public void OnFire()
        {
            if (!_canFire) return;

            var bullet = Instantiate(_prefab, transform.position, transform.rotation);
            bullet.SetParams(transform.eulerAngles.ConvertRotationFromType(), _side);

            StartCoroutine(OnDelay());
        }

        private IEnumerator OnDelay()
        {
            _canFire = false;
            yield return new WaitForSeconds(_delatFire);
            _canFire = true;
        }
    }
}


