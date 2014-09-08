using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TripodReporter.Web.Infrastructure
{
    public class ExcelResult : ActionResult
    {
        public string stringwriter { get; set; }
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Buffer = true;
            context.HttpContext.Response.Clear();
            context.HttpContext.Response.AddHeader("content-disposition", "attachement; filename=report.xls");
            context.HttpContext.Response.ContentType = "application/vnd.ms-excel";
            context.HttpContext.Response.Write(stringwriter);
        }
    }
}