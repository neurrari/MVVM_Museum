using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Museum.Model
{
    public class Act
    {
        public int Id { get; set; }
        public DateOnly DateIssuing { get; set; }
        public DateOnly DateAccepting { get; set; }
        public int IdExhibit { get; set; }
        public int IdExhibition { get; set; }

    }
}
