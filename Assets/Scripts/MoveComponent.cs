using UnityEngine;

namespace Tanks
{
    public class MoveComponent : MonoBehaviour
    {
        [SerializeField, Range(1f, 10f)]
        private float _speed = 1f;

        public void OnMove(DirectionType type)
        {
            //transform.position = Extensions.ConvertTypeFromDirection(type) * (Time.deltaTime * _speed)
            transform.position += type.ConvertTypeFromDirection() * (Time.deltaTime * _speed);
            transform.eulerAngles = Extensions.ConvertTypeFromRotation(type);
        }
    }
}


