using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Mvc.Models;

namespace Nop.Plugin.Widgets.LivePersonChat.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        [NopResourceDisplayName("Plugins.Widgets.LivePersonChat.LiveEngageTag")]
        public string LiveEngageTag { get; set; }
    }
}