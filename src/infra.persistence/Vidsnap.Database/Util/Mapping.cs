﻿using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Vidsnap.Common.Dto.DataSource;
using Vidsnap.Database.Entities;

namespace Vidsnap.Database.Util;

[ExcludeFromCodeCoverage]
public static class Mapping
{
    private static readonly Lazy<IMapper> Lazy = new(() =>
    {
        var config = new MapperConfiguration(cfg =>
        {
            // This line ensures that internal properties are also mapped over.
            cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
            cfg.AddProfile<MappingProfile>();
        });
        var mapper = config.CreateMapper();
        return mapper;
    });

    public static IMapper Mapper => Lazy.Value;
}

[ExcludeFromCodeCoverage]
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Video, VideoDto>();
        CreateMap<VideoDto, Video>();
    }
}