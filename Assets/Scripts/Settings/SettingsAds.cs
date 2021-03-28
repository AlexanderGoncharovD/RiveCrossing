using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Settings
{
    /// <summary>
    ///     Рекламные настройки
    /// </summary>
    public sealed class SettingsAds : SettingsBase
    {
        #region Orivate Fields

        private const string _AppId = "";
        private bool _hasBannerAds;
        private bool _hasRewardAds;

        #endregion

        #region Properties

        /// <summary>
        ///     Рекламный идентификатор приложения
        /// </summary>
        public string AppId => _AppId;

        /// <summary>
        ///     Показывать ли баннерную рекламу
        /// </summary>
        public bool HasBannerAds
        {
            get => _hasBannerAds;
            set
            {
                _hasBannerAds = value;
                SetProperty(nameof(HasBannerAds), value);
            }
        }

        /// <summary>
        ///     Показывать ли рекламу за вознагражение
        /// </summary>
        public bool HasRewardAds
        {
            get => _hasRewardAds;
            set
            {
                _hasRewardAds = value;
                SetProperty(nameof(HasRewardAds), value);
            }
        }

        #endregion
        
        public override void Load()
        {

            if (!bool.TryParse(PlayerPrefs.GetString(nameof(HasBannerAds)), out _hasBannerAds))
            {
                HasBannerAds = SettingsDefault.hasBannerAds;
            }

            if (!bool.TryParse(PlayerPrefs.GetString(nameof(HasRewardAds)), out _hasRewardAds))
            {
                HasRewardAds = SettingsDefault.hasRewardAds;
            }

        }
    }
}
