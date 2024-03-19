using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Tipoul.Athentication.Agent.Services;

namespace Tipoul.Athentication.Agent.Middlewares
{
    public class AthenticationMiddleware : IMiddleware
    {
        private readonly List<ControllerModel> controllers;

        private readonly AthenticationProvider athenticationProvider;

        public AthenticationMiddleware(AthenticationProvider athenticationProvider)
        {
            controllers = Assembly.GetEntryAssembly().GetTypes()
                .Where(f => f.Name.EndsWith("Controller"))
                .Select(controllerType => new ControllerModel(controllerType)).ToList();
            this.athenticationProvider = athenticationProvider;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var controllerName = context.GetRouteValue("controller") as string;
            var actionName = context.GetRouteValue("action") as string;

            var allowAnonymous = controllers.Any(f => f.Name == $"{controllerName}Controller" && (f.AllowAnonymous || f.ActionModels.Any(x => x.Name == actionName && x.AllowAnonymous)));

            if (allowAnonymous || athenticationProvider.HasToken())
                await next.Invoke(context);
            else
                context.Response.Redirect($"/login?redirectUrl={context.Request.Scheme}://{context.Request.Host}{context.Request.Path}");
        }

        private class ControllerModel
        {
            public ControllerModel(Type controller)
            {
                Name = controller.Name;
                AllowAnonymous = controller.GetCustomAttribute<AllowAnonymousAttribute>() != null;
                ActionModels = controller.GetMethods()
                    .Where(f => !f.IsStatic && f.IsPublic && !f.IsConstructor && f.DeclaringType == controller)
                    .Select(actionMethod => new ActionModel(actionMethod)).ToList();
            }

            public string Name { get; set; }

            public bool AllowAnonymous { get; set; }

            public List<ActionModel> ActionModels { get; set; }
        }

        private class ActionModel
        {
            public ActionModel(MethodInfo actionMethod)
            {
                Name = actionMethod.Name;
                AllowAnonymous = actionMethod.GetCustomAttribute<AllowAnonymousAttribute>() != null;
            }

            public string Name { get; set; }

            public bool AllowAnonymous { get; set; }
        }
    }
}
