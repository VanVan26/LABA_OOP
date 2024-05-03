using System.ComponentModel.DataAnnotations.Schema;

namespace LABA_OOP3.Models
{
    public class HumanToClassroom
    {
        public int Id { get; set; } 

        public int HumanID { get; set; }
        [ForeignKey("HumanID")]
        public Human? Human { get; set; }

        public int ClassroomID { get; set; }
        [ForeignKey("ClassroomID")]
        public Classroom? Classroom { get; set; }
    }
}
