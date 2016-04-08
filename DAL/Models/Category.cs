﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Common.Enumerations;

namespace DAL.Models
{
    /// <summary>
    /// db entity =>  dbo.categories
    /// </summary>
    public class Category
    {
        public Category()
        {
            Status = Status.Active;
        }

        public int Id { get; set; }

        public int? ParentId { get; set; }  // foreign key 
        public virtual Category Parent { get; set; } // navigation property

        public virtual ICollection<Category> Children { get; set; }// 1=>n relation

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Desc { get; set; }

        [Required]
        public Status Status { get; set; }

        public virtual ICollection<League> Leagues { get; set; } // 1=>n relation

    }
}
