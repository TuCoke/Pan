using Jiex.EFcore;
using Jiex.Entities;
using Jiex.Extensions;
using Jiex.Handler.Homes;
using Jiex.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jiex.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="request">get参数</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseValue<PagedResultDto<GetPostItem>>))]
        public async Task<IActionResult> Get([FromQuery] GetPostRequest request)
        {
            var result = await _mediator.Send(request);
            return Json(new ResponseValue<PagedResultDto<GetPostItem>>(result));
        }


        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseValue))]
        //public async Task<IActionResult> Create([FromBody] Posts request)
        //{
        //    var result = await .AddAsync(request);

        //    if (result) return Json(new ResponseValue());
        //    else return Json(new ResponseValue("创建失败"));

        //}
    }
}
