using Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models.Abstractions
{
    public abstract class BaseModel : IBaseModel<string>,IAuditInfo
    {
        public BaseModel()
        {
            Id = Guid.NewGuid().ToString();
        }
        
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
