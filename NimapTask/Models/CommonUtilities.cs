using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NimapTask.Models
{
    public static class CommonUtilities
    {
        public static SelectList ToSelectList(this DataTable table, string value, string text)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Text = row[value].ToString(),
                    Value = row[text].ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }
    }
}