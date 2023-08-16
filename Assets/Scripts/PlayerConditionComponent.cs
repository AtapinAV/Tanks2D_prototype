using System.Collections;
using UnityEngine;

namespace Tanks
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerConditionComponent : ConditionComponent
    {
        private bool _immortal;
        private Vector3 _startPoint;
        private SpriteRenderer _render;

        [SerializeField, Range(1f, 10f)]
        private float _immortalTime = 3f;
        [SerializeField, Range(0.1f, 2f)]
        private float _immortalSwitchVisual = 0.2f;

        private void Start()
        {
            _startPoint = transform.position;
            _render = GetComponent<SpriteRenderer>();
        }

        public override void SetDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                transform.position = _startPoint;
                StartCoroutine(OnImmortal());
                Destroy(gameObject, 5f);
            }
            
        }

        private IEnumerator OnImmortal()
        {
            _immortal = true;
            var time = _immortalTime;
            while (time > 0f)
            {
                _render.enabled = !_render.enabled;
                time -= Time.deltaTime;
                yield return new WaitForSeconds(_immortalSwitchVisual);
            }
            _immortal = false;
            _render.enabled = true;
        }
    }
}


