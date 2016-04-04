using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SheepShop.Models
{
    [DataContract(Name ="mountainsheep")]
    public class Herd
    {
        [Key]
        public int ID { get; set; }
        [DisplayName("name")]
        [DataMember(Name="name")]
        public string Name { get; set; }
        [DataMember]
        public Sex sex { get; set; }
        public enum Sex
        {
            f
        }
        [DataType(DataType.DateTime)]
        [DisplayName("Born Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BornDate { get; set; }


        //sheep age converted in sheep years also if sheep turns 10 human years it will die ,
        //and returns result 0 for SheepAge
        [DataMember(Name="age")]
        public double shipAge
        {
            get
            {
                DateTime born = BornDate;
                DateTime now = DateTime.Now;
                TimeSpan ts = now - born;
                double humanAge = ts.Days;
                double age = Math.Abs(ts.Days / 365) * 3.65;
                if (humanAge < 3650 )
                    return age;
                return 0;
            }
            set { var temp = value; }
        }


        //Average Milk per day also if sheep turns 10 human years it will die ,
        //and returns result 0 for milk and totalMilk if is dead
        [DataMember]
        public double milk { get {
                DateTime born = BornDate;
                DateTime now = DateTime.Now;
                TimeSpan D = now - born;
                if (D.Days < 3650)
                return 50 - D.Days * 0.03;
                return 0;
            } set { var temp = value; } }


        //Total milk per sheep starting from day 0 (change the starting date bellow)
        [DataMember]
        public double totalMilk
        {
            get
            {
                DateTime dt1 = new DateTime(2016, 01, 29);
                DateTime dt2 = DateTime.Now;
                var days = dt2.Subtract(dt1).TotalDays;
                return Math.Abs(days * milk)                ;
            }
            set { }
        }
        //it returns 1 skin of wool of every shave for each sheep
        public double shaveSheep { get {
                DateTime born = BornDate;
                DateTime now = DateTime.Now;
                TimeSpan D = now - born;
                if (D.Days < 365)     
                    return 0;
                return 1;
            }
        }
        //if sheep is < 1 year old its eligible to be shaven and 
        //directly returns how many skins of wool are available from each sheep, starting from given date i.e. day 0 
        //if its not eligible to be shaven and if its 10 years old, it returns result 0
        //(change the starting date bellow)
        [DataMember]
        public double skinWool
        {
            get
            {
                DateTime dt1 = new DateTime(2016, 01, 29);
                DateTime dt2 = DateTime.Now;
                var days = dt2.Subtract(dt1).TotalDays;
                DateTime born = BornDate;
                DateTime now = DateTime.Now;
                TimeSpan D = now - born;
                double shave = 8 + D.Days * 0.01;
                double increment = -1;
                
                for (double i = 0; i < D.Days && i < days; i+=shave)
                {
                increment = increment + 1;
                }
                if(D.Days < 3650 && D.Days > 365)
                    return shaveSheep+increment;
                return 0;
                    ;
            }
            set {}
        }

        //public IEnumerable<Stock> stock { get; set; }

    }
}