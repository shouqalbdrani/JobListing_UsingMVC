using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TechJobPortal.Models;

namespace TechJobPortal.Controllers
{
    public class JobController : Controller
    {
        private static List<JobListing> _jobs = new List<JobListing>
        {
            new JobListing { Id = 1, Title = "Software Engineer", CompanyName = "Elm", Location = "Saudi Arabia", JobType = JobType.FullTime, PostedDate = new DateTime(2025, 2, 27) },
            new JobListing { Id = 2, Title = "Data Analyst", CompanyName = "Elm", Location = "Saudi Arabia", JobType = JobType.Remote, PostedDate = new DateTime(2025, 2, 25) },
            new JobListing { Id = 3, Title = "Frontend Developer", CompanyName = "Elm", Location = "Saudi Arabia", JobType = JobType.PartTime, PostedDate = new DateTime(2025, 2, 22) }, 
            new JobListing { Id = 4, Title = "Backend Developer", CompanyName = "Elm", Location = "Saudi Arabia", JobType = JobType.Contract, PostedDate = new DateTime(2025, 2, 20) },
            new JobListing { Id = 5, Title = "Developer", CompanyName = "Elm", Location = "Saudi Arabia", JobType = JobType.Contract, PostedDate = new DateTime(2025, 2, 20) } 
        };

        public IActionResult Index(string searchQuery)
        {
            var jobs = _jobs;

            if (!string.IsNullOrEmpty(searchQuery))
            {
                searchQuery = searchQuery.ToLower(); 
                jobs = jobs.Where(j => j.Title.ToLower().Contains(searchQuery) ||  j.CompanyName.ToLower().Contains(searchQuery)).ToList();
            }

            ViewBag.SearchQuery = searchQuery; 
            return View(jobs);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var job = _jobs.FirstOrDefault(j => j.Id == id);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }
    }
}
