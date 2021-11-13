using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationEntitiesLib.Employee
{
    public class EmployeeImagesModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string ImgPath { get; set; }
    }
}
