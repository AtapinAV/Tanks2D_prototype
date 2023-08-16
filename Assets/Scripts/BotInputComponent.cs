using UnityEngine;

namespace Tanks
{
    [RequireComponent(typeof(MoveComponent), typeof(FireComponent))]
    public class BotInputComponent : MonoBehaviour
    {
        private FireComponent _fireComp;
        private MoveComponent _moveComp;
        private DirectionType _direction;

        private void Start()
        {
            _fireComp = GetComponent<FireComponent>();
            _moveComp = GetComponent<MoveComponent>();
            
        }

        public void BotParams(DirectionType direction) => _direction = direction;

        private void Update()
        {
            _fireComp.OnFire();

            _moveComp.OnMove(_direction);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(gameObject, 2f);
        }
    }
}


