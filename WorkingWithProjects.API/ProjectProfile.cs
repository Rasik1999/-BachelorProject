﻿using AutoMapper;
using System.Collections.Generic;
using WorkingWithProjects.API.Models.ViewModel;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectViewModel>();
        }
    }
}