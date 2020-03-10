using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_1.PL.WEB_UI.Models.Image
{
    public class CreateImageVM
    {
        public int Id { get; set; }

        public Byte[] Data { get; set; }

        public string Type { get; set; }
    }
}