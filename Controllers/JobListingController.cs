using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TechJobPortal.Controllers
{
    public class JobListingController : Controller
    {
        private static List<JobListing> jobListings = new List<JobListing>
        {
            new JobListing { Id = 1, Title = "Software Engineer", CompanyName = "Tech Corp", Location = "Riyadh", JobType = JobType.FullTime, PostedDate = DateTime.Now.AddDays(-2) },
            new JobListing { Id = 2, Title = "Web Developer", CompanyName = "WebTech", Location = "Jeddah", JobType = JobType.Remote, PostedDate = DateTime.Now.AddDays(-5) },
            new JobListing { Id = 3, Title = "Project Manager", CompanyName = "BizSolutions", Location = "Dammam", JobType = JobType.Contract, PostedDate = DateTime.Now.AddDays(-10) },
            new JobListing { Id = 4, Title = "Data Analyst", CompanyName = "DataPros", Location = "Mecca", JobType = JobType.PartTime, PostedDate = DateTime.Now.AddDays(-1) },
            new JobListing { Id = 5, Title = "AI Engineer", CompanyName = "AI Labs", Location = "Medina", JobType = JobType.FullTime, PostedDate = DateTime.Now.AddDays(-7) }
        };

        public IActionResult Index(string search, string sortOrder, string jobType)
        {
            var filteredJobs = jobListings.AsQueryable();

            // Search by title or company name
            if (!string.IsNullOrEmpty(search))
            {
                filteredJobs = filteredJobs.Where(j => j.Title.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                                                       j.CompanyName.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            // Filter by job type
            if (!string.IsNullOrEmpty(jobType))
            {
                if (Enum.TryParse(typeof(JobType), jobType, out var jobTypeEnum))
                {
                    filteredJobs = filteredJobs.Where(j => j.JobType == (JobType)jobTypeEnum);
                }
            }

            // Sort jobs
            filteredJobs = sortOrder == "oldest" ? filteredJobs.OrderBy(j => j.PostedDate) : filteredJobs.OrderByDescending(j => j.PostedDate);

            ViewBag.JobTypes = new SelectList(Enum.GetValues(typeof(JobType)));
            return View(filteredJobs.ToList());
        }

        public IActionResult Details(int id)
        {
            var job = jobListings.FirstOrDefault(j => j.Id == id);
            if (job == null)
                return NotFound();
            return View(job);
        }
    }
}
