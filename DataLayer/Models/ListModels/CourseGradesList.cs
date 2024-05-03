using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.ListModels
{
    public class CourseGradesList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string CourseName { get; set; }

        public string CourseCode { get; set; }

        [Required]
        public User Instructor { get; set; }

        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }

        public List<GradeRecord> Grades { get; set; }

        public CourseGradesList(string courseName, string courseCode, User instructor)
        {
            CourseName = courseName;
            CourseCode = courseCode;
            Instructor = instructor;
        }

        public CourseGradesList()
        {
        }
    }
}
