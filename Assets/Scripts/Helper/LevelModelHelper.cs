using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Helper
{
    public class LevelModelHelper : MonoBehaviour
    {

        public Sprite[] platformsSprites;
        public Sprite[] lockPlatformsSprites;

        /// <summary>
        ///		Модель игровой точки
        /// </summary>
        public GameObject pointModel;

        /// <summary>
        ///		Модель игровой точки
        /// </summary>
        public GameObject platformModel;

        /// <summary>
        ///		Модель игрока
        /// </summary>
        public GameObject playerModel;
	}
}
