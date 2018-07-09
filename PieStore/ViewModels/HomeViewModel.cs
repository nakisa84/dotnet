using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PieStore.Models;

namespace PieStore.ViewModels
{
    public class HomeViewModel
    {
        public string Title { get; set; }
        public List<Pie> Pies { get; set; }
    }
}
