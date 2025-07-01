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
        [HttpPost]
       
        public ActionResult Update(JobPost model, HttpPostedFileBase OfficialNotification, string StateName)
        {
            try
            {
                var existing = db.JobPosts.FirstOrDefault(j => j.Id == model.Id);
                if (existing == null)
                    return HttpNotFound();

                var UniqueId = existing.UniqueId ?? Guid.NewGuid();
                existing.UniqueId = UniqueId;

                // Update core fields
                existing.Department = model.Department;
                existing.NO_Post = model.NO_Post;
                existing.min_Age = model.min_Age;
                existing.max_Age = model.max_Age;
                existing.Location = model.Location;
                existing.StateName = StateName;
                existing.AdvertisementDate = model.AdvertisementDate;
                existing.LastDate = model.LastDate;
                existing.mode = model.mode;

                // File upload (replace if new one is uploaded)
                if (OfficialNotification != null && OfficialNotification.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(OfficialNotification.FileName);
                    string path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                    OfficialNotification.SaveAs(path);
                    existing.OfficialNotificationPath = "/Uploads/" + fileName;
                }

                // Remove old Posts
                var oldPosts = db.PostItems.Where(p => p.UnqueId == UniqueId);
                db.PostItems.RemoveRange(oldPosts);

                // Add new Posts
                if (model.Posts != null)
                {
                    foreach (var post in model.Posts)
                    {
                        db.PostItems.Add(new PostItem
                        {
                            UnqueId = UniqueId,
                            PostName = post.PostName,
                            NoOfPosts = post.NoOfPosts,
                            Qualification = post.Qualification,
                            Salary = post.Salary
                        });
                    }
                }

                // Remove old Sections
                var oldLinks = db.tb_jobLinks.Where(p => p.UnqueId == UniqueId);
                db.tb_jobLinks.RemoveRange(oldLinks);

                // Add new Sections
                if (model.Sections != null)
                {
                    foreach (var item in model.Sections)
                    {
                        if (item.IsChecked)
                        {
                            db.tb_jobLinks.Add(new tb_jobLinks
                            {
                                UnqueId = UniqueId,
                                link = item.Text,
                                linknamce = item.Label
                            });
                        }
                    }
                }

                // Remove old Fee entries
                var oldFees = db.Fees.Where(f => f.UnqueId == UniqueId);
                db.Fees.RemoveRange(oldFees);

                // Add new Fee entry
                if (model.FEELIST != null)
                {
                    foreach (var fee in model.FEELIST)
                    {
                        db.Fees.Add(new Fee
                        {
                            UnqueId = UniqueId,
                            General_OBC_EWS = fee.General_OBC_EWS,
                            SC_ST_PwD_Ex_Serviceman = fee.SC_ST_PwD_Ex_Serviceman,
                            For_Girls = fee.For_Girls
                        });
                    }
                }

                db.SaveChanges();
                TempData["SuccessMessage"] = "Job post updated successfully!";
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
        public JsonResult Edit(int id)
        {
            var data = db.JobPosts.FirstOrDefault(j => j.Id == id);
            if (data == null) return Json(null, JsonRequestBehavior.AllowGet);

            var feeList = db.Fees
                .Where(f => f.UnqueId == data.UniqueId)
                .Select(f => new FEELIST
                {
                    General_OBC_EWS = f.General_OBC_EWS,
                    SC_ST_PwD_Ex_Serviceman = f.SC_ST_PwD_Ex_Serviceman,
                    For_Girls = f.For_Girls
                }).ToList();

            var posts = db.PostItems
                .Where(p => p.UnqueId == data.UniqueId)
                .Select(p => new PostItemLIST
                {
                    PostName = p.PostName,
                    NoOfPosts = p.NoOfPosts,
                    Qualification = p.Qualification,
                    Salary = p.Salary
                }).ToList();
            var sections = db.tb_jobLinks
    .Where(s => s.UnqueId == data.UniqueId && (!string.IsNullOrEmpty(s.linknamce) || !string.IsNullOrEmpty(s.link)))
    .Select(s => new SectionItem
    {
        IsChecked = true, // Force IsChecked to true if either value is present
        Label = s.linknamce,
        Text = s.link
    }).ToList();
            //var sections = db.tb_jobLinks
            //    .Where(s => s.UnqueId == data.UniqueId)
            //    .Select(s => new SectionItem
            //    {
            //        IsChecked = s.IsChecked,
            //        Label = s.linknamce,
            //        Text = s.link
            //    }).ToList();

            data.FEELIST = feeList;
            data.Posts = posts;
            data.Sections = sections;

            return Json(data, JsonRequestBehavior.AllowGet);
        }
     
        public ActionResult Delete(int id)
        {
            try
            {
                var jobPost = db.JobPosts.FirstOrDefault(j => j.Id == id);
                if (jobPost == null)
                    return HttpNotFound();

                var uniqueId = jobPost.UniqueId;

                // Delete related PostItems
                if (uniqueId.HasValue)
                {
                    var posts = db.PostItems.Where(p => p.UnqueId == uniqueId.Value).ToList();
                    db.PostItems.RemoveRange(posts);

                    // Delete related Sections
                    var links = db.tb_jobLinks.Where(l => l.UnqueId == uniqueId.Value).ToList();
                    db.tb_jobLinks.RemoveRange(links);

                    // Delete related Fees
                    var fees = db.Fees.Where(f => f.UnqueId == uniqueId.Value).ToList();
                    db.Fees.RemoveRange(fees);
                }

                // Delete the main JobPost
                db.JobPosts.Remove(jobPost);

                db.SaveChanges();

                TempData["SuccessMessage"] = "Job post deleted successfully.";
                return RedirectToAction("Adminjoblist", "Home");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while deleting the job post.";
                System.Diagnostics.Debug.WriteLine("Error in Delete: " + ex.Message);
                return RedirectToAction("Details", "Post");
            }
        }

    }
}
