using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Museum.Model
{
    public class Exhibition
    {
        public int Id { get; set; }
        public string NameExhibition { get; set; }
        public string Arranger { get; set; }
        public DateOnly DateOpen { get; set; }
        public DateOnly DateClose { get; set; }
    }
}
