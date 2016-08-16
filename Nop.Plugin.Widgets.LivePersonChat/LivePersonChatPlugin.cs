using System.Collections.Generic;
using System.Web.Routing;
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

        private readonly ISettingService _settingService;

        #endregion

        #region Ctor

        public LivePersonChatPlugin(ISettingService settingService)
        {
            this._settingService = settingService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>Widget zones</returns>
        public IList<string> GetWidgetZones()
        {
            return new List<string>() { "body_end_html_tag_before" };
        }

        /// <summary>
        /// Gets a route for provider configuration
        /// </summary>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "WidgetsLivePersonChat";
            routeValues = new RouteValueDictionary() { { "Namespaces", "Nop.Plugin.Widgets.LivePersonChat.Controllers" }, { "area", null } };
        }

        /// <summary>
        /// Gets a route for displaying widget
        /// </summary>
        /// <param name="widgetZone">Widget zone where it's displayed</param>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        public void GetDisplayWidgetRoute(string widgetZone, out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "PublicInfo";
            controllerName = "WidgetsLivePersonChat";
            routeValues = new RouteValueDictionary()
            {
                {"Namespaces", "Nop.Plugin.Widgets.LivePersonChat.Controllers"},
                {"area", null},
                {"widgetZone", widgetZone}
            };
        }
        
        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            //settings
            var settings = new LivePersonChatSettings()
            {
                LiveEngageTag = ""
            };
            _settingService.SaveSetting(settings);

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.LivePersonChat.LiveEngageTag", "LiveEngage Tag");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.LivePersonChat.LiveEngageTag.Hint", "Enter your LiveEngage Tag code here.");

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
            this.DeletePluginLocaleResource("Plugins.Widgets.LivePersonChat.LiveEngageTag");
            this.DeletePluginLocaleResource("Plugins.Widgets.LivePersonChat.LiveEngageTag.Hint");

            base.Uninstall();
        }

        #endregion
    }
}
