﻿using BlogSystem.Domain.Contracts.Entities;
using BlogSystem.Domain.Models.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Domain.Models
{
    public class Comment : DeletableEntity, IComment
    {
        [Key]
        public int CommentId
        {
            get; set;
        }

        [Required]
        public string CommentText
        {
            get; set;
        }

        [Required]
        public DateTime Date
        {
            get; set;
        }

        public virtual ApplicationUser Author
        {
            get; set;
        }
        
        public Post Post
        {
            get; set;
        }
    }
}
