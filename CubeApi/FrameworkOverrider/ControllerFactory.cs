using CubeInfrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;

namespace CubeApi.FrameworkOverrider
{
    public class ControllerFactory: IControllerFactory
    {
        public object CreateController(ControllerContext context)
        {
            var controllerType = context.ActionDescriptor.ControllerTypeInfo.AsType();
            
            return Container.Instance().Create(controllerType);
        }
 
        public void ReleaseController(ControllerContext context, object controller)
        {
            if (controller is IDisposable controllerDispose)
            {
                controllerDispose.Dispose();
            }
        }

    }
}
