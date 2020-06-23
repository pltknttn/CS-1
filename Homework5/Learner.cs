using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    public class Learner
    {
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public int[] ReportCard { get; set; }  
        public double AverageMark
        {
            get {
                if (ReportCard.Length == 0) return 0;
                
                double sum = 0;
                foreach (int card in ReportCard) 
                    sum += 1.00*card;

                return Math.Round(sum / ReportCard.Length, 1);
            }
        }

        public Learner( string surname, string firstname, int[] reportCard)
        {
            Surname = surname;
            Firstname = firstname;
            ReportCard = reportCard;
        }
         
        public override string ToString()
        {
            return $"{Surname} {Firstname}";
        }
    }
}
