﻿using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.LivePersonChat.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.LivePersonChat.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    public class WidgetsLivePersonChatController : BasePluginController
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly ISettingService _settingService;
        private readonly LivePersonChatSettings _livePersonChatSettings;
        private readonly IPermissionService _permissionService;

        #endregion

        #region Ctor

        public WidgetsLivePersonChatController(ISettingService settingService, 
            ILocalizationService localizationService, 
            LivePersonChatSettings livePersonChatSettings,
            IPermissionService permissionService)
        {
            this._settingService = settingService;
            this._localizationService = localizationService;
            this._livePersonChatSettings = livePersonChatSettings;
            this._permissionService = permissionService;
        }

        #endregion

        #region Methods
        
        public IActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            var model = new ConfigurationModel
            {
                LiveEngageTag = _livePersonChatSettings.LiveEngageTag
            };

            return View("~/Plugins/Widgets.LivePersonChat/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public IActionResult Configure(ConfigurationModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            if (!ModelState.IsValid)
                return Configure();

            //save settings
            _livePersonChatSettings.LiveEngageTag = model.LiveEngageTag;

            _settingService.SaveSetting(_livePersonChatSettings);

            SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));

            return Configure();
        }
        
        #endregion
    }
}