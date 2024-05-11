using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Museum.Model
{
    public class MuseumHall
    {
        public int Id { get; set; }
        public string NumberOfHall { get; set; }
        public int AmountOfPlaces { get; set; }
        public int IdEmployee { get; set; }
    }
}
