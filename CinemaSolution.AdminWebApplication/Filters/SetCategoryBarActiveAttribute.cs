using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CinemaSolution.AdminWebApplication.Filters
{
    public class SetBarActiveAttribute : ActionFilterAttribute
    {
        private readonly string _barActiveValue;

        public SetBarActiveAttribute(string barActiveValue)
        {
            _barActiveValue = barActiveValue;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as Controller;
            if (controller != null)
            {
                controller.ViewData["BarActive"] = _barActiveValue;
            }
            base.OnActionExecuting(context);
        }
    }
}
