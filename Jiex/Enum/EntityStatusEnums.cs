using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Jiex.Enum
{
	public enum EntityStatusEnums
	{
		[Description("删除")]
		Delete = -1,
		[Description("禁用")]
		Disable = 0,
		[Description("启用")]
		Normal = 1,
	}
}
