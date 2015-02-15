using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OTOMCollapse.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            GroupContainer viewModel = new GroupContainer();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(GroupContainer groupContainer)
        {
            GroupContainer viewModel = new GroupContainer();
            return View(viewModel);
        }

    }

    public class GroupContainer
    {
        public GroupContainer()
        {
            repeatGroups = new List<RepeatGroup>(){new RepeatGroup()};
        }

        public List<RepeatGroup> repeatGroups { get; set; }
    }

    public class RepeatGroup
    {
        public RepeatGroup()
        {
            nestedRepeatGroup = new List<NestedRepeatGroup>() { new NestedRepeatGroup() };
        }

        public string id { get; set; }

        [UIHint("NestedRepeatGroup")]
        public List<NestedRepeatGroup> nestedRepeatGroup { get; set; }
    }

    public class NestedRepeatGroup
    {
        public string id { get; set; }
    }

}
