using System.Web.Mvc;
using Nop.Plugin.Widgets.LivePersonChat.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.Widgets.LivePersonChat.Controllers
{
    public class WidgetsLivePersonChatController : BasePluginController
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly ISettingService _settingService;
        private readonly LivePersonChatSettings _livePersonChatSettings;

        #endregion

        #region Ctor

        public WidgetsLivePersonChatController(ISettingService settingService, 
            ILocalizationService localizationService, 
            LivePersonChatSettings livePersonChatSettings)
        {
            this._settingService = settingService;
            this._localizationService = localizationService;
            this._livePersonChatSettings = livePersonChatSettings;
        }

        #endregion

        #region Methods

        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure()
        {
            var model = new ConfigurationModel
            {
                LiveEngageTag = _livePersonChatSettings.LiveEngageTag
            };

            return View("~/Plugins/Widgets.LivePersonChat/Views/Configure.cshtml", model);
        }

        [HttpPost]
        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure(ConfigurationModel model)
        {
            if (!ModelState.IsValid)
                return Configure();

            //save settings
            _livePersonChatSettings.LiveEngageTag = model.LiveEngageTag;

            _settingService.SaveSetting(_livePersonChatSettings);

            SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));

            return Configure();
        }

        [ChildActionOnly]
        public ActionResult PublicInfo(string widgetZone)
        {
            var model = new PublicInfoModel
            {
                LiveEngageTag = _livePersonChatSettings.LiveEngageTag
            };

            return View("~/Plugins/Widgets.LivePersonChat/Views/PublicInfo.cshtml", model);
        }

        #endregion
    }
}