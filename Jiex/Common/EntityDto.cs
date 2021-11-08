using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jiex.Common
{
	public class EntityDto<TPrimaryKey>
	{
		public TPrimaryKey Id { get; set; }
	}
}
