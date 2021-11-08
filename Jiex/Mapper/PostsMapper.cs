using AutoMapper;
using Jiex.Entities;
using Jiex.Handler.Homes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jiex.Mapper
{
    public class PostsMapper : Profile
    {
        public PostsMapper()
        {
            CreateMap<Posts, GetPostItem>();
        }
    }
}
