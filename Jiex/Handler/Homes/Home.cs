using AutoMapper;
using Jiex.Common;
using Jiex.EFcore;
using Jiex.Entities;
using Jiex.Enum;
using Jiex.Extensions;
using Jiex.Model.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Jiex.Handler.Homes
{
    public class HomeHandler : IRequestHandler<GetPostRequest, PagedResultDto<GetPostItem>>
    {
        private readonly IRepository<Posts, int> _postsRepository;
        private readonly IRepository<Discussions, int> _disRepository;
        private readonly IMapper _mapper;

        public HomeHandler(IRepository<Posts, int> postsRepository, IRepository<Discussions, int> disRepository, IMapper mapper)
        {
            _postsRepository = postsRepository;
            _disRepository = disRepository;
            _mapper = mapper;
        }

        public async Task<PagedResultDto<GetPostItem>> Handle(GetPostRequest request, CancellationToken cancellationToken)
        {
            // 查询条件
            var postquery = _postsRepository.GetQuery();
            var disquery = _disRepository.GetQuery();
            var queries = from post in postquery
                          join dis in disquery
                          on (int)post.DiscussionId equals dis.Id
                          select new GetPostItem
                          {
                              Id = post.Id,
                              Type = post.Type,
                              Content = post.Content,
                              Title = dis.Title,
                              CreateOn = post.CreateOn,
                              UpdateOn = post.UpdateOn
                          };
            var query = queries.WhereIf(!string.IsNullOrEmpty(request.Keyworks), a => a.Title.Contains(request.Keyworks) || a.Content.Contains(request.Keyworks));
            
            //查询数据库
            var items = await query.PagedAsync(request);
            var total = await query.CountAsync();
            var pageTotal = items.Count();
            return new PagedResultDto<GetPostItem>(items, total, pageTotal);
        }
    }

    /// <summary>
    /// 请求类型
    /// </summary>
    public class GetPostRequest : PagedRequest, IRequest<PagedResultDto<GetPostItem>>
    {
        public string Keyworks { get; set; }
    }

    /// <summary>
    /// 返回类型
    /// </summary>
    public class GetPostItem : EntityDto<int>
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 状态：-1-删除 0-禁用 1-正常
        /// </summary>
        public EntityStatusEnums Status { get; set; }

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
