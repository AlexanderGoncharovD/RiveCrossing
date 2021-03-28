using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Settings
{
    /// <summary>
    ///     Игровые настройки
    /// </summary>
    public sealed class Settings : SettingsBase
    {
        #region Properties

        /// <summary>
        ///     Настройки рекламы
        /// </summary>
        public SettingsAds Ads { get; private set; }

        #endregion

        public override void Load()
        {
            Ads = new SettingsAds();
        }
    }
}
