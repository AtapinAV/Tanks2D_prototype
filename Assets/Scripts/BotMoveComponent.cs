using UnityEngine;
using System;
using Random = System.Random;

namespace Tanks
{
    public class BotMoveComponent : MonoBehaviour
    {
        private FireComponent _fireComp;

        [SerializeField, Range(1f, 10f)]
        private float _moveSpeed = 2f;
        [SerializeField]
        private DirectionBot _directionBot;

        private void Start()
        {
            _fireComp = GetComponent<FireComponent>();
        }

        private void Update()
        {
            _fireComp.OnFire();

            switch (_directionBot)
            {
                case DirectionBot.Up:
                    transform.position += _moveSpeed * Time.deltaTime * Vector3.up;
                    transform.eulerAngles = new Vector3(0f, 0f, 0f);
                    break;
                case DirectionBot.Right:
                    transform.position += _moveSpeed * Time.deltaTime * Vector3.right;
                    transform.eulerAngles = new Vector3(0f, 0f, 270f);
                    break;
                case DirectionBot.Down:
                    transform.position += _moveSpeed * Time.deltaTime * Vector3.down;
                    transform.eulerAngles = new Vector3(0f, 0f, 180f);
                    break;
                case DirectionBot.Left:
                    transform.position += _moveSpeed * Time.deltaTime * Vector3.left;
                    transform.eulerAngles = new Vector3(0f, 0f, 90f);
                    break;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Random random = new Random();
            int randomMove = random.Next(0, 4);
            DirectionBot direction = (DirectionBot) randomMove;
            _directionBot = direction;
        }
    }

    public enum DirectionBot : int
    {
        Up, Right, Down, Left
    }
}


