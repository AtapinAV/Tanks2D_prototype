using UnityEngine;

namespace Tanks
{
    public  class ConditionComponent : MonoBehaviour
    {
        [SerializeField, Range(1, 10)]
        protected int _health = 3;

        public virtual void SetDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}


