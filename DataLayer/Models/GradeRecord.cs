using DataLayer.Model;
using DataLayer.Models.ListModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class GradeRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("CourseGradesList")]
        public int CourseGradesListId { get; set; }
        public CourseGradesList CourseGradesList { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public User Student { get; set; }

        [Required]
        public string Grade { get; set; }

        public string AssessmentType { get; set; }  // E.g., "Midterm", "Final", "Project"

        public DateTime DateAssigned { get; set; }

        public GradeRecord(int courseGradesListId, int studentId, string grade, string assessmentType, DateTime dateAssigned)
        {
            CourseGradesListId = courseGradesListId;
            StudentId = studentId;
            Grade = grade;
            AssessmentType = assessmentType;
            DateAssigned = dateAssigned;
        }

        public GradeRecord()
        {
        }
    }
}
