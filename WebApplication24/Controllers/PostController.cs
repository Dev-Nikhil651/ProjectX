using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using WebApplication24.Models;
using WebApplication24.Services;

namespace WebApplication24.Controllers.PostController
{
    public class PostController : Controller
    {
        private readonly JobPostService jobService = new JobPostService();
        private jobsEntities1 db = new jobsEntities1();

        [HttpPost]
        public ActionResult SubmitJobForm(JobPost model, HttpPostedFileBase OfficialNotification, string StateName)
        {
            try{ 
            var UniqueId = Guid.NewGuid();
            model.UniqueId = UniqueId;
            if (OfficialNotification != null && OfficialNotification.ContentLength > 0)
            {
                string fileName = Path.GetFileName(OfficialNotification.FileName);
                string path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                OfficialNotification.SaveAs(path);

                model.OfficialNotificationPath = "/Uploads/" + fileName; // Add this property to model
            }

            db.JobPosts.Add(model);
            db.SaveChanges();
            if (model.Posts != null)
            {
                foreach (var post_list in model.Posts)
                {
                    PostItem post = new PostItem
                    {
                        UnqueId = UniqueId,

                        PostName = post_list.PostName,
                        NoOfPosts = post_list.NoOfPosts,
                        Qualification = post_list.Qualification,
                        Salary = post_list.Salary

                    };

                    db.PostItems.Add(post);
                }
            }



            foreach (var item in model.Sections)
            {
                if (item.IsChecked == true)
                {
                    tb_jobLinks link = new tb_jobLinks
                    {
                        UnqueId = UniqueId,
                        link = item.Text,
                        linknamce = item.Label
                    };
                    db.tb_jobLinks.Add(link);
                }
            }
            if (model.FEELIST != null)
            {
                foreach (var item in model.FEELIST)
                {

                    Fee feemodel = new Fee
                    {
                        UnqueId = UniqueId,
                        General_OBC_EWS = item.General_OBC_EWS,
                        SC_ST_PwD_Ex_Serviceman = item.SC_ST_PwD_Ex_Serviceman,
                        For_Girls = item.For_Girls
                    };
                    db.Fees.Add(feemodel);

                }
            }
            db.SaveChanges();
            TempData["SuccessMessage"] = "Job posted successfully!";
            return RedirectToAction("Index", "Home");
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
        
        [HttpGet]
        public ActionResult Details( string id)
        {
            var result = jobService.GetAllJobPosts();
            var result_filterdata = result.FirstOrDefault(n => n.Id.ToString() == id);
            //string department = result_filterdata.Department;

            return View(result_filterdata);
        }
    }
}
