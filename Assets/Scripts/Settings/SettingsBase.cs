using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Settings
{
    public abstract class SettingsBase
    {
        private bool _isLoading;

        protected SettingsBase()
        {
            _isLoading = true;
            Load();
            _isLoading = false;
        }

        public void SetProperty(string propertyName, object value)
        {
            if (_isLoading == false)
            {
                PlayerPrefs.SetString(propertyName, value.ToString());
            }
        }

        public abstract void Load();
        public abstract void RestoreToDefault();
    }
}
