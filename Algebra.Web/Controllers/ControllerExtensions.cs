﻿using Algebra.Web.Toast;
using Microsoft.AspNetCore.Mvc;

namespace Algebra.Web.Controllers
{
    public static class ControllerExtensions
    {
        public static ToastMessage AddToastMessage
            (
            this Controller controller, 
            string title, 
            string message, 
            ToastType toastType = ToastType.Info
            )
        {
            Toastr toastr = controller.TempData["Toastr"] as Toastr;
            toastr = toastr ?? new Toastr();
            var toastMessage = toastr.AddToastMessage(title, message, toastType);
            controller.TempData["Toastr"] = toastr;
            return toastMessage;
        }
    }
}
