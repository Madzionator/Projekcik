using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Projekcik.Core.DTO;
using Projekcik.Core.Exceptions;
using Projekcik.Database;
using Projekcik.Database.Models;

namespace Projekcik.Core.Services
{
    public interface IJobService
    {
        void CreateJob(JobEditDto dto);
        void EditJob(Guid id, JobEditDto dto);
        JobDto GetJob(Guid id);
        IList<JobDto> BrowseJobs();
    }

    public class JobService : IJobService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public JobService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateJob(JobEditDto dto)
        {
            var job = _mapper.Map<Job>(dto);
            _context.Jobs.Add(job);
            _context.SaveChanges();
        }

        public void EditJob(Guid id, JobEditDto dto)
        {
            var job = _context.Jobs.Find(id);
            if (job is null)
            {
                throw new JobNotFoundException(id);
            }

            job = _mapper.Map(dto, job);
            _context.Jobs.Update(job);
            _context.SaveChanges();
        }

        public JobDto GetJob(Guid id)
        {
            var job = _context.Jobs.Find(id);
            if (job is null)
            {
                throw new JobNotFoundException(id);
            }

            var dto = _mapper.Map<JobDto>(job);
            return dto;
        }

        public IList<JobDto> BrowseJobs()
        {
            var jobs = _context.Jobs.AsNoTracking();
            return _mapper.Map<List<JobDto>>(jobs);
        }
    }
}
