using System.ComponentModel.DataAnnotations.Schema;

namespace LABA_OOP3.Models
{
    public class Descktop
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int HumanID { get; set; }
        [ForeignKey("HumanID")]
        public Human? Human { get; set; }

    }
}
