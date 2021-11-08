using Jiex.Base;
using Jiex.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jiex.EFcore
{
	[Serializable]
	public abstract class BaseEntity : BaseEntity<int>
	{
	}

	public abstract class BaseEntity<TPrimaryKey> : BaseEntityCore<TPrimaryKey>, IEntityStatus, IHasCreationTime, IHasModiticationTime
	{
		/// <summary>
		/// 状态：-1-删除 0-禁用 1-正常
		/// </summary>
		public EntityStatusEnums Status { get; set; } = EntityStatusEnums.Normal;

		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? CreateOn { get; set; }

		/// <summary>
		/// 更新时间
		/// </summary>
		public DateTime? UpdateOn { get; set; }
   
    }
}
