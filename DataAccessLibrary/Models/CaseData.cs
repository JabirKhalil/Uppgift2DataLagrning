using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class CaseData
    {
        private int v;
        private string v1;
        private string v2;
        private string v3;
        



        //    public int CaseId { get; set; }
        //    public string Info { get; set; }
        //    public string CaseStatus { get; set; }
        //    public string Category { get; set; }
        //    public DateTime CaseDate{ get; set; }

        public int CaseId { get; set; }
        public string Info { get; set; }
        
        public string Category { get; set; }
        public string CaseStatus { get; set; }
        public CaseData()
        {
        }

        public CaseData(int v, string v1, string v2, string v3 )
        {
            this.v = v;
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
           
        }
    }
}
