using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace toDoList.Api.Models
{
    public class toDoListDto
    {
        public int Id { get; set; }
        public string task { get; set; }  
        public string priority { get; set; }
        public string status { get; set; }
    }
}

