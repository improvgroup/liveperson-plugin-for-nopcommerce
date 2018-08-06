using System.Collections.Generic;
using Nop.Core;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;

namespace Nop.Plugin.Widgets.LivePersonChat
{
    /// <summary>
    /// Live person provider
    /// </summary>
    public class LivePersonChatPlugin : BasePlugin, IWidgetPlugin
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;

        #endregion

        #region Ctor

        public LivePersonChatPlugin(ILocalizationService localizationService, 
            ISettingService settingService, 
            IWebHelper webHelper)
        {
            this._localizationService = localizationService;
            this._settingService = settingService;
            this._webHelper = webHelper;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>Widget zones</returns>
        public IList<string> GetWidgetZones()
        {
            return new List<string> { "body_end_html_tag_before" };
        }

        public void GetPublicViewComponent(string widgetZone, out string viewComponentName)
        {
            viewComponentName = "WidgetsLivePerson";
        }

        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/WidgetsLivePersonChat/Configure";
        }
        
        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            //settings
            var settings = new LivePersonChatSettings
            {
                LiveEngageTag = ""
            };
            _settingService.SaveSetting(settings);

            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.LivePersonChat.LiveEngageTag", "LiveEngage Tag");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.LivePersonChat.LiveEngageTag.Hint", "Enter your LiveEngage Tag code here.");

            base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<LivePersonChatSettings>();

            //locales
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.LivePersonChat.LiveEngageTag");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.LivePersonChat.LiveEngageTag.Hint");

            base.Uninstall();
        }

        /// <summary>
        /// Gets a name of a view component for displaying widget
        /// </summary>
        /// <param name="widgetZone">Name of the widget zone</param>
        /// <returns>View component name</returns>
        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "WidgetsLivePerson";
        }

        #endregion
    }
}
