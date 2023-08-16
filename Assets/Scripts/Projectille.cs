using UnityEngine;

namespace Tanks
{
    [RequireComponent(typeof(MoveComponent))]
    public class Projectille : MonoBehaviour
    {
        private SideType _side;
        private DirectionType _direction;

        private MoveComponent _moveComp;

        [SerializeField, Range(1, 10)]
        private int _damage = 1;
        [SerializeField, Range(1f, 5f)]
        private float _lifeTime = 3f;

        private void Start()
        {
            _moveComp = GetComponent<MoveComponent>();
            Destroy(gameObject, _lifeTime);
        }

        public void SetParams(DirectionType direction, SideType side) => (_direction, _side) = (direction, side);

        private void Update()
        {
            _moveComp.OnMove(_direction);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var fire = collision.GetComponent<FireComponent>();
            if (fire != null)
            {
                if (fire.GetSide == _side) return;

                var condition = fire.GetComponent<ConditionComponent>();
                condition.SetDamage(_damage);
                Destroy(gameObject);
                return;
            }

            var cell = collision.GetComponent<CellComponent>();
            if (cell != null)
            {
                if (cell.DestroyProjectile) Destroy(gameObject);
                if (cell.DestroyCell) Destroy(cell.gameObject);
                return;
            }
        }
    }
}


