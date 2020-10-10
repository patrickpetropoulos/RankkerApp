using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using RankkerCommon.DTOs;
using RankkerCommon.Models;

namespace RankkerCommon.AutoMapper
{
    public class ModelToDTOProfile : Profile
    {
        public ModelToDTOProfile()
        {
            CreateMap<Movie, MovieDTO>();
            CreateMap<MovieGenre, MovieGenreDTO>();

        }

    }
}
