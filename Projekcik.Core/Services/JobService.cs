using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        void DeleteJob(Guid id);
        IList<JobStatsDto> GetStats();
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
            job.Locations = _context.Locations.Where(location => dto.LocationIds.Contains(location.Id)).ToList();
            _context.Jobs.Add(job);
            _context.SaveChanges();
        }

        public void EditJob(Guid id, JobEditDto dto)
        {
            var job = _context.Jobs
                .Include(jb => jb.Locations)
                .FirstOrDefault(jb => jb.Id == id);
            if (job is null)
            {
                throw new JobNotFoundException(id);
            }

            job = _mapper.Map(dto, job);
            job.Locations = _context.Locations.Where(location => dto.LocationIds.Contains(location.Id)).ToList();
            _context.Jobs.Update(job);
            _context.SaveChanges();
        }

        public JobDto GetJob(Guid id)
        {
            var job = _context.Jobs
                .Include(jb => jb.Locations)
                .FirstOrDefault(jb => jb.Id == id);

            if (job is null)
            {
                throw new JobNotFoundException(id);
            }

            var dto = _mapper.Map<JobDto>(job);
            return dto;
        }

        public IList<JobDto> BrowseJobs()
        {
            var jobs = _context.Jobs.Include(x => x.Locations).AsNoTracking();
            return _mapper.Map<List<JobDto>>(jobs);
        }

        public void DeleteJob(Guid id)
        {
            var job = _context.Jobs.Find(id);
            job.IsDeleted = true;
            _context.Jobs.Update(job);
            _context.SaveChanges();
        }

        public IList<JobStatsDto> GetStats()
        {
            return _context.Jobs
                .Include(x => x.Locations)
                .AsNoTracking()
                .Select(job =>
                    new JobStatsDto
                    {
                        Id = job.Id,
                        Title = job.Title,
                        MaximumSalary = job.MaximumSalary,
                        MinimumSalary = job.MinimumSalary,
                        CompanyName = job.CompanyName,
                        Locations = _mapper.Map<List<LocationEditDto>>(job.Locations),
                        CandidateCount = job.Candidates.Count,
                    })
                .ToList();
        }
    }
}
