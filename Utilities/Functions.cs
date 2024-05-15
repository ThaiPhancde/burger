using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace burger.Utilities{
    public class Functions{
        public static string TitleSlugGenerator(string type, string? title, long id){
            return type + "-" +SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString() + ".html";
        }
    }
}