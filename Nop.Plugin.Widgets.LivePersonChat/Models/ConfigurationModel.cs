using System.Collections.Generic;
using System.Web.Mvc;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;

namespace Nop.Plugin.Widgets.LivePersonChat.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        [NopResourceDisplayName("Plugins.Widgets.LivePersonChat.LiveEngageTag")]
        [AllowHtml]
        public string LiveEngageTag { get; set; }
    }
}