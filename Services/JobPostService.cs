using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using WebApplication24.Models;

namespace WebApplication24.Services
{
    public class JobPostService
    {
        private readonly jobsEntities1 db;

        public JobPostService()
        {
            db = new jobsEntities1(); // Manual instantiation (since not using dependency injection in classic MVC)
        }

        public List<JobPost> GetAllJobPosts()
        {
            try
            {
               
                var postItems = db.PostItems.ToList();
                var jobLinks = db.tb_jobLinks.ToList();
                var Feeitem = db.Fees.ToList();
                var jobs = db.JobPosts.ToList();

                var result = jobs.Select(job => new JobPost
                {
                    Id = job.Id,
                    Department = job.Department,
                    LastDate = job.LastDate,
                    AdvertisementDate = job.AdvertisementDate,
                    Location = job.Location,
                    OfficialNotification = job.OfficialNotification,
                    OfficialNotificationPath = job.OfficialNotificationPath,
                    NO_Post = job.NO_Post,
                    UniqueId = job.UniqueId,
                    min_Age=job.min_Age,
                    max_Age=job.max_Age,
                    StateName=job.StateName,
                    
                    FEELIST = Feeitem.Where(p => p.UnqueId == job.UniqueId).Select(p =>
                     new FEELIST
                     {
                         SC_ST_PwD_Ex_Serviceman = p.SC_ST_PwD_Ex_Serviceman,
                         General_OBC_EWS = p.General_OBC_EWS,
                         For_Girls = p.For_Girls
                     }).ToList(),


                    Posts = postItems
                        .Where(p => p.UnqueId == job.UniqueId)
                        .Select(p => new PostItemLIST
                        {
                            PostName = p.PostName,
                            NoOfPosts = p.NoOfPosts.ToString(),
                            Qualification = p.Qualification,
                            Salary=p.Salary
                        }).ToList(),

                    Sections = jobLinks
                        .Where(p => p.UnqueId == job.UniqueId)
                        .Select(p => new SectionItem
                        {
                            Label = p.linknamce,
                            Text = p.link,
                            IsChecked = true
                        }).ToList()
                }).ToList();

                return result;
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }

                // Optionally rethrow or log in detail
                throw;
            }
        }
    }
}
