using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.LivePersonChat.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        [NopResourceDisplayName("Plugins.Widgets.LivePersonChat.LiveEngageTag")]
        public string LiveEngageTag { get; set; }
    }
}