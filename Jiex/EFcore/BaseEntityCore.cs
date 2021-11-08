using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jiex.EFcore
{
    public abstract class BaseEntityCore : BaseEntityCore<int>
    {
    }
    public abstract class BaseEntityCore<TPrimaryKey> : IEntity
    {
        [Key]
        public TPrimaryKey Id { get; set; }
    }
}
