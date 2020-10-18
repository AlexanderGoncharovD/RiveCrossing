using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Water : MonoBehaviour
    {
        #region Fields

        private Renderer _renderer;
        private Material _material;

        public float speed = 0.5f;

        #endregion

        #region Private Methods

        private void Start()
        {
            _renderer = this.GetComponent<Renderer>();
            _material = _renderer.material;
        }

        private void Update()
        {
            var vector = new Vector2(Time.time * speed, 0);
            _material.SetTextureOffset("_MainTex", vector);
        }

        #endregion
    }
}
