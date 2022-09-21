﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace courseapp.Models
{
    public partial class Category
    {
        public Category()
        {
            Course = new HashSet<Course>();
            CourseLesson = new HashSet<CourseLesson>();
            InverseParent = new HashSet<Category>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Column("Parent_Id")]

        public int? ParentId { get; set; }

        public string? ParentName { get; set; }

        [ForeignKey("ParentId")]
        [InverseProperty("InverseParent")]
        public virtual Category Parent { get; set; }
        [InverseProperty("Category")]
        public virtual ICollection<Course> Course { get; set; }
        [InverseProperty("Course")]
        public virtual ICollection<CourseLesson> CourseLesson { get; set; }
        [InverseProperty("Parent")]
        public virtual ICollection<Category> InverseParent { get; set; }
    }
}