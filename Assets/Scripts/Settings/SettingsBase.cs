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

        protected SettingsBase()
        {
            Load();
        }

        public void SetProperty(string propertyName, object value)
        {
            PlayerPrefs.SetString(propertyName, value.ToString());
        }

        public abstract void Load();

        public virtual void RestoreToDefault()
        {
            PlayerPrefs.DeleteAll();
            Load();
        }
    }
}
