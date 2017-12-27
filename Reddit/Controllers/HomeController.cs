namespace Reddit.Controllers
{
    using Reddit.Models;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        private RedditContext db = new RedditContext();
        public ActionResult Index()
        {
            return View(db.Topics.OrderByDescending(x => x.Date).ToList());
        }

        public ActionResult CreateTopic()
        {
            if (Request.IsAuthenticated)
            {
                return View();
            }

            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult CreateTopic(CreateTopicViewModel model)
        {
            if (ModelState.IsValid)
            {
                Topic topic = new Topic
                {
                    Author = User.Identity.Name,
                    Name = model.Name
                };
                topic.Comments.Add(new Comment
                {
                    Author = User.Identity.Name,
                    Content = model.Content
                });
                db.Topics.Add(topic);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }
        public ActionResult EditReply(int topicId, int commentId)
        {
            Topic topic = db.Topics.Find(topicId);
            Comment comment = topic.Comments.Find(x => x.Id == commentId);

            return View(comment);
        }

        public ActionResult ViewTopic(int topicId)
        {           
            Topic topic = db.Topics.Find(topicId);
            if (topic != null)
            {
                return View(topic);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult PostReply(AnswerViewModel model, int topicId)
        {              
            Topic topic = db.Topics.Find(topicId);

            topic.Comments.Add(new Comment
            {
                Author = User.Identity.Name,
                Content = model.Comment
            });
            db.SaveChanges();

            return RedirectToAction("ViewTopic", new { id = topicId });
        }

        [HttpPost]
        public ActionResult DeleteReply(AnswerViewModel model, int topicId, int commentId)
        {        
            Topic topic = db.Topics.Find(topicId);
            Comment comment = topic.Comments.Find(x => x.Id == commentId);

            topic.Comments.Remove(comment);
            if (topic.Comments.Count == 0)
            {
                db.Topics.Remove(topic);
            }
            db.SaveChanges();
           
            if(topic.Comments.Count == 0)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("ViewTopic", new { id = topicId });
        }

        [HttpPost]
        public ActionResult EditReply(Comment comment)
        {           
            if (ModelState.IsValid)
            {                              
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");              
            }
            return View(comment);
        }      
    }
}