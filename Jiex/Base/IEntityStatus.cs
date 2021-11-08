using Jiex.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jiex.Base
{
	public interface IEntityStatus
	{
		/// <summary>
		/// 状态：-1-删除 0-禁用 1-正常
		/// </summary>
		public EntityStatusEnums Status { get; set; }
	}
}
