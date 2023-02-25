using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessValleyManager.ENTITIES
{
    public class CLS_RECETTE_DEPENSE
    {
        public int ID_REC_DEP { get; set; }
        public string TYPE_REC_DEP { get; set; }
        public string FACT_REC_DEP { get; set; }
        public string DATE_REC_DEP { get; set; }
        public string DISTIN_REC_DEP { get; set; }
        public string DESCRIP_REC_DEP { get; set; }
        public double WITHOUT_VAT_REC_DEP { get; set; }
        public double VAT_REC_DEP { get; set; }
        public double MNT_VAT_REC_DEP { get; set; }
        public double TOTAL_REC_DEP { get; set; }
    }
}
