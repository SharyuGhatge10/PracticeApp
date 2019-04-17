using System;
using System.Collections.Generic;
using System.Text;

namespace Tourisum.Model
{
   public class MenuPageContents
    {
        public string _MenuPageContentlImage { get; set; }
        public string _MenuPageContentlLabel { get; set; }
        public MenuPageContents(string Image,string Label)
        {
            _MenuPageContentlImage = Image;
            _MenuPageContentlLabel = Label;
        }
    }
}
